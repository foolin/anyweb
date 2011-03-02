﻿using System;
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
using Studio.Security;
using AnyWell.AW_DL;
using AnyWell.Configs;

public partial class Admin_PasswordEdit : PageAdmin
{
    protected void btnOk_Click(object sender, EventArgs e)
    {
        AW_Admin_bean admin = (new AW_Admin_dao()).funcGetAdminFromCookie();
        if (Secure.Md5(txtOld.Text) != admin.fdAdmiPwd)
        {
            WebAgent.AlertAndBack("旧密码输入错误");
        }
        else
        {
            admin.fdAdmiPwd = Secure.Md5(txtNew.Text);
            (new AW_Admin_dao()).funcUpdate(admin);
            this.AddLog(EventType.Update, "修改密码", "管理员" + admin.fdAdmiAccount + "修改登录密码");
            WebAgent.SuccAndGo("修改密码成功", "PasswordEdit.aspx");
        }
    }
}