using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWeb.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
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
	
	
	
	}
}
