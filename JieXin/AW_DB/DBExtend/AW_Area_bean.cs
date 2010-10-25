using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Area_bean
	{
        private List<AW_Area_bean> _children;
        /// <summary>
        /// 子区域
        /// </summary>
        public List<AW_Area_bean> Children
        {
            get
            {
                return _children;
            }
            set
            {
                _children = value;
            }
        }
	}
}
