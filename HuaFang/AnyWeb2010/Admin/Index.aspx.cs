using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Index : System.Web.UI.Page
{
    protected AW_Admin_bean _adminInfo;
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        _adminInfo = (new AW_Admin_dao()).funcGetAdminFromCookie();
        if (_adminInfo == null)
            Response.Redirect("~/Admin/Login.aspx");
    }
}
