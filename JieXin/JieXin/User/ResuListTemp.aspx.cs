using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class User_ResuListTemp : PageUser
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        rep.DataSource = new AW_Resume_dao().funcGetResumeList(this.LoginUser.fdUserID);
        rep.DataBind();
    }
}
