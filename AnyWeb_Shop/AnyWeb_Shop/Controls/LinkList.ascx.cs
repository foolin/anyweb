using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Agent;

public partial class Controls_LinkList : ControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        int record = 0;
        repLinks.DataSource =new LinkAgent().GetLinkList2(PN1.PageSize,PN1.PageIndex,out record);
        repLinks.DataBind();
        PN1.SetPage(record);
        /*
        repLinks.DataSource = new LinkAgent().GetLinkList();
        repLinks.DataBind();
         */
    }
}
