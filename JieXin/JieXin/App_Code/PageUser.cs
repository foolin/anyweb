using System;
using System.Collections.Generic;
using System.Web;
using AnyWell.AW_DL;

/// <summary>
///PageUser 的摘要说明
/// </summary>
public class PageUser : PageBase
{
    public PageUser()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    private AW_User_bean _loginUser;
    /// <summary>
    /// 个人用户
    /// </summary>
    public AW_User_bean LoginUser
    {
        get { return _loginUser; }
        set { _loginUser = value; }
    }

    protected override void OnPreInit(EventArgs e)
    {
        this._loginUser = new AW_User_bean();
        if (this.Session["USERID"] == null)
        {
            this.Session["USERID"] = "10000";
            this.Session["USERNAME"] = "gudieaofei";
            this._loginUser.fdUserID = 10000;
            this._loginUser.fdUserAccount = "gudieaofei";
        }
        else
        {
            this._loginUser.fdUserID = int.Parse(this.Session["USERID"].ToString());
            this._loginUser.fdUserAccount = this.Session["USERNAME"].ToString();
        }
    }
}
