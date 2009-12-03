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

public partial class ArticleCategoryList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ods1_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
     
    }

    public string GetUrl(int type)
    {
        string url = "";
        if ( type == 1 )
        {
            url= "ArticleCategoryHandle.aspx";
        }
        if ( type == 3 )
        {
            url= "SingerArticleEdit.aspx";
        }
        return url;
    }
}
