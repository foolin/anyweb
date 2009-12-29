using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Agent;

public partial class Controls_PromotionListIndex : ControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        repList.DataSource = new GoodsAgent().GetPromotListByIndex();
        repList.DataBind();
    }
}
