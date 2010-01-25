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

using AnyWeb.AW_DL;
using System.Text.RegularExpressions;

public partial class Ajax_MemberAccountExists : ShopAjaxBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string account = QF("account").Trim();
        if (account == "")
        {
            this.ExecuteFalse(1, "格式错误");
        }
        else if(Studio.Web.WebAgent.IsEmail(account))
        {
            if ((new AW_Member_dao()).funcEmailExists(account))
                this.ExecuteFalse(1, "该邮箱已被注册");
        }
        else if (Regex.IsMatch(account, @"\d{11}"))
        {
            if ((new AW_Member_dao()).funcMobileExists(account))
                this.ExecuteFalse(1, "该手机号码已被注册");
        }
        else
        {
            this.ExecuteFalse(1, "格式错误");
        }

        //临时cookie记录准备被强制注册的邮箱
        HttpCookie co = new HttpCookie("TEMP_EMAIL");
        co.Value = account;
        HttpContext.Current.Response.SetCookie(co);

        this.ExecuteSucc("");
    }
}