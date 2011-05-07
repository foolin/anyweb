using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Ajax_GetSysMenu : AjaxPageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string menuFile = "~/App_Data/SysMenu.xml";
        DropMenu menu = DropMenu.GetMenuData( menuFile );

        int parentID = 0;
        int.TryParse( QS( "parentid" ), out parentID );

        DropMenuItem menuItem;
        if( parentID == 0 )
        {
            menuItem = menu.RootItem;
        }
        else
        {
            menuItem = menu.GetItemByID( parentID, menu.RootItem );
        }
    }
}
