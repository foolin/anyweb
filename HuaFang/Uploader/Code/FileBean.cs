using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Windows.Threading;

namespace AnyWell.Uploader
{
    public class FileBean : INotifyPropertyChanged
    {
        private FileInfo _file;
        public FileInfo file
        {
            get
            {
                return _file;
            }
            set
            {
                _file = value;
                Stream temp = file.OpenRead();
                fileLength = temp.Length;
                temp.Close();
            }
        }
        public Dispatcher dispatcher
        {
            get;
            set;
        }
        public string fileName
        {
            get
            {
                return file.Name;
            }
        }
        private FileUploadStatus _status;
        /// <summary>
        /// 上传状态
        /// </summary>
        public FileUploadStatus status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;

                this.dispatcher.BeginInvoke( delegate()
                {
                    if( PropertyChanged != null )
                        PropertyChanged( this, new PropertyChangedEventArgs( "Status" ) );
                    if( StatusChanged != null )
                        StatusChanged( this, null );
                } );
            }
        }
        /// <summary>
        /// 状态字符串
        /// </summary>
        public string statusText
        {
            get
            {
                switch( status )
                {
                    case FileUploadStatus.Waiting:
                        return "等待";
                    case FileUploadStatus.Uploading:
                        return "上传";
                    case FileUploadStatus.Removed:
                        return "删除";
                    case FileUploadStatus.Error:
                        return "失败";
                    case FileUploadStatus.Complete:
                        return "完成";
                    default:
                        return "";
                }
            }
        }
        /// <summary>
        /// 上传URL
        /// </summary>
        public Uri uploadUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 上传分块大小
        /// </summary>
        public long chunkSize
        {
            get;
            set;
        }
        /// <summary>
        /// 远程文件名
        /// </summary>
        public string newName
        {
            get;
            set;
        }
        /// <summary>
        /// 文件存放路径
        /// </summary>
        public string filePath
        {
            get;
            set;
        }
        private long _bytesUploaded;
        /// <summary>
        /// 已上传字节数
        /// </summary>
        public long bytesUploaded
        {
            get
            {
                return _bytesUploaded;
            }
            set
            {
                _bytesUploaded = value;

                this.dispatcher.BeginInvoke( delegate()
                {
                    if( PropertyChanged != null )
                        PropertyChanged( this, new PropertyChangedEventArgs( "BytesUploaded" ) );
                } );
            }
        }
        /// <summary>
        /// 文件字节数
        /// </summary>
        public long fileLength
        {
            get;
            set;
        }
        public int percent
        {
            get
            {
                return ( int ) ( ( ( double ) bytesUploaded / ( double ) fileLength ) * 100 );
            }
        }
        public bool removed = false;
        public bool stoped = false;

        public FileBean( FileInfo file, Dispatcher dispatcher )
        {
            this.file = file;
            this.dispatcher = dispatcher;
            status = FileUploadStatus.Waiting;
            chunkSize = 102400;
            newName = GetNewName();
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        public void Upload()
        {
            if( file == null || uploadUrl == null )
                return;
            status = FileUploadStatus.Uploading;
            UploadFileEx();
        }

        /// <summary>
        /// 异步上传
        /// </summary>
        public void UploadFileEx()
        {
            long temp = fileLength - bytesUploaded;

            UriBuilder ub = new UriBuilder( uploadUrl );
            bool complete = temp <= chunkSize;
            ub.Query = string.Format( "{3}filename={0}&StartByte={1}&Complete={2}&filepath={4}", newName, bytesUploaded, complete, string.IsNullOrEmpty( ub.Query ) ? "" : ub.Query.Remove( 0, 1 ) + "&", this.filePath );

            HttpWebRequest webrequest = ( HttpWebRequest ) WebRequest.Create( ub.Uri );
            webrequest.Method = "POST";
            webrequest.BeginGetRequestStream( new AsyncCallback( WriteCallback ), webrequest );
        }

        private void WriteCallback( IAsyncResult asynchronousResult )
        {
            HttpWebRequest webrequest = ( HttpWebRequest ) asynchronousResult.AsyncState;
            Stream requestStream = webrequest.EndGetRequestStream( asynchronousResult );

            byte[] buffer = new Byte[ 4096 ];
            int bytesRead = 0;
            int tempTotal = 0;

            Stream fileStream = file.OpenRead();

            fileStream.Position = bytesUploaded;
            while( ( bytesRead = fileStream.Read( buffer, 0, buffer.Length ) ) != 0 && tempTotal + bytesRead < chunkSize && !removed && !stoped )
            {
                requestStream.Write( buffer, 0, bytesRead );
                requestStream.Flush();
                bytesUploaded += bytesRead;
                tempTotal += bytesRead;
                if( UploadProgressChanged != null )
                {
                    UploadProgressChangedEventArgs args = new UploadProgressChangedEventArgs( percent, bytesRead, bytesUploaded, fileLength, file.Name );
                    this.dispatcher.BeginInvoke( delegate()
                    {
                        UploadProgressChanged( this, args );
                    } );
                }
            }

            fileStream.Close();
            requestStream.Close();
            webrequest.BeginGetResponse( new AsyncCallback( ReadCallback ), webrequest );
        }

        private void ReadCallback( IAsyncResult asynchronousResult )
        {
            HttpWebRequest webrequest = ( HttpWebRequest ) asynchronousResult.AsyncState;
            HttpWebResponse response = ( HttpWebResponse ) webrequest.EndGetResponse( asynchronousResult );
            StreamReader reader = new StreamReader( response.GetResponseStream() );

            string responsestring = reader.ReadToEnd();
            reader.Close();

            if( stoped )
            {
                status = FileUploadStatus.Stoped;
            }
            else if( removed )
            {
                DelFileOnServer();
                status = FileUploadStatus.Removed;
            }
            else if( bytesUploaded < fileLength )
            {
                UploadFileEx();
            }
            else
            {
                status = FileUploadStatus.Complete;
            }

        }

        /// <summary>
        /// 获取远程文件名
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private string GetNewName()
        {
            long r = DateTime.Now.Ticks;
            Thread.Sleep( 1 );
            return r.ToString() + file.Extension;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        public void RemoveUpload()
        {
            removed = true;
            if( status != FileUploadStatus.Uploading )
                status = FileUploadStatus.Removed;
        }

        /// <summary>
        /// 暂停上传
        /// </summary>
        public void StopUpload()
        {
            stoped = true;
        }

        /// <summary>
        /// 继续上传
        /// </summary>
        public void ContinueUpload()
        {
            stoped = false;
            if( status == FileUploadStatus.Stoped )
                status = FileUploadStatus.Waiting;
        }

        /// <summary>
        /// 删除远程文件
        /// </summary>
        private void DelFileOnServer()
        {
            UriBuilder ub = new UriBuilder( uploadUrl );
            ub.Query = string.Format( "{1}filename={0}&Delete=true&filepath={2}", newName, string.IsNullOrEmpty( ub.Query ) ? "" : ub.Query.Remove( 0, 1 ) + "&", this.filePath );
            WebClient client = new WebClient();
            client.DownloadStringAsync( ub.Uri );
        }

        public event EventHandler StatusChanged;
        public event ProgressChangedEvent UploadProgressChanged;
        public event PropertyChangedEventHandler PropertyChanged;
    }

    /// <summary>
    /// 上传状态
    /// </summary>
    public enum FileUploadStatus
    {
        Waiting,
        Uploading,
        Complete,
        Removed,
        Stoped,
        Error
    }
}
