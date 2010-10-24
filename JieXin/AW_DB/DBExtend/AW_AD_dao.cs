using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;
using AnyWell.Configs;

namespace AnyWell.AW_DL
{
	public partial class AW_AD_dao
	{
        /// <summary>
        /// 获取企业图片广告
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_AD_bean> funcGetADList(int type,int pageSize,int pageIndex,out int recordCount)
        {
            this.propWhere = "fdAdType=" + type;
            this.propOrder = "ORDER BY fdAdSort DESC,fdAdID DESC";
            this.propGetCount = true;
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            List<AW_AD_bean> list = this.funcGetList();
            recordCount = this.propCount;
            return list;
        }

        /// <summary>
        /// 调整图片广告排序
        /// </summary>
        /// <param name="type"></param>
        /// <param name="noticeId"></param>
        /// <param name="nextId"></param>
        /// <param name="previewId"></param>
        public void funcSortAD(int type,int noticeId, int nextId, int previewId)
        {
            AW_AD_bean ad = AW_AD_bean.funcGetByID(noticeId, "fdAdID,fdAdSort");
            AW_AD_bean next = nextId == 0 ? null : AW_AD_bean.funcGetByID(nextId, "fdAdID,fdAdSort");
            AW_AD_bean preview = previewId == 0 ? null : AW_AD_bean.funcGetByID(previewId, "fdAdID,fdAdSort");

            this.propSelect = " fdAdID,fdAdSort";
            this.propOrder = " ORDER BY fdAdSort DESC";

            this._propFields = "fdAdID,fdAdSort";

            if (next != null)
            {
                if (ad.fdAdSort > next.fdAdSort) //从上往下移
                {
                    this.propWhere += string.Format(" AND fdAdSort<={0} AND fdAdSort>{1} AND fdAdType={2}", ad.fdAdSort, next.fdAdSort, type);
                    List<AW_AD_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        ad.fdAdSort = list[list.Count - 1].fdAdSort;
                        this.funcUpdate(ad);
                        for (int i = 1; i < list.Count; i++)
                        {
                            list[i].fdAdSort = list[i - 1].fdAdSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += string.Format(" AND fdAdSort>={0} AND fdAdSort<={1} AND fdAdType={2}", ad.fdAdSort, next.fdAdSort, type);
                    List<AW_AD_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        ad.fdAdSort = list[0].fdAdSort;
                        this.funcUpdate(ad);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdAdSort = list[i + 1].fdAdSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
            }
            else if (preview != null)
            {
                if (ad.fdAdSort > preview.fdAdSort) //从上往下移
                {
                    this.propWhere += string.Format(" AND fdAdSort<={0} AND fdAdSort>={1} AND fdAdType={2}", ad.fdAdSort, preview.fdAdSort, type);
                    List<AW_AD_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        ad.fdAdSort = list[list.Count - 1].fdAdSort;
                        this.funcUpdate(ad);
                        for (int i = list.Count - 1; i > 0; i--)
                        {
                            list[i].fdAdSort = list[i - 1].fdAdSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += string.Format(" AND fdAdSort>={0} AND fdAdSort<{1} AND fdAdType={2}", ad.fdAdSort, preview.fdAdSort, type);
                    List<AW_AD_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        ad.fdAdSort = list[0].fdAdSort;
                        this.funcUpdate(ad);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdAdSort = list[i + 1].fdAdSort;
                            this.funcUpdate(list[i]);
                        }
                    }

                }
            }
            CacheAgent.ClearCache( "AD_CACHE_" );
        }

        public override int funcInsert( Bean_Base aBean )
        {
            int result = base.funcInsert( aBean );
            CacheAgent.ClearCache( "AD_CACHE_" );
            return result;
        }

        public override int funcUpdate( Bean_Base aBean )
        {
            int result = base.funcUpdate( aBean );
            CacheAgent.ClearCache( "AD_CACHE_" );
            return result;
        }

        public override int funcDelete( int id )
        {
            int result = base.funcDelete( id );
            CacheAgent.ClearCache( "AD_CACHE_" );
            return result;
        }

        public override int funcDeletes( string aIDList )
        {
            int result = base.funcDeletes( aIDList );
            CacheAgent.ClearCache( "AD_CACHE_" );
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
