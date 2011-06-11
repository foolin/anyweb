using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Data;
using Studio.Web;

namespace AnyWell.AW_DL
{
	public partial class AW_Admin_bean
	{
        /// <summary>
        /// 用户状态
        /// </summary>
        public string AdminStatus
        {
            get
            {
                switch( fdAdmiStatus )
                {
                    case 0:
                        return "正常";
                    case 1:
                        return "锁定";
                    default:
                        return "";
                }
            }
        }
	}

    public enum AdminLevel : int
    {
        Administrator = 1,
        Normal = 2
    }
}
