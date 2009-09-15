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

public partial class Article : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["id"]) || !WebAgent.IsInt32(Request.QueryString["id"]))
            Response.Redirect("/index.aspx");
        AnyWeb.AnyWeb_DL.Column col = new ColumnAgent().GetColumnByArticle(int.Parse(Request.QueryString["id"]));
        if (col != null)
            HotList1.ColumnID = col.ColuID;
        else
            Response.Redirect("/index.aspx");
    }
}
