using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Xml;
using System.IO;

/// <summary>
/// 菜单对象
/// </summary>

namespace AnyP.BizBlog.Admin
{
    public class XMenu
    {
        public XMenu()
        {
            _menuItems = new ArrayList();
        }

        private ArrayList _menuItems;
        /// <summary>
        /// 菜单项集合
        /// </summary>
        public ArrayList MenuItems
        {
            get { return _menuItems; }
            set { _menuItems = value; }
        }

        /// <summary>
        /// 重置菜单，取消所有选中
        /// </summary>
        public void Reset()
        {
            IEnumerator dic = this.MenuItems.GetEnumerator();
            while (dic.MoveNext())
            {
                ((XMenuItem)dic.Current).Selected = false;
            }
        }

        /// <summary>
        /// 选择某一项及所有上级

        /// </summary>
        /// <param name="mi"></param>
        public void Choose(XMenuItem mi)
        {
            mi.Selected = true;
            if (mi.Parent != null)
            {
                Choose(mi.Parent);
            }
        }

        public static XMenu GetMenuData(string menuFile)
        {
            XMenu menu = (XMenu)HttpRuntime.Cache["WEBMENU_" + menuFile];
            if (menu != null)
            {
                return menu;
            }

            string fileName = HttpContext.Current.Server.MapPath(menuFile);
            if (!File.Exists(fileName))
            {
                return null;
            }

            menu = new XMenu();
            menu.Retrieve(fileName);
            HttpRuntime.Cache.Insert("WEBMENU_" + menuFile, menu, new System.Web.Caching.CacheDependency(fileName));
            return menu;
        }


        /// <summary>
        /// 获取当前项目的菜单，读取/sitemenus.xml文件
        /// </summary>
        /// <returns></returns>
        public static XMenu GetCurrentMenu()
        {
            return GetMenuData("~/Admin/sitemenus.xml");
        }

        /// <summary>
        /// 根据当前页面路径获取同一父系分支中指定层次的菜单列表
        /// </summary>
        /// <param name="depth"></param>
        /// <returns></returns>
        public static ArrayList GetCurrentItems(int depth)
        {
            return GetCurrentItems("~/Admin/sitemenus.xml", depth);
        }

        /// <summary>
        /// 根据当前页面路径获取同一父系分支中指定层次的菜单列表
        /// </summary>
        /// <param name="depth"></param>
        /// <returns></returns>
        public static ArrayList GetCurrentItems(string menuFile, int depth)
        {
            XMenu menu = GetMenuData(menuFile);
            if (menu != null)
            {
                return menu.GetMenuItems(depth, HttpContext.Current.Request.FilePath);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据当前页面路径按权限获取同一父系分支中指定层次的菜单列表
        /// </summary>
        /// <param name="depth"></param>
        /// <returns></returns>
        public static ArrayList GetCurrentItems(int depth, ArrayList permissions)
        {
            return GetCurrentItems("~/Admin/sitemenus.xml", depth, permissions);
        }

        /// <summary>
        /// 根据当前页面路径按权限获取同一父系分支中指定层次的菜单列表
        /// </summary>
        /// <param name="depth"></param>
        /// <returns></returns>
        public static ArrayList GetCurrentItems(string menuFile, int depth,ArrayList permissions)
        {
            XMenu menu = GetMenuData(menuFile);
            if (menu != null)
            {
                return menu.GetMenuItems(depth, HttpContext.Current.Request.FilePath,permissions);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据指定页面路径按权限获取同一父系分支中指定层次的菜单列表
        /// </summary>
        /// <param name="depth"></param>
        /// <returns></returns>
        public static ArrayList GetCurrentItems(int depth, string path, ArrayList permissions)
        {
            return GetCurrentItems("~/Admin/sitemenus.xml", depth, path, permissions);
        }

        /// <summary>
        /// 根据指定页面路径按权限获取同一父系分支中指定层次的菜单列表
        /// </summary>
        /// <param name="depth"></param>
        /// <returns></returns>
        public static ArrayList GetCurrentItems(string menuFile, int depth, string path, ArrayList permissions)
        {
            XMenu menu = GetMenuData(menuFile);
            if (menu != null)
            {
                return menu.GetMenuItems(depth, path, permissions);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 读取web.sitemap数据
        /// </summary>
        /// <param name="siteMapFile"></param>
        public void Retrieve(string siteMapFile)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(siteMapFile);
            XMenuItem root = new XMenuItem();
            root.Depth = 1;
            root.Children = new ArrayList();
            root.Parent = null;
            root.Module = 0;
            root.Function = 1;
            root.Name = "根菜单";
            GetChildren(root, xml.DocumentElement.ChildNodes, 2);
        }

        /// <summary>
        /// 递归读取下级菜单
        /// </summary>
        /// <param name="item">当前菜单项</param>
        /// <param name="nodes">下级数据</param>
        /// <param name="depth">当前层次</param>
        void GetChildren(XMenuItem item, XmlNodeList nodes, int depth)
        {
            foreach (XmlNode node in nodes)
            {
                string url = "";
                string name = "";
                string desc = "";
                int module = -1;
                int function = -1;
                bool visible = true;
                int sort = 1;
                int type = 0;
                string icon = "";

                XMenuItem mi = new XMenuItem();
                if (node.Attributes["url"] != null)
                    url = node.Attributes["url"].Value;
                if (node.Attributes["name"] != null)
                    name = node.Attributes["name"].Value;
                if (node.Attributes["description"] != null)
                    desc = node.Attributes["description"].Value;

                if (node.Attributes["module"] != null)
                    module = int.Parse(node.Attributes["module"].Value);
                else
                    module = item.Module;

                if (node.Attributes["function"] != null)
                    function = int.Parse(node.Attributes["function"].Value);
                else
                    function = item.Function;

                if (node.Attributes["visible"] != null)
                    visible = node.Attributes["visible"].Value == "1";
                if (node.Attributes["sort"] != null)
                    sort = int.Parse(node.Attributes["sort"].Value);
                if (node.Attributes["type"] != null)
                    type = int.Parse(node.Attributes["type"].Value);
                if (node.Attributes["icon"] != null)
                    icon = node.Attributes["icon"].Value;

                mi.Url = url;
                mi.Name = name;
                mi.Description = desc;
                mi.Module = module;
                mi.Function = function;
                mi.Visible = visible;
                mi.Sort = sort;
                mi.Type = type;
                mi.Icon = icon;
                mi.Depth = depth;
                mi.Children = new ArrayList();
                mi.Parent = item;

                this.MenuItems.Add(mi);
                if (node.HasChildNodes)
                {
                    GetChildren(mi, node.ChildNodes, depth + 1);
                }
                item.Children.Add(mi);
            }
        }
        public ArrayList GetMenuItems(int depth, string path)
        {
            return this.GetMenuItems(depth, path, null);
        }
        /// <summary>
        /// 获取某一个菜单同一父系分支中指定层次的菜单列表
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public ArrayList GetMenuItems(int depth, string path, ArrayList permissions)
        {
            ArrayList items = new ArrayList();
            XMenuItem mi = this.GetItemByPath(path);
            if (mi == null)
            {
                return null;
            }

            //重新设定选择项

            Reset();
            Choose(mi);

            switch (depth)
            {
                case -2://当前下级(第一个匹配的页面)
                    {
                        items = mi.Children;
                        break;
                    }
                case -1://当前下级(最终页面)
                    {
                        if (mi.Type != 0)
                        {
                            mi = this.GetItemByPath(path, true);
                        }
                        items = mi.Children;
                        break;
                    }
                case 0://返回同级 
                    {
                        if (mi.Type != 0)
                        {
                            mi = this.GetItemByPath(path, true);
                        }
                        items = mi.Parent.Children;
                        break;
                    }
                default://返回指定级别的Parent的同级

                    {
                        if (mi.Type != 0)
                        {
                            mi = this.GetItemByPath(path, true);
                        }
                        XMenuItem parent = GetParentByDepth(depth, mi);
                        items = parent.Children;
                        break;
                    }
            }

            ArrayList allowedItems = new ArrayList();
            foreach (XMenuItem mit in items)
            {
                if (mit.Visible == true && (permissions == null || permissions.Contains(mit.Permission)))
                    allowedItems.Add(mit);
            }
            return allowedItems;
        }

        bool HasVisibleChild(XMenuItem mi)
        {
            foreach (XMenuItem cmi in mi.Children)
            {
                if (cmi.Visible == true)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 根据页面路径获得菜单项
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public XMenuItem GetItemByPath(string path)
        {
            return GetItemByPath(path, false);
        }

        /// <summary>
        /// 根据页面路径获得菜单项

        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public XMenuItem GetItemByPath(string path, bool final)
        {
            string fileName = path.ToLower();

            IEnumerator dic = this.MenuItems.GetEnumerator();
            while (dic.MoveNext())
            {
                if (((XMenuItem)dic.Current).FileName == fileName && ((XMenuItem)dic.Current).Type != 2 && (((XMenuItem)dic.Current).Type == 0 || final == false))
                {
                    return (XMenuItem)dic.Current;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取某一菜单项指定层级的父级
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="mi"></param>
        /// <returns></returns>
        XMenuItem GetParentByDepth(int depth, XMenuItem mi)
        {
            if (mi.Parent == null || mi.Depth <= depth)
            {
                return mi;
            }

            if (mi.Parent.Depth == depth)
            {
                return mi.Parent;
            }
            else
            {
                return GetParentByDepth(depth, mi.Parent);
            }
        }
    }

    public enum XFunction : int
    {
        view = 1,
        modify = 2
    }

    public enum XModule : int 
    {
        common = 0,         //公共
        content =1,         //内容管理
        site = 2,           //网站设计
        seo = 3,            //SEO优化
        setting = 4,        //网站设置
        manage = 5,         //系统管理
        product = 6,        //商城子系统

        food = 7,            //餐饮子系统

        personalBlog = 8    //个人博客
    }
}
