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
using Studio.Web;
using Admin.Framework;
using Common.Common;

public partial class ShopArticleEdit : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {

    }
    protected void ods3_Selecting(object sender , ObjectDataSourceSelectingEventArgs e)
    {
        if(WebAgent.IsInt32(QS("aid")))
        {
            e.InputParameters["id"] = int.Parse( QS( "aid" ) );
            
        }
    }
    protected void ods3_Updated(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Update , "修改商城文章" , "修改商城文章,文章编号：" + QS( "aid" ) );

            WebAgent.SuccAndGo( "修改成功." , "ShopArticleList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "修改失败." , "ShopArticleList.aspx" );
        }
    }
}
