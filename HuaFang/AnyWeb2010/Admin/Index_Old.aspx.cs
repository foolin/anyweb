using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using AnyWell.AW;
using Studio.Web;

public partial class Admin_Index_Old : System.Web.UI.Page
{
    protected AW_Admin_bean _adminInfo;

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        _adminInfo = (new AW_Admin_dao()).funcGetAdminFromCookie();
        if (_adminInfo == null)
            Response.Redirect("~/Admin/Login.aspx");

        if (_adminInfo.Purviews != null)
        {
            DropMenu menu = DropMenu.GetMenuData("~/App_Data/Menus.xml");
            bool allow = false;
            DropMenuItem menuItem = menu.GetItemByPath(Context.Request.FilePath, menu.RootItem);
            if (menuItem == null)
            {
                allow = true;
            }
            while (menuItem != null)
            {
                if (_adminInfo.Purviews.Contains(menuItem.ID) == true)
                {
                    allow = true;
                    break;
                }
                else
                {
                    if (menuItem.Type == 1 && menuItem.Depth <= 4) //4级内普通菜单只检查当前权限
                    {
                        break;
                    }
                    menuItem = menuItem.Parent;//4级以上菜单或内部页面循环检查上级菜单权限
                }
            }

            if (allow == false)
            {
                WebAgent.AlertAndBack("对不起，你没有访问该页面的权限。");
            }
        }

    }

    public string Path = "";

    protected override void OnPreRender(EventArgs e)
    {
        string menuFile = "~/App_Data/menus.xml";
        DropMenu menu = DropMenu.GetMenuData(menuFile);
        DropMenuItem root = menu.RootItem;
        DropMenuItem dmi;
        if (Path == "")
            dmi = (new DropMenu()).GetItemByPath(Request.FilePath, root);
        else
            dmi = (new DropMenu()).GetItemByPath(Request.FilePath.Replace(Path, ""), root);
        string pos;

        if (dmi != null)
        {
            if (dmi.Parent == null)
            {
                pos = dmi.Name;
            }
            else
            {
                if (dmi.Parent.Parent == null)
                {
                    pos = string.Format("{0}&gt; {1}", dmi.Parent.Name, dmi.Name);
                }
                else
                {
                    if (dmi.Parent.Parent.Parent == null)
                    {
                        pos = string.Format("{0} &gt; {1}", dmi.Parent.Name, dmi.Name);
                    }
                    else
                    {
                        pos = string.Format("{0} &gt; {1} &gt; {2}", dmi.Parent.Parent.Name, dmi.Parent.Name, dmi.Name);
                    }

                }
            }

            this.compPos.Text = pos;
        }
    }
}
