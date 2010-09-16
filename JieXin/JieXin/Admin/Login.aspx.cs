using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Shop_Admin_Login : System.Web.UI.Page
{
    protected void submit_Click(object sender, EventArgs e)
    {
        using (AW_Admin_dao dao = new AW_Admin_dao())
        {
            if (dao.funcLogin(txtUserName.Text, txtPassword.Text))
                Response.Redirect("index.aspx");
            else
                WebAgent.AlertAndBack("帐号或密码错误");
        }

    }
}
