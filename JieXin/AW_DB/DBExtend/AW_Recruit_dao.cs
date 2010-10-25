using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Recruit_dao
	{


        /**************************************************自定义控件********************************************************************************/
        string selectStr = "fdRecrID,fdRecrTitle,fdRecrCompany,fdRecrAreaID,fdRecrType,fdRecrSort";

        /// <summary>
        /// 获取招聘列表
        /// </summary>
        /// <param name="topCount">前n条</param>
        /// <param name="where">附加筛选条件</param>
        /// <param name="order">附加排序条件</param>
        /// <param name="cacheName">缓存名称</param>
        /// <param name="getContent">是否获取招聘内容</param>
        /// <returns></returns>
        public List<AW_Recruit_bean> funcGetRecruitListByUC(int typeID, int topCount, string where, string order, string cacheName, bool getContent )
        {
            if( !string.IsNullOrEmpty( cacheName ) && HttpRuntime.Cache[ "RECRUIT_CACHE_UC_" + cacheName ] != null )
            {
                return ( List<AW_Recruit_bean> ) HttpRuntime.Cache[ "RECRUIT_CACHE_UC_" + cacheName ];
            }

            this.propSelect = this.selectStr;
            if( getContent )
            {
                this.propSelect += ",fdRecrContent";
            }

            if( topCount > 0 )
            {
                this.propSelect = " TOP " + topCount + " " + this.propSelect;
            }

            this.propWhere = "1=1";

            if( typeID > 0 )
            {
                this.propWhere += " AND fdRecrType=" + typeID;
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
                this.propOrder = "ORDER BY fdRecrSort DESC";
            }

            List<AW_Recruit_bean> recruits = this.funcGetList();

            if( !string.IsNullOrEmpty( cacheName ) )
            {
                HttpRuntime.Cache.Insert( "RECRUIT_CACHE_UC_" + cacheName, recruits, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes( 20 ), System.Web.Caching.CacheItemPriority.NotRemovable, null );
            }

            return recruits;
        }

        /// <summary>
        /// 获取招聘列表
        /// </summary>
        /// <param name="where">附加筛选条件</param>
        /// <param name="order">附加排序条件</param>
        /// <param name="pageID">当前页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="getContent">是否获取招聘内容</param>
        /// <returns></returns>
        public List<AW_Recruit_bean> funcGetRecruitListByUC(int typeID, string where, string order, int pageID, int pageSize, out int recordCount, bool getContent )
        {
            this.propSelect = this.selectStr;
            if( getContent )
            {
                this.propSelect += ",fdArtiContent";
            }

            this.propWhere = "1=1";

            if( typeID > 0 )
            {
                this.propWhere += " AND fdRecrType=" + typeID;
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
                this.propOrder = "ORDER BY fdRecrSort DESC";
            }

            this.propPage = pageID;
            this.propPageSize = pageSize;
            this.propGetCount = true;

            List<AW_Recruit_bean> recruits = this.funcGetList();
            recordCount = this.propCount;

            return recruits;
        }
	}
}
