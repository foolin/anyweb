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

public partial class Content_ArticleMove : AdminBase
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

        drpColumn.DataSource = new ColumnAgent().GetColumnListByArticle();
        drpColumn.DataBind();

        lblids.Text = Request["id"].ToString();
    }

    protected void btnSaveArticle_Click(object sender, EventArgs e)
    {
        if (lblids.Text != "")
        {
            ArticleAgent agent = new ArticleAgent();
            foreach (string ArticleID in lblids.Text.Split(','))
            {
                Article ar = agent.GetArticleTitle(int.Parse(ArticleID));
                if (ar != null)
                {
                    EventLog log = new EventLog();
                    log.EvenDesc = "移动文章" + ar.ArtiTitle + "成功.";
                    log.EvenAt = DateTime.Now;
                    log.EvenIP = HttpContext.Current.Request.UserHostAddress;
                    log.EvenUserAcc = this.LoginUser.UserAcc;
                    new EventLogAgent().AddLog(log);
                }
            }
            agent.MoveArticle(lblids.Text, int.Parse(drpColumn.SelectedValue));
        }
        WebAgent.SuccAndGo("移动成功", "ArticleList.aspx");
    }
}
