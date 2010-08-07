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
using Studio.Security;
using System.IO;

public partial class Layout_LinkEdit : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
            WebAgent.AlertAndBack("参数错误");
        Link lnk = new LinkAgent().GetLinkInfo(int.Parse(QS("id")));
        if (lnk == null)
            WebAgent.AlertAndBack("友情链接不存在");

        drpSort.DataSource = new SortAgent().GetSortListByLink();
        drpSort.DataBind();

        drpSort.SelectedValue = lnk.LinkSortID.ToString();
        txtLinkName.Text = lnk.LinkName;
        txtLinkUrl.Text = lnk.LinkUrl;
        txtLinkOrder.Text = lnk.LinkOrder.ToString();
    }

    protected void btnEditLink_Click(object sender, EventArgs e)
    {
        LinkAgent agent = new LinkAgent();
        Link lnk = new LinkAgent().GetLinkInfo(int.Parse(QS("id")));
        lnk.LinkName = this.txtLinkName.Text;
        lnk.LinkSortID = int.Parse(drpSort.SelectedValue);
        lnk.LinkUrl = this.txtLinkUrl.Text;
        lnk.LinkOrder = int.Parse(txtLinkOrder.Text);
        if (new LinkAgent().UpdateLinkInfo(lnk) > 0)
        {
            EventLog log = new EventLog();
            log.EvenDesc = "修改友情链接" + lnk.LinkName + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            WebAgent.SuccAndGo("修改友情成功", "LinkList.aspx");
        }
        else
            WebAgent.AlertAndBack("修改友情链接失败");
    }
}
