using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
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

        /// <summary>
        /// 访问路径
        /// </summary>
        public string fdColuPath
        {
            get 
            {
                return string.Format("/c/{0}.aspx", this.fdColuID);
            }
        }
	}
}
