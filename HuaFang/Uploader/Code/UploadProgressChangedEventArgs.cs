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

namespace AnyWell.Uploader
{
    public delegate void ProgressChangedEvent( object sender, UploadProgressChangedEventArgs args );
    public class UploadProgressChangedEventArgs
    {
        public int ProgressPercentage
        {
            get;
            set;
        }
        public long bytesUploaded
        {
            get;
            set;
        }
        public long totalBytesUploaded
        {
            get;
            set;
        }
        public long totalBytes
        {
            get;
            set;
        }
        public string fileName
        {
            get;
            set;
        }

        public UploadProgressChangedEventArgs()
        {
        }

        public UploadProgressChangedEventArgs( int progressPercentage, long bytesUploaded, long totalBytesUploaded, long totalBytes, string fileName )
        {
            ProgressPercentage = progressPercentage;
            this.bytesUploaded = bytesUploaded;
            this.totalBytes = totalBytes;
            this.fileName = fileName;
            this.totalBytesUploaded = totalBytesUploaded;
        }
    }
}
