using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_Ajax_GetSites : AjaxPageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        StringBuilder sb = new StringBuilder();
        List<AW_Site_bean> sites = new AW_Site_dao().funcGetSites();
        int idx = 1;
        foreach( AW_Site_bean bean in sites )
        {
            sb.AppendFormat( "sites.push(new site(\"{0}\", \"{1}\", \"{2}\"));", bean.fdSiteID, bean.fdSiteName, idx++ );
        }
        RenderString( sb.ToString() );
    }
}
