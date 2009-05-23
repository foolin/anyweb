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
using Studio.Web;

public partial class Content_ColumnEdit : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
            WebAgent.AlertAndBack("参数错误");
        Column col = new ColumnAgent().GetColumnInfo(int.Parse(QS("id")));
        if(col==null)
            WebAgent.AlertAndBack("栏目不存在");

        drpParent.DataSource = new ColumnAgent().GetParentColumnList(int.Parse(QS("id")));
        drpParent.DataBind();
        drpParent.Items.Insert(0, new ListItem("没有上级栏目", "0"));

        txtName.Text = col.ColuName;
        txtDesc.Text = col.ColuDesc;
        drpParent.SelectedValue = col.ColuParent.ToString();
    }

    protected void btnAddColumn_Click(object sender, EventArgs e)
    {
        Column col = new Column();
        col.ColuID = int.Parse(QS("id"));
        col.ColuName = txtName.Text;
        col.ColuDesc = txtDesc.Text;
        col.ColuParent = int.Parse(drpParent.SelectedValue);
        if (new ColumnAgent().UpdateColumnInfo(col) > 0)
        {
            EventLog log = new EventLog();
            log.EvenDesc = "修改栏目" + col.ColuName + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            WebAgent.SuccAndGo("修改栏目成功", "ColumnList.aspx");
        }
        else
            WebAgent.AlertAndBack("修改栏目失败");
    }
}
