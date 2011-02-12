using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Template_bean
	{
        /// <summary>
        /// 模板类型
        /// </summary>
        public string fdTempTypeStr
        {
            get
            {
                switch (this._fdTempType)
                {
                    case 1:
                        return "首页模版";
                    case 2:
                        return "内容模板";
                    case 3:
                        return "嵌套模板";
                    case 4:
                        return "扩展模版";
                    default:
                        return "首页模板";
                }
            }
        }
	}
}
