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

public partial class Content_ArticleDel : AdminBase
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
                    EventLog log = new EventLog();
                    log.EvenDesc = "删除文章" + ar.ArtiTitle + "成功.";
                    log.EvenAt = DateTime.Now;
                    log.EvenIP = HttpContext.Current.Request.UserHostAddress;
                    log.EvenUserAcc = this.LoginUser.UserAcc;
                    new EventLogAgent().AddLog(log);
                }
            }
            agent.DeleteArticle(Request["id"].ToString());
        }
        WebAgent.SuccAndGo("删除成功", "ArticleList.aspx");
    }
}
