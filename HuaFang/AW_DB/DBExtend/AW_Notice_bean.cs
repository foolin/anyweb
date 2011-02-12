using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Notice_bean
	{
        /// <summary>
        /// 访问路径
        /// </summary>
        public string fdNotiPath
        {
            get
            {
                return string.Format("/n/{0}.aspx", this.fdNotiID);
            }
        }
	}
}
