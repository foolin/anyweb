using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Plugins_Regist_RegistExport : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int sid = 0;
        if( !int.TryParse( QS( "sid" ), out sid ) )
        {
            ShowError( "站点不存在！" );
        }

        AW_Site_bean site = new AW_Site_dao().funcGetSiteInfo( sid );
        if( site == null )
        {
            ShowError( "站点不存在！" );
        }
    }
}
