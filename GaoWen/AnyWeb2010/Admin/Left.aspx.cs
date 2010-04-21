using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;
using AnyWeb.AW;

public partial class Admin_Left : System.Web.UI.Page
{
    protected override void OnPreRender(EventArgs e)
    {
        admin = (new AW_Admin_dao()).funcGetAdminFromCookie();
        string menuFile = "~/App_Data/menus.xml";
        DropMenu menu = DropMenu.GetMenuData(menuFile);
        repMenu.DataSource = menu.RootItem.Children;
        repMenu.DataBind();
    }

    public string GetPath()
    {
        if (Request.ApplicationPath == "/")
            return "";
        else
            return Request.ApplicationPath;
    }

    protected void repMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DropMenuItem item = (DropMenuItem)e.Item.DataItem;
        Repeater repChile = (Repeater)e.Item.FindControl("repChild");
        if (repChile != null && item.Children != null)
        {
            List<DropMenuItem> listChild = new List<DropMenuItem>();
            foreach (DropMenuItem child in item.Children)
            {
                if (child.Type != 2 && child.Type != 3)
                {
                    listChild.Add(child);
                }
            }
            repChile.DataSource = listChild;
            repChile.DataBind();
        }
    }

    protected AW_Admin_bean admin;
}
