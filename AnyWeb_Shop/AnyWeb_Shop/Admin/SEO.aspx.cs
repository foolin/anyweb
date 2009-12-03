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
using Admin.Framework;
using Studio.Web;
using Common.Common;

public partial class SEO :AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {

    }
    protected void ods1_Selecting(object sender , ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["shopid"] = ShopInfo.ID;
    }
    protected void ods1_Updated(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Update , "编辑SEO管理" , "编辑SEO管理" );

            if ( HttpContext.Current.Cache["SHOP_" + ShopInfo.ID] != null )
            {
                HttpContext.Current.Cache.Remove("SHOP_" + ShopInfo.ID);
            }

            WebAgent.SuccAndGo( "修改成功." ,Request.RawUrl);
        }
    }
}
