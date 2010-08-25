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

public partial class Admin_Content_NoticeDel : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected override void OnPreRender(EventArgs e)
    {
        if (Request.UrlReferrer == null)
        {
            WebAgent.AlertAndBack("参数错误");
        }

        if (Request["id"] != null)
        {
            NoticeAgent agent = new NoticeAgent();
            foreach (string NoticeID in Request["id"].Split(','))
            {
                Notice notice = agent.GetNoticeInfo(int.Parse(NoticeID));
                if (notice != null)
                {
                    EventLog log = new EventLog();
                    log.EvenDesc = "删除流动通知" + notice.Title + "成功.";
                    log.EvenAt = DateTime.Now;
                    log.EvenIP = HttpContext.Current.Request.UserHostAddress;
                    log.EvenUserAcc = this.LoginUser.UserAcc;
                    new EventLogAgent().AddLog(log);
                }
            }
            agent.DeleteNotice(Request["id"].ToString());
        }
        WebAgent.SuccAndGo("删除成功", "NoticeList.aspx");
    }
}
