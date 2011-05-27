using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Article_dao
	{
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetArticleList( string ids )
        {
            this.propSelect = "fdArtiID,fdArtiTitle,fdArtiType,fdArtiSourceID,fdArtiStatus";
            this.propWhere = string.Format( "fdArtiID IN ({0})", ids );
            this.propOrder = "ORDER BY fdArtiSort DESC,fdArtiID DESC";
            return this.funcGetList();
        }

        /// <summary>
        /// 获取文章列表(所有字段)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetWholeArticleList( string ids )
        {
            this.propWhere = string.Format( "fdArtiID IN ({0})", ids );
            this.propOrder = "ORDER BY fdArtiSort DESC,fdArtiID DESC";
            return this.funcGetList();
        }

        /// <summary>
        /// 获取栏目文章列表
        /// </summary>
        /// <param name="column">所属栏目</param>
        /// <param name="getChildren">级联获取下级栏目文章</param>
        /// <param name="field">排序字段</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">返回记录数</param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetArticleList( AW_Column_bean column, bool getChildren, string field, string orderBy, int pageIndex, int pageSize, out int recordCount )
        {
            this.propTableApp = "INNER JOIN AW_Column ON fdArtiColuID=fdColuID";
            this.propSelect = "fdArtiID,fdArtiColuID,fdArtiCreateAt,fdArtiType,fdArtiTitle,fdArtiClickCount,fdArtiCommentCount,fdArtiStatus,fdColuID,fdColuName";
            this.propWhere = "fdArtiIsDel=0";
            if( getChildren )
            {
                this.propWhere += string.Format( " AND fdArtiColuID IN ({0})", column.ColumnAndChildrenString() );
            }
            else
            {
                this.propWhere += string.Format( " AND fdArtiColuID={0}", column.fdColuID );
            }
            if( !string.IsNullOrEmpty( field ) && !string.IsNullOrEmpty( orderBy ) )
            {
                this.propOrder = string.Format( "ORDER BY {0} {1}", field, orderBy );
            }
            else
            {
                this.propOrder = "ORDER BY fdArtiSort DESC,fdArtiID DESC";
            }
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Article_bean> list = new List<AW_Article_bean>();
            for( int i = 0; i < ds.Tables[ 0 ].Rows.Count; i++ )
            {
                DataRow row = ds.Tables[ 0 ].Rows[ i ];
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow( row );
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow( row );
                bean.fdAutoId = pageSize * ( pageIndex - 1 ) + i + 1;
                list.Add( bean );
            }
            return list;
        }

        /// <summary>
        /// 获取站点文档列表
        /// </summary>
        /// <param name="siteId">站点编号</param>
        /// <param name="field">排序字段</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetSiteArticleList( int siteId, string field, string orderBy, int pageIndex, int pageSize, out int recordCount )
        {
            this.propTableApp = "INNER JOIN AW_Column ON fdArtiColuID=fdColuID";
            this.propSelect = "fdArtiID,fdArtiColuID,fdArtiCreateAt,fdArtiType,fdArtiTitle,fdArtiClickCount,fdArtiCommentCount,fdColuID,fdColuName";
            this.propWhere = string.Format( "fdArtiIsDel=0 AND fdColuSiteID={0}", siteId );
            if( !string.IsNullOrEmpty( field ) && !string.IsNullOrEmpty( orderBy ) )
            {
                this.propOrder = string.Format( "ORDER BY {0} {1}", field, orderBy );
            }
            else
            {
                this.propOrder = "ORDER BY fdArtiSort DESC,fdArtiID DESC";
            }
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Article_bean> list = new List<AW_Article_bean>();
            for( int i = 0; i < ds.Tables[ 0 ].Rows.Count; i++ )
            {
                DataRow row = ds.Tables[ 0 ].Rows[ i ];
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow( row );
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow( row );
                list.Add( bean );
                bean.fdAutoId = pageSize * ( pageIndex - 1 ) + i + 1;
            }
            return list;
        }

        /// <summary>
        /// 获取站点回收站列表
        /// </summary>
        /// <param name="siteId">站点编号</param>
        /// <param name="field">排序字段</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetSiteArticleRecycleList( int siteId, string field, string orderBy, int pageIndex, int pageSize, out int recordCount )
        {
            this.propTableApp = "INNER JOIN AW_Column ON fdArtiColuID=fdColuID";
            this.propSelect = "fdArtiID,fdArtiColuID,fdArtiCreateAt,fdArtiType,fdArtiTitle,fdArtiClickCount,fdArtiCommentCount,fdColuID,fdColuName";
            this.propWhere = string.Format( "fdArtiIsDel=1 AND fdColuSiteID={0}", siteId );
            if( !string.IsNullOrEmpty( field ) && !string.IsNullOrEmpty( orderBy ) )
            {
                this.propOrder = string.Format( "ORDER BY {0} {1}", field, orderBy );
            }
            else
            {
                this.propOrder = "ORDER BY fdArtiSort DESC,fdArtiID DESC";
            }
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Article_bean> list = new List<AW_Article_bean>();
            for( int i = 0; i < ds.Tables[ 0 ].Rows.Count; i++ )
            {
                DataRow row = ds.Tables[ 0 ].Rows[ i ];
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow( row );
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow( row );
                list.Add( bean );
                bean.fdAutoId = pageSize * ( pageIndex - 1 ) + i + 1;
            }
            return list;
        }

        /// <summary>
        /// 文章排序
        /// </summary>
        /// <param name="article">文章</param>    
        /// <param name="preview">上一篇文章</param>
        /// <param name="next">下一篇文章</param>
        public bool funcSortArticle( AW_Article_bean article, AW_Article_bean preview, AW_Article_bean next )
        {
            this.propSelect = " fdArtiID,fdArtiSort";
            this.propWhere = "fdArtiIsDel=0";
            this.propOrder = " ORDER BY fdArtiSort DESC";

            this._propFields = "fdArtiID,fdArtiSort";

            bool result = false;

            IDbConnection conn = this.NewConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();

            try
            {
                if( next != null )
                {
                    if( article.fdArtiSort > next.fdArtiSort ) //从上往下移
                    {
                        this.propWhere += " AND fdArtiSort<=" + article.fdArtiSort + " AND fdArtiSort>" + next.fdArtiSort.ToString();
                        List<AW_Article_bean> list = this.funcGetList();
                        if( list.Count > 1 )
                        {
                            article.fdArtiSort = list[ list.Count - 1 ].fdArtiSort;
                            this.funcUpdate( article, tran );
                            for( int i = 1; i < list.Count; i++ )
                            {
                                list[ i ].fdArtiSort = list[ i - 1 ].fdArtiSort;
                                this.funcUpdate( list[ i ], tran );
                            }
                        }
                    }
                    else //从下往上移
                    {
                        this.propWhere += " AND fdArtiSort>=" + article.fdArtiSort + " AND fdArtiSort<=" + next.fdArtiSort.ToString();
                        List<AW_Article_bean> list = this.funcGetList();
                        if( list.Count > 1 )
                        {
                            article.fdArtiSort = list[ 0 ].fdArtiSort;
                            this.funcUpdate( article, tran );
                            for( int i = 0; i < list.Count - 1; i++ )
                            {
                                list[ i ].fdArtiSort = list[ i + 1 ].fdArtiSort;
                                this.funcUpdate( list[ i ], tran );
                            }
                        }
                    }
                }
                else if( preview != null )
                {
                    if( article.fdArtiSort > preview.fdArtiSort ) //从上往下移
                    {
                        this.propWhere += " AND fdArtiSort<=" + article.fdArtiSort + " AND fdArtiSort>=" + preview.fdArtiSort.ToString();
                        List<AW_Article_bean> list = this.funcGetList();
                        if( list.Count > 1 )
                        {
                            article.fdArtiSort = list[ list.Count - 1 ].fdArtiSort;
                            this.funcUpdate( article, tran );
                            for( int i = list.Count - 1; i > 0; i-- )
                            {
                                list[ i ].fdArtiSort = list[ i - 1 ].fdArtiSort;
                                this.funcUpdate( list[ i ], tran );
                            }
                        }
                    }
                    else //从下往上移
                    {
                        this.propWhere += " AND fdArtiSort>=" + article.fdArtiSort + " AND fdArtiSort<" + preview.fdArtiSort.ToString();
                        List<AW_Article_bean> list = this.funcGetList();
                        if( list.Count > 1 )
                        {
                            article.fdArtiSort = list[ 0 ].fdArtiSort;
                            this.funcUpdate( article, tran );
                            for( int i = 0; i < list.Count - 1; i++ )
                            {
                                list[ i ].fdArtiSort = list[ i + 1 ].fdArtiSort;
                                this.funcUpdate( list[ i ], tran );
                            }
                        }

                    }
                }
                tran.Commit();
                result = true;
            }
            catch( Exception )
            {
                tran.Rollback();
                result = false;
            }
            finally
            {
                conn.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 放入回收站
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int funcRecycleArticle( string ids )
        {
            string sql = string.Format( "UPDATE AW_Article SET fdArtiIsDel=1,fdArtiStatus=0 WHERE fdArtiID IN ({0})", ids );
            return this.funcExecute( sql );
        }

        /// <summary>
        /// 从回收站恢复文档
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int funcRevokeArticle( string ids )
        {
            string sql = string.Format( "UPDATE AW_Article SET fdArtiIsDel=0 WHERE fdArtiID IN ({0})", ids );
            return this.funcExecute( sql );
        }

        /// <summary>
        /// 移动文档
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="coluID"></param>
        /// <returns></returns>
        public int funcMoveArticle( string ids, int coluID )
        {
            string sql = string.Format( "UPDATE AW_Article SET fdArtiColuID={0},fdArtiStatus=CASE fdArtiStatus WHEN 2 THEN 1 ELSE fdArtiStatus END WHERE fdArtiID IN ({1})", coluID, ids );
            return this.funcExecute( sql );
        }

        /// <summary>
        /// 复制文档
        /// </summary>
        /// <param name="aids">文档IDs</param>
        /// <param name="cids">栏目IDs</param>
        /// <returns></returns>
        public bool funcCopyArticle( string aids, string cids )
        {
            AW_Column_dao dao = new AW_Column_dao();
            List<AW_Article_bean> list = funcGetWholeArticleList( aids );
            bool result = false;

            IDbConnection conn = this.NewConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();

            try
            {
                foreach( string cid in cids.Split( ',' ) )
                {
                    AW_Column_bean column = dao.funcGetColumnInfo( int.Parse( cid ) );
                    if( column != null )
                    {
                        foreach( AW_Article_bean bean in list )
                        {
                            bean.fdArtiID = funcNewID();
                            bean.fdArtiSort = bean.fdArtiID * 10;
                            bean.fdArtiColuID = column.fdColuID;
                            bean.fdArtiClickCount = 0;
                            bean.fdArtiCommentCount = 0;
                            bean.fdArtiCreateAt = DateTime.Now;
                            funcInsert( bean, tran );
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                tran.Commit();
                result = true;
            }
            catch( Exception )
            {
                tran.Rollback();
                result = false;
            }
            finally
            {
                conn.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 引用文档
        /// </summary>
        /// <param name="aids"></param>
        /// <param name="cids"></param>
        /// <returns></returns>
        public bool funcPointArticle( string aids, string cids )
        {
            AW_Column_dao dao = new AW_Column_dao();
            List<AW_Article_bean> list = funcGetArticleList( aids );
            bool result = false;

            IDbConnection conn = this.NewConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();

            try
            {
                foreach( string cid in cids.Split( ',' ) )
                {
                    AW_Column_bean column = dao.funcGetColumnInfo( int.Parse( cid ) );
                    if( column != null )
                    {
                        foreach( AW_Article_bean bean in list )
                        {
                            AW_Article_bean newArticle = new AW_Article_bean();
                            newArticle.fdArtiID = funcNewID();
                            newArticle.fdArtiSort = newArticle.fdArtiID * 10;
                            newArticle.fdArtiColuID = column.fdColuID;
                            newArticle.fdArtiCreateAt = DateTime.Now;
                            newArticle.fdArtiType = 4;
                            newArticle.fdArtiTitle = bean.fdArtiTitle;
                            if( bean.fdArtiType == 4 )
                            {
                                newArticle.fdArtiSourceID = bean.fdArtiSourceID;
                            }
                            else
                            {
                                newArticle.fdArtiSourceID = bean.fdArtiID;
                            }
                            funcInsert( newArticle, tran );
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                tran.Commit();
                result = true;
            }
            catch( Exception )
            {
                tran.Rollback();
                result = false;
            }
            finally
            {
                conn.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 获取回收站文章列表
        /// </summary>
        /// <param name="column"></param>
        /// <param name="getChildren"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetArticleRecycleList( AW_Column_bean column, bool getChildren, string field, string orderBy, int pageIndex, int pageSize, out int recordCount )
        {
            this.propTableApp = "INNER JOIN AW_Column ON fdArtiColuID=fdColuID";
            this.propSelect = "fdArtiID,fdArtiColuID,fdArtiCreateAt,fdArtiType,fdArtiTitle,fdArtiClickCount,fdArtiCommentCount,fdColuID,fdColuName";
            this.propWhere = "fdArtiIsDel=1";
            if( getChildren )
            {
                this.propWhere += string.Format( " AND fdArtiColuID IN ({0})", column.ColumnAndChildrenString() );
            }
            else
            {
                this.propWhere += string.Format( " AND fdArtiColuID={0}", column.fdColuID );
            }
            if( !string.IsNullOrEmpty( field ) && !string.IsNullOrEmpty( orderBy ) )
            {
                this.propOrder = string.Format( "ORDER BY {0} {1}", field, orderBy );
            }
            else
            {
                this.propOrder = "ORDER BY fdArtiSort DESC,fdArtiID DESC";
            }
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Article_bean> list = new List<AW_Article_bean>();
            for( int i = 0; i < ds.Tables[ 0 ].Rows.Count; i++ )
            {
                DataRow row = ds.Tables[ 0 ].Rows[ i ];
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow( row );
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow( row );
                list.Add( bean );
                bean.fdAutoId = pageSize * ( pageIndex - 1 ) + i + 1;
            }
            return list;
        }

        /// <summary>
        /// 清空回收站
        /// </summary>
        /// <param name="column">栏目</param>
        /// <param name="withChildren">包括所有子栏目</param>
        /// <returns></returns>
        public int funcClearRecycle( AW_Column_bean column,bool withChildren )
        {
            string sql = "DELETE AW_Article WHERE fdArtiIsDel=1";
            if( withChildren )
            {
                sql += string.Format( " AND fdArtiColuID IN ({0})", column.ColumnAndChildrenString() );
            }
            else
            {
                sql += string.Format( " AND fdArtiColuID={0}", column.fdColuID );
            }
            return funcExecute( sql );
        }

        /// <summary>
        /// 清空站点回收站
        /// </summary>
        /// <param name="siteId">站点编号</param>
        /// <returns></returns>
        public int funcClearSiteRecycle( int siteId )
        {
            string sql = string.Format( "DELETE AW_Article WHERE fdArtiIsDel=1 AND fdArtiColuID IN (SELECT fdColuID FROM AW_Column WHERE fdColuSiteID={0})", siteId );
            return funcExecute( sql );
        }

        /// <summary>
        /// 搜索文档
        /// </summary>
        /// <param name="column">栏目</param>
        /// <param name="key">关键字</param>
        /// <param name="from">起始时间</param>
        /// <param name="to">结束时间</param>
        /// <param name="type">文档类型</param>
        /// <param name="getChildren">搜索子栏目</param>
        /// <param name="field">排序字段</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<AW_Article_bean> funcSearchArticle( AW_Column_bean column, string key, DateTime from, DateTime to, int type, bool getChildren, string field, string orderBy, int pageIndex, int pageSize, out int recordCount )
        {
            this.propTableApp = "INNER JOIN AW_Column ON fdArtiColuID=fdColuID";
            this.propSelect = "fdArtiID,fdArtiColuID,fdArtiCreateAt,fdArtiType,fdArtiTitle,fdArtiClickCount,fdArtiCommentCount,fdColuID,fdColuName";
            this.propWhere = "fdArtiIsDel=0";
            if( key.Length > 0 )
            {
                this.propWhere += string.Format( " AND fdArtiTitle LIKE '%{0}%'", key );
            }
            if( from != DateTime.Parse( "1900-01-01" ) )
            {
                this.propWhere += string.Format( " AND fdArtiCreateAt>'{0}'", from );
            }
            if( to != DateTime.Parse( "2099-01-01" ) )
            {
                this.propWhere += string.Format( " AND fdArtiCreateAt<'{0}'", to.AddDays( 1 ) );
            }
            if( type != -1 )
            {
                this.propWhere += string.Format( " AND fdArtiType={0}", type );
            }
            if( getChildren )
            {
                this.propWhere += string.Format( " AND fdArtiColuID IN ({0})", column.ColumnAndChildrenString() );
            }
            else
            {
                this.propWhere += string.Format( " AND fdArtiColuID={0}", column.fdColuID );
            }
            if( !string.IsNullOrEmpty( field ) && !string.IsNullOrEmpty( orderBy ) )
            {
                this.propOrder = string.Format( "ORDER BY {0} {1}", field, orderBy );
            }
            else
            {
                this.propOrder = "ORDER BY fdArtiSort DESC,fdArtiID DESC";
            }
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Article_bean> list = new List<AW_Article_bean>();
            for( int i = 0; i < ds.Tables[ 0 ].Rows.Count; i++ )
            {
                DataRow row = ds.Tables[ 0 ].Rows[ i ];
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow( row );
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow( row );
                list.Add( bean );
                bean.fdAutoId = pageSize * ( pageIndex - 1 ) + i + 1;
            }
            return list;
        }

        /// <summary>
        /// 搜索站点文档
        /// </summary>
        /// <param name="siteId">站点编号</param>
        /// <param name="key">关键字</param>
        /// <param name="from">起始时间</param>
        /// <param name="to">结束时间</param>
        /// <param name="type">类型</param>
        /// <param name="field">排序字段</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<AW_Article_bean> funcSearchSiteArticle( int siteId, string key, DateTime from, DateTime to, int type, string field, string orderBy, int pageIndex, int pageSize, out int recordCount )
        {
            this.propTableApp = "INNER JOIN AW_Column ON fdArtiColuID=fdColuID";
            this.propSelect = "fdArtiID,fdArtiColuID,fdArtiCreateAt,fdArtiType,fdArtiTitle,fdArtiClickCount,fdArtiCommentCount,fdColuID,fdColuName";
            this.propWhere = string.Format( "fdArtiIsDel=0 AND fdColuSiteID={0}", siteId );
            if( key.Length > 0 )
            {
                this.propWhere += string.Format( " AND fdArtiTitle LIKE '%{0}%'", key );
            }
            if( from != DateTime.Parse( "1900-01-01" ) )
            {
                this.propWhere += string.Format( " AND fdArtiCreateAt>'{0}'", from );
            }
            if( to != DateTime.Parse( "2099-01-01" ) )
            {
                this.propWhere += string.Format( " AND fdArtiCreateAt<'{0}'", to.AddDays( 1 ) );
            }
            if( type != -1 )
            {
                this.propWhere += string.Format( " AND fdArtiType={0}", type );
            }
            if( !string.IsNullOrEmpty( field ) && !string.IsNullOrEmpty( orderBy ) )
            {
                this.propOrder = string.Format( "ORDER BY {0} {1}", field, orderBy );
            }
            else
            {
                this.propOrder = "ORDER BY fdArtiSort DESC,fdArtiID DESC";
            }
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Article_bean> list = new List<AW_Article_bean>();
            for( int i = 0; i < ds.Tables[ 0 ].Rows.Count; i++ )
            {
                DataRow row = ds.Tables[ 0 ].Rows[ i ];
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow( row );
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow( row );
                list.Add( bean );
                bean.fdAutoId = pageSize * ( pageIndex - 1 ) + i + 1;
            }
            return list;
        }

        /// <summary>
        /// 更新文档状态
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int funcPublishArticleByIds( string ids,int status )
        {
            string cmdText = string.Format( "UPDATE AW_Article SET fdArtiStatus={0} WHERE fdArtiID IN ({1})", status, ids );
            return funcExecute( cmdText );
        }

        /// <summary>
        /// 获取文章数
        /// </summary>
        /// <param name="columnID"></param>
        /// <param name="getChild"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int funcGetArticleCount( int columnID, bool getChild, string where )
        {
            this.propSelect = "COUNT(fdArtiID)";
            this.propWhere = "fdArtiIsDel=0";
            if( columnID != -1 )
            {
                if( getChild )
                {
                    AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( columnID );
                    this.propWhere += string.Format( " AND fdArtiColuID IN ({0})", column.ColumnAndChildrenString() );
                }
                else
                {
                    this.propWhere += string.Format( " AND fdArtiColuID={0}", columnID );
                }
            }

            if( string.IsNullOrEmpty( where ) == false )
            {
                this.propWhere += " AND " + where.Replace( ";", "；" ).Replace( "--", "－－" );
            }

            DataSet ds = funcCommon();
            return int.Parse( ds.Tables[ 0 ].Rows[ 0 ][ 0 ].ToString() );
        }

        /// <summary>
        /// 重写修改文档
        /// </summary>
        /// <param name="aBean"></param>
        /// <returns></returns>
        public override int funcUpdate( Bean_Base aBean )
        {
            int result = 0;
            IDbConnection conn = this.NewConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();

            try
            {
                base.funcUpdate( aBean, tran );
                string sql = string.Format( "UPDATE AW_Article SET fdArtiTitle='{0}',fdArtiStatus=CASE fdArtiStatus WHEN 2 THEN 1 ELSE fdArtiStatus END WHERE fdArtiType=4 AND fdArtiSourceID={1}", ( ( AW_Article_bean ) aBean ).fdArtiTitle, ( ( AW_Article_bean ) aBean ).fdArtiID );
                funcExecute( sql, tran );
                tran.Commit();
                result = 1;
            }
            catch( Exception )
            {
                tran.Rollback();
                result = 0;
            }
            finally
            {
                conn.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 重写删除文档
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override int funcDelete( int id )
        {
            int result = 0;
            IDbConnection conn = this.NewConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();

            try
            {
                base.funcDelete( id, tran );
                string sql = string.Format( "DELETE AW_Article WHERE fdArtiType=4 AND fdArtiSourceID={1}", id );
                funcExecute( sql, tran );
                tran.Commit();
                result = 1;
            }
            catch( Exception )
            {
                tran.Rollback();
                result = 0;
            }
            finally
            {
                conn.Dispose();
            }
            return result;
        }

        /**************************************************自定义控件********************************************************************************/

        string selectStr = "fdArtiID,fdArtiColuID,fdArtiCreateAt,fdArtiType,fdArtiLink,fdArtiTitle,fdArtiSubTitle,fdArtiDescription,fdArtiClickCount,fdArtiCommentCount,fdArtiIsAuthorship,fdArtiFrom,fdArtiFromLink,fdArtiFromAuthor,fdArtiCanComment,fdArtiSort,fdArtiImage,fdArtiSourceID";

        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="columnID">栏目编号</param>
        /// <param name="topCount">前n条</param>
        /// <param name="getChild">是否级联获取下级</param>
        /// <param name="where">附加筛选条件</param>
        /// <param name="order">附加排序条件</param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetArticleListByUC( int columnID, int topCount, bool getChild, string where, string order)
        {
            this.propSelect = this.selectStr;
            this.propWhere = "fdArtiIsDel=0";
            if( topCount > 0 )
            {
                this.propSelect = " TOP " + topCount + " " + this.propSelect;
            }

            if( columnID != -1 )
            {
                if( getChild )
                {
                    AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( columnID );
                    this.propWhere += string.Format( " AND fdArtiColuID IN ({0})", column.ColumnAndChildrenString() );
                }
                else
                {
                    this.propWhere += string.Format( " AND fdArtiColuID={0}", columnID );
                }
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
                this.propOrder = "ORDER BY fdArtiSort DESC";
            }

            List<AW_Article_bean> articles = this.funcGetList();

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
        /// <returns></returns>
        public List<AW_Article_bean> funcGetArticleListByUC( int columnID, bool getChild, string where, string order, int pageID, int pageSize, out int recordCount )
        {
            this.propSelect = this.selectStr;
            this.propWhere = "fdArtiIsDel=0";
            if( columnID != -1 )
            {
                if( getChild )
                {
                    AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( columnID );
                    this.propWhere += string.Format( " AND fdArtiColuID IN ({0})", column.ColumnAndChildrenString() );
                }
                else
                {
                    this.propWhere += string.Format( " AND fdArtiColuID={0}", columnID );
                }
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
                this.propOrder = "ORDER BY fdArtiSort DESC";
            }

            this.propPage = pageID;
            this.propPageSize = pageSize;
            this.propGetCount = true;

            List<AW_Article_bean> articles = this.funcGetList();
            recordCount = this.propCount;

            return articles;
        }

        /// <summary>
        /// 下一篇文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public AW_Article_bean funcGetNextArticleByUC( AW_Article_bean article )
        {
            string sql = string.Format( "SELECT TOP 1 * FROM AW_Article WHERE fdArtiIsDel=0 AND fdArtiColuID={0} AND fdArtiSort<{1} ORDER BY fdArtiSort DESC", article.fdArtiColuID, article.fdArtiSort );
            
            DataSet ds = this.funcGet( sql );

            if( ds.Tables[ 0 ].Rows.Count == 0 )
            {
                return null;
            }
            else
            {
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow( ds.Tables[ 0 ].Rows[ 0 ] );
                return bean;
            }
        }

        /// <summary>
        /// 上一篇文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public AW_Article_bean funcGetPreviousArticleByUC( AW_Article_bean article )
        {
            string sql = string.Format( "SELECT TOP 1 fdArtiID FROM AW_Article WHERE fdArtiIsDel=0 AND fdArtiColuID={0} AND fdArtiSort>{1} ORDER BY fdArtiSort", article.fdArtiColuID, article.fdArtiSort );
            
            DataSet ds = this.funcGet( sql );

            if( ds.Tables[ 0 ].Rows.Count == 0 )
            {
                return null;
            }
            else
            {
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow( ds.Tables[ 0 ].Rows[ 0 ] );
                return bean;
            }
        }
	}
}
