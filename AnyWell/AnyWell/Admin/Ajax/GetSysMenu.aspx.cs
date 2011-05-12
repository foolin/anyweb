using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Admin_Ajax_GetSysMenu : AjaxPageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string menuFile = "~/App_Data/Menu.xml";
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

        StringBuilder sb = new StringBuilder();
        int idx = 1;

        if( menuItem.Children != null )
        {
            foreach( DropMenuItem child in menuItem.Children )
            {
                if( child.ID > 10 )
                {
                    sb.AppendFormat( "var child = new menu({0}, \"{1}\", \"{2}\",{3}, {4});child.parent = m;child.row = createMenuRow(child);columns.push(child);", child.ID, child.Name, child.Url, idx++, ( CheckChildMenu( child ) == true ? "true" : "false" ) );
                }
            }
        }
        RenderString( sb.ToString() );
    }

    bool CheckChildMenu( DropMenuItem item )
    {
        if( item.Children != null && item.Children.Count > 0 )
        {
            return true;
        }
        return false;
    }
}
