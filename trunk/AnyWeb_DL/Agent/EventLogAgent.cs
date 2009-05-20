using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using System.Data;

namespace AnyWeb.AnyWeb_DL
{
    public class EventLogAgent : DbAgent
    {
        public EventLogAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }

        /// <summary>
        /// ÃÌº”»’÷æ
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
    }
}
