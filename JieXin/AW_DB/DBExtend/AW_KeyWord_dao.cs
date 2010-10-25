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
	public partial class AW_KeyWord_dao
	{
        /// <summary>
        /// 获取关键词列表
        /// </summary>
        /// <param name="status"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<AW_KeyWord_bean> funcKeyWordList(int status, int pageSize, int pageIndex)
        {
            this.propOrder = "ORDER BY fdKeyWSort DESC, fdKeyWID DESC";
            if (status != -1)
            {
                this.propWhere = " fdKeyWIsShow =" + status;
            }
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propGetCount = true;
            return this.funcGetList();
        }

        /// <summary>
        /// 调整搜素关键字排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nextId"></param>
        /// <param name="previewId"></param>
        public void funcSortKeyWords(int id, int nextId, int previewId)
        {
            AW_KeyWord_bean keyword = AW_KeyWord_bean.funcGetByID(id, "fdKeyWID,fdKeyWSort");
            AW_KeyWord_bean next = nextId == 0 ? null : AW_KeyWord_bean.funcGetByID(nextId, "fdKeyWID,fdKeyWSort");
            AW_KeyWord_bean preview = previewId == 0 ? null : AW_KeyWord_bean.funcGetByID(previewId, "fdKeyWID,fdKeyWSort");

            this.propSelect = " fdKeyWID,fdKeyWSort";
            this.propOrder = " ORDER BY fdKeyWSort DESC, fdKeyWID DESC";

            this._propFields = "fdKeyWID,fdKeyWSort";

            if (next != null)
            {
                if (keyword.fdKeyWSort > next.fdKeyWSort) //从上往下移
                {
                    this.propWhere += " AND fdKeyWSort<=" + keyword.fdKeyWSort + " AND fdKeyWSort>" + next.fdKeyWSort.ToString();
                    List<AW_KeyWord_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        keyword.fdKeyWSort = list[list.Count - 1].fdKeyWSort;
                        this.funcUpdate(keyword);
                        for (int i = 1; i < list.Count; i++)
                        {
                            list[i].fdKeyWSort = list[i - 1].fdKeyWSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdKeyWSort>=" + keyword.fdKeyWSort + " AND fdKeyWSort<=" + next.fdKeyWSort.ToString();
                    List<AW_KeyWord_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        keyword.fdKeyWSort = list[0].fdKeyWSort;
                        this.funcUpdate(keyword);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdKeyWSort = list[i + 1].fdKeyWSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
            }
            else if (preview != null)
            {
                if (keyword.fdKeyWSort > preview.fdKeyWSort) //从上往下移
                {
                    this.propWhere += " AND fdKeyWSort<=" + keyword.fdKeyWSort + " AND fdKeyWSort>=" + preview.fdKeyWSort.ToString();
                    List<AW_KeyWord_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        keyword.fdKeyWSort = list[list.Count - 1].fdKeyWSort;
                        this.funcUpdate(keyword);
                        for (int i = list.Count - 1; i > 0; i--)
                        {
                            list[i].fdKeyWSort = list[i - 1].fdKeyWSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdKeyWSort>=" + keyword.fdKeyWSort + " AND fdKeyWSort<" + preview.fdKeyWSort.ToString();
                    List<AW_KeyWord_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        keyword.fdKeyWSort = list[0].fdKeyWSort;
                        this.funcUpdate(keyword);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdKeyWSort = list[i + 1].fdKeyWSort;
                            this.funcUpdate(list[i]);
                        }
                    }

                }
            }
            CacheAgent.ClearCache( "KEYWORD_CACHE_" );
        }

        public override int funcInsert( Bean_Base aBean )
        {
            int result = base.funcInsert( aBean );
            CacheAgent.ClearCache( "KEYWORD_CACHE_" );
            return result;
        }

        public override int funcUpdate( Bean_Base aBean )
        {
            int result = base.funcUpdate( aBean );
            CacheAgent.ClearCache( "KEYWORD_CACHE_" );
            return result;
        }

        public override int funcDelete( int id )
        {
            int result = base.funcDelete( id );
            CacheAgent.ClearCache( "KEYWORD_CACHE_" );
            return result;
        }

        public override int funcDeletes( string aIDList )
        {
            int result = base.funcDeletes( aIDList );
            CacheAgent.ClearCache( "KEYWORD_CACHE_" );
            return result;
        }

        /**************************************************自定义控件********************************************************************************/
        /// <summary>
        /// 获取热门搜索列表
        /// </summary>
        /// <param name="topCount">前n条</param>
        /// <param name="where">附加筛选条件</param>
        /// <param name="order">附加排序条件</param>
        /// <param name="cacheName">缓存名称</param>
        /// <returns></returns>
        public List<AW_KeyWord_bean> funcGetKeyWordListByUC( int topCount, string where, string order, string cacheName )
        {
            if( !string.IsNullOrEmpty( cacheName ) && HttpRuntime.Cache[ "KEYWORD_CACHE_UC_" + cacheName ] != null )
            {
                return ( List<AW_KeyWord_bean> ) HttpRuntime.Cache[ "KEYWORD_CACHE_UC_" + cacheName ];
            }

            if( topCount > 0 )
            {
                this.propSelect = " TOP " + topCount + " *";
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
                this.propOrder = "ORDER BY fdKeyWSort DESC";
            }

            List<AW_KeyWord_bean> keywords = this.funcGetList();

            if( !string.IsNullOrEmpty( cacheName ) )
            {
                HttpRuntime.Cache.Insert( "KEYWORD_CACHE_UC_" + cacheName, keywords, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes( 20 ), System.Web.Caching.CacheItemPriority.NotRemovable, null );
            }

            return keywords;
        }
	}
}
