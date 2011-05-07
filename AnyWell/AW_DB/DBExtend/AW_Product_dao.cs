using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Product_dao
	{
        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<AW_Product_bean> funcGetProductList( string ids )
        {
            this.propSelect = "fdProdID,fdProdName,fdProdType,fdProdSourceID";
            this.propWhere = string.Format( "fdProdID IN ({0})", ids );
            this.propOrder = "ORDER BY fdProdSort DESC,fdProdID DESC";
            return this.funcGetList();
        }

        /// <summary>
        /// 获取栏目产品列表
        /// </summary>
        /// <param name="column">所属栏目</param>
        /// <param name="getChildren">级联获取下级栏目产品</param>
        /// <param name="field">排序字段</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">返回记录数</param>
        /// <returns></returns>
        public List<AW_Product_bean> funcGetProductList( AW_Column_bean column, bool getChildren, string field, string orderBy, int pageIndex, int pageSize, out int recordCount )
        {
            this.propTableApp = "INNER JOIN AW_Column ON fdProdColuID=fdColuID";
            this.propSelect = "fdProdID,fdProdColuID,fdProdType,fdProdName,fdProdCode,fdProdCreateAt,fdProdClickCount,fdProdCommentCount,fdColuID,fdColuName";
            this.propWhere = "fdProdIsDel=0";
            if( getChildren )
            {
                this.propWhere += string.Format( " AND fdProdColuID IN ({0})", column.ColumnAndChildrenString() );
            }
            else
            {
                this.propWhere += string.Format( " AND fdProdColuID={0}", column.fdColuID );
            }
            if( !string.IsNullOrEmpty( field ) && !string.IsNullOrEmpty( orderBy ) )
            {
                this.propOrder = string.Format( "ORDER BY {0} {1}", field, orderBy );
            }
            else
            {
                this.propOrder = "ORDER BY fdProdSort DESC,fdProdID DESC";
            }
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Product_bean> list = new List<AW_Product_bean>();
            for( int i = 0; i < ds.Tables[ 0 ].Rows.Count; i++ )
            {
                DataRow row = ds.Tables[ 0 ].Rows[ i ];
                AW_Product_bean bean = new AW_Product_bean();
                bean.funcFromDataRow( row );
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow( row );
                bean.fdAutoId = pageSize * ( pageIndex - 1 ) + i + 1;
                list.Add( bean );
            }
            return list;
        }

        /// <summary>
        /// 产品排序
        /// </summary>
        /// <param name="product">产品</param>    
        /// <param name="preview">上一篇产品</param>
        /// <param name="next">下一篇产品</param>
        public bool funcSortProduct( AW_Product_bean product, AW_Product_bean preview, AW_Product_bean next )
        {
            this.propSelect = "fdProdID,fdProdSort";
            this.propOrder = "ORDER BY fdProdSort DESC";

            this._propFields = "fdProdID,fdProdSort";

            bool result = false;

            IDbConnection conn = this.NewConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();

            try
            {
                if( next != null )
                {
                    if( product.fdProdSort > next.fdProdSort ) //从上往下移
                    {
                        this.propWhere += " AND fdProdSort<=" + product.fdProdSort + " AND fdProdSort>" + next.fdProdSort.ToString();
                        List<AW_Product_bean> list = this.funcGetList();
                        if( list.Count > 1 )
                        {
                            product.fdProdSort = list[ list.Count - 1 ].fdProdSort;
                            this.funcUpdate( product, tran );
                            for( int i = 1; i < list.Count; i++ )
                            {
                                list[ i ].fdProdSort = list[ i - 1 ].fdProdSort;
                                this.funcUpdate( list[ i ], tran );
                            }
                        }
                    }
                    else //从下往上移
                    {
                        this.propWhere += " AND fdProdSort>=" + product.fdProdSort + " AND fdProdSort<=" + next.fdProdSort.ToString();
                        List<AW_Product_bean> list = this.funcGetList();
                        if( list.Count > 1 )
                        {
                            product.fdProdSort = list[ 0 ].fdProdSort;
                            this.funcUpdate( product, tran );
                            for( int i = 0; i < list.Count - 1; i++ )
                            {
                                list[ i ].fdProdSort = list[ i + 1 ].fdProdSort;
                                this.funcUpdate( list[ i ], tran );
                            }
                        }
                    }
                }
                else if( preview != null )
                {
                    if( product.fdProdSort > preview.fdProdSort ) //从上往下移
                    {
                        this.propWhere += " AND fdProdSort<=" + product.fdProdSort + " AND fdProdSort>=" + preview.fdProdSort.ToString();
                        List<AW_Product_bean> list = this.funcGetList();
                        if( list.Count > 1 )
                        {
                            product.fdProdSort = list[ list.Count - 1 ].fdProdSort;
                            this.funcUpdate( product, tran );
                            for( int i = list.Count - 1; i > 0; i-- )
                            {
                                list[ i ].fdProdSort = list[ i - 1 ].fdProdSort;
                                this.funcUpdate( list[ i ], tran );
                            }
                        }
                    }
                    else //从下往上移
                    {
                        this.propWhere += " AND fdProdSort>=" + product.fdProdSort + " AND fdProdSort<" + preview.fdProdSort.ToString();
                        List<AW_Product_bean> list = this.funcGetList();
                        if( list.Count > 1 )
                        {
                            product.fdProdSort = list[ 0 ].fdProdSort;
                            this.funcUpdate( product, tran );
                            for( int i = 0; i < list.Count - 1; i++ )
                            {
                                list[ i ].fdProdSort = list[ i + 1 ].fdProdSort;
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
        public int funcRecycleProduct( string ids )
        {
            string sql = string.Format( "UPDATE AW_Product SET fdProdIsDel=1 WHERE fdProdID IN ({0})", ids );
            return this.funcExecute( sql );
        }

        /// <summary>
        /// 移动产品
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="coluID"></param>
        /// <returns></returns>
        public int funcMoveProduct( string ids, int coluID )
        {
            string sql = string.Format( "UPDATE AW_Product SET fdProdColuID={0} WHERE fdProdID IN ({1})", coluID, ids );
            return this.funcExecute( sql );
        }

        /// <summary>
        /// 获取产品列表(所有字段)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<AW_Product_bean> funcGetWholeProductList( string ids )
        {
            this.propWhere = string.Format( "fdProdID IN ({0})", ids );
            this.propOrder = "ORDER BY fdProdSort DESC,fdProdID DESC";
            return this.funcGetList();
        }

        /// <summary>
        /// 复制产品
        /// </summary>
        /// <param name="pids">产品IDs</param>
        /// <param name="cids">栏目IDs</param>
        /// <returns></returns>
        public bool funcCopyProduct( string pids, string cids )
        {
            AW_Column_dao dao = new AW_Column_dao();
            List<AW_Product_bean> list = funcGetWholeProductList( pids );
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
                        foreach( AW_Product_bean bean in list )
                        {
                            bean.fdProdID = funcNewID();
                            bean.fdProdSort = bean.fdProdID * 10;
                            bean.fdProdColuID = column.fdColuID;
                            bean.fdProdClickCount = 0;
                            bean.fdProdCommentCount = 0;
                            bean.fdProdCreateAt = DateTime.Now;
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
        /// 引用产品
        /// </summary>
        /// <param name="aids"></param>
        /// <param name="cids"></param>
        /// <returns></returns>
        public bool funcPointProduct( string aids, string cids )
        {
            AW_Column_dao dao = new AW_Column_dao();
            List<AW_Product_bean> list = funcGetProductList( aids );
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
                        foreach( AW_Product_bean bean in list )
                        {
                            AW_Product_bean newProduct = new AW_Product_bean();
                            newProduct.fdProdID = funcNewID();
                            newProduct.fdProdSort = newProduct.fdProdID * 10;
                            newProduct.fdProdColuID = column.fdColuID;
                            newProduct.fdProdCreateAt = DateTime.Now;
                            newProduct.fdProdType = 1;
                            newProduct.fdProdName = bean.fdProdName;
                            if( bean.fdProdType == 1 )
                            {
                                newProduct.fdProdSourceID = bean.fdProdSourceID;
                            }
                            else
                            {
                                newProduct.fdProdSourceID = bean.fdProdID;
                            }
                            funcInsert( newProduct, tran );
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
        /// 获取回收站产品列表
        /// </summary>
        /// <param name="column"></param>
        /// <param name="getChildren"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Product_bean> funcGetProductRecycleList( AW_Column_bean column, bool getChildren, string field, string orderBy, int pageIndex, int pageSize, out int recordCount )
        {
            this.propTableApp = "INNER JOIN AW_Column ON fdProdColuID=fdColuID";
            this.propSelect = "fdProdID,fdProdColuID,fdProdType,fdProdName,fdProdCode,fdProdCreateAt,fdProdClickCount,fdProdCommentCount,fdColuID,fdColuName";
            this.propWhere = "fdProdIsDel=1";
            if( getChildren )
            {
                this.propWhere += string.Format( " AND fdProdColuID IN ({0})", column.ColumnAndChildrenString() );
            }
            else
            {
                this.propWhere += string.Format( " AND fdProdColuID={0}", column.fdColuID );
            }
            if( !string.IsNullOrEmpty( field ) && !string.IsNullOrEmpty( orderBy ) )
            {
                this.propOrder = string.Format( "ORDER BY {0} {1}", field, orderBy );
            }
            else
            {
                this.propOrder = "ORDER BY fdProdSort DESC,fdProdID DESC";
            }
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Product_bean> list = new List<AW_Product_bean>();
            for( int i = 0; i < ds.Tables[ 0 ].Rows.Count; i++ )
            {
                DataRow row = ds.Tables[ 0 ].Rows[ i ];
                AW_Product_bean bean = new AW_Product_bean();
                bean.funcFromDataRow( row );
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow( row );
                list.Add( bean );
                bean.fdAutoId = pageSize * ( pageIndex - 1 ) + i + 1;
            }
            return list;
        }

        /// <summary>
        /// 从回收站恢复产品
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int funcRevokeProduct( string ids )
        {
            string sql = string.Format( "UPDATE AW_Product SET fdProdIsDel=0 WHERE fdProdID IN ({0})", ids );
            return this.funcExecute( sql );
        }

        /// <summary>
        /// 清空回收站
        /// </summary>
        /// <param name="column">栏目</param>
        /// <param name="withChildren">包括所有子栏目</param>
        /// <returns></returns>
        public int funcClearRecycle( AW_Column_bean column, bool withChildren )
        {
            string sql = "DELETE AW_Product WHERE fdProdIsDel=1";
            if( withChildren )
            {
                sql += string.Format( " AND fdProdColuID IN ({0})", column.ColumnAndChildrenString() );
            }
            else
            {
                sql += string.Format( " AND fdProdColuID={0}", column.fdColuID );
            }
            return funcExecute( sql );
        }

        /// <summary>
        /// 搜索产品
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
        public List<AW_Product_bean> funcSearchProduct( AW_Column_bean column, string key, DateTime from, DateTime to, int type, bool getChildren, string field, string orderBy, int pageIndex, int pageSize, out int recordCount )
        {
            this.propTableApp = "INNER JOIN AW_Column ON fdProdColuID=fdColuID";
            this.propSelect = "fdProdID,fdProdColuID,fdProdType,fdProdName,fdProdCode,fdProdCreateAt,fdProdClickCount,fdProdCommentCount,fdColuID,fdColuName";
            this.propWhere = "fdProdIsDel=0";
            if( key.Length > 0 )
            {
                this.propWhere += string.Format( " AND fdProdName LIKE '%{0}%'", key );
            }
            if( from != DateTime.Parse( "1900-01-01" ) )
            {
                this.propWhere += string.Format( " AND fdProdCreateAt>'{0}'", from );
            }
            if( to != DateTime.Parse( "2099-01-01" ) )
            {
                this.propWhere += string.Format( " AND fdProdCreateAt<'{0}'", to.AddDays( 1 ) );
            }
            if( type != -1 )
            {
                this.propWhere += string.Format( " AND fdProdType={0}", type );
            }
            if( getChildren )
            {
                this.propWhere += string.Format( " AND fdProdColuID IN ({0})", column.ColumnAndChildrenString() );
            }
            else
            {
                this.propWhere += string.Format( " AND fdProdColuID={0}", column.fdColuID );
            }
            if( !string.IsNullOrEmpty( field ) && !string.IsNullOrEmpty( orderBy ) )
            {
                this.propOrder = string.Format( "ORDER BY {0} {1}", field, orderBy );
            }
            else
            {
                this.propOrder = "ORDER BY fdProdSort DESC,fdProdID DESC";
            }
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Product_bean> list = new List<AW_Product_bean>();
            for( int i = 0; i < ds.Tables[ 0 ].Rows.Count; i++ )
            {
                DataRow row = ds.Tables[ 0 ].Rows[ i ];
                AW_Product_bean bean = new AW_Product_bean();
                bean.funcFromDataRow( row );
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow( row );
                list.Add( bean );
                bean.fdAutoId = pageSize * ( pageIndex - 1 ) + i + 1;
            }
            return list;
        }

        /// <summary>
        /// 重写修改产品
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
                string sql = string.Format( "UPDATE AW_Product SET fdProdName='{0}' WHERE fdProdType=1 AND fdProdSourceID={1}", ( ( AW_Product_bean ) aBean ).fdProdName, ( ( AW_Product_bean ) aBean ).fdProdID );
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
        /// 重写删除产品
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
                string sql = string.Format( "DELETE AW_Product WHERE fdProdType=4 AND fdProdSourceID={1}", id );
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
	}
}
