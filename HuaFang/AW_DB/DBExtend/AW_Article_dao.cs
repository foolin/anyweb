using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;
using System.Web.Caching;
using AnyWell.Configs;

namespace AnyWell.AW_DL
{
    public partial class AW_Article_dao
    {
        /// <summary>
        /// 根据栏目获取文章列表
        /// </summary>
        /// <param name="column"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetArticle(AW_Column_bean column, int pageSize, int pageIndex)
        {
            this.propSelect = "a.fdArtiID,a.fdArtiTitle,c.fdColuName";
            this.propTableApp = " a INNER JOIN AW_Column c ON a.fdArtiColumnID = c.fdColuID";
            this.propOrder = "ORDER BY a.fdArtiSort DESC,fdArtiID DESC";
            if (column != null)
            {
                this.propWhere = " c.fdColuID = " + column.fdColuID.ToString();
                if (column.Children != null)
                {
                    this.propWhere += " OR c.fdColuParentID = " + column.fdColuID.ToString();
                }
            }
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propGetCount = true;
            DataSet ds = this.funcCommon();
            List<AW_Article_bean> list = new List<AW_Article_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow(r);
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }

        /// <summary>
        /// 调整文章排序
        /// </summary>
        /// <param name="column"></param>
        /// <param name="goodsId"></param>
        /// <param name="nextId"></param>
        /// <param name="previewId"></param>
        public void funcSortArticle(int articleId, int nextId, int previewId)
        {
            AW_Article_bean article = AW_Article_bean.funcGetByID(articleId, "fdArtiID,fdArtiSort");
            AW_Article_bean next = nextId == 0 ? null : AW_Article_bean.funcGetByID(nextId, "fdArtiID,fdArtiSort");
            AW_Article_bean preview = previewId == 0 ? null : AW_Article_bean.funcGetByID(previewId, "fdArtiID,fdArtiSort");

            this.propSelect = " fdArtiID,fdArtiSort";
            this.propOrder = " ORDER BY fdArtiSort DESC";

            this._propFields = "fdArtiID,fdArtiSort";

            if (next != null)
            {
                if (article.fdArtiSort > next.fdArtiSort) //从上往下移
                {
                    this.propWhere += " AND fdArtiSort<=" + article.fdArtiSort + " AND fdArtiSort>" + next.fdArtiSort.ToString();
                    List<AW_Article_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        article.fdArtiSort = list[list.Count - 1].fdArtiSort;
                        this.funcUpdate(article);
                        for (int i = 1; i < list.Count; i++)
                        {
                            list[i].fdArtiSort = list[i - 1].fdArtiSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdArtiSort>=" + article.fdArtiSort + " AND fdArtiSort<=" + next.fdArtiSort.ToString();
                    List<AW_Article_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        article.fdArtiSort = list[0].fdArtiSort;
                        this.funcUpdate(article);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdArtiSort = list[i + 1].fdArtiSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
            }
            else if (preview != null)
            {
                if (article.fdArtiSort > preview.fdArtiSort) //从上往下移
                {
                    this.propWhere += " AND fdArtiSort<=" + article.fdArtiSort + " AND fdArtiSort>=" + preview.fdArtiSort.ToString();
                    List<AW_Article_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        article.fdArtiSort = list[list.Count - 1].fdArtiSort;
                        this.funcUpdate(article);
                        for (int i = list.Count - 1; i > 0; i--)
                        {
                            list[i].fdArtiSort = list[i - 1].fdArtiSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdArtiSort>=" + article.fdArtiSort + " AND fdArtiSort<" + preview.fdArtiSort.ToString();
                    List<AW_Article_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        article.fdArtiSort = list[0].fdArtiSort;
                        this.funcUpdate(article);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdArtiSort = list[i + 1].fdArtiSort;
                            this.funcUpdate(list[i]);
                        }
                    }

                }
            }
            CacheAgent.ClearCache( "ARTICLE_CACHE_" );
        }

        /// <summary>
        /// 更新点击数
        /// </summary>
        /// <param name="articleId"></param>
        public void funcUpdateClick( int articleId )
        {
            string sql = "UPDATE AW_Article SET fdArtiClick=fdArtiClick+1 WHERE fdArtiID=" + articleId;
            this.funcExecute( sql );
        }

        /// <summary>
        /// 批量移动文章
        /// </summary>
        /// <param name="coluId"></param>
        /// <param name="ids"></param>
        public int funcMoveArticle( int coluId, string ids )
        {
            string sql = string.Format( "UPDATE AW_Article SET fdArtiColumnID={0} WHERE fdArtiID IN ({1})", coluId, ids );
            int result = this.funcExecute( sql );
            CacheAgent.ClearCache( "ARTICLE_CACHE_" );
            return result;
        }

        /// <summary>
        /// 获取文章
        /// </summary>
        /// <param name="artiId"></param>
        /// <returns></returns>
        public AW_Article_bean funcGetArticleById( int artiId )
        {
            AW_Article_bean bean = AW_Article_bean.funcGetByID( artiId );
            if( bean == null )
            {
                return null;
            }
            else
            {
                bean.TagList = new AW_Tag_dao().funcGetTagListByObjId( artiId, 0 );
                return bean;
            }
        }

        public override int funcInsert( Bean_Base aBean )
        {
            int result = base.funcInsert( aBean );
            CacheAgent.ClearCache( "ARTICLE_CACHE_" );
            return result;
        }

        public override int funcUpdate( Bean_Base aBean )
        {
            int result = base.funcUpdate( aBean );
            CacheAgent.ClearCache( "ARTICLE_CACHE_" );
            return result;
        }

        public override int funcDelete( int id )
        {
            new AW_Tag_Associated_dao().funcClearAssociateds( id.ToString(), 0 );
            int result = base.funcDelete( id );
            CacheAgent.ClearCache( "ARTICLE_CACHE_" );
            return result;
        }

        public override int funcDeletes( string aIDList )
        {
            new AW_Tag_Associated_dao().funcClearAssociateds( aIDList, 0 );
            int result = base.funcDeletes( aIDList );
            CacheAgent.ClearCache( "ARTICLE_CACHE_" );
            return result;
        }

        /**************************************************自定义控件********************************************************************************/
        string selectStr = "fdArtiID,fdArtiColumnID,fdArtiTitle,fdArtiCreateAt";

        /// <summary>
        /// 下一篇文章编号
        /// </summary>
        /// <param name="articleID"></param>
        /// <param name="columnid"></param>
        /// <returns></returns>
        public int funcGetNextArticleIDByUC(int articleID)
        {
            string cmdText = "SELECT TOP 1 fdArtiID FROM AW_Article WHERE fdArtiColumnID=(SELECT fdArtiColumnID FROM AW_Article WHERE fdArtiID=@fdArtiID) AND fdArtiSort<(SELECT fdArtiSort FROM AW_Article WHERE fdArtiID=@fdArtiID) ORDER BY fdArtiSort DESC";

            object nextArticleID;
            using (IDbExecutor db = this.NewExecutor())
            {
                nextArticleID = db.ExecuteScalar(CommandType.Text, cmdText,
                this.NewParam("@fdArtiID", articleID));
            }
            if (nextArticleID == null || nextArticleID == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return int.Parse(nextArticleID.ToString());
            }
        }

        /// <summary>
        /// 上一篇文章编号
        /// </summary>
        /// <param name="articleID"></param>
        /// <param name="columnid"></param>
        /// <returns></returns>
        public int funcGetPreviousArticleIDByUC(int articleID)
        {
            string cmdText = "SELECT TOP 1 fdArtiID FROM AW_Article WHERE fdArtiColumnID=(SELECT fdArtiColumnID FROM AW_Article WHERE fdArtiID=@fdArtiID) AND fdArtiSort>(SELECT fdArtiSort FROM AW_Article WHERE fdArtiID=@fdArtiID) ORDER BY fdArtiSort";

            object previousArticleID;
            using (IDbExecutor db = this.NewExecutor())
            {
                previousArticleID = db.ExecuteScalar(CommandType.Text, cmdText,
                this.NewParam("@fdArtiID", articleID));
            }
            if (previousArticleID == null || previousArticleID == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return int.Parse(previousArticleID.ToString());
            }
        }

        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="columnID">栏目编号</param>
        /// <param name="topCount">前n条</param>
        /// <param name="getChild">是否级联获取下级</param>
        /// <param name="where">附加筛选条件</param>
        /// <param name="order">附加排序条件</param>
        /// <param name="cacheName">缓存名称</param>
        /// <param name="getContent">是否获取文章内容</param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetArticleListByUC(int columnID, int topCount, bool getChild, string where, string order,string cacheName,bool getContent)
        {
            if (!string.IsNullOrEmpty(cacheName) && HttpRuntime.Cache["ARTICLE_CACHE_UC_" + cacheName] != null)
            {
                return (List<AW_Article_bean>)HttpRuntime.Cache["ARTICLE_CACHE_UC_" + cacheName];
            }

            this.propSelect = this.selectStr;
            if (getContent)
            {
                this.propSelect += ",fdArtiContent";
            }

            if (topCount > 0)
            {
                this.propSelect = " TOP " + topCount + " " + this.propSelect;
            }

            if( columnID != -1 )
            {
                this.propTableApp = ",AW_Column ";

                if( getChild )
                {
                    this.propWhere = "(fdColuID = @fdColuID OR fdColuParentID=@fdColuID)";
                }
                else
                {
                    this.propWhere = "fdColuID = @fdColuID";
                }

                this.propWhere += " AND fdColuID=fdArtiColumnID ";    
                this.funcAddParam( "@fdColuID", columnID );
            }

            if (string.IsNullOrEmpty(where) == false)
            {
                this.propWhere += " AND " + where.Replace(";", "；").Replace("--", "－－");
            }

            if (string.IsNullOrEmpty(order) == false)
            {
                this.propOrder = "ORDER BY " + funcReplaceSqlField(order);
            }
            else
            {
                this.propOrder = "ORDER BY fdArtiSort DESC";
            }

            List<AW_Article_bean> articles = this.funcGetList();

            if (!string.IsNullOrEmpty(cacheName))
            {
                HttpRuntime.Cache.Insert("ARTICLE_CACHE_UC_" + cacheName, articles, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20), System.Web.Caching.CacheItemPriority.NotRemovable, null);
            }

            return articles;
        }

        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="columnID">栏目编号</param>
        /// <param name="getChild">是否级联获取下级</param>
        /// <param name="where">附加筛选条件</param>
        /// <param name="order">附加排序条件</param>
        /// <param name="pageID">当前页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="getContent">是否获取文章内容</param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetArticleListByUC(int columnID, bool getChild, string where, string order, int pageID, int pageSize, out int recordCount,bool getContent)
        {
            this.propSelect = this.selectStr;
            if (getContent)
            {
                this.propSelect += ",fdArtiContent";
            }

            this.propTableApp = ",AW_Column ";

            if (columnID != -1)
            {
                if (getChild)
                {
                    this.propWhere = "(fdColuID = @fdColuID OR fdColuParentID=@fdColuID)";
                }
                else
                {
                    this.propWhere = "fdColuID = @fdColuID";
                }
            }
            else
            {
                this.propWhere = "1=1";
            }

            this.propWhere += " AND fdColuID=fdArtiColumnID ";

            if (string.IsNullOrEmpty(where) == false)
            {
                this.propWhere += " AND " + where.Replace(";", "；").Replace("--", "－－");
            }

            if (string.IsNullOrEmpty(order) == false)
            {
                this.propOrder = "ORDER BY " + funcReplaceSqlField(order);
            }
            else
            {
                this.propOrder = "ORDER BY fdArtiSort DESC";
            }

            this.propPage = pageID;
            this.propPageSize = pageSize;
            this.propGetCount = true;

            this.funcAddParam("@fdColuID", columnID);
            List<AW_Article_bean> articles = this.funcGetList();
            recordCount = this.propCount;

            return articles;
        }
    }
}
