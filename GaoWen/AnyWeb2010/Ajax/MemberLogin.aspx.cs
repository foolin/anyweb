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

public partial class Ajax_MemberLogin : ShopAjaxBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string email = QS("email");
        string mobile = QS("mobile");
        string type = QS("type");
        string account = type == "1" ? mobile : email;
        string pwd = QS("pwd");



        if (type == "1")
        {
            if (mobile == "")
                ExecuteFalse(2, "请输入手机号码！");
            else if (Regex.IsMatch(mobile, @"\d{11}") == false)
                ExecuteFalse(2, "手机号码必须是11位数字！");
        }
        else if (type == "2")
        {
            if (email == "")
                ExecuteFalse(2, "登陆邮箱不能为空！");
            else if (!Studio.Web.WebAgent.IsEmail(email))
                ExecuteFalse(3, "登陆邮箱格式不正确！");
        }
        else
        {
            ExecuteFalse(2, "参数错误！");
        }

        AW_Member_bean member = new AW_Member_dao().funcLogin(int.Parse(type), account, pwd);
        if (member == null)
        {
            ExecuteFalse(2, "用户名或密码错误");
        }
        else if (member.fdMembStatus != 1)
        {
            ExecuteFalse(3, "用户被锁定请联系管理员");
        }
        else
        {
            ExecuteSucc("登陆成功");
        }
    }
}
