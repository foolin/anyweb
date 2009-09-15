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

public partial class Controls_ArticleContent : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["id"]) || !WebAgent.IsInt32(Request.QueryString["id"]))
            Response.Redirect("/index.aspx");
        Article ar = new ArticleAgent().GetArticleInfo(int.Parse(Request.QueryString["id"]));
        if (ar == null)
            WebAgent.FailAndGo("文章不存在");
    }
}
