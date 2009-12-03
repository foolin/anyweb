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

public partial class ContactUs :AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {

    }
    protected void ods3_Selecting(object sender , ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["shopid"] = ShopInfo.ID;
    }
    protected void ods3_Updated(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( Common.Common.EventID.Update , "修改联系我们" , "修改联系我们" );

            WebAgent.SuccAndGo( "保存成功." , "ContactUs.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "保存失败." , "ContactUs.aspx" );
        }
    }
}
