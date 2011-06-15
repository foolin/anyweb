using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Subscribe_dao
	{
        /// <summary>
        /// 获取订阅列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<AW_Subscribe_bean> funcGetSubscribeList(string ids)
        {
            this.propWhere = string.Format("fdSubsID IN ({0})", ids);
            this.propOrder = "ORDER BY fdSubsSort DESC,fdSubsID DESC";
            return this.funcGetList();
        }

        /// <summary>
        /// 获取站点订阅列表
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public List<AW_Subscribe_bean> funcGetSubscribeList( int sid )
        {
            this.propWhere = string.Format( "fdSubsSiteID={0}", sid );
            this.propOrder = "ORDER BY fdSubsSort DESC,fdSubsID DESC";
            return this.funcGetList();
        }

        /// <summary>
        /// 获取订阅列表
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Subscribe_bean> funcGetSubscribeList(int siteId, int pageIndex, int pageSize, out int recordCount)
        {
            this.propWhere = "fdSubsSiteID=" + siteId;
            this.propOrder = "ORDER BY fdSubsSort DESC,fdSubsID DESC";
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            this.propGetCount = true;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Subscribe_bean> list = new List<AW_Subscribe_bean>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                AW_Subscribe_bean bean = new AW_Subscribe_bean();
                bean.funcFromDataRow(row);
                bean.fdAutoId = pageSize * (pageIndex - 1) + i + 1;
                list.Add(bean);
            }
            return list;
        }

        /// <summary>
        /// 检查邮箱是否存在
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool funcCheckEmailExist( int sid, string email )
        {
            this.propSelect = "fdSubsID";
            this.propWhere = string.Format( "fdSubsEmail='{0}' AND fdSubsSiteID={1}", email, sid );
            return this.funcCommon().Tables[ 0 ].Rows.Count > 0;
        }
	}
}
