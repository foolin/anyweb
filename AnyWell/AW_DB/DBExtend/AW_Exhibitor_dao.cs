using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Exhibitor_dao
    {    
        /// <summary>
        /// 获取栏目展商列表
        /// </summary>
        /// <param name="column">所属栏目</param>
        /// <param name="getChildren">级联获取下级栏目展商</param>
        /// <param name="field">排序字段</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">返回记录数</param>
        /// <returns></returns>
        public List<AW_Exhibitor_bean> funcGetExhibitorList( AW_Column_bean column, bool getChildren, string field, string orderBy, int pageIndex, int pageSize, out int recordCount )
        {
            this.propTableApp = "INNER JOIN AW_Column ON fdExhiColuID=fdColuID";
            this.propSelect = "fdExhiID,fdExhiColuID,fdExhiCreateAt,fdExhiName,fdExhiEnName,fdExhiStatus,fdColuID,fdColuName";
            this.propWhere = "fdExhiIsDel=0";
            if( getChildren )
            {
                this.propWhere += string.Format( " AND fdColuID IN ({0})", column.ColumnAndChildrenString() );
            }
            else
            {
                this.propWhere += string.Format( " AND fdColuID={0}", column.fdColuID );
            }
            if( !string.IsNullOrEmpty( field ) && !string.IsNullOrEmpty( orderBy ) )
            {
                this.propOrder = string.Format( "ORDER BY {0} {1}", field, orderBy );
            }
            else
            {
                this.propOrder = "ORDER BY fdExhiSort DESC,fdExhiID DESC";
            }
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Exhibitor_bean> list = new List<AW_Exhibitor_bean>();
            for( int i = 0; i < ds.Tables[ 0 ].Rows.Count; i++ )
            {
                DataRow row = ds.Tables[ 0 ].Rows[ i ];
                AW_Exhibitor_bean bean = new AW_Exhibitor_bean();
                bean.funcFromDataRow( row );
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow( row );
                bean.fdAutoId = pageSize * ( pageIndex - 1 ) + i + 1;
                list.Add( bean );
            }
            return list;
        }

        /// <summary>
        /// 获取展商列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<AW_Exhibitor_bean> funcGetExhibitorList( string ids )
        {
            this.propSelect = "fdExhiID,fdExhiColuID,fdExhiCreateAt,fdExhiName,fdExhiEnName,fdExhiStatus";
            this.propWhere = string.Format( "fdExhiID IN ({0})", ids );
            this.propOrder = "ORDER BY fdExhiSort DESC,fdExhiID DESC";
            return this.funcGetList();
        }

        /// <summary>
        /// 放入回收站
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int funcRecycleExhibitor( string ids )
        {
            string sql = string.Format( "UPDATE AW_Exhibitor SET fdExhiIsDel=1 WHERE fdExhiID IN ({0})", ids );
            return this.funcExecute( sql );
        }

        /// <summary>
        /// 获取栏目展商回收站列表
        /// </summary>
        /// <param name="column">所属栏目</param>
        /// <param name="getChildren">级联获取下级栏目展商</param>
        /// <param name="field">排序字段</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">返回记录数</param>
        /// <returns></returns>
        public List<AW_Exhibitor_bean> funcGetExhibitorRecycleList( AW_Column_bean column, bool getChildren, string field, string orderBy, int pageIndex, int pageSize, out int recordCount )
        {
            this.propTableApp = "INNER JOIN AW_Column ON fdExhiColuID=fdColuID";
            this.propSelect = "fdExhiID,fdExhiColuID,fdExhiCreateAt,fdExhiName,fdExhiEnName,fdExhiStatus,fdColuID,fdColuName";
            this.propWhere = "fdExhiIsDel=1";
            if( getChildren )
            {
                this.propWhere += string.Format( " AND fdColuID IN ({0})", column.ColumnAndChildrenString() );
            }
            else
            {
                this.propWhere += string.Format( " AND fdColuID={0}", column.fdColuID );
            }
            if( !string.IsNullOrEmpty( field ) && !string.IsNullOrEmpty( orderBy ) )
            {
                this.propOrder = string.Format( "ORDER BY {0} {1}", field, orderBy );
            }
            else
            {
                this.propOrder = "ORDER BY fdExhiSort DESC,fdExhiID DESC";
            }
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Exhibitor_bean> list = new List<AW_Exhibitor_bean>();
            for( int i = 0; i < ds.Tables[ 0 ].Rows.Count; i++ )
            {
                DataRow row = ds.Tables[ 0 ].Rows[ i ];
                AW_Exhibitor_bean bean = new AW_Exhibitor_bean();
                bean.funcFromDataRow( row );
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow( row );
                bean.fdAutoId = pageSize * ( pageIndex - 1 ) + i + 1;
                list.Add( bean );
            }
            return list;
        }

        /// <summary>
        /// 从回收站恢复展商
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int funcRevokeExhibitor( string ids )
        {
            string sql = string.Format( "UPDATE AW_Exhibitor SET fdExhiIsDel=0 WHERE fdExhiID IN ({0})", ids );
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
            string sql = "DELETE AW_Exhibitor WHERE fdExhiIsDel=1";
            if( withChildren )
            {
                sql += string.Format( " AND fdExhiColuID IN ({0})", column.ColumnAndChildrenString() );
            }
            else
            {
                sql += string.Format( " AND fdExhiColuID={0}", column.fdColuID );
            }
            return funcExecute( sql );
        }

        /// <summary>
        /// 展商排序
        /// </summary>
        /// <param name="article">文章</param>    
        /// <param name="preview">上一个展商</param>
        /// <param name="next">下一个展商</param>
        public bool funcSortExhibitor( AW_Exhibitor_bean exhibitor, AW_Exhibitor_bean preview, AW_Exhibitor_bean next )
        {
            this.propSelect = " fdExhiID,fdExhiSort";
            this.propWhere = "fdExhiIsDel=0";
            this.propOrder = " ORDER BY fdExhiSort DESC";

            this._propFields = "fdExhiID,fdExhiSort";

            bool result = false;

            IDbConnection conn = this.NewConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();

            try
            {
                if( next != null )
                {
                    if( exhibitor.fdExhiSort > next.fdExhiSort ) //从上往下移
                    {
                        this.propWhere += " AND fdExhiSort<=" + exhibitor.fdExhiSort + " AND fdExhiSort>" + next.fdExhiSort.ToString();
                        List<AW_Exhibitor_bean> list = this.funcGetList();
                        if( list.Count > 1 )
                        {
                            exhibitor.fdExhiSort = list[ list.Count - 1 ].fdExhiSort;
                            this.funcUpdate( exhibitor, tran );
                            for( int i = 1; i < list.Count; i++ )
                            {
                                list[ i ].fdExhiSort = list[ i - 1 ].fdExhiSort;
                                this.funcUpdate( list[ i ], tran );
                            }
                        }
                    }
                    else //从下往上移
                    {
                        this.propWhere += " AND fdExhiSort>=" + exhibitor.fdExhiSort + " AND fdExhiSort<=" + next.fdExhiSort.ToString();
                        List<AW_Exhibitor_bean> list = this.funcGetList();
                        if( list.Count > 1 )
                        {
                            exhibitor.fdExhiSort = list[ 0 ].fdExhiSort;
                            this.funcUpdate( exhibitor, tran );
                            for( int i = 0; i < list.Count - 1; i++ )
                            {
                                list[ i ].fdExhiSort = list[ i + 1 ].fdExhiSort;
                                this.funcUpdate( list[ i ], tran );
                            }
                        }
                    }
                }
                else if( preview != null )
                {
                    if( exhibitor.fdExhiSort > preview.fdExhiSort ) //从上往下移
                    {
                        this.propWhere += " AND fdExhiSort<=" + exhibitor.fdExhiSort + " AND fdExhiSort>=" + preview.fdExhiSort.ToString();
                        List<AW_Exhibitor_bean> list = this.funcGetList();
                        if( list.Count > 1 )
                        {
                            exhibitor.fdExhiSort = list[ list.Count - 1 ].fdExhiSort;
                            this.funcUpdate( exhibitor, tran );
                            for( int i = list.Count - 1; i > 0; i-- )
                            {
                                list[ i ].fdExhiSort = list[ i - 1 ].fdExhiSort;
                                this.funcUpdate( list[ i ], tran );
                            }
                        }
                    }
                    else //从下往上移
                    {
                        this.propWhere += " AND fdExhiSort>=" + exhibitor.fdExhiSort + " AND fdExhiSort<" + preview.fdExhiSort.ToString();
                        List<AW_Exhibitor_bean> list = this.funcGetList();
                        if( list.Count > 1 )
                        {
                            exhibitor.fdExhiSort = list[ 0 ].fdExhiSort;
                            this.funcUpdate( exhibitor, tran );
                            for( int i = 0; i < list.Count - 1; i++ )
                            {
                                list[ i ].fdExhiSort = list[ i + 1 ].fdExhiSort;
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
        /// 更新展商状态
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int funcPublishExhibitorByIds( string ids, int status )
        {
            string cmdText = string.Format( "UPDATE AW_Exhibitor SET fdExhiStatus={0} WHERE fdExhiID IN ({1})", status, ids );
            return funcExecute( cmdText );
        }

        /// <summary>
        /// 获取展商数
        /// </summary>
        /// <param name="columnID"></param>
        /// <param name="getChild"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int funcGetExhibitorCount( int columnID, bool getChild, string where )
        {
            this.propSelect = "COUNT(fdExhiID)";
            this.propWhere = "fdExhiIsDel=0";
            if( columnID != -1 )
            {
                if( getChild )
                {
                    AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( columnID );
                    this.propWhere += string.Format( " AND fdExhiColuID IN ({0})", column.ColumnAndChildrenString() );
                }
                else
                {
                    this.propWhere += string.Format( " AND fdExhiColuID={0}", columnID );
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
        /// 获取指定栏目下待发布的展商列表
        /// </summary>
        /// <param name="siteID"></param>
        /// <returns></returns>
        public List<AW_Exhibitor_bean> funcGetColumnExhibitorAdditional( int columnId )
        {
            this.propSelect = "fdExhiID, fdExhiName, fdExhiColuID";
            this.propWhere = string.Format( "fdExhiStatus<>2 AND fdExhiIsDel=0 AND fdExhiColuID={0}", columnId );
            return this.funcGetList();
        }

        /// <summary>
        /// 获取指定栏目下所有展商列表
        /// </summary>
        /// <param name="columnId"></param>
        /// <returns></returns>
        public List<AW_Exhibitor_bean> funcGetColumnExhibitorComplete( int columnId )
        {
            this.propSelect = "fdExhiID, fdExhiName, fdExhiColuID";
            this.propWhere = string.Format( "fdExhiIsDel=0 AND fdExhiColuID={0}", columnId );
            return this.funcGetList();
        }

        /**************************************************自定义控件********************************************************************************/

        string selectStr = "fdExhiID,fdExhiColuID,fdExhiName,fdExhiEnName,fdExhiNumber,fdExhiType,fdExhiUrl,fdExhiCreateAt";

        /// <summary>
        /// 获取展商列表
        /// </summary>
        /// <param name="columnID">栏目编号</param>
        /// <param name="topCount">前n条</param>
        /// <param name="getChild">是否级联获取下级</param>
        /// <param name="where">附加筛选条件</param>
        /// <param name="order">附加排序条件</param>
        /// <returns></returns>
        public List<AW_Exhibitor_bean> funcGetExhibitorListByUC( int columnID, int topCount, bool getChild, string where, string order )
        {
            this.propSelect = this.selectStr;
            this.propWhere = "fdExhiIsDel=0";
            if( topCount > 0 )
            {
                this.propSelect = " TOP " + topCount + " " + this.propSelect;
            }

            if( columnID != -1 )
            {
                if( getChild )
                {
                    AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( columnID );
                    this.propWhere += string.Format( " AND fdExhiColuID IN ({0})", column.ColumnAndChildrenString() );
                }
                else
                {
                    this.propWhere += string.Format( " AND fdExhiColuID={0}", columnID );
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
                this.propOrder = "ORDER BY fdExhiSort DESC";
            }

            return this.funcGetList();
        }

        /// <summary>
        /// 获取展商列表
        /// </summary>
        /// <param name="columnID">栏目编号</param>
        /// <param name="getChild">是否级联获取下级</param>
        /// <param name="where">附加筛选条件</param>
        /// <param name="order">附加排序条件</param>
        /// <param name="pageID">当前页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<AW_Exhibitor_bean> funcGetExhibitorListByUC( int columnID, bool getChild, string where, string order, int pageID, int pageSize, out int recordCount )
        {
            this.propSelect = this.selectStr;
            this.propWhere = "fdExhiIsDel=0";
            if( columnID != -1 )
            {
                if( getChild )
                {
                    AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( columnID );
                    this.propWhere += string.Format( " AND fdExhiColuID IN ({0})", column.ColumnAndChildrenString() );
                }
                else
                {
                    this.propWhere += string.Format( " AND fdExhiColuID={0}", columnID );
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
                this.propOrder = "ORDER BY fdExhiSort DESC";
            }

            this.propPage = pageID;
            this.propPageSize = pageSize;
            this.propGetCount = true;

            List<AW_Exhibitor_bean> exhibitors = this.funcGetList();
            recordCount = this.propCount;

            return exhibitors;
        }

        /// <summary>
        /// 下一个展商
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public AW_Exhibitor_bean funcGetNextExhibitorByUC( AW_Exhibitor_bean exhibitor )
        {
            string sql = string.Format( "SELECT TOP 1 * FROM AW_Exhibitor WHERE fdExhiIsDel=0 AND fdExhiColuID={0} AND fdExhiSort<{1} ORDER BY fdExhiSort DESC", exhibitor.fdExhiColuID, exhibitor.fdExhiSort );

            DataSet ds = this.funcGet( sql );

            if( ds.Tables[ 0 ].Rows.Count == 0 )
            {
                return null;
            }
            else
            {
                AW_Exhibitor_bean bean = new AW_Exhibitor_bean();
                bean.funcFromDataRow( ds.Tables[ 0 ].Rows[ 0 ] );
                return bean;
            }
        }

        /// <summary>
        /// 上一个展商
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public AW_Exhibitor_bean funcGetPreviousExhibitorByUC( AW_Exhibitor_bean exhibitor )
        {
            string sql = string.Format( "SELECT TOP 1 fdExhiID FROM AW_Exhibitor WHERE fdExhiIsDel=0 AND fdExhiColuID={0} AND fdExhiSort>{1} ORDER BY fdExhiSort", exhibitor.fdExhiColuID, exhibitor.fdExhiSort );

            DataSet ds = this.funcGet( sql );

            if( ds.Tables[ 0 ].Rows.Count == 0 )
            {
                return null;
            }
            else
            {
                AW_Exhibitor_bean bean = new AW_Exhibitor_bean();
                bean.funcFromDataRow( ds.Tables[ 0 ].Rows[ 0 ] );
                return bean;
            }
        }
	}
}
