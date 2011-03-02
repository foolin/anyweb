using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_SiteInfoList : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        compRep.DataSource = new AW_SiteInfo_dao().funcGetSiteInfoList();
        compRep.DataBind();
    }
}
