using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Log_dao
	{
        /// <summary>
        /// 获取日志列表
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="field">排序字段</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<AW_Log_bean> funcGetLogList( int adminId, string key, string field, string orderBy, int pageIndex, int pageSize, out int recordCount )
        {
            this.propTableApp = "INNER JOIN AW_Admin ON fdLogAdminID=fdAdmiID";
            this.propSelect = "fdLogID,fdLogName,fdLogDesc,fdLogAdminID,fdLogType,fdLogIP,fdLogCreateAt,fdAdmiAccount";
            if( adminId > 0 )
            {
                this.propWhere = "fdLogAdminID=" + adminId;
            }
            if( !string.IsNullOrEmpty( key ) )
            {
                this.propWhere += string.Format( " AND fdLogName LIKE '%{0}%'", key );
            }
            if( !string.IsNullOrEmpty( field ) && !string.IsNullOrEmpty( orderBy ) )
            {
                this.propOrder = string.Format( "ORDER BY {0} {1}", field, orderBy );
            }
            else
            {
                this.propOrder = "ORDER BY fdLogID DESC";
            }
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Log_bean> list = new List<AW_Log_bean>();
            for( int i = 0; i < ds.Tables[ 0 ].Rows.Count; i++ )
            {
                DataRow row = ds.Tables[ 0 ].Rows[ i ];
                AW_Log_bean bean = new AW_Log_bean();
                bean.funcFromDataRow( row );
                bean.fdAutoId = pageSize * ( pageIndex - 1 ) + i + 1;
                bean.Admin = new AW_Admin_bean();
                bean.Admin.funcFromDataRow( row );
                list.Add( bean );
            }
            return list;
        }

        /// <summary>
        /// 清空操作日志
        /// </summary>
        /// <param name="adminId">管理员编号</param>
        public void funcClearLog( int adminId )
        {
            string sql = "DELETE AW_Log";
            if( adminId > 0 )
            {
                sql += " WHERE fdLogAdminID=" + adminId;
            }
            this.funcExecute( sql );
        }
	}
}
