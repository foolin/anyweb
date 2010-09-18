using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_NavigationList : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        compRep.DataSource = new AW_Navigation_dao().funcGetNavigations();
        compRep.DataBind();
    }

    protected string getTypeName(int type)
    {
        switch (type)
        {
            case 1: return "文章栏目";
            case 2: return "最新招聘";
            case 3: return "自定义链接";
            default: return "文章栏目";
        }
    }
}
