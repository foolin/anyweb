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
	public partial class AW_Brand_bean
    {
        private AW_Brand_bean _parent;
        /// <summary>
        /// 父级品牌
        /// </summary>
        public AW_Brand_bean Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        private List<AW_Brand_bean> _children;
        /// <summary>
        /// 子品牌
        /// </summary>
        public List<AW_Brand_bean> Children
        {
            get { return _children; }
            set { _children = value; }
        }
	}
}
