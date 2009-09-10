using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AnyWeb.AnyWeb_DL;

public partial class Ajax_CheckAcc : AjaxPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string _acc = QS("acc");
        if (_acc == "")
        {
            ExecFail("9", "参数错误");
        }
        if (new UserAgent().CheckUserAcc(_acc))
            ExecSucc("用户帐号可用");
        else
            ExecFail("5", "用户帐号已存在");
    }
}
