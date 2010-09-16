using System;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Studio.Web;
using AnyWell.AW_DL;
using AnyWell.Configs;
using AnyWell.AW;

public partial class Admin_AdminDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
            Response.Redirect("adminlist.aspx");

        AW_Admin_bean admin = (new AW_Admin_dao()).funcGetAdminInfo(int.Parse(QS("id")));
        if (admin == null)
            Response.Redirect("adminlist.aspx");

        if (admin.fdAdmiAccount == "SuperAdmin")
            WebAgent.AlertAndBack("SuperAdmin帐号不可删除");

        (new AW_Admin_dao()).funcDelete(admin.fdAdmiID);
        Response.Redirect("adminlist.aspx");
    }
}
