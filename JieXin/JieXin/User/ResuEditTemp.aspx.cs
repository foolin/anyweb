using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class User_ResuEditTemp : PageUser
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (string.IsNullOrEmpty(QS("id")) || !WebAgent.IsInt32(QS("id")))
        {
            Response.Redirect("/User/LogOut.aspx");
        }
        AW_Resume_bean bean = AW_Resume_bean.funcGetByID(int.Parse(QS("id")));
        if (bean == null)
        {
            Response.Redirect("/User/LogOut.aspx");
        }
        if (bean.fdResuUserID != this.LoginUser.fdUserID)
        {
            Response.Redirect("/User/LogOut.aspx");
        }

        rep1.DataSource = new AW_Education_dao().funcGetList();
        rep1.DataBind();
    }
}
