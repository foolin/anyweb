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

public partial class Admin_Content_ArticleToNotice : AdminBase
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
            ArticleAgent agent = new ArticleAgent();
            foreach (string ArticleID in Request["id"].Split(','))
            {
                Article ar = agent.GetArticleTitle(int.Parse(ArticleID));
                if (ar != null)
                {
                    Notice n = new Notice();
                    n.NotiArtiID = int.Parse(ArticleID);
                    n.NotiOrder = 0;
                    n.NotiCreateAt = DateTime.Now;
                    if (new NoticeAgent().AddNotice(n) > 0)
                    {
                        EventLog log = new EventLog();
                        log.EvenDesc = "添加流动通知" + ar.ArtiTitle + "成功.";
                        log.EvenAt = DateTime.Now;
                        log.EvenIP = HttpContext.Current.Request.UserHostAddress;
                        log.EvenUserAcc = this.LoginUser.UserAcc;
                        new EventLogAgent().AddLog(log);
                    }
                }
            }
        }
        WebAgent.SuccAndGo("操作成功", "ArticleList.aspx");
    }
}
