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

public partial class Content_ArticleList : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        drpCoulumn.DataSource = new ColumnAgent().GetColumnListByArticle();
        drpCoulumn.DataBind();
        drpCoulumn.Items.Insert(0, new ListItem("所有栏目", "0"));
        drpUser.DataSource = new UserAgent().GetAllUserList();
        drpUser.DataBind();
        drpUser.Items.Insert(0, new ListItem("所有用户", "0"));

        if (QS("c") != "")
            drpCoulumn.SelectedValue = QS("c");
        if (QS("u") != "")
            drpUser.SelectedValue = QS("u");
        if (QS("t") != "")
            txtTitle.Text = QS("t");

        int Record = 0;
        repArticle.DataSource = new ArticleAgent().GetArticleList(int.Parse(drpCoulumn.SelectedValue), int.Parse(drpUser.SelectedValue), txtTitle.Text, PN1.PageSize, PN1.PageIndex, out Record);
        repArticle.DataBind();
        PN1.SetPage(Record);
    }
}
