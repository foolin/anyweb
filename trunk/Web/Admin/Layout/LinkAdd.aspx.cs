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

public partial class Layout_LinkAdd : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        txtLinkOrder.Text = (this.SiteInfo.SiteLinkCount + 1).ToString();
    }

    protected void btnAddLink_Click(object sender, EventArgs e)
    {
        LinkAgent agent = new LinkAgent();
        Link lnk = new Link();
        lnk.LinkName = this.txtLinkName.Text;
        lnk.LinkCateID = int.Parse(type.SelectedValue);
        lnk.LinkUrl = this.txtLinkUrl.Text;
        if (!lnk.LinkUrl.ToLower().StartsWith("http://"))
            lnk.LinkUrl = "http://" + lnk.LinkUrl;
        lnk.LinkOrder = int.Parse(this.txtLinkOrder.Text);
        if (agent.AddLink(lnk))
        {
            SiteInfo.SiteLinkCount += 1;
            EventLog log = new EventLog();
            log.EvenDesc = "添加友情链接" + lnk.LinkName + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            WebAgent.SuccAndGo("添加友情链接成功", "LinkList.aspx");
        }
        else
            WebAgent.AlertAndBack("添加友情链接失败");
    }
}
