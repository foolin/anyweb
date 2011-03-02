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
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Browser;
using System.Threading;

namespace DC.FileUpload
{
    public partial class FileUploadControl : UserControl
    {
        public int MaxConcurrentUploads { get; set; }
        public long UploadChunkSize { get; set; }
        public bool ResizeImage { get; set; }
        public int ImageSize { get; set; }
        /// <summary>
        /// 文件存放路径
        /// </summary>
        public string FilePath{ get; set; }
        private DateTime start;

        public Brush BackgroundColor
        {
            get { return controlBorder.Background; }
            set { controlBorder.Background = value; }
        }
        public CornerRadius CornerRadius
        {
            get { return controlBorder.CornerRadius; }
            set { controlBorder.CornerRadius = value; }
        }
        public Brush BorderBrushColor
        {
            get { return controlBorder.BorderBrush; }
            set { controlBorder.BorderBrush = value; }
        }
        public Thickness BorderThickness
        {
            get { return controlBorder.BorderThickness; }
            set { controlBorder.BorderThickness = value; }
        }

        /// <summary>
        /// 文件选择框过滤条件
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// 是否允许多选
        /// </summary>
        public bool Multiselect { get; set; }
        /// <summary>
        /// 上传URL
        /// </summary>
        public Uri UploadUrl { get; set; }
        /// <summary>
        /// 上传完成调用JS方法
        /// </summary>
        public string JavascriptCompleteFunction { get; set; }
        /// <summary>
        /// 返回调用JS方法
        /// </summary>
        public string JavascriptReturnFunction{get;set;}
        /// <summary>
        /// 上传状态
        /// </summary>
        private bool uploading { get; set; }
        /// <summary>
        /// 当前上传的总体积
        /// </summary>
        private long TotalUploadSize { get; set; }
        private long TotalUploaded { get; set; }
        /// <summary>
        /// 文件上传的总体积限制
        /// </summary>
        public long MaximumTotalUpload { get; set; }
        /// <summary>
        /// 单个文件的体积限制
        /// </summary>
        public long MaximumUpload { get; set; }
        /// <summary>
        /// 最大上传数
        /// </summary>
        public int MaxNumberToUpload { get; set; }
        private int count = 0;

        public bool AllowThumbnail 
        {
            get { return displayThumbailChckBox.Visibility == Visibility.Visible; }
            set 
            {
                bool temp = value;
                if (temp) 
                    displayThumbailChckBox.Visibility = Visibility.Visible; 
                else 
                    displayThumbailChckBox.Visibility = Visibility.Collapsed; 
            }
        }

        private ScrollHelper helper;

        private ObservableCollection<FileUpload> files;


        public FileUploadControl()
        {
            InitializeComponent();
            files = new ObservableCollection<FileUpload>();
            files.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(files_CollectionChanged);
            MaxConcurrentUploads = 1;
            MaxNumberToUpload = -1;
            MaximumTotalUpload = MaximumUpload = -1;
            Filter = "All Files|*.*";
            Multiselect = true;
            uploading = false;
            UploadChunkSize = 4194304;

            addFilesButton.Click += new RoutedEventHandler(addFilesButton_Click);
            uploadButton.Click += new RoutedEventHandler(uploadButton_Click);
            clearFilesButton.Click += new RoutedEventHandler(clearFilesButton_Click);
            setFilesButton.Click += new RoutedEventHandler( setFilesButton_Click );

            displayThumbailChckBox.Checked += new RoutedEventHandler(displayThumbailChckBox_Checked);
            displayThumbailChckBox.Unchecked += new RoutedEventHandler(displayThumbailChckBox_Checked);

            helper = new ScrollHelper(filesScrollViewer);

            Loaded += new RoutedEventHandler(FileUploadControl_Loaded);
        }

        void displayThumbailChckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chkbox = sender as CheckBox;

            foreach (FileUpload fu in files)
            {
                if (fu.DisplayThumbnail != chkbox.IsChecked)
                    fu.DisplayThumbnail = (bool)chkbox.IsChecked;
            }
        }
        public FileUploadControl(Uri uploadUrl)
            : this()
        {
            UploadUrl = uploadUrl;
        }

