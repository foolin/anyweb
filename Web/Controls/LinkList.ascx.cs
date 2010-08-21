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
using System.Collections.Generic;
using AnyWeb.AnyWeb_DL;

public partial class Controls_LinkList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        repZFWZ.DataSource = new LinkAgent().GetLinkListByCateID(1);
        repZFWZ.DataBind();

        repGXWZ.DataSource = new LinkAgent().GetLinkListByCateID(2);
        repGXWZ.DataBind();

        repGXHZS.DataSource = new LinkAgent().GetLinkListByCateID(3);
        repGXHZS.DataBind();

        repSYWZ.DataSource = new LinkAgent().GetLinkListByCateID(4);
        repSYWZ.DataBind();
    }
}
