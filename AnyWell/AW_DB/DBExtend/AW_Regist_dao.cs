using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Regist_dao
	{
        /// <summary>
        /// 检查邮箱是否存在
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool funcCheckEmailExist( int siteId, string email )
        {
            this.propWhere = string.Format( "fdRegiSiteID={0} AND fdRegiEmail='{1}'", siteId, email );
            return this.funcCommon().Tables[ 0 ].Rows.Count > 0;
        }

        /// <summary>
        /// 获取观众预登记列表
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Regist_bean> funcGetRegistList( int siteId, int pageIndex, int pageSize, out int recordCount )
        {
            this.propWhere = "fdRegiSiteID=" + siteId;
            this.propOrder = "ORDER BY fdRegiID DESC";
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            this.propGetCount = true;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Regist_bean> list = new List<AW_Regist_bean>();
            for( int i = 0; i < ds.Tables[ 0 ].Rows.Count; i++ )
            {
                DataRow row = ds.Tables[ 0 ].Rows[ i ];
                AW_Regist_bean bean = new AW_Regist_bean();
                bean.funcFromDataRow( row );
                bean.fdAutoId = pageSize * ( pageIndex - 1 ) + i + 1;
                list.Add( bean );
            }
            return list;
        }

        /// <summary>
        /// 获取观众预登记列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<AW_Regist_bean> funcGetRegistList( string ids )
        {
            this.propWhere = string.Format( "fdRegiID IN ({0})", ids );
            this.propOrder = "ORDER BY fdRegiID DESC";
            return this.funcGetList();
        }

        /// <summary>
        /// 获取站点观众预登记列表
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public List<AW_Regist_bean> funcGetRegistList( int sid )
        {
            this.propWhere = string.Format( "fdRegiSiteID={0}", sid );
            this.propOrder = "ORDER BY fdRegiID DESC";
            return this.funcGetList();
        }
	}
}
