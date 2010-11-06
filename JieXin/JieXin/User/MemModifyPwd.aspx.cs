using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.Configs;
using Studio.Web;
using AnyWell.AW_DL;
using Studio.Security;

public partial class User_Default : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            using (AW_User_dao dao = new AW_User_dao())
            {
                AW_User_bean bean = (new AW_User_dao()).funcGetUserFromCookie();
                if (Secure.Md5(txtOldPwd.Text.Trim()) == bean.fdUserPwd)
                    bean.fdUserPwd = Secure.Md5(txtNewPwd1.Text.Trim());
                dao.funcUpdate(bean);
                dao.funcLogin(bean.fdUserAccount.Trim(), txtNewPwd1.Text.Trim(), false);
                Response.Redirect("/User/Index.aspx");
            }
        }
    }
}
