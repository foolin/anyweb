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
        /// <param name="account"></param>
        /// <param name="type"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<AW_Log_bean> funcGetLogList(string account,int type,int pageSize,int pageIndex)
        {
            this.propWhere = "1=1";
            if (!string.IsNullOrEmpty(account))
            {
                this.propWhere += string.Format(" AND fdLogAccount='{0}'", account);
            }
            if (type != 0)
            {
                this.propWhere += string.Format(" AND fdLogType={0}", type);
            }
            this.propOrder = "ORDER BY fdLogID DESC";
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            return this.funcGetList();
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        public void funcClearLog()
        {
            string sql = "DELETE AW_Log";
            this.funcExecute(sql);
        }
	}
}
