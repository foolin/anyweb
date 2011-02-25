#pragma checksum "E:\PROJECT\DOTNET\HuaFang\FileUpload\FileUploadRowControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D48480F178744AE013D9572A330D8B3A"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.4952
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace DC.FileUpload {
    
    
    public partial class FileUploadRowControl : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Border LayoutRoot;
        
        internal System.Windows.VisualStateGroup StatusGroup;
        
        internal System.Windows.VisualState Pending;
        
        internal System.Windows.VisualState Resizing;
        
        internal System.Windows.VisualState Error;
        
        internal System.Windows.VisualState Complete;
        
        internal System.Windows.VisualState Uploading;
        
        internal System.Windows.Controls.Image imagePreview;
        
        internal System.Windows.Controls.ProgressBar progressBar;
        
        internal System.Windows.Controls.Image errorImage;
        
        internal System.Windows.Controls.Image resizeImage;
        
        internal System.Windows.Controls.Image completeImage;
        
        internal System.Windows.Controls.Image pendingImage;
        
        internal System.Windows.Controls.Button removeButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/DC.FileUpload;component/FileUploadRowControl.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Border)(this.FindName("LayoutRoot")));
            this.StatusGroup = ((System.Windows.VisualStateGroup)(this.FindName("StatusGroup")));
            this.Pending = ((System.Windows.VisualState)(this.FindName("Pending")));
            this.Resizing = ((System.Windows.VisualState)(this.FindName("Resizing")));
            this.Error = ((System.Windows.VisualState)(this.FindName("Error")));
            this.Complete = ((System.Windows.VisualState)(this.FindName("Complete")));
            this.Uploading = ((System.Windows.VisualState)(this.FindName("Uploading")));
            this.imagePreview = ((System.Windows.Controls.Image)(this.FindName("imagePreview")));
            this.progressBar = ((System.Windows.Controls.ProgressBar)(this.FindName("progressBar")));
            this.errorImage = ((System.Windows.Controls.Image)(this.FindName("errorImage")));
            this.resizeImage = ((System.Windows.Controls.Image)(this.FindName("resizeImage")));
            this.completeImage = ((System.Windows.Controls.Image)(this.FindName("completeImage")));
            this.pendingImage = ((System.Windows.Controls.Image)(this.FindName("pendingImage")));
            this.removeButton = ((System.Windows.Controls.Button)(this.FindName("removeButton")));
        }
    }
}
