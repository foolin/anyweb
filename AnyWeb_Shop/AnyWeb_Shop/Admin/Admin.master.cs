using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Common.Common;
using AnyP.BizBlog.Admin;

public partial class Admin_Admin : System.Web.UI.MasterPage
{
    int itemID = 0;
    protected int SelectedID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected Shop ShopInfo
    {
        get
        {
            return (Shop)Context.Items["SHOP_INFO"];

           
        }
    }
    protected ArrayList GetChildrenMenu(string path)
    {
        ArrayList lstChilds = AnyP.BizBlog.Admin.XMenu.GetCurrentItems( "~/Admin/ShopMenus.xml" , -2 , path , null );
        if ( lstChilds != null )
        {
            foreach ( XMenuItem mi in lstChilds )
            {
                mi.ID = ++itemID;
                if ( mi.FileName == Request.Path.ToLower() )
                {
                    mi.Selected = true;
                    SelectedID = mi.ID;
                }
                else
                {
                    foreach ( XMenuItem cmi in mi.Children )
                    {
                        if ( cmi.FileName == Request.Path.ToLower() )
                        {
                            mi.Selected = true;
                            SelectedID = mi.ID;
                            break;
                        }
                    }
                }
            }
        }
        return lstChilds;
    }    

    protected void rep3_ItemDataBound(object sender , RepeaterItemEventArgs e)
    {
        if ( e.Item.ItemIndex >= 0 )
        {
            XMenuItem mi = (XMenuItem)e.Item.DataItem;
            Repeater rep4 = (Repeater)e.Item.FindControl( "rep4" );
            rep4.DataSource = GetChildrenMenu( mi.FileName );
            rep4.DataBind();
        }
    }


    protected void txtBack_Click(object sender , EventArgs e)
    {
        if ( Request.Cookies["COMID"] == null )
        {
            HttpCookie co = new HttpCookie( "COMID" );
            co.Value = ShopInfo.ComID.ToString();
            Response.SetCookie( co );
        }
        else
        {
            Response.Redirect( "/Admin/Default.Aspx" );
        }
    }
}
