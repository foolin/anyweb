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

public partial class SetNavUrl : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
        string url = "";
        if ( QS( "mode" ) !="" )
        { 
            switch(QS("mode"))
            {
                case "default":
                    url = "/Admin/default";
                    break;
                case "order":
                    url = "/Admin/OrderList.aspx";
                    break;
                case "user":
                    url = "/Admin/User/UserList.aspx";
                    break;
                case "goods":
                    url = "/Admin/GoodsCategoryList.aspx";
                    break;
                case "article":
                    url = "/Admin/ArticleList.aspx";
                    break;
                case "region":
                    url = "/Admin/ShopSetting/SetDefault.aspx";
                    break;
                case "system":
                    url = "/Admin/BasicInfoManage.aspx";
                    break;
                case "page":
                    url = "/Admin/SlideList.aspx";
                    break;

            }
            Response.Redirect( url );
        }
    }
}
