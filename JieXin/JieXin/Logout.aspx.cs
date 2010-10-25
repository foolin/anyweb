using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        HttpCookie co = HttpContext.Current.Request.Cookies[ "USER" ];
        if( co != null )
        {
            co.Expires = DateTime.Now.AddDays( -1 );
            Response.SetCookie( co );
        }
        Response.Redirect( "/index.aspx" );
    }
}
