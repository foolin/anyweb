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
using AnyWeb.AnyWeb_DL;

public partial class Layout_LinkDel : AdminBase
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
            WebAgent.AlertAndBack("链接不存在");
        if (new LinkAgent().DeleteLink(int.Parse(QS("id"))) > 0)
        {
            EventLog log = new EventLog();
            log.EvenDesc = "删除链接" + lnk.LinkName + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            if(lnk.LinkType==0)
                WebAgent.SuccAndGo("删除链接成功", "LinkList.aspx");
            else
                WebAgent.SuccAndGo("删除链接成功", "ImageLinkList.aspx");
        }
        else
            WebAgent.AlertAndBack("删除连接失败");
    }
}
