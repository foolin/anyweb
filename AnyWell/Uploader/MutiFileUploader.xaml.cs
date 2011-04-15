using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Windows.Browser;

namespace AnyWell.Uploader
{
    public partial class MutiFileUploader : UserControlBase
    {
        private ScrollHelper helper;
        public MutiFileUploader()
        {
            InitializeComponent();
            uploadChunkSize = 102400;
            addFilesButton.Click += new RoutedEventHandler( addFilesButton_Click );
            progressBar.MouseEnter += new MouseEventHandler( progressBar_MouseEnter );
            fileUploaderGrid.MouseLeave += new MouseEventHandler( fileUploaderGrid_MouseLeave );
            helper = new ScrollHelper( filesScrollViewer );
            Loaded += new RoutedEventHandler( FileUploader_Loaded );
            files.CollectionChanged += new NotifyCollectionChangedEventHandler( files_CollectionChanged );
        }

        /// <summary>
        /// 添加文件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void addFilesButton_Click( object sender, RoutedEventArgs e )
        {
            if( maxNumberToUpload > 0 && files.Count >= maxNumberToUpload )
            {
                MessageBox.Show( "超出允许上传的文件总数！" );
                return;
            }

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = filter;
            dlg.Multiselect = true;

            if( ( bool ) dlg.ShowDialog() )
            {
                if( maxNumberToUpload > 0 && dlg.Files.Count() + files.Count() > maxNumberToUpload )
                {
                    MessageBox.Show( "超出允许上传的文件总数！" );
                    return;
                }
                foreach( FileInfo file in dlg.Files )
                {
                    if( maxiSize > 0 && file.Length > maxiSize )
                    {
                        MessageBox.Show( string.Format( "文件 '{0}'超出了限制的文件大小。", file.Name ) );
                        continue;
                    }
                    FileBean bean = new FileBean( file, this.Dispatcher );
                    if( uploadChunkSize > 0 )
                    {
                        bean.chunkSize = uploadChunkSize;
                    }
                    bean.uploadUrl = uploadUrl;
                    bean.filePath = filePath;
                    bean.StatusChanged += new EventHandler( upload_StatusChanged );
                    bean.UploadProgressChanged += new ProgressChangedEvent( upload_UploadProgressChanged );
                    files.Add( bean );
                }
                totalUploadSize = files.Sum( f => f.file.Length );
                progressBar.Maximum = totalUploadSize;
                progressBar.Value = 0;
                progressBar.Visibility = Visibility.Visible;
                totalSizeTextBlock.Visibility = Visibility.Visible;
                if( !uploading )
                {
                    HtmlPage.Window.Eval( string.Format( "document.getElementById(\"{0}\").width=280;", uploaderID ) );
                }
                UploadFiles();
            }
        }

        /// <summary>
        /// 更新上传总进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void upload_UploadProgressChanged( object sender, UploadProgressChangedEventArgs args )
        {
            totalUploaded += args.bytesUploaded;
            progressBar.Value = totalUploaded;
            totalSizeTextBlock.Text = string.Format( "{0}/{1}({2})",
                 new ByteConverter().Convert( totalUploaded, this.GetType(), null, null ).ToString(),
                new ByteConverter().Convert( totalUploadSize, this.GetType(), null, null ).ToString(),
                percent + "%" );
        }

        /// <summary>
        /// 开始上传文件
        /// </summary>
        protected override void UploadFiles()
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
                if( fileListGrid.Visibility != Visibility.Visible )
                {
                    HtmlPage.Window.Eval( string.Format( "document.getElementById(\"{0}\").width=60;", uploaderID ) );
                }
                returnFuntion();
                progressBar.Visibility = Visibility.Collapsed;
                totalSizeTextBlock.Visibility = Visibility.Collapsed;
                files.Clear();
            }
        }

        void progressBar_MouseEnter( object sender, EventArgs e )
        {
            if( fileListGrid.Visibility != Visibility.Visible )
            {
                fileListGrid.Visibility = Visibility.Visible;
                HtmlPage.Window.Eval( string.Format( "document.getElementById(\"{0}\").height=164;", uploaderID ) );
            }
        }

        void fileUploaderGrid_MouseLeave( object sender, EventArgs e )
        {
            if( fileListGrid.Visibility == Visibility.Visible )
            {
                fileListGrid.Visibility = Visibility.Collapsed;
                HtmlPage.Window.Eval( string.Format( "document.getElementById(\"{0}\").height=13;", uploaderID ) );
                if( !uploading )
                {
                    HtmlPage.Window.Eval( string.Format( "document.getElementById(\"{0}\").width=60;", uploaderID ) );
                }
            }
        }

        void FileUploader_Loaded( object sender, RoutedEventArgs e )
        {
            fileList.ItemsSource = files;
        }

        /// <summary>
        /// 文件变更后更新状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void files_CollectionChanged( object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e )
        {
            totalUploadSize = files.Sum( f => f.fileLength );
            totalUploaded = files.Sum( f => f.bytesUploaded );
            progressBar.Maximum = totalUploadSize;
            progressBar.Value = totalUploaded;
            totalSizeTextBlock.Text = string.Format( "{0}/{1}({2})",
                 new ByteConverter().Convert( totalUploaded, this.GetType(), null, null ).ToString(),
                new ByteConverter().Convert( totalUploadSize, this.GetType(), null, null ).ToString(),
                percent + "%" );
        }
    }
}
