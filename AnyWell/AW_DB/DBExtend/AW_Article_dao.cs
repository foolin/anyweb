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
            this.propSelect = "fdArtiID,fdArtiTitle";
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
            string sql = string.Format( "UPDATE AW_Article SET fdArtiIsDel=1 WHERE fdArtiID IN ({0})", ids );
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
            string sql = string.Format( "UPDATE AW_Article SET fdArtiColuID={0} WHERE fdArtiID IN ({1})", coluID, ids );
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
                            bean.fdArtiID = dao.funcNewID();
                            bean.fdArtiSort = bean.fdArtiID * 10;
                            bean.fdArtiColuID = column.fdColuID;
                            bean.fdArtiClickCount = 0;
                            bean.fdArtiCommentCount = 0;
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
            catch( Exception ex )
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
	}
}
