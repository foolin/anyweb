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
	public partial class AW_Recruit_dao
	{
        /// <summary>
        /// 获取招聘列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Recruit_bean> funcGetRecruitList( string key, int pageSize, int pageIndex, out int recordCount )
        {
            this.propSelect = "fdRecrID,fdRecrTitle,fdRecrJob,fdRecrAreaName";
            if( !string.IsNullOrEmpty( key ) )
            {
                this.propWhere = string.Format( " AND fdRecrTitle LIKE '%{0}%'", key );
            }
            this.propOrder = "ORDER BY fdRecrSort DESC,fdRecrID DESC";
            this.propGetCount = true;
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            List<AW_Recruit_bean> list = new List<AW_Recruit_bean>();
            DataSet ds = this.funcCommon();
            foreach( DataRow row in ds.Tables[ 0 ].Rows )
            {
                AW_Recruit_bean bean = new AW_Recruit_bean();
                bean.funcFromDataRow( row );
                list.Add( bean );
            }
            recordCount = this.propCount;
            return list;
        }

        /// <summary>
        /// 调整招聘排序
        /// </summary>
        /// <param name="column"></param>
        /// <param name="recruitId"></param>
        /// <param name="nextId"></param>
        /// <param name="previewId"></param>
        public void funcSortRecruit(int recruitId, int nextId, int previewId)
        {
            AW_Recruit_bean recruit = AW_Recruit_bean.funcGetByID(recruitId, "fdRecrID,fdRecrSort");
            AW_Recruit_bean next = nextId == 0 ? null : AW_Recruit_bean.funcGetByID(nextId, "fdRecrID,fdRecrSort");
            AW_Recruit_bean preview = previewId == 0 ? null : AW_Recruit_bean.funcGetByID(previewId, "fdRecrID,fdRecrSort");

            this.propSelect = " fdRecrID,fdRecrSort";
            this.propOrder = " ORDER BY fdRecrSort DESC";

            this._propFields = "fdRecrID,fdRecrSort";

            if (next != null)
            {
                if (recruit.fdRecrSort > next.fdRecrSort) //从上往下移
                {
                    this.propWhere += " AND fdRecrSort<=" + recruit.fdRecrSort + " AND fdRecrSort>" + next.fdRecrSort.ToString();
                    List<AW_Recruit_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        recruit.fdRecrSort = list[list.Count - 1].fdRecrSort;
                        this.funcUpdate(recruit);
                        for (int i = 1; i < list.Count; i++)
                        {
                            list[i].fdRecrSort = list[i - 1].fdRecrSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdRecrSort>=" + recruit.fdRecrSort + " AND fdRecrSort<=" + next.fdRecrSort.ToString();
                    List<AW_Recruit_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        recruit.fdRecrSort = list[0].fdRecrSort;
                        this.funcUpdate(recruit);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdRecrSort = list[i + 1].fdRecrSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
            }
            else if (preview != null)
            {
                if (recruit.fdRecrSort > preview.fdRecrSort) //从上往下移
                {
                    this.propWhere += " AND fdRecrSort<=" + recruit.fdRecrSort + " AND fdRecrSort>=" + preview.fdRecrSort.ToString();
                    List<AW_Recruit_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        recruit.fdRecrSort = list[list.Count - 1].fdRecrSort;
                        this.funcUpdate(recruit);
                        for (int i = list.Count - 1; i > 0; i--)
                        {
                            list[i].fdRecrSort = list[i - 1].fdRecrSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdRecrSort>=" + recruit.fdRecrSort + " AND fdRecrSort<" + preview.fdRecrSort.ToString();
                    List<AW_Recruit_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        recruit.fdRecrSort = list[0].fdRecrSort;
                        this.funcUpdate(recruit);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdRecrSort = list[i + 1].fdRecrSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
            }
            CacheAgent.ClearCache( "RECRUIT_CACHE_" );
        }

        public override int funcInsert( Bean_Base aBean )
        {
            int result = base.funcInsert( aBean );
            CacheAgent.ClearCache( "RECRUIT_CACHE_" );
            return result;
        }

        public override int funcUpdate( Bean_Base aBean )
        {
            int result = base.funcUpdate( aBean );
            CacheAgent.ClearCache( "RECRUIT_CACHE_" );
            return result;
        }

        public override int funcDelete( int id )
        {
            int result = base.funcDelete( id );
            CacheAgent.ClearCache( "RECRUIT_CACHE_" );
            return result;
        }

        public override int funcDeletes( string aIDList )
        {
            int result = base.funcDeletes( aIDList );
            CacheAgent.ClearCache( "RECRUIT_CACHE_" );
            return result;
        }

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
