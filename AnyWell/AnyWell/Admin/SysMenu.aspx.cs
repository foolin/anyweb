using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SysMenu : PageAdmin
{
    protected string goPath = "";
    protected void Page_Load( object sender, EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "mid" ) ) == false )
        {
            int mid = int.Parse( QS( "mid" ) );

            string menuFile = "~/App_Data/Menu.xml";
            DropMenu menu = DropMenu.GetMenuData( menuFile );
            DropMenuItem menuItem = menu.GetItemByID( mid, menu.RootItem );

            if( menuItem != null )
            {
                string idPath = menuItem.ID.ToString();
                while( menuItem.Parent != null )
                {
                    idPath = menuItem.Parent.ID.ToString() + '.' + idPath;
                    menuItem = menuItem.Parent;
                }
                goPath = idPath;
            }
        }
    }
}
