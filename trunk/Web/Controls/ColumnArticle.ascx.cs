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

public partial class Controls_ColumnArticle : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["id"]) || !WebAgent.IsInt32(Request.QueryString["id"]))
            Response.Redirect("/index.aspx");
        litTitle.Text = new ColumnAgent().GetColumnInfo(int.Parse(Request.QueryString["id"])).ColuName;
        this.Parent.Page.Title = litTitle.Text;
        int RecordCount = 0;
        repArticle.DataSource = new ArticleAgent().GetArticleListByColumn(int.Parse(Request.QueryString["id"]), PN1.PageSize, PN1.PageIndex, out RecordCount);
        repArticle.DataBind();
        PN1.SetPage(RecordCount);
    }
}
