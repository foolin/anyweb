using System;
using System.Collections.Generic;
using System.Web;

namespace AnyWeb.AW_DL
{
    public partial class AW_Article_bean
    {
        private AW_Column_bean _Column;

        public AW_Column_bean Column
        {
            get { return _Column; }
            set { _Column = value; }
        }

        private string _pathStr;
        /// <summary>
        /// 访问路径
        /// </summary>
        public string PathStr
        {
            get 
            {
                if (HttpContext.Current.Request.ApplicationPath == "/")
                {
                    return string.Format("/c/{0}/{1}.aspx", fdArtiColumnID, fdArtiID);
                }
                else
                {
                    return string.Format("{0}/c/{1}/{2}.aspx", HttpContext.Current.Request.ApplicationPath, fdArtiColumnID, fdArtiID);
                }
            }
            set { _pathStr = value; }
        }
    }
}