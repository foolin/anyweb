using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Generic;

using Studio.Data;

/// <summary>
/// 雇员数据代理
/// </summary>
public class EmployeeAgent : DbAgent
{
    public EmployeeAgent() : base(Setting.GetSetting().DBType, Setting.GetSetting().DBConnectionString) { }

    /// <summary>
    /// 获取雇员列表
    /// </summary>
    /// <param name="keyword"></param>
    /// <param name="pageNo"></param>
    /// <param name="pageSize"></param>
    /// <param name="recordCount"></param>
    /// <returns></returns>
    public IList<Employee> GetEmployeeList(string keyword, int pageNo, int pageSize, out int recordCount)
    {
        DataSet ds;
        using (IDbExecutor db = this.NewExecutor())
        {
            IDbDataParameter param1 = this.NewParam("@RecordCount", 0, DbType.Int32, 4, true);
            ds = db.GetDataSet(CommandType.StoredProcedure, "demo_GetEmployeeList",
                this.NewParam("@PageNo", pageNo),
                this.NewParam("@PageSize", pageSize),
                this.NewParam("@Keyword", keyword),
                param1);
            recordCount = (int)param1.Value;
        }
        IList<Employee> list = new List<Employee>();
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            list.Add(new Employee(row));
        }
        return list;
    }

    /// <summary>
    /// 获取雇员信息
    /// </summary>
    /// <param name="empID"></param>
    /// <returns></returns>
    public Employee GetEmployInfo(string empID)
    {
        DataSet ds;
        using (IDbExecutor db = this.NewExecutor())
        {
            ds = db.GetDataSet(CommandType.StoredProcedure, "demo_GetEmployeeInfo",
                this.NewParam("@EmpID", empID));
        }
        if (ds.Tables[0].Rows.Count == 0)
            return null;
        else
            return new Employee(ds.Tables[0].Rows[0]);
    }

    /// <summary>
    /// 更新雇员信息
    /// </summary>
    /// <param name="emp"></param>
    public void UpdateEmployee(Employee emp)
    {
        using (IDbExecutor db = this.NewExecutor())
        {
            db.ExecuteNonQuery(CommandType.StoredProcedure, "demo_UpdateEmployee",
                this.NewParam("@EmpID", emp.ID),
                this.NewParam("@FirstName", emp.FirstName),
                this.NewParam("@LastName", emp.LastName),
                this.NewParam("@HireDate", emp.HireDate),
                this.NewParam("@JobID", emp.JobInfo.ID)
                );
        }
    }

    /// <summary>
    /// 更新雇员信息
    /// </summary>
    /// <param name="emp"></param>
    public void AddEmployee(Employee emp)
    {
        using (IDbExecutor db = this.NewExecutor())
        {
            db.ExecuteNonQuery(CommandType.StoredProcedure, "demo_AddEmployee",
                this.NewParam("@EmpID", emp.ID),
                this.NewParam("@FirstName", emp.FirstName),
                this.NewParam("@LastName", emp.LastName),
                this.NewParam("@HireDate", emp.HireDate),
                this.NewParam("@JobID", emp.JobInfo.ID)
                );
        }
    }

    /// <summary>
    /// 删除雇员信息
    /// </summary>
    /// <param name="empID"></param>
    public void DeleteEmployee(string empID)
    {
        using (IDbExecutor db = this.NewExecutor())
        {
            db.ExecuteNonQuery(CommandType.StoredProcedure, "demo_DeleteEmployee",
                this.NewParam("@EmpID", empID)
                );
        }
    }

    public void test()
{
return null;
}
