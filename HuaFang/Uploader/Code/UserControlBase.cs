using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Windows.Browser;

namespace AnyWell.Uploader
{
    public class UserControlBase : UserControl
    {
        /// <summary>
        /// 控件ID
        /// </summary>
        public string uploaderID
        {
            get;
            set;
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
        public long uploadChunkSize
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
        /// <summary>
        /// 单文件大小限制
        /// </summary>
        public long maxiSize
        {
            get;
            set;
        }
        /// <summary>
        /// 上传总进度
        /// </summary>
        public int percent
        {
            get
            {
                return ( int ) ( ( ( double ) totalUploaded / ( double ) totalUploadSize ) * 100 );
            }
        }
        /// <summary>
        /// 文件选择框过滤条件
        /// </summary>
        public string filter
        {
            get;
            set;
        }
        /// <summary>
        /// 上传完成调用JS方法
        /// </summary>
        public string javascriptCompleteFunction
        {
            get;
            set;
        }
        /// <summary>
        /// 已上传的总体积
        /// </summary>
        public long totalUploaded
        {
            get;
            set;
        }
        /// <summary>
        /// 文件总体积
        /// </summary>
        public long totalUploadSize
        {
            get;
            set;
        }
        /// <summary>
        /// 最大上传数
        /// </summary>
        public int maxNumberToUpload
        {
            get;
            set;
        }
        private ObservableCollection<FileBean> _files = new ObservableCollection<FileBean>();
        /// <summary>
        /// 文件列表
        /// </summary>
        public ObservableCollection<FileBean> files
        {
            get
            {
                return _files;
            }
            set
            {
                _files = value;
            }
        }
        public bool uploading
        {
            get;
            set;
        }

        /// <summary>
        /// 返回调用JS方法
        /// </summary>
        protected virtual void returnFuntion()
        {
            if( !string.IsNullOrEmpty( javascriptCompleteFunction ) )
            {
                string path = "";
                var q = files.Where( f => f.status == FileUploadStatus.Complete );
                foreach( FileBean bean in q )
                {
                    path += "," + bean.newName;
                }
                if( path.Length > 0 )
                    path = path.Substring( 1 );

                try
                {
                    HtmlPage.Window.Eval( string.Format( "{0}('{1}')", javascriptCompleteFunction, path ) );
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// 上传状态变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void upload_StatusChanged( object sender, EventArgs e )
        {
            FileBean bean = sender as FileBean;
            if( bean.status == FileUploadStatus.Complete )
            {
                if( uploading )
                    UploadFiles();
            }
            else if( bean.status == FileUploadStatus.Removed )
            {
                files.Remove( bean );
                if( uploading )
                    UploadFiles();
            }
        }

        /// <summary>
        /// 开始上传文件
        /// </summary>
        protected virtual void UploadFiles()
        {
            uploading = true;
            if( files.Count( f => f.status == FileUploadStatus.Waiting ) > 0 )
            {
                FileBean bean = files.First( f => f.status != FileUploadStatus.Uploading && f.status != FileUploadStatus.Removed && f.status != FileUploadStatus.Complete && f.status != FileUploadStatus.Error );
                bean.Upload();
            }
            else
            {
                uploading = false;
                HtmlPage.Window.Eval( string.Format( "document.getElementById(\"{0}\").width=60;", uploaderID ) );
                returnFuntion();
                files.Clear();
            }
        }
    }
}
