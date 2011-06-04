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
	}
}
