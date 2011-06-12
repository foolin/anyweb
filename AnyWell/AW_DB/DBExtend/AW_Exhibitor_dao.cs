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
        /// 获取展商列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<AW_Exhibitor_bean> funcGetExhibitorList( string ids )
        {
            this.propWhere = string.Format( "fdExhiID IN ({0})", ids );
            this.propOrder = "ORDER BY fdExhiSort DESC,fdExhiID DESC";
            return this.funcGetList();
        }

        /// <summary>
        /// 获取展商列表
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Exhibitor_bean> funcGetExhibitorList( int siteId, int pageIndex, int pageSize, out int recordCount )
        {
            this.propWhere = "fdExhiSiteID=" + siteId;
            this.propOrder = "ORDER BY fdExhiSort DESC,fdExhiID DESC";
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            this.propGetCount = true;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Exhibitor_bean> list = new List<AW_Exhibitor_bean>();
            for( int i = 0; i < ds.Tables[ 0 ].Rows.Count; i++ )
            {
                DataRow row = ds.Tables[ 0 ].Rows[ i ];
                AW_Exhibitor_bean bean = new AW_Exhibitor_bean();
                bean.funcFromDataRow( row );
                bean.fdAutoId = pageSize * ( pageIndex - 1 ) + i + 1;
                list.Add( bean );
            }
            return list;
        }

        /// <summary>
        /// 获取前几条展商
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="top"></param>
        /// <param name="type"></param>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="enName"></param>
        /// <returns></returns>
        public List<AW_Exhibitor_bean> funcGetExhibitorList( int siteId, int top, int type, string number, string name, string enName )
        {
            this.propSelect = string.Format( "TOP {0} *", top );
            this.propWhere = "fdExhiSiteID=" + siteId;
            this.propOrder = "ORDER BY fdExhiSort DESC,fdExhiID DESC";
            if( type > 0 )
            {
                this.propWhere += string.Format( " AND fdExhiType={0}", type );
            }
            if( !string.IsNullOrEmpty( number ) )
            {
                this.propWhere += string.Format( " AND fdExhiNumber LIKE '%{0}%'", number );
            }
            if( !string.IsNullOrEmpty( name ) )
            {
                this.propWhere += string.Format( " AND fdExhiName LIKE '%{0}%'", name );
            }
            if( !string.IsNullOrEmpty( enName ) )
            {
                this.propWhere += string.Format( " AND fdExhiEnName LIKE '%{0}%'", enName );
            }
            return this.funcGetList();
        }

        /// <summary>
        /// 获取展商列表
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="type"></param>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="enName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Exhibitor_bean> funcGetExhibitorList( int siteId, int type, string number, string name, string enName, int pageIndex, int pageSize, out int recordCount )
        {
            this.propWhere = "fdExhiSiteID=" + siteId;
            this.propOrder = "ORDER BY fdExhiSort DESC,fdExhiID DESC";
            if( type > 0 )
            {
                this.propWhere += string.Format( " AND fdExhiType={0}", type );
            }
            if( !string.IsNullOrEmpty( number ) )
            {
                this.propWhere += string.Format( " AND fdExhiNumber LIKE '%{0}%'", number );
            }
            if( !string.IsNullOrEmpty( name ) )
            {
                this.propWhere += string.Format( " AND fdExhiName LIKE '%{0}%'", name );
            }
            if( !string.IsNullOrEmpty( enName ) )
            {
                this.propWhere += string.Format( " AND fdExhiEnName LIKE '%{0}%'", enName );
            }
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            this.propGetCount = true;
            List<AW_Exhibitor_bean> list = this.funcGetList();
            recordCount = this.propCount;
            return list;
        }

        /// <summary>
        /// 展商排序
        /// </summary>
        /// <param name="siteId">站点编号</param>
        /// <param name="exhibitor">展商</param>    
        /// <param name="preview">上一篇展商</param>
        /// <param name="next">下一篇展商</param>
        public bool funcSortExhibitor( int siteId,AW_Exhibitor_bean exhibitor, AW_Exhibitor_bean preview, AW_Exhibitor_bean next )
        {
            this.propSelect = " fdExhiID,fdExhiSort";
            this.propWhere = "fdExhiSiteID=" + siteId;
            this.propOrder = "ORDER BY fdExhiSort DESC,fdExhiID DESC";

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

        /**************************************************自定义控件********************************************************************************/

        
	}
}
