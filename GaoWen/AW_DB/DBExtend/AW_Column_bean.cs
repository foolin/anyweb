using System;
using System.Collections.Generic;
using System.Web;

namespace AnyWeb.AW_DL
{
    public partial class AW_Column_bean
    {
        private AW_Column_bean _parent;
        /// <summary>
        /// 父级栏目
        /// </summary>
        public AW_Column_bean Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        private List<AW_Column_bean> _children;
        /// <summary>
        /// 子栏目
        /// </summary>
        public List<AW_Column_bean> Children
        {
            get { return _children; }
            set { _children = value; }
        }

        private AW_Template_bean _indexTemplate;
        /// <summary>
        /// 首页模版
        /// </summary>
        public AW_Template_bean IndexTemplate
        {
            get { return _indexTemplate; }
            set { _indexTemplate = value; }
        }

        private AW_Template_bean _contentTemplate;
        /// <summary>
        /// 内容模版
        /// </summary>
        public AW_Template_bean ContentTemplate
        {
            get { return _contentTemplate; }
            set { _contentTemplate = value; }
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
                    return string.Format("/c/{0}.aspx", fdColuID);
                }
                else
                {
                    return string.Format("/{0}/c/{1}.aspx", HttpContext.Current.Request.ApplicationPath, fdColuID);
                }
            }
            set { _pathStr = value; }
        }
    }
}