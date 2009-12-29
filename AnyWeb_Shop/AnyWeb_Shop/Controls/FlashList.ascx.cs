using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Agent;

public partial class Controls_FlashList : ControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        repFlash.DataSource = new SlideAgent().GetSlideList();
        repFlash.DataBind();
    }
}
