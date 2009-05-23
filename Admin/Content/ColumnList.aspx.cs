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

public partial class Content_ColumnList : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        repColumn.DataSource = new ColumnAgent().GetColumnList();
        repColumn.DataBind();
    }

    protected void repColumn_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Column col = (Column)e.Item.DataItem;

        Repeater rep = (Repeater)e.Item.FindControl("repChildren");
        if (rep != null)
        {
            rep.DataSource = col.ColuChidren;
            rep.DataBind();
        }
    }
}
