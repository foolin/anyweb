using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWeb.AnyWeb_DL;

public partial class Article : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["id"]) || !WebAgent.IsInt32(Request.QueryString["id"]))
            Response.Redirect("/index.aspx");
        AnyWeb.AnyWeb_DL.Article ar = new ArticleAgent().GetArticleInfo(int.Parse(Request.QueryString["id"]));
        if (ar == null)
            WebAgent.FailAndGo("文章不存在");
        switch (ar.ArtiColumnID) 
        {
            case 1: 
                strColumn = "ZXXW";
                break;
            case 2:
                strColumn = "SWDT";
                break;
            case 3:
                strColumn = "ZCFG";
                break;
            case 4:
                strColumn = "JXRLZY";
                break;
            default:
                strColumn = "SY";
                break;
        }
        this.Title = string.Format("广州市天河区沙河供销合作社 - {0}", ar.ArtiTitle);
        litTitle.Text = ar.ArtiTitle;
        litContent.Text = ar.ArtiContent;
    }

    protected string strColumn;
}
