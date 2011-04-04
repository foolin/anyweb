using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Index : PageAdmin
{
    protected override void OnPreInit( EventArgs e )
    {
        AdminInfo = ( new AW_Admin_dao() ).funcGetAdminFromCookie();
        if( AdminInfo == null )
        {
            Response.Redirect( "Login.aspx" );
        }
    }
}
