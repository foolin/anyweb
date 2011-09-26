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
        public List<AW_Article_bean> funcGetArticle( AW_Column_bean column, string key, int pageSize, int pageIndex )
        {
            this.propSelect = "a.fdArtiID,a.fdArtiColumnID,a.fdArtiTitle,a.fdArtiCreateAt,a.fdArtiPic,a.fdArtiDesc,a.fdArtiType,a.fdArtiCategory,c.fdColuID,c.fdColuName";
            this.propTableApp = " a INNER JOIN AW_Column c ON a.fdArtiColumnID = c.fdColuID";
            this.propOrder = "ORDER BY a.fdArtiSort DESC,fdArtiID DESC";

            if( !string.IsNullOrEmpty( key ) )
            {
                this.propWhere += string.Format( " AND fdArtiTitle LIKE '%{0}%'", key.Replace( "%", "[%]" ).Replace( "'", "''" ) );
            }

            if( column != null )
            {
                string where = "c.fdColuID = " + column.fdColuID.ToString();
                if( column.Children != null )
                {
                    where = string.Format( "({0} OR c.fdColuParentID = {1})", where, column.fdColuID );
                }
                this.propWhere += " AND " + where;
            }
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propGetCount = true;
            DataSet ds = this.funcCommon();
            List<AW_Article_bean> list = new List<AW_Article_bean>();
            foreach( DataRow r in ds.Tables[ 0 ].Rows )
            {
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow( r );
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow( r );
                list.Add( bean );
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
        public AW_Article_bean funcGetArticleById( int artiId, bool getPic )
        {
            AW_Article_bean bean = AW_Article_bean.funcGetByID( artiId );
            if( bean == null )
            {
                return null;
            }
            else
            {
                bean.TagList = new AW_Tag_dao().funcGetTagListByObjId( artiId, 0 );
                if( getPic )
                {
                    new AW_Article_Picture_dao().funcInitArticlePic( bean );
                }
                return bean;
            }
        }

        /// <summary>
        /// 获取搜索结果
        /// </summary>
        /// <param name="querryString"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetSearchArtcile( string querryString, int pageIndex, int pageSize, out int recordCount )
        {
            this.propSelect = "fdArtiID,fdArtiTitle,fdArtiCreateAt,fdArtiPic,fdArtiDesc,fdArtiType";
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            this.propGetCount = true;
            this.propWhere = querryString;
            this.propOrder = "ORDER BY fdArtiSort DESC,fdArtiID DESC";
            List<AW_Article_bean> list = this.funcGetList();
            recordCount = this.propCount;
            return list;
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
        string selectStr = "fdArtiID,fdArtiColumnID,fdArtiTitle,fdArtiCreateAt,fdArtiPic,fdArtiDesc,fdArtiType,fdArtiCategory,fdColuID,fdColuName";

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

            this.propTableApp = ",AW_Column ";

            if( columnID != -1 )
            {
                if( getChild )
                {
                    this.propWhere = "(fdColuID = @fdColuID OR fdColuParentID=@fdColuID)";
                }
                else
                {
                    this.propWhere = "fdColuID = @fdColuID";
                }
                this.funcAddParam( "@fdColuID", columnID );
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
                this.propOrder = "ORDER BY fdArtiSort DESC,fdArtiID DESC";
            }

            List<AW_Article_bean> articles = new List<AW_Article_bean>();
            foreach( DataRow row in this.funcCommon().Tables[ 0 ].Rows )
            {
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow( row );
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow( row );
                articles.Add( bean );
            }

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
                this.propOrder = "ORDER BY fdArtiSort DESC,fdArtiID DESC";
            }

            this.propPage = pageID;
            this.propPageSize = pageSize;
            this.propGetCount = true;

            this.funcAddParam("@fdColuID", columnID);
            List<AW_Article_bean> articles = new List<AW_Article_bean>();
            foreach( DataRow row in this.funcCommon().Tables[ 0 ].Rows )
            {
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow( row );
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow( row );
                articles.Add( bean );
            }
            recordCount = this.propCount;

            return articles;
        }

        /**************************************************前台********************************************************************************/
        /// <summary>
        /// 根据标签或者其它文章
        /// </summary>
        /// <param name="artiId"></param>
        /// <param name="tagIds"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetArticleListByTag( int artiId,string tagIds, int top )
        {
            string sql = string.Format( "SELECT TOP {0} fdArtiID,fdArtiColumnID,fdArtiTitle,fdArtiCreateAt,fdArtiPic,fdArtiDesc,fdArtiType FROM AW_Article WHERE fdArtiID IN (SELECT DISTINCT fdTaAsDataID FROM AW_Tag_Associated WHERE fdTaAsDataID<>{1} AND fdTaAsType=0 AND fdTaAsTagID IN ({2})) ORDER BY fdArtiSort DESC,fdArtiID DESC", top, artiId, tagIds );
            List<AW_Article_bean> list = new List<AW_Article_bean>();
            foreach( DataRow row in this.funcGet(sql).Tables[ 0 ].Rows )
            {
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow( row );
                list.Add( bean );
            }
            return list;
        }

        /// <summary>
        /// 获取设计师(专题文章左侧索引)
        /// </summary>
        /// <param name="columnId"></param>
        /// <param name="category"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetFashionArticleList( int columnId, int category, int city )
        {
            this.propSelect = "TOP 50 fdArtiID,fdArtiTitle";
            if( columnId == 0 )
            {
                this.propWhere = "fdArtiColumnID=124";
            }
            else
            {
                this.propWhere = "fdArtiColumnID=" + columnId;
            }
            if( category > 0 )
            {
                this.propWhere += " AND fdArtiCategory=" + category;
            }
            if( city > 0 )
            {
                this.propWhere += " AND fdArtiCity=" + city;
            }
            //this.propWhere = string.Format( "fdArtiColumnID={0} AND fdArtiCategory={1} AND fdArtiCity={2}", columnId, category, city );
            this.propOrder = "ORDER BY fdArtiTitle ASC";
            return this.funcGetList();
        }

        /// <summary>
        /// 获取秀场直击文章列表
        /// </summary>
        /// <param name="columnId"></param>
        /// <param name="category"></param>
        /// <param name="city"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetFashionArticleList( int columnId, int category, int city, string title, int pageIndex, int pageSize, out int recordCount )
        {
            this.propSelect = "fdArtiID,fdArtiTitle,fdArtiPic,fdArtiType,fdArtiCategory,fdArtiCity,fdColuID,fdColuName";
            this.propTableApp = " INNER JOIN AW_Column ON fdColuID=fdArtiColumnID";
            this.propWhere = "1=1";
            if( columnId > 0 )
            {
                this.propWhere += string.Format( " AND (fdColuID={0} OR fdColuParentID={0})", columnId );
            }
            if( category > 0 )
            {
                this.propWhere += string.Format( " AND fdArtiCategory={0}", category );
            }
            if( city > 0 )
            {
                this.propWhere += string.Format( " AND fdArtiCity={0}", city );
            }
            if( title.Length > 0 )
            {
                this.propWhere += string.Format( " AND fdArtiTitle LIKE '%{0}%'", title );
            }
            this.propOrder = "ORDER BY fdArtiSort DESC,fdArtiID DESC";
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            this.propGetCount = true;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Article_bean> list = new List<AW_Article_bean>();
            foreach( DataRow row in ds.Tables[ 0 ].Rows )
            {
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow( row );
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow( row );
                list.Add( bean );
            }
            return list;
        }

        /// <summary>
        /// 根据标签获取文章列表
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetArticleListByTag( int tagId, int pageIndex, int pageSize, out int recordCount )
        {
            this.propSelect = "fdArtiID,fdArtiColumnID,fdArtiTitle,fdArtiCreateAt,fdArtiPic,fdArtiDesc,fdArtiType";
            this.propTableApp = " INNER JOIN AW_Tag_Associated ON fdTaAsDataID=fdArtiID";
            this.propWhere = string.Format( "fdTaAsTagID={0} AND fdTaAsType=0", tagId );
            this.propOrder = "ORDER BY fdArtiSort DESC,fdArtiID DESC";
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propGetCount = true;
            List<AW_Article_bean> list = this.funcGetList();
            recordCount = this.propCount;
            return list;
        }

        /// <summary>
        /// 获取专题文章更多秀场
        /// </summary>
        /// <param name="coluId"></param>
        /// <param name="artiId"></param>
        /// <param name="artiTitle"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetFashionMoreArticleList( int artiId, string artiTitle, int topCount )
        {
            this.propSelect = this.selectStr;

            if( topCount > 0 )
            {
                this.propSelect = " TOP " + topCount + " " + this.propSelect;
            }

            this.propTableApp = ",AW_Column ";
            this.propWhere = "fdColuID=fdArtiColumnID AND (fdColuID=124 OR fdColuParentID=124)";
            this.propWhere += string.Format( " AND fdArtiTitle=@fdArtiTitle AND fdArtiID<>{0} AND fdArtiType=2", artiId );
            this.funcAddParam( "@fdArtiTitle", artiTitle );

            this.propOrder = "ORDER BY fdArtiSort DESC,fdArtiID DESC";

            List<AW_Article_bean> articles = new List<AW_Article_bean>();
            foreach( DataRow row in this.funcCommon().Tables[ 0 ].Rows )
            {
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow( row );
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow( row );
                articles.Add( bean );
            }
            return articles;
        }

        public List<AW_Article_bean> funcGetArticleListByLibrary( int columnId, int topCount, string where, AW_Library_bean library )
        {
            this.propSelect = this.selectStr;

            if( topCount > 0 )
            {
                this.propSelect = " TOP " + topCount + " " + this.propSelect;
            }

            this.propTableApp = ",AW_Column ";
            this.propWhere = "fdColuID=fdArtiColumnID ";
            if( columnId > 0 )
            {
                this.propWhere += " AND fdColuID = " + columnId;
            }

            if (!string.IsNullOrEmpty(where))
            {
                this.propWhere += " AND " + where.Replace(";", "；").Replace("--", "－－");
            }

            this.propWhere += string.Format( " AND (fdArtiTitle LIKE '%{0}%' OR fdArtiTitle LIKE '%{1}%')", library.fdLibrName.Replace( "%", "[%]" ).Replace( "'", "''" ), library.fdLibrEnName.Replace( "%", "[%]" ).Replace( "'", "''" ) );

            this.propOrder = "ORDER BY fdArtiSort DESC,fdArtiID DESC";

            List<AW_Article_bean> articles = new List<AW_Article_bean>();
            foreach( DataRow row in this.funcCommon().Tables[ 0 ].Rows )
            {
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow( row );
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow( row );
                articles.Add( bean );
            }
            return articles;
        }
    }
}
