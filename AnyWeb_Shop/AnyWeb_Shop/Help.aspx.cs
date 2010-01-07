using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Common;
using Common.Agent;
using Studio.Web;

public partial class Help : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (string.IsNullOrEmpty(QS("id")) || !WebAgent.IsInt32(QS("id")))
        {
            WebAgent.FailAndGo("参数错误！", "index.aspx");
        }
        else
        {
            repHelp.DataSource = ShopInfo.SysArticle;
            repHelp.DataBind();
            Article = new ArticleAgent().GetArticleByid(int.Parse(QS("id")));
            if (Article == null)
                WebAgent.FailAndGo("帮且文档不存在！", "index.aspx");
            this.Title = Article.Title;
        }

    }

    private Article _article;
    public Article Article
    {
        get { return _article; }
        set { _article = value; }
    }
}
