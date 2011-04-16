using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Site_dao
	{
        /// <summary>
        /// 获取站点列表
        /// </summary>
        /// <returns></returns>
        public List<AW_Site_bean> funcGetSites()
        {
            string cacheKey = "AW_SITES";
            List<AW_Site_bean> sites = ( List<AW_Site_bean> ) HttpRuntime.Cache[ cacheKey ];
            if( sites != null )
            {
                return sites;
            }
            this.propOrder = " ORDER BY fdSiteSort ASC,fdSiteID ASC";
            sites = this.funcGetList();
            AW_Column_dao columnDao = new AW_Column_dao();
            AW_Template_dao templateDao = new AW_Template_dao();
            foreach( AW_Site_bean site in sites )
            {
                site.TemplateList = templateDao.funcGetTemplateList( site.fdSiteID );
                if( site.fdSiteIndexTemplateID > 0 )
                {
                    site.IndexTemplate = site.GetTemplate( site.fdSiteIndexTemplateID );
                }
                if( site.fdSiteColumnTemplateID > 0 )
                {
                    site.ColumnTemplate = site.GetTemplate( site.fdSiteColumnTemplateID );
                }
                if( site.fdSiteContentTemplateID > 0 )
                {
                    site.ContentTemplate = site.GetTemplate( site.fdSiteContentTemplateID );
                }
                site.Columns = columnDao.funcGetSiteColumnTree( site );
            }
            HttpRuntime.Cache.Insert( cacheKey, sites, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes( 20 ), System.Web.Caching.CacheItemPriority.NotRemovable, null );
            return sites;
        }

        /// <summary>
        /// 获取站点信息
        /// </summary>
        /// <param name="siteID"></param>
        /// <returns></returns>
        public AW_Site_bean funcGetSiteInfo( int siteID )
        {
            List<AW_Site_bean> sites = this.funcGetSites();
            foreach( AW_Site_bean site in sites )
            {
                if( site.fdSiteID == siteID )
                    return site;
            }
            return null;
        }

        /// <summary>
        /// 判断站点访问路径是否存在
        /// </summary>
        /// <param name="url"></param>
        /// <param name="siteId"></param>
        /// <returns></returns>
        public int funcUrlExist( string url,int siteId )
        {
            string sql = "";
            if( siteId == 0 )
            {
                sql = string.Format( "select fdSiteID from AW_Site where fdSiteUrl='{0}' or fdSiteUrl='http://{0}'", url );
            }
            else
            {
                sql = string.Format( "select fdSiteID from AW_Site where (fdSiteUrl='{0}' or fdSiteUrl='http://{0}') AND fdSiteID<>{1}", url, siteId );
            }
            return this.funcGet( sql ).Tables[ 0 ].Rows.Count;
        }

        /// <summary>
        /// 判断站点文件路径是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <param name="siteId"></param>
        /// <returns></returns>
        public int funcPathExist( string path,int siteId )
        {
            string sql = "";
            if( siteId == 0 )
            {
                sql = string.Format( "select fdSiteID from AW_Site where fdSitePath='/{0}' or fdSitePath='{0}'", path );
            }
            else
            {
                sql = string.Format( "select fdSiteID from AW_Site where (fdSitePath='/{0}' or fdSitePath='{0}') AND fdSiteID<>{1}", path, siteId );
            }
            return this.funcGet( sql ).Tables[ 0 ].Rows.Count;
        }

        /// <summary>
        /// 站点排序
        /// </summary>
        /// <param name="bean"></param>
        /// <param name="nextBean"></param>
        /// <returns></returns>
        public bool funcSortSite( AW_Site_bean bean, AW_Site_bean nextBean )
        {
            string cacheKey = "AW_SITES";
            List<AW_Site_bean> list = new List<AW_Site_bean>( this.funcGetSites() );
            bool result;

            IDbConnection conn = this.NewConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();

            try
            {
                //往后排序
                if( nextBean == null || bean.fdSiteSort < nextBean.fdSiteSort )
                {
                    for( int i = 0; i < list.Count; i++ )
                    {
                        if( list[ i ].fdSiteID == bean.fdSiteID )
                        {
                            //排序是否完成
                            if( i == list.Count - 1 || ( nextBean != null && list[ i + 1 ].fdSiteID == nextBean.fdSiteID ) )
                            {
                                this.funcUpdate( list[ i ], tran );
                                break;
                            }

                            //交换位置
                            AW_Site_bean beanTemp = list[ i ];
                            list[ i ] = list[ i + 1 ];
                            list[ i + 1 ] = beanTemp;

                            //交换排序
                            int sort = list[ i ].fdSiteSort;
                            list[ i ].fdSiteSort = list[ i + 1 ].fdSiteSort;
                            list[ i + 1 ].fdSiteSort = sort;

                            this.funcUpdate( list[ i ], tran );
                        }
                    }
                }
                else
                {
                    for( int i = list.Count - 1; i >= 0; i-- )
                    {
                        if( list[ i ].fdSiteID == bean.fdSiteID )
                        {
                            //交换位置
                            AW_Site_bean beanTemp = list[ i ];
                            list[ i ] = list[ i - 1 ];
                            list[ i - 1 ] = beanTemp;

                            //交换排序
                            int sort = list[ i ].fdSiteSort;
                            list[ i ].fdSiteSort = list[ i - 1 ].fdSiteSort;
                            list[ i - 1 ].fdSiteSort = sort;

                            this.funcUpdate( list[ i ], tran );

                            //排序是否完成
                            if( list[ i ].fdSiteID == nextBean.fdSiteID )
                            {
                                this.funcUpdate( list[ i - 1 ], tran );
                                break;
                            }
                        }
                    }
                }
                tran.Commit();
                HttpRuntime.Cache.Insert( cacheKey, list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes( 20 ), System.Web.Caching.CacheItemPriority.NotRemovable, null );
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
        /// 删除站点
        /// </summary>
        /// <param name="site"></param>
        public void funcDelSite( AW_Site_bean site )
        {
            this.funcDelete( site.fdSiteID );
            List<AW_Site_bean> siteList = this.funcGetSites();
            siteList.Remove( site );
        }

        public override int funcInsert( Bean_Base aBean )
        {
            int result = base.funcInsert( aBean );
            List<AW_Site_bean> siteList = this.funcGetSites();
            ( ( AW_Site_bean ) aBean ).Columns = new List<AW_Column_bean>();
            siteList.Add( ( AW_Site_bean ) aBean );
            return result;
        }
	}
}
