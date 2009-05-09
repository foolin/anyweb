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

public partial class EmpDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void frm1_DataBound(object sender, EventArgs e)
    {
        if (frm1.DataItem == null)
            return;

        Employee emp = (Employee)frm1.DataItem;
        DropDownList drpJob = ((DropDownList)frm1.FindControl("drpJob"));
        drpJob.DataSource = Setting.GetSetting().Jobs;
        drpJob.DataBind();
        ListItem li = drpJob.Items.FindByValue(emp.JobInfo.ID.ToString());
        if (li != null) li.Selected = true;
    }

    protected void Data1_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        WebAgent.SuccAndGo("删除成功", "emplist.aspx");
    }
}
