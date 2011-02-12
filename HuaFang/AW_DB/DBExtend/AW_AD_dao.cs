using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace AnyWell.AW_DL
{
    public partial class AW_AD_dao
    {
        /// <summary>
        /// 获取首页广告图
        /// </summary>
        /// <returns></returns>
        public List<AW_AD_bean> funcGetAdList()
        {
            List<AW_AD_bean> list = (List<AW_AD_bean>)HttpRuntime.Cache["INDEXAD"];
            if (list != null) 
            {
                return list;
            }
            list = new List<AW_AD_bean>();
            this.propOrder = "ORDER BY fdAdID ASC";
            list = this.funcGetList();
            HttpRuntime.Cache.Insert("INDEXAD", list, null, DateTime.MaxValue, TimeSpan.FromMinutes(5));
            return list;
        }

        /// <summary>
        /// 修改首页广告
        /// </summary>
        /// <param name="bean"></param>
        public override int funcUpdate(Bean_Base aBean)
        {
            int result = base.funcUpdate(aBean);
            if (HttpRuntime.Cache["INDEXAD"] != null)
            {
                HttpRuntime.Cache.Remove("INDEXAD");
            }
            return result;
        }
    }
}
