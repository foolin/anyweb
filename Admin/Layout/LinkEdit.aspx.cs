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
            WebAgent.AlertAndBack("用户不存在");
        txtLinkName.Text = lnk.LinkName;
        txtLinkImage.Text = lnk.LinkImage;
        txtLinkUrl.Text = lnk.LinkUrl;
        txtLinkSort.Text = Convert.ToString(lnk.LinkSort);
    }

    protected void btnEditLink_Click(object sender, EventArgs e)
    {
        LinkAgent agent = new LinkAgent();
        Link lnk = new Link();
        lnk.LinkID = int.Parse(QS("id"));
        lnk.LinkName = this.txtLinkName.Text;
        lnk.LinkImage = this.txtLinkImage.Text;
        lnk.LinkUrl = this.txtLinkUrl.Text;
        if (txtLinkSort.Text != "")
            lnk.LinkSort = Convert.ToInt32(this.txtLinkSort.Text);
        else
            lnk.LinkSort = 0;
        if (new LinkAgent().UpdateLinkInfo(lnk) > 0)
        {
            EventLog log = new EventLog();
            log.EvenDesc = "修改友情链接" + lnk.LinkName + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            WebAgent.SuccAndGo("修改连接成功", "LinkList.aspx");
        }
        else
            WebAgent.AlertAndBack("修改连接失败");
    }
}
