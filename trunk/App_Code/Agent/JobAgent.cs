using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Studio.Data;

/// <summary>
/// 职位代理
/// </summary>
public class JobAgent : DbAgent
{
    public JobAgent() : base(Setting.GetSetting().DBType, Setting.GetSetting().DBConnectionString) { }
    public JobAgent(string dbconnection)
    {
        this.DBType = DatabaseType.SqlServer;
        this.ConnectionString = dbconnection;
    }

    /// <summary>
    /// 获取工作列表
    /// </summary>
    /// <returns></returns>
    public List<Job> GetJobList()
    {
        DataSet ds;
        using (IDbExecutor db = this.NewExecutor())
        {
            ds = db.GetDataSet(CommandType.StoredProcedure, "demo_GetJobList");
        }
        List<Job> list = new List<Job>();
        foreach (DataRow r in ds.Tables[0].Rows)
        {
            list.Add(new Job(r));
        }
        return list;
    }
}
