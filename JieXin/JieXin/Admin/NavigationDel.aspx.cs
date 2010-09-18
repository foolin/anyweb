using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_NavigationDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        string backUrl = "NavigationList.aspx";

        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
            Response.Redirect(backUrl);

        (new AW_Navigation_dao()).funcDeleteNavigation(int.Parse(QS("id")));
        WebAgent.SuccAndGo("删除成功", backUrl);
    }
}
