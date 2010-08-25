using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AnyWeb_DL;
using Studio.Web;

public partial class Column : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["id"]) || !WebAgent.IsInt32(Request.QueryString["id"]))
            WebAgent.FailAndGo("栏目不存在！", "/index.aspx");
        AnyWeb.AnyWeb_DL.Column column = new ColumnAgent().GetColumnInfo(int.Parse(Request.QueryString["id"]));
        if(column==null)
            WebAgent.FailAndGo("栏目不存在！", "/index.aspx");

        if (column.ColuID == 1)
            strColumn = "ZXXW";
        else if (column.ColuID == 2)
            strColumn = "SWDT";
        else
            strColumn = "ZCFG";

        this.Title = string.Format("广州市天河区沙河供销合作社 - {0}", column.ColuName);
        litTitle.Text = column.ColuName;
        int RecordCount = 0;
        repArticle.DataSource = new ArticleAgent().GetArticleListByColumn(int.Parse(Request.QueryString["id"]), PN1.PageSize, PN1.PageIndex, out RecordCount);
        repArticle.DataBind();
        PN1.SetPage(RecordCount);
    }

    protected string strColumn;
}
