using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Ajax_GetMenu : AjaxPageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        Response.ContentType = "text/xml";
        Response.WriteFile( Server.MapPath( "~/App_Data/Menu.xml" ) );
    }
}
