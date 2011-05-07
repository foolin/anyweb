using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.IO;
using System.Collections;

public class DropMenu
{
    int count = 0;

    DropMenuItem _RootItem;
    public DropMenuItem RootItem
    {
        get
        {
            return _RootItem;
        }
    }

    public static DropMenu GetMenuData( string menuFile )
    {
        DropMenu menu = ( DropMenu ) HttpRuntime.Cache[ "DROPMENU_" + menuFile ];
        if( menu != null )
        {
            return menu;
        }

        string fileName = HttpContext.Current.Server.MapPath( menuFile );
        if( !File.Exists( fileName ) )
        {
            return null;
        }

        menu = new DropMenu();
        menu.Retrieve( fileName );
        HttpRuntime.Cache.Insert( "DROPMENU_" + menuFile, menu, new System.Web.Caching.CacheDependency( fileName ) );
        return menu;
    }

    public void Retrieve( string siteMapFile )
    {
        XmlDocument xml = new XmlDocument();
        xml.Load( siteMapFile );
        _RootItem = new DropMenuItem();
        _RootItem.ID = 0;
        _RootItem.Children = new ArrayList();
        _RootItem.Parent = null;
        _RootItem.Name = "根菜单";
        GetChildren( _RootItem, xml.DocumentElement.ChildNodes[ 0 ].ChildNodes, 2 );
    }

    public DropMenuItem GetItemByID( int id, DropMenuItem parent )
    {
        foreach( DropMenuItem child in parent.Children )
        {
            if( child.ID == id )
            {
                return child;
            }
            DropMenuItem item = GetItemByID( id, child );
            if( item != null )
            {
                return item;
            }
        }
        return null;
    }

    /// <summary>
    /// 获取当前路径接点
    /// </summary>
    /// <param name="filepath">当前路径</param>
    /// <returns></returns>
    public DropMenuItem GetItemByPath( string path, DropMenuItem dmi )
    {
        if( dmi == null )
        {
            DropMenu dm = GetMenuData( "~/AppData/SysMenu.xml" );
            dmi = dm.RootItem;
        }

        for( int i = 0; i < dmi.Children.Count; i++ )
        {
            if( ( ( DropMenuItem ) dmi.Children[ i ] ).Url.ToLower() != path.ToLower() )
            {
                count++;

                GetItemByPath( path, ( DropMenuItem ) dmi.Children[ i ] );
            }
            else
            {
                _RootItem = ( DropMenuItem ) dmi.Children[ i ];
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
    void GetChildren( DropMenuItem item, XmlNodeList nodes, int depth )
    {
        foreach( XmlNode node in nodes )
        {
            string url = "";
            string target = "";
            string name = "";

            DropMenuItem mi = new DropMenuItem();
            mi.ID = int.Parse( node.Attributes[ "id" ].Value );
            if( node.Attributes[ "url" ] != null )
                url = node.Attributes[ "url" ].Value;
            if( node.Attributes[ "target" ] != null )
                target = node.Attributes[ "target" ].Value;
            if( node.Attributes[ "name" ] != null )
                name = node.Attributes[ "name" ].Value;

            mi.Url = url;
            mi.Target = target;
            mi.Name = name;
            mi.Children = new ArrayList();
            mi.Parent = item;
            if( node.HasChildNodes )
            {
                GetChildren( mi, node.ChildNodes, depth + 1 );
            }
            item.Children.Add( mi );
        }
    }
}
