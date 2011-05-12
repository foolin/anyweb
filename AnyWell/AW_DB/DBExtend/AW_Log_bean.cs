using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Log_bean
	{
        private AW_Admin_bean _Admin;
        /// <summary>
        /// 管理员帐号
        /// </summary>
        public AW_Admin_bean Admin
        {
            get
            {
                return _Admin;
            }
            set
            {
                _Admin = value;
            }
        }

        /// <summary>
        /// 操作类型名称
        /// </summary>
        public string TypeName
        {
            get
            {
                switch( fdLogType )
                {
                    case 1:
                        return "登陆";
                    case 2:
                        return "新增";
                    case 3:
                        return "修改";
                    case 4:
                        return "删除";
                    default:
                        return "";
                }
            }
        }
	}
}
