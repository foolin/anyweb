using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Agent;

public partial class DeliveryMode : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        repMode.DataSource = new ModeAgent().GetModeByType(2);
        repMode.DataBind();
    }
}
