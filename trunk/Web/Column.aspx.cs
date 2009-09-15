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

public partial class Column : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["id"]) || !WebAgent.IsInt32(Request.QueryString["id"]))
            Response.Redirect("/index.aspx");
        HotList1.ColumnID = int.Parse(Request.QueryString["id"]);
    }
}
