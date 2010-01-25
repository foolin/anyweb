using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using AnyWeb.AW_DL;
using Studio.Web;

public partial class Admin_CategoryList : ShopAdmin
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);


        repCategories.DataSource = (new AW_Category_dao()).funcGetCategories();
        repCategories.DataBind();
    }
}
