using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Column_dao
	{
        /// <summary>
        /// 获取站点的整个栏目树
        /// </summary>
        /// <param name="siteId"></param>
        /// <returns></returns>
        public List<AW_Column_bean> funcGetSiteColumnTree( AW_Site_bean site )
        {
            List<AW_Column_bean> list = new List<AW_Column_bean>();
            this.propWhere = string.Format( "fdColuSiteID={0} and fdColuIsDel=0", site.fdSiteID );
            DataSet ds = this.funcCommon();

            foreach( DataRow dr in ds.Tables[ 0 ].Select( "fdColuParentID=0", "fdColuSort ASC" ) )
            {
                AW_Column_bean bean = new AW_Column_bean();
                bean.funcFromDataRow( dr );
                bean.Site = site;
                funcBindTreeNode( bean, ds, site );
                list.Add( bean );
            }
            return list;
        }

        /// <summary>
        /// 初始树形结构
        /// </summary>
        /// <param name="node"></param>
        /// <param name="ds"></param>
        /// <param name="site"></param>
        void funcBindTreeNode( AW_Column_bean node, DataSet ds, AW_Site_bean site )
        {
            node.Children = new List<AW_Column_bean>();
            foreach( DataRow dr in ds.Tables[ 0 ].Select( "fdColuParentID=" + node.fdColuID.ToString(), "fdColuSort ASC" ) )
            {
                AW_Column_bean bean = new AW_Column_bean();
                bean.funcFromDataRow( dr );
                bean.Parent = node;
                bean.Site = site;
                funcBindTreeNode( bean, ds, site );
                if( node.Children == null )
                    node.Children = new List<AW_Column_bean>();
                node.Children.Add( bean );
            }
        }

        /// <summary>
        /// 获取栏目信息
        /// </summary>
        /// <param name="columnID"></param>
        /// <returns></returns>
        public AW_Column_bean funcGetColumnInfo( int columnID )
        {
            List<AW_Site_bean> sites = new AW_Site_dao().funcGetSites();
            foreach( AW_Site_bean site in sites )
            {
                AW_Column_bean column = site.funcGetColumnByID( site.Columns, columnID );
                if( column != null )
                {
                    return column;
                }
            }
            return null;
        }

        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="bean"></param>
        /// <returns></returns>
        public int funcAddColumn( AW_Column_bean parent, AW_Column_bean bean )
        {
            int result = this.funcInsert( bean );
            bean.Site = parent.Site;
            bean.Parent = parent;
            parent.Children.Add( bean );
            return result;
        }

        /// <summary>
        /// 添加站点栏目
        /// </summary>
        /// <param name="site"></param>
        /// <param name="bean"></param>
        /// <returns></returns>
        public int funcAddColumn( AW_Site_bean site, AW_Column_bean bean )
        {
            int result = this.funcInsert( bean );
            site.Columns.Add( bean );
            return result;
        }

        /// <summary>
        /// 栏目排序
        /// </summary>
        /// <param name="bean"></param>
        /// <param name="nextBean"></param>
        /// <returns></returns>
        public bool funcSortColumn( AW_Column_bean bean, AW_Column_bean nextBean )
        {
            List<AW_Column_bean> list;
            if( bean.Parent != null )
            {
                list = new List<AW_Column_bean>( bean.Parent.Children );
            }
            else
            {
                list = new List<AW_Column_bean>( bean.Site.Columns );
            }
            bool result;

            IDbConnection conn = this.NewConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();

            try
            {
                //往后排序
                if( nextBean == null || bean.fdColuSort < nextBean.fdColuSort )
                {
                    for( int i = 0; i < list.Count; i++ )
                    {
                        if( list[ i ].fdColuID == bean.fdColuID )
                        {
                            //排序是否完成
                            if( i == list.Count - 1 || ( nextBean != null && list[ i + 1 ].fdColuID == nextBean.fdColuID ) )
                            {
                                this.funcUpdate( list[ i ], tran );
                                break;
                            }

                            //交换位置
                            AW_Column_bean beanTemp = list[ i ];
                            list[ i ] = list[ i + 1 ];
                            list[ i + 1 ] = beanTemp;

                            //交换排序
                            int sort = list[ i ].fdColuSort;
                            list[ i ].fdColuSort = list[ i + 1 ].fdColuSort;
                            list[ i + 1 ].fdColuSort = sort;

                            this.funcUpdate( list[ i ], tran );
                        }
                    }
                }
                else
                {
                    for( int i = list.Count - 1; i >= 0; i-- )
                    {
                        if( list[ i ].fdColuID == bean.fdColuID )
                        {
                            //交换位置
                            AW_Column_bean beanTemp = list[ i ];
                            list[ i ] = list[ i - 1 ];
                            list[ i - 1 ] = beanTemp;

                            //交换排序
                            int sort = list[ i ].fdColuSort;
                            list[ i ].fdColuSort = list[ i - 1 ].fdColuSort;
                            list[ i - 1 ].fdColuSort = sort;

                            this.funcUpdate( list[ i ], tran );

                            //排序是否完成
                            if( list[ i ].fdColuID == nextBean.fdColuID )
                            {
                                this.funcUpdate( list[ i - 1 ], tran );
                                break;
                            }
                        }
                    }
                }
                tran.Commit();
                if( bean.Parent != null )
                {
                    bean.Parent.Children = list;
                }
                else
                {
                    bean.Site.Columns = list;
                }
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
        /// 删除子栏目列表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="tran"></param>
        public void funcDeleteChildren( List<AW_Column_bean> list, IDbTransaction tran )
        {
            foreach( AW_Column_bean column in list )
            {
                funcDelete( column.fdColuID, tran );

                if( column.Children != null && column.Children.Count > 0 )
                {
                    funcDeleteChildren( column.Children, tran );
                }
            }
        }

        /// <summary>
        /// 批量删除栏目
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int funcDeleteColumns( string ids )
        {
            int result = 0;
            List<AW_Column_bean> list = new List<AW_Column_bean>();

            IDbConnection conn = this.NewConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();

            try
            {
                foreach( string str in ids.Split( ',' ) )
                {
                    if( str == "" )
                        continue;
                    AW_Column_bean column = funcGetColumnInfo( int.Parse( str ) );
                    if( column != null )
                    {
                        funcDelete( column.fdColuID, tran );

                        list.Add( column );

                        if( column.Children != null && column.Children.Count > 0 )
                        {
                            funcDeleteChildren( column.Children, tran );
                        }
                    }
                }
                tran.Commit();
                foreach( AW_Column_bean column in list )
                {
                    if( column.Parent == null )
                    {
                        column.Site.Columns.Remove( column );
                    }
                    else
                    {
                        column.Parent.Children.Remove( column );
                    }
                }
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

        public override int funcDelete( int id )
        {
            int result = 0;

            IDbConnection conn = this.NewConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();

            AW_Column_bean column = funcGetColumnInfo( id );

            try
            {
                base.funcDelete( id, tran );
                if( column.Children != null && column.Children.Count > 0 )
                {
                    funcDeleteChildren( column.Children, tran );
                }
                tran.Commit();

                if( column.Parent == null )
                {
                    column.Site.Columns.Remove( column );
                }
                else
                {
                    column.Parent.Children.Remove( column );
                }

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
