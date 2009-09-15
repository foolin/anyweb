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
        List<Link> list = new LinkAgent().GetLinkList();
        if (list.Count <= 20)
        {
            repImage.DataSource = list;
            repImage.DataBind();
            drpLink.Visible = false;
        }
        else
        {
            repImage.DataSource = list.GetRange(0, 20);
            repImage.DataBind();
            drpLink.DataSource = list.GetRange(20, list.Count - 20);
            drpLink.DataBind();
        }
    }
}
