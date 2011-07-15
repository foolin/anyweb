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
using System.Windows.Browser;
using AnyWell.Uploader;

namespace Uploader
{
    public partial class App : Application
    {

        public App()
        {
            this.Startup += this.Application_Startup;
            this.Exit += this.Application_Exit;
            this.UnhandledException += this.Application_UnhandledException;

            InitializeComponent();
        }

        private void Application_Startup( object sender, StartupEventArgs e )
        {
            bool multiSelect = false;
            long tempLong = 0;
            int tempInt = 0;

            if( e.InitParams.Keys.Contains( "Multiselect" ) && !string.IsNullOrEmpty( e.InitParams[ "Multiselect" ] ) )
            {
                bool.TryParse( e.InitParams[ "Multiselect" ], out multiSelect );
            }

            if( multiSelect )
            {
                MutiFileUploader fileUploader = new MutiFileUploader();

                fileUploader.uploadUrl = new Uri( HtmlPage.Document.DocumentUri, HttpUtility.UrlDecode( e.InitParams[ "UploadPage" ] ) );
                fileUploader.uploaderID = e.InitParams[ "UploaderID" ];

                if( e.InitParams.Keys.Contains( "UploadChunkSize" ) && !string.IsNullOrEmpty( e.InitParams[ "UploadChunkSize" ] ) )
                {

                    if( long.TryParse( e.InitParams[ "UploadChunkSize" ], out tempLong ) && tempLong > 0 )
                        fileUploader.uploadChunkSize = tempLong;
                }

                if( e.InitParams.Keys.Contains( "Filter" ) && !string.IsNullOrEmpty( e.InitParams[ "Filter" ] ) )
                {
                    fileUploader.filter = e.InitParams[ "Filter" ];
                }

                if( e.InitParams.Keys.Contains( "JavascriptCompleteFunction" ) && !string.IsNullOrEmpty( e.InitParams[ "JavascriptCompleteFunction" ] ) )
                {
                    fileUploader.javascriptCompleteFunction = e.InitParams[ "JavascriptCompleteFunction" ];
                }

                if( e.InitParams.Keys.Contains( "FilePath" ) && !string.IsNullOrEmpty( e.InitParams[ "FilePath" ] ) )
                {
                    fileUploader.filePath = e.InitParams[ "FilePath" ];
                }

                if( e.InitParams.Keys.Contains( "MaxNumberToUpload" ) && !string.IsNullOrEmpty( e.InitParams[ "MaxNumberToUpload" ] ) )
                {
                    if( int.TryParse( e.InitParams[ "MaxNumberToUpload" ], out tempInt ) && tempInt > 0 )
                        fileUploader.maxNumberToUpload = tempInt;
                }

                if( e.InitParams.Keys.Contains( "MaxSizeToUpload" ) && !string.IsNullOrEmpty( e.InitParams[ "MaxSizeToUpload" ] ) )
                {
                    if( long.TryParse( e.InitParams[ "MaxSizeToUpload" ], out tempLong ) && tempLong > 0 )
                        fileUploader.maxiSize = tempLong;
                }

                this.RootVisual = fileUploader;
            }
            else
            {
                FileUploader fileUploader = new FileUploader();

                fileUploader.uploadUrl = new Uri( HtmlPage.Document.DocumentUri, HttpUtility.UrlDecode( e.InitParams[ "UploadPage" ] ) );
                fileUploader.uploaderID = e.InitParams[ "UploaderID" ];

                if( e.InitParams.Keys.Contains( "UploadChunkSize" ) && !string.IsNullOrEmpty( e.InitParams[ "UploadChunkSize" ] ) )
                {

                    if( long.TryParse( e.InitParams[ "UploadChunkSize" ], out tempLong ) && tempLong > 0 )
                        fileUploader.uploadChunkSize = tempLong;
                }

                if( e.InitParams.Keys.Contains( "Filter" ) && !string.IsNullOrEmpty( e.InitParams[ "Filter" ] ) )
                {
                    fileUploader.filter = e.InitParams[ "Filter" ];
                }

                if( e.InitParams.Keys.Contains( "JavascriptCompleteFunction" ) && !string.IsNullOrEmpty( e.InitParams[ "JavascriptCompleteFunction" ] ) )
                {
                    fileUploader.javascriptCompleteFunction = e.InitParams[ "JavascriptCompleteFunction" ];
                }

                if( e.InitParams.Keys.Contains( "FilePath" ) && !string.IsNullOrEmpty( e.InitParams[ "FilePath" ] ) )
                {
                    fileUploader.filePath = e.InitParams[ "FilePath" ];
                }

                if( e.InitParams.Keys.Contains( "MaxSizeToUpload" ) && !string.IsNullOrEmpty( e.InitParams[ "MaxSizeToUpload" ] ) )
                {
                    if( long.TryParse( e.InitParams[ "MaxSizeToUpload" ], out tempLong ) && tempLong > 0 )
                        fileUploader.maxiSize = tempLong;
                }

                this.RootVisual = fileUploader;
            }
        }

        private void Application_Exit( object sender, EventArgs e )
        {

        }
        private void Application_UnhandledException( object sender, ApplicationUnhandledExceptionEventArgs e )
        {
            // 如果应用程序是在调试器外运行的，则使用浏览器的
            // 异常机制报告该异常。在 IE 上，将在状态栏中用一个 
            // 黄色警报图标来显示该异常，而 Firefox 则会显示一个脚本错误。
            if( !System.Diagnostics.Debugger.IsAttached )
            {

                // 注意: 这使应用程序可以在已引发异常但尚未处理该异常的情况下
                // 继续运行。 
                // 对于生产应用程序，此错误处理应替换为向网站报告错误
                // 并停止应用程序。
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke( delegate
                {
                    ReportErrorToDOM( e );
                } );
            }
        }
        private void ReportErrorToDOM( ApplicationUnhandledExceptionEventArgs e )
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace( '"', '\'' ).Replace( "\r\n", @"\n" );

                System.Windows.Browser.HtmlPage.Window.Eval( "throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");" );
            }
            catch( Exception )
            {
            }
        }
    }
}
