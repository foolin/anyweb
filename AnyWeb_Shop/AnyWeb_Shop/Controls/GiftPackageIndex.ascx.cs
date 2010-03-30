using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Common.Agent;

public partial class Controls_GiftPackageIndex : ControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        repList.DataSource = new GiftPackageAgent().GetGiftPackageList(5, 1, true);
        repList.DataBind();
    }
}
