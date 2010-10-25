using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Area_dao
	{
        public List<AW_Area_bean> funcInitArea()
        {
            if( HttpRuntime.Cache[ "AREA_CACHE_AREAS" ] != null )
            {
                return ( List<AW_Area_bean> ) HttpRuntime.Cache[ "AREA_CACHE_AREAS" ];
            }

            List<AW_Area_bean> list = new List<AW_Area_bean>();
            DataSet ds = this.funcCommon();
            funcInitAreaList( ds, list, 0 );
            HttpRuntime.Cache.Insert( "AREA_CACHE_AREAS", list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes( 20 ), System.Web.Caching.CacheItemPriority.NotRemovable, null );
            return list;
        }

        public void funcInitAreaList( DataSet ds, List<AW_Area_bean> list, int parent )
        {
            string where = string.Format( "fdAreaParent={0}", parent );
            foreach( DataRow row in ds.Tables[ 0 ].Select( where ) )
            {
                AW_Area_bean bean = new AW_Area_bean();
                bean.funcFromDataRow( row );
                bean.Children = new List<AW_Area_bean>();
                funcInitAreaList( ds, bean.Children, bean.fdAreaID );
                list.Add( bean );
            }
        }
	}
}
