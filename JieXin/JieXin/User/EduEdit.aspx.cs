using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class User_EduEdit : PageUser
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (string.IsNullOrEmpty(QS("eduid")) || !WebAgent.IsInt32(QS("eduid")))
        {
            Response.Clear();
            Response.Write("");
            Response.End();
        }
        bean = AW_Education_bean.funcGetByID(int.Parse(QS("eduid")));
        if(bean==null)
        {
            Response.Clear();
            Response.Write("");
            Response.End();
        }
        AW_Resume_bean resume = AW_Resume_bean.funcGetByID(bean.fdEducResuID);
        if (resume == null)
        {
            Response.Clear();
            Response.Write("");
            Response.End();
        }
        if (resume.fdResuUserID != this.LoginUser.fdUserID)
        {
            Response.Clear();
            Response.Write("");
            Response.End();
        }
    }

    private AW_Education_bean _bean;
    public AW_Education_bean bean
    {
        get { return _bean; }
        set { _bean = value; }
    }
}
