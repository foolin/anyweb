using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_SiteInfo_dao
	{
        /// <summary>
        /// 获取站点基本信息列表
        /// </summary>
        /// <returns></returns>
        public List<AW_SiteInfo_bean> funcGetSiteInfoList()
        {
            this.propOrder = "ORDER BY fdSiInSort ASC";
            return this.funcGetList();
        }

        /**************************************************自定义控件********************************************************************************/

        /// <summary>
        /// 获取站点基本信息列表
        /// </summary>
        /// <returns></returns>
        public List<AW_SiteInfo_bean> funcGetSiteInfoListByUC()
        {
            return this.funcGetSiteInfoList();
        }
	}
}
