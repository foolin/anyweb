using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Publish_dao
    {
        /// <summary>
        /// 更新发布状态
        /// </summary>
        /// <param name="bean"></param>
        public void funcUpdateStatus( AW_Publish_bean bean )
        {

            this.funcExecute( CommandType.Text, "UPDATE AW_Publish SET fdPublStatus=@fdPublStatus,fdPublError=(CASE @fdPublError WHEN '' THEN '' ELSE @fdPublError END),fdPublStartAt=@fdPublStartAt,fdPublFinishAt=@fdPublFinishAt WHERE fdPublID=@fdPublID",
                    this.NewParam( "@fdPublStatus", bean.fdPublStatus ),
                    this.NewParam( "@fdPublError", bean.fdPublError ),
                    this.NewParam( "@fdPublStartAt", bean.fdPublStartAt ),
                    this.NewParam( "@fdPublFinishAt", bean.fdPublFinishAt ),
                    this.NewParam( "@fdPublID", bean.fdPublID ) );
        }

        /// <summary>
        /// 获取发布日志列表
        /// </summary>
        /// <param name="adminId">管理员编号</param>
        /// <param name="status">状态</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Publish_bean> funcGetPublishList( int adminId, int status, int pageIndex, int pageSize, out int recordCount )
        {
            this.propTableApp = " p INNER JOIN AW_Admin a ON fdPublAdminID=fdAdmiID";
            this.propSelect = "p.*,a.fdAdmiName";
            this.propWhere = "1=1";
            if( adminId > 0 )
            {
                this.propWhere += " AND fdPublAdminID=" + adminId;
            }
            if( status > 0 )
            {
                this.propWhere += " AND fdPublStatus=" + status;
            }
            this.propOrder = "ORDER BY fdPublID DESC";
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            this.propGetCount = true;
            DataSet ds = this.funcCommon();
            List<AW_Publish_bean> list = new List<AW_Publish_bean>();
            for( int i = 0; i < ds.Tables[ 0 ].Rows.Count; i++ )
            {
                DataRow row = ds.Tables[ 0 ].Rows[ i ];
                AW_Publish_bean bean = new AW_Publish_bean();
                bean.funcFromDataRow( row );
                bean.fdAutoId = pageSize * ( pageIndex - 1 ) + i + 1;
                bean.Creater = new AW_Admin_bean();
                bean.Creater.funcFromDataRow( row );
                list.Add( bean );

            }
            recordCount = this.propCount;
            return list;
        }

        /// <summary>
        /// 获取发布日志列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<AW_Publish_bean> funcGetPublishList( string ids )
        {
            this.propSelect = "fdPublName";
            this.propWhere = string.Format( "fdPublID IN ({0})", ids );
            this.propOrder = "ORDER BY fdPublID DESC";
            return this.funcGetList();
        }

        /// <summary>
        /// 删除发布日志
        /// </summary>
        /// <param name="ids"></param>
        public void funcDeletePublish( string ids )
        {
            string sql = string.Format( "DELETE AW_Publish WHERE (fdPublStatus=2 OR fdPublStatus=3) AND fdPublID IN ({0})", ids );
            this.funcExecute( sql );
        }

        /// <summary>
        /// 清空发布日志
        /// </summary>
        public void funcClearPublish()
        {
            string sql = "DELETE AW_Publish WHERE fdPublStatus=2 OR fdPublStatus=3";
            this.funcExecute( sql );
        }

        /// <summary>
        /// 初始化发布任务(在数据库同步出错时调用)
        /// </summary>
        /// <returns></returns>
        public List<AW_Publish_bean> funcInitPublish()
        {
            this.propWhere = "fdPublStatus<>2 AND fdPublStatus<>3";
            this.propOrder = "ORDER BY fdPublID ASC";
            return this.funcGetList();
        }
	}
}
