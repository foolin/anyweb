using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Mapping_bean
	{
        private AW_Template_bean _Template;
        /// <summary>
        /// 映射模版
        /// </summary>
        public AW_Template_bean Template
        {
            get { return _Template; }
            set { _Template = value; }
        }
	}
}
