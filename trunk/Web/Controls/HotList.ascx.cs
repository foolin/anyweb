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

public partial class Controls_HotList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (ColumnID == 0)
            Response.Redirect("/index.aspx");
        repHot.DataSource = new ArticleAgent().GetHotArticleList(ColumnID);
        repHot.DataBind();
    }

    private int _columnID = 0;
    /// <summary>
    /// 栏目ID
    /// </summary>
    public int ColumnID
    {
        get { return _columnID; }
        set { _columnID = value; }
    }

}
