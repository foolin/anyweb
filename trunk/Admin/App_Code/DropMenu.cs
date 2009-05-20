using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;
using System.Collections;

/// <summary>
/// DropMenu 的摘要说明

/// </summary>
public class DropMenu
{
    int count = 0;

    public DropMenu()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    DropMenuItem _root;
    public DropMenuItem RootItem
    {
        get
        {
            return _root;
        }
    }

    public static DropMenu GetMenuData(string menuFile)
    {
        DropMenu menu = (DropMenu)HttpRuntime.Cache["DROPMENU_" + menuFile];
        if (menu != null)
        {
            return menu;
        }

        string fileName = HttpContext.Current.Server.MapPath(menuFile);
        if (!File.Exists(fileName))
        {
            return null;
        }

        menu = new DropMenu();
        menu.Retrieve(fileName);
        HttpRuntime.Cache.Insert("DROPMENU_" + menuFile, menu, new System.Web.Caching.CacheDependency(fileName));
        return menu;
    }

    public void Retrieve(string siteMapFile)
    {
        XmlDocument xml = new XmlDocument();
        xml.Load(siteMapFile);
        _root = new DropMenuItem();
        _root.Depth = 1;
        _root.Children = new ArrayList();
        _root.Parent = null;
        _root.Module = 0;
        _root.Function = 1;
        _root.Name = "根菜单";
        GetChildren(_root, xml.DocumentElement.ChildNodes[0].ChildNodes, 2);
    }

    /// <summary>
    /// 获取当前路径接点
    /// </summary>
    /// <param name="filepath">当前路径</param>
    /// <returns></returns>
    public DropMenuItem GetItemByPath(string path, DropMenuItem dmi)
    {

        if (count > 300)
        {
            return dmi;
        }

        if (dmi == null)
        {
            DropMenu dm = GetMenuData("~/App_Data/Menus.xml");
            dmi = dm.RootItem;
        }

        for (int i = 0; i < dmi.Children.Count; i++)
        {
            if (((DropMenuItem)dmi.Children[i]).Url.ToLower() != path.ToLower())
            {
                count++;

                GetItemByPath(path, (DropMenuItem)dmi.Children[i]);
            }
            else
            {
                this._root = (DropMenuItem)dmi.Children[i];
                break;
            }
        }

        return RootItem;
    }

    /// <summary>
    /// 递归读取下级菜单
    /// </summary>
    /// <param name="item">当前菜单项</param>
    /// <param name="nodes">下级数据</param>
    /// <param name="depth">当前层次</param>
    void GetChildren(DropMenuItem item, XmlNodeList nodes, int depth)
    {
        foreach (XmlNode node in nodes)
        {
            string url = "";
            string target = "";
            string name = "";
            int module = -1;
            int function = -1;
            int sort = 1;
            int type = 0;
            string icon = "";

            DropMenuItem mi = new DropMenuItem();
            if (node.Attributes["url"] != null)
                url = node.Attributes["url"].Value;
            if (node.Attributes["target"] != null)
                target = node.Attributes["target"].Value;
            if (node.Attributes["name"] != null)
                name = node.Attributes["name"].Value;
            if (node.Attributes["module"] != null)
                module = int.Parse(node.Attributes["module"].Value);
            else
                module = item.Module;

            if (node.Attributes["function"] != null)
                function = int.Parse(node.Attributes["function"].Value);
            else
                function = item.Function;

            if (node.Attributes["sort"] != null)
                sort = int.Parse(node.Attributes["sort"].Value);
            if (node.Attributes["type"] != null)
                type = int.Parse(node.Attributes["type"].Value);
            if (node.Attributes["icon"] != null)
                icon = node.Attributes["icon"].Value;

            mi.Url = url;
            mi.Target = target;
            mi.Name = name;
            mi.Module = module;
            mi.Function = function;
            mi.Sort = sort;
            mi.Type = type;
            mi.Icon = icon;
            mi.Depth = depth;
            mi.Children = new ArrayList();
            mi.Parent = item;
            if (node.HasChildNodes)
            {
                GetChildren(mi, node.ChildNodes, depth + 1);
            }
            item.Children.Add(mi);
        }
    }
}