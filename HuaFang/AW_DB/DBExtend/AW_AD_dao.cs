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

        /**************************************************自定义控件********************************************************************************/
        /// <summary>
        /// 获取广告列表
        /// </summary>
        /// <param name="typeID">广告类型</param>
        /// <param name="topCount">前n条</param>
        /// <param name="where">附加筛选条件</param>
        /// <param name="order">附加排序条件</param>
        /// <param name="cacheName">缓存名称</param>
        /// <returns></returns>
        public List<AW_AD_bean> funcGetADListByUC( int typeID, int topCount, string where, string order, string cacheName )
        {
            if( !string.IsNullOrEmpty( cacheName ) && HttpRuntime.Cache[ "AD_CACHE_UC_" + cacheName ] != null )
            {
                return ( List<AW_AD_bean> ) HttpRuntime.Cache[ "AD_CACHE_UC_" + cacheName ];
            }

            if( topCount > 0 )
            {
                this.propSelect = " TOP " + topCount + " *";
            }

            this.propWhere = "1=1";

            if( typeID > 0 )
            {
                this.propWhere += " AND fdAdType=" + typeID;
            }

            if( string.IsNullOrEmpty( where ) == false )
            {
                this.propWhere += " AND " + where.Replace( ";", "；" ).Replace( "--", "－－" );
            }

            if( string.IsNullOrEmpty( order ) == false )
            {
                this.propOrder = "ORDER BY " + funcReplaceSqlField( order );
            }
            else
            {
                this.propOrder = "ORDER BY fdAdSort DESC";
            }

            List<AW_AD_bean> ads = this.funcGetList();

            if( !string.IsNullOrEmpty( cacheName ) )
            {
                HttpRuntime.Cache.Insert( "AD_CACHE_UC_" + cacheName, ads, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes( 20 ), System.Web.Caching.CacheItemPriority.NotRemovable, null );
            }

            return ads;
        }
    }
}
