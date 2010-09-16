using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class User_EduGet : PageUser
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (string.IsNullOrEmpty(QS("id")) || !WebAgent.IsInt32(QS("id")))
        {
            return;
        }
        AW_Resume_bean bean = AW_Resume_bean.funcGetByID(int.Parse(QS("id")));
        if (bean == null)
            return;
        if (bean.fdResuUserID != this.LoginUser.fdUserID)
            return;
        this._eduId = new AW_Education_dao().funcNewID();
    }

    private int _eduId;
    public int EduID
    {
        get { return _eduId; }
        set { _eduId = value; }
    }
}
