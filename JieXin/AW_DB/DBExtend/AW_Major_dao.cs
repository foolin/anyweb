using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Major_dao
    {
        public List<AW_Major_bean> funcInitMajor()
        {
            if( HttpRuntime.Cache[ "MAJOR_CACHE_MAJORS" ] != null )
            {
                return ( List<AW_Major_bean> ) HttpRuntime.Cache[ "MAJOR_CACHE_MAJORS" ];
            }

            List<AW_Major_bean> list = new List<AW_Major_bean>();
            DataSet ds = this.funcCommon();
            funcInitMajorList( ds, list, 0 );
            HttpRuntime.Cache.Insert( "MAJOR_CACHE_MAJORS", list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes( 20 ), System.Web.Caching.CacheItemPriority.NotRemovable, null );
            return list;
        }

        public void funcInitMajorList( DataSet ds, List<AW_Major_bean> list, int parent )
        {
            string where = string.Format( "fdMajoParent={0}", parent );
            foreach( DataRow row in ds.Tables[ 0 ].Select( where ) )
            {
                AW_Major_bean bean = new AW_Major_bean();
                bean.funcFromDataRow( row );
                bean.Children = new List<AW_Major_bean>();
                funcInitMajorList( ds, bean.Children, bean.fdMajoID );
                list.Add( bean );
            }
        }

        /// <summary>
        /// 获取专业编号
        /// </summary>
        /// <param name="majorName"></param>
        /// <returns></returns>
        public int funcGetMajorId( string majorName )
        {
            this.propSelect = "fdMajoID";
            this.propWhere = "fdMajoName=@fdMajoName";
            this.funcAddParam( "@fdMajoName", majorName );
            DataSet ds = this.funcCommon();
            if( ds.Tables[ 0 ].Rows.Count > 0 )
            {
                return ( int ) ds.Tables[ 0 ].Rows[ 0 ][ 0 ];
            }
            else
            {
                return 0;
            }
        }
	}
}
