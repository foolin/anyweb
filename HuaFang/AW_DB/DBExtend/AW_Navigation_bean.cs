using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Navigation_bean
	{
        private List<AW_Navigation_bean> _children;
        /// <summary>
        /// 二级导航栏
        /// </summary>
        public List<AW_Navigation_bean> Children
        {
            get { return _children; }
            set { _children = value; }
        }

        private AW_Navigation_bean _parent;
        /// <summary>
        /// 父级栏目
        /// </summary>
        public AW_Navigation_bean Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
	}
}
