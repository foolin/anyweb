using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW;
using AnyWell.AW_DL;

public partial class Shop_Ajax_GetMenuItems : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AW_Admin_bean admin = (new AW_Admin_dao()).funcGetAdminFromCookie();
        string menuFile = "~/App_Data/menus.xml";
        DropMenu menu = DropMenu.GetMenuData(menuFile);
        DropMenuItem root = menu.RootItem;

        Response.Write("var menus = new Array();");
        Response.Write("var menuContainer = document.getElementById('mainmenu');");
        Response.Write("var menu1;");
        RendMenuJs(root, 1, admin);
        Response.Write("for(i = 0; i< menus.length; i++) {");
        Response.Write("    menuContainer.appendChild(menus[i].element);\r\n");
        Response.Write("}");
    }

    void RendMenuJs(DropMenuItem mi, int level, AW_Admin_bean admin)
    {
        foreach (DropMenuItem child in mi.Children)
        {
            if (level == 1)
            {
                if (admin.Purviews == null || admin.Purviews.Contains(child.ID))
                {
                    Response.Write(string.Format("menu1 = new MenuItem({0}, \"{1}\",\"{2}\", \"{3}\", \"{4}\");\r\n", level, 0, child.Name, GetPath() + child.Url, child.Target));
                    Response.Write("menus.push(menu1);");
                }
            }
            else
            {
                if (child.Type == 2)
                {
                    if (admin.Purviews == null || admin.Purviews.Contains(child.Parent.ID))
                    {
                        Response.Write(string.Format("menu{0}.addSeparator();\r\n", level - 1));
                    }
                }
                else
                {
                    if (child.Type != 3)
                    {
                        if (admin.Purviews == null || admin.Purviews.Contains(child.ID))
                        {
                            Response.Write(string.Format("menu{4} = new MenuItem({0}, \"{1}\",\"{2}\", \"{3}\", \"{5}\", \"h\");\r\n", level, 0, child.Name, GetPath() + child.Url, level, child.Target));
                            Response.Write(string.Format("menu{0}.add(menu{1});\r\n", level - 1, level));
                        }
                    }
                }
            }
            if (mi.Children.Count > 0)
            {
                RendMenuJs(child, level + 1, admin);
            }
        }
    }


    string GetPath()
    {
        if (Request.ApplicationPath == "/")
            return "";
        else
            return Request.ApplicationPath;
    }
}
