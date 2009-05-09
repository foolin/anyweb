using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// 雇员对象
/// </summary>
public class Employee
{
	public Employee() { }

    public Employee(DataRow r)
    {
        ID = (string)r["emp_id"];
        FirstName = (string)r["fname"];
        LastName = (string)r["lname"];
        JobInfo = Setting.GetSetting().GetJobById((short)r["job_id"]);
        HireDate = (DateTime)r["hire_date"];
    }

    private string _id;
    /// <summary>
    /// 编号
    /// </summary>
    public string ID
    {
        get { return _id; }
        set { _id = value; }
    }

    private string _firstName;
    /// <summary>
    /// 名
    /// </summary>
    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    private string _lastName;
    /// <summary>
    /// 姓
    /// </summary>
    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    private Job _jobInfo;
    /// <summary>
    /// 职位信息
    /// </summary>
    public Job JobInfo
    {
        get { return _jobInfo; }
        set { _jobInfo = value; }
    }

    private DateTime _hireDate;
    /// <summary>
    /// 入职时间
    /// </summary>
    public DateTime HireDate
    {
        get { return _hireDate; }
        set { _hireDate = value; }
    }
}
