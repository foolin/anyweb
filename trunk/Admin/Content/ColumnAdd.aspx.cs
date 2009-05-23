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

public partial class Content_ColumnAdd : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        drpParent.DataSource = new ColumnAgent().GetParentColumnList(0);
        drpParent.DataBind();
        drpParent.Items.Insert(0, new ListItem("没有上级栏目", "0"));
    }

    protected void btnAddColumn_Click(object sender, EventArgs e)
    {
        Column col = new Column();
        col.ColuName = txtName.Text;
        col.ColuParent = int.Parse(drpParent.SelectedValue);
        col.ColuCreateAt = DateTime.Now;
        col.ColuDesc = txtDesc.Text;
        if (new ColumnAgent().AddColumn(col) > 0)
        {
            EventLog log = new EventLog();
            log.EvenDesc = "添加栏目" + col.ColuName + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            WebAgent.SuccAndGo("添加栏目成功", "ColumnList.aspx");
        }
        else
            WebAgent.AlertAndBack("添加栏目失败");
    }

}
