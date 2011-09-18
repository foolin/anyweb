using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;

namespace Studio.Web
{
    public class Uploader : Control, INamingContainer
    {
        //private string _ID;
        ///// <summary>
        ///// 控件ID
        ///// </summary>
        //public override string ID
        //{
        //    get
        //    {
        //        return _ID;
        //    }
        //    set
        //    {
        //        _ID = value;
        //    }
        //}

        private bool _MultiSelect;
        /// <summary>
        /// 是否多文件上传
        /// </summary>
        public bool MultiSelect
        {
            get
            {
                return _MultiSelect;
            }
            set
            {
                _MultiSelect = value;
            }
        }

        private string _UploadPage = "/Admin/Ajax/FileUpload.ashx";
        /// <summary>
        /// 上传接收页面
        /// </summary>
        public string UploadPage
        {
            get
            {
                return _UploadPage;
            }
            set
            {
                _UploadPage = value;
            }
        }

        private long _UploadChunkSize = 102400;
        /// <summary>
        /// 上传分块大小
        /// </summary>
        public long UploadChunkSize
        {
            get
            {
                return _UploadChunkSize;
            }
            set
            {
                _UploadChunkSize = value;
            }
        }

        private string _Filter;
        /// <summary>
        /// 过滤条件
        /// </summary>
        public string Filter
        {
            get
            {
                return _Filter;
            }
            set
            {
                _Filter = value;
            }
        }

        private string _JavascriptBeginFunction;
        /// <summary>
        /// 任务开始回调函数
        /// </summary>
        public string JavascriptBeginFunction
        {
            get
            {
                return _JavascriptBeginFunction;
            }
            set
            {
                _JavascriptBeginFunction = value;
            }
        }

        private string _JavascriptSingleCompleteFunction;
        /// <summary>
        /// 单个任务上传完成后回调函数
        /// </summary>
        public string JavascriptSingleCompleteFunction
        {
            get
            {
                return _JavascriptSingleCompleteFunction;
            }
            set
            {
                _JavascriptSingleCompleteFunction = value;
            }
        }

        private string _JavascriptCompleteFunction;
        /// <summary>
        /// 上传完成后回调函数
        /// </summary>
        public string JavascriptCompleteFunction
        {
            get
            {
                return _JavascriptCompleteFunction;
            }
            set
            {
                _JavascriptCompleteFunction = value;
            }
        }

        private string _FilePath = "/Files";
        /// <summary>
        /// 文件保存位置
        /// </summary>
        public string FilePath
        {
            get
            {
                return _FilePath;
            }
            set
            {
                _FilePath = value;
            }
        }

        private int _MaxNumberToUpload;
        /// <summary>
        /// 最大上传数
        /// </summary>
        public int MaxNumberToUpload
        {
            get
            {
                return _MaxNumberToUpload;
            }
            set
            {
                _MaxNumberToUpload = value;
            }
        }

        private long _MaxSizeToUpload;
        /// <summary>
        /// 单文件大小限制
        /// </summary>
        public long MaxSizeToUpload
        {
            get
            {
                return _MaxSizeToUpload;
            }
            set
            {
                _MaxSizeToUpload = value;
            }
        }

        private string _Style;
        /// <summary>
        /// 控件样式
        /// </summary>
        public string Style
        {
            get
            {
                return _Style;
            }
            set
            {
                _Style = value;
            }
        }

        protected override void Render( HtmlTextWriter writer )
        {
            int width = 60, height = 13;
            string initParams = string.Format( "UploaderID={0},UploadPage={1},UploadChunkSize={2},FilePath={4},Multiselect={5},Filter={6}", ID, UploadPage, UploadChunkSize, JavascriptCompleteFunction, FilePath, MultiSelect, Filter );
            if( MultiSelect )
            {
                //width = 182;
                if( !string.IsNullOrEmpty( JavascriptSingleCompleteFunction ) )
                {
                    initParams += string.Format( ",JavascriptSingleCompleteFunction={0}", JavascriptSingleCompleteFunction );
                }
            }
            //else
            //{
            //    //width = 60;
            //}
            if( !string.IsNullOrEmpty( JavascriptBeginFunction ) )
            {
                initParams += string.Format( ",JavascriptBeginFunction={0}", JavascriptBeginFunction );
            }
            if( !string.IsNullOrEmpty( JavascriptCompleteFunction ) )
            {
                initParams += string.Format( ",JavascriptCompleteFunction={0}", JavascriptCompleteFunction );
            }
            writer.Write( "<object id=\"{0}\" {3} data=\"data:application/x-silverlight-2,\" type=\"application/x-silverlight-2\" width=\"{1}\" height=\"{2}\">", ID, width, height, string.IsNullOrEmpty( Style ) ? "" : string.Format( "Style=\"{0}\"", Style ) );
            writer.Write( "<param name=\"source\" value=\"/ClientBin/Uploader.xap\"/>" );
            writer.Write( "<param name=\"background\" value=\"white\" />" );
            writer.Write( "<param name=\"minRuntimeVersion\" value=\"3.0.40624.0\" />" );
            writer.Write( "<param name=\"autoUpgrade\" value=\"true\" />" );
            writer.Write( "<param name=\"initParams\" value=\"{0}\" />", initParams );
            writer.Write( "<a href=\"http://go.microsoft.com/fwlink/?LinkID=149156&v=3.0.40624.0\" style=\"text-decoration: none;\">" );
            writer.Write( "<img src=\"http://go.microsoft.com/fwlink/?LinkId=108181\" alt=\"获取 Microsoft Silverlight\" style=\"border-style: none\"/>" );
            writer.Write( "</a>" );
            writer.Write( "</object><iframe id=\"_sl_historyFrame\" style='visibility:hidden;height:0;width:0;border:0px'></iframe>" );
        }
    }
}
