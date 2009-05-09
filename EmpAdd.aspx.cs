using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Studio.Web;

public partial class EmpAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Data1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        Employee emp = (Employee)e.InputParameters[0];
        emp.JobInfo = new Job();
        emp.JobInfo.ID = short.Parse(((DropDownList)frm1.FindControl("drpJob")).SelectedValue);
    }

    protected void Data1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        WebAgent.SuccAndGo("添加成功", "emplist.aspx");
    }

    protected void frm1_DataBound(object sender, EventArgs e)
    {
        DropDownList drpJob = ((DropDownList)frm1.FindControl("drpJob"));
        drpJob.DataSource = Setting.GetSetting().Jobs;
        drpJob.DataBind();
    }
}
