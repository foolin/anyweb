using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Content_SiteList : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        List<AW_Site_bean> list = new AW_Site_dao().funcGetSites();
        if( list.Count > 0 )
        {
            repSites.DataSource = list;
            repSites.DataBind();
        }
        else
        {
            noDatas.Visible = true;
        }
    }
}
