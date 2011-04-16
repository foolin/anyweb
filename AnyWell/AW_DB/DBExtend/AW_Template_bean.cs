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
        public string TempTypeName
        {
            get
            {
                switch( fdTempType )
                {
                    case 1:
                        return "栏目模板";
                    case 2:
                        return "内容模板";
                    case 3:
                        return "嵌套模板";
                    case 4:
                        return "首页模板";
                    default:
                        return "";
                }
            }
        }

        private AW_Site_bean _Site;
        /// <summary>
        /// 所属站点
        /// </summary>
        public AW_Site_bean Site
        {
            get
            {
                return _Site;
            }
            set
            {
                _Site = value;
            }
        }
	}
}
