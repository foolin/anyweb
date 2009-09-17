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
using AnyWeb.AnyWeb_DL;

public partial class Admin_Setting_LogList : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnPreRender(EventArgs e)
    {
        drpUser.DataSource = new UserAgent().GetAllUserList();
        drpUser.DataBind();
        drpUser.Items.Insert(0, new ListItem("所有用户", ""));

        if (QS("u") != "")
            drpUser.SelectedValue = QS("u");

        int RecordCount = 0;
        repEventLog.DataSource = new EventLogAgent().GetLogList(drpUser.SelectedValue, PN1.PageSize, PN1.PageIndex, out RecordCount);
        repEventLog.DataBind();
        PN1.SetPage(RecordCount);
    }
    protected void SelectUser(object sender, EventArgs e)
    {
        Response.Redirect("/Admin/Setting/LogList.aspx?u=" + drpUser.SelectedValue);
    }
}
