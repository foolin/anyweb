using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class User_ResuInit : PageUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected override void OnPreRender(EventArgs e)
    {
        AW_Resume_bean bean = new AW_Resume_bean();
        using (AW_Resume_dao dao = new AW_Resume_dao())
        {
            bean.fdResuID = dao.funcNewID();
            bean.fdResuName = "我的简历";
            bean.fdResuStatus = 1;
            bean.fdResuUserID = this.LoginUser.fdUserID;
            dao.funcInsert(bean);
        }
        Response.Redirect("/User/ResuAddTemp.aspx?id=" + bean.fdResuID);
    }
}
