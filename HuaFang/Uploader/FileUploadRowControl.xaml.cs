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
using System.ComponentModel;

namespace AnyWell.Uploader
{
    public partial class FileUploadRowControl : UserControl
    {
        public FileUploadRowControl()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler( FileUploadRowControl_Loaded );
            removeButton.Click += new RoutedEventHandler( removeButton_Click );
        }

        void FileUploadRowControl_Loaded( object sender, RoutedEventArgs e )
        {
            FileBean bean = DataContext as FileBean;
            bean.PropertyChanged += new PropertyChangedEventHandler( File_PropertyChanged );
            ChangeVisible( bean );
        }

        void File_PropertyChanged( object sender, PropertyChangedEventArgs e )
        {
            FileBean bean = sender as FileBean;

            if( e.PropertyName == "Status" )
            {
                ChangeVisible( bean );
                switch( bean.status )
                {
                    case FileUploadStatus.Waiting:
                        status.Text = "等待";
                        break;
                    case FileUploadStatus.Uploading:
                        status.Text = "上传";
                        break;
                    case FileUploadStatus.Complete:
                        status.Text = "完成";
                        break;
                    case FileUploadStatus.Error:
                        status.Text = "失败";
                        break;
                    case FileUploadStatus.Removed:
                        status.Text = "删除";
                        break;
                    default:
                        break;
                }
            }
            else if( e.PropertyName == "BytesUploaded" )
            {
                percent.Text = bean.percent + "%";
            }
        }

        void ChangeVisible( FileBean bean )
        {
            if( bean.status == FileUploadStatus.Uploading )
            {
                percent.Visibility = Visibility.Visible;
                status.Visibility = Visibility.Collapsed;
            }
            else
            {
                percent.Visibility = Visibility.Collapsed;
                status.Visibility = Visibility.Visible;
            }
        }

        void removeButton_Click( object sender, RoutedEventArgs e )
        {
            MessageBoxResult result = MessageBox.Show( "确定删除该文件？", "删除文件?", MessageBoxButton.OKCancel );
            if( result == MessageBoxResult.OK )
            {
                FileBean bean = DataContext as FileBean;
                if( bean != null )
                    bean.RemoveUpload();
            }
        }
    }
}
