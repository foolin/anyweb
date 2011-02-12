using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Category_bean
	{
        private AW_Category_bean _parent;
        /// <summary>
        /// 父级分类
        /// </summary>
        public AW_Category_bean Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        private List<AW_Category_bean> _children;
        /// <summary>
        /// 子分类
        /// </summary>
        public List<AW_Category_bean> Children
        {
            get { return _children; }
            set { _children = value; }
        }

        public AW_Category_bean funcGetRootCategory()
        {
            if (this.Parent != null)
                return this.Parent.funcGetRootCategory();
            else
                return this;
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
        public string pathStr
        {
            get
            {
                if (HttpContext.Current.Request.ApplicationPath == "/")
                {
                    return string.Format("/p/{0}.aspx", fdCateID);
                }
                else
                {
                    return string.Format("/{0}/p/{1}.aspx", HttpContext.Current.Request.ApplicationPath, fdCateID);
                }
            }
            set { _pathStr = value; }
        }
	}
}
