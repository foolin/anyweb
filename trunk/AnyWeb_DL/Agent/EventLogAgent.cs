using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using System.Data;
using System.Collections;

namespace AnyWeb.AnyWeb_DL
{
    public class EventLogAgent : DbAgent
    {
        public EventLogAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="log"></param>
        public void AddLog(EventLog log)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                db.ExecuteNonQuery(CommandType.StoredProcedure, "AddLog",
                    this.NewParam("@EvenDesc", log.EvenDesc),
                    this.NewParam("@EvenIP", log.EvenIP),
                    this.NewParam("@EvenAt", log.EvenAt),
                    this.NewParam("@EvenUserAcc", log.EvenUserAcc));
            }
        }

        /// <summary>
        /// 获取事件日志列表
        /// </summary>
        /// <param name="EvenUserAcc"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageNo"></param>
        /// <param name="Record"></param>
        /// <returns></returns>
        public ArrayList GetLogList(string EvenUserAcc, int PageSize, int PageNo, out int Record)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 4, true);
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetLogList",
                    this.NewParam("@EvenUserAcc", EvenUserAcc),
                    this.NewParam("@PageSize", PageSize),
                    this.NewParam("@PageNo", PageNo),
                    record);
                Record = (int)record.Value;
            }

            ArrayList list = new ArrayList();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                EventLog log = new EventLog(row);
                list.Add(log);
            }
            return list;
        }

        /// <summary>
        /// 批量删除事件记录
        /// </summary>
        /// <param name="ids"></param>
        public void DeleteLog(string ids)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                db.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteLogs",
                    this.NewParam("@ids", ids));
            }
        }

        /// <summary>
        /// 清空记录
        /// </summary>
        public void ClearLog()
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                db.ExecuteNonQuery(CommandType.StoredProcedure, "ClearLogs");
            }
        }

    }
}