        /// <summary>
        /// 更新文件上传状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void files_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            countTextBlock.Text = "图片数: " + files.Count.ToString();
            TotalUploadSize = files.Sum(f => f.FileLength);
            TotalUploaded = files.Sum(f => f.BytesUploaded);
            totalSizeTextBlock.Text = string.Format("{0} of {1}",
                new ByteConverter().Convert(TotalUploaded, this.GetType(), null, null).ToString(),
                new ByteConverter().Convert(TotalUploadSize, this.GetType(), null, null).ToString());
            progressBar.Maximum = TotalUploadSize;
            progressBar.Value = TotalUploaded;
        }

        /// <summary>
        /// 清空上传列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void clearFilesButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show( "确定清空所有图片？", "图片清空?", MessageBoxButton.OKCancel );
            if( result == MessageBoxResult.OK )
            {
                var q = files.Where( f => f.Status == FileUploadStatus.Uploading );
                foreach( FileUpload fu in q )
                    fu.CancelUpload();
                timeLeftTextBlock.Text = "";
                files.Clear();
            }
        }

        /// <summary>
        /// 上传按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void uploadButton_Click(object sender, RoutedEventArgs e)
        {
            if ((string)uploadButton.Content == "上传")
            {
                if( files.Count == 0 )
                {
                    return;
                }
                uploadButton.Content = "停止";
                start = DateTime.Now;
                UploadFiles();
            }
            else
            {
                var q = files.Where(f => f.Status == FileUploadStatus.Uploading);
                foreach (FileUpload fu in q)
                    fu.CancelUpload();
                uploading = false;
                uploadButton.Content = "上传";
            }
        }

        /// <summary>
        /// 选择按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void addFilesButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = Filter;
            dlg.Multiselect = Multiselect;

            if ((bool)dlg.ShowDialog())
            {
                foreach (FileInfo file in dlg.Files)
                {               
                    FileUpload upload = new FileUpload(this.Dispatcher, UploadUrl, file);
                    if (UploadChunkSize > 0)
                        upload.ChunkSize = UploadChunkSize;
                    if (ResizeImage)
                    {
                        upload.ResizeImage = ResizeImage;
                        upload.ImageSize = ImageSize;
                    }

                    if (MaxNumberToUpload > -1)
                    {
                        count++;
                        if (count > MaxNumberToUpload)
                        {
                            MessageBox.Show( "您已经超出了允许上传的图片总数。" );
                            break;
                        }
                    }

                    if (MaximumTotalUpload >= 0 && TotalUploadSize + upload.FileLength > MaximumTotalUpload)
                    {
                        MessageBox.Show("你已经超出了允许上传的图片总体积。");
                        break;
                    }
                    if (MaximumUpload >= 0 && upload.FileLength > MaximumUpload)
                    {
                        MessageBox.Show( string.Format( "图片 '{0}'超出了限制的图片大小。", upload.Name ) );
                        continue;
                    }
                    upload.NewName = getNewName( file );
                    upload.FilePath = FilePath;
                    upload.DisplayThumbnail = (bool)displayThumbailChckBox.IsChecked;
                    upload.StatusChanged += new EventHandler(upload_StatusChanged);
                    upload.UploadProgressChanged += new ProgressChangedEvent(upload_UploadProgressChanged);
                    upload.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(upload_PropertyChanged);
                    files.Add(upload);
                }
            }
        }

        void upload_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {            
            if (e.PropertyName == "FileLength")
            {
                files_CollectionChanged(null, null);
            }
        }

        /// <summary>
        /// 更新上传总进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void upload_UploadProgressChanged(object sender, UploadProgressChangedEventArgs args)
        {
            

            TotalUploaded += args.BytesUploaded;
            progressBar.Value = TotalUploaded;
            totalSizeTextBlock.Text = string.Format("{0} of {1}",
                 new ByteConverter().Convert(TotalUploaded, this.GetType(), null, null).ToString(),
                new ByteConverter().Convert(TotalUploadSize, this.GetType(), null, null).ToString());

            double ByteProcessTime = 0;
            double EstimatedTime = 0;

            try
            {
                TimeSpan timeSpan = DateTime.Now - start;
                ByteProcessTime = TotalUploaded / timeSpan.TotalSeconds;
                EstimatedTime = (TotalUploadSize - TotalUploaded) / ByteProcessTime;
                timeSpan = TimeSpan.FromSeconds(EstimatedTime);
                timeLeftTextBlock.Text = string.Format("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            }
            catch { }
        }

        /// <summary>
        /// 上传状态变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void upload_StatusChanged(object sender, EventArgs e)
        {
            FileUpload fu = sender as FileUpload;
            if (fu.Status == FileUploadStatus.Complete)
            {
                if (uploading)
                    UploadFiles();
            }
            else if (fu.Status == FileUploadStatus.Removed)
            {
                files.Remove(fu);
                if (uploading)
                    UploadFiles();
            }
            else if (fu.Status == FileUploadStatus.Uploading && files.Count(f => f.Status == FileUploadStatus.Uploading) < MaxConcurrentUploads)
                UploadFiles();
        }

        void FileUploadControl_Loaded(object sender, RoutedEventArgs e)
        {
            fileList.ItemsSource = files;
        }

        /// <summary>
        /// 开始上传文件
        /// </summary>
        private void UploadFiles()
        {

            uploading = true;
            while (files.Count(f => f.Status == FileUploadStatus.Uploading || f.Status == FileUploadStatus.Resizing) < MaxConcurrentUploads && uploading)
            {
                if (files.Count(f => f.Status != FileUploadStatus.Complete && f.Status != FileUploadStatus.Uploading && f.Status != FileUploadStatus.Resizing) > 0)
                {
                    FileUpload fu = files.First(f => f.Status != FileUploadStatus.Complete && f.Status != FileUploadStatus.Uploading && f.Status != FileUploadStatus.Resizing);
                    fu.Upload();
                }
                else if (files.Count(f => f.Status == FileUploadStatus.Uploading || f.Status == FileUploadStatus.Resizing) == 0)
                {
                    uploading = false;
                    uploadButton.Content = "上传";
                    if (!string.IsNullOrEmpty(JavascriptCompleteFunction))
                    {
                        try
                        {
                            HtmlPage.Window.CreateInstance(JavascriptCompleteFunction);
                        }
                        catch { }
                    }
                    MessageBoxResult result = MessageBox.Show( "图片上传成功，确定返回？", "确定返回？", MessageBoxButton.OKCancel );
                    if( result == MessageBoxResult.OK )
                    {
                        returnFuntion();
                    }
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 确定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void setFilesButton_Click( object sender, RoutedEventArgs e )
        {
            if( files.Count( f => f.Status != FileUploadStatus.Complete ) > 0 )
            {
                MessageBoxResult result = MessageBox.Show( "存在图片未上传，确定返回？", "确定返回？", MessageBoxButton.OKCancel );
                if( result != MessageBoxResult.OK )
                {
                    return;
                }
            }
            returnFuntion();
        }

        /// <summary>
        /// 获取远程文件名
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private string getNewName( FileInfo file )
        {
            long r = DateTime.Now.Ticks;
            Thread.Sleep( 1 );
            return "S_" + r.ToString() + file.Extension;
        }

        /// <summary>
        /// 返回调用JS方法
        /// </summary>
        private void returnFuntion()
        {
            if( !string.IsNullOrEmpty( JavascriptReturnFunction ) )
            {
                string path = "";
                var q = files.Where( f => f.Status == FileUploadStatus.Complete );
                foreach( FileUpload fu in q )
                {
                    path += "," + fu.FilePath + fu.NewName;
                }
                if( path.Length > 0 )
                    path = path.Substring( 1 );

                try
                {
                    HtmlPage.Window.CreateInstance( JavascriptReturnFunction, path );
                }
                catch
                {
                }
            }
        }
    }
}
