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
                case "goods":
                    url = "/Admin/GoodsList.aspx";
                    break;
                case "article":
                    url = "/Admin/ArticleList.aspx";
                    break;
                case "system":
                    url = "/Admin/AboutUs.aspx";
                    break;
                case "page":
                    url = "/Admin/SlideList.aspx";
                    break;

            }
            Response.Redirect( url );
        }
    }
}
