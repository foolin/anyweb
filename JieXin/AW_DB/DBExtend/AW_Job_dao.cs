using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Job_dao
    {
        public List<AW_Job_bean> funcInitJob()
        {
            if( HttpRuntime.Cache[ "JOB_CACHE_JOBS" ] != null )
            {
                return ( List<AW_Job_bean> ) HttpRuntime.Cache[ "JOB_CACHE_JOBS" ];
            }

            List<AW_Job_bean> list = new List<AW_Job_bean>();
            DataSet ds = this.funcCommon();
            funcInitJobList( ds, list, 0 );
            HttpRuntime.Cache.Insert( "JOB_CACHE_JOBS", list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes( 20 ), System.Web.Caching.CacheItemPriority.NotRemovable, null );
            return list;
        }

        public void funcInitJobList( DataSet ds, List<AW_Job_bean> list, int parent )
        {
            string where = string.Format( "fdJobParent={0}", parent );
            foreach( DataRow row in ds.Tables[ 0 ].Select( where ) )
            {
                AW_Job_bean bean = new AW_Job_bean();
                bean.funcFromDataRow( row );
                bean.Children = new List<AW_Job_bean>();
                funcInitJobList( ds, bean.Children, bean.fdJobID );
                list.Add( bean );
            }
        }
	}
}
