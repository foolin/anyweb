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

public partial class Ajax_MemberRegister : ShopAjaxBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string validate = QF("validate");
        if (validate.ToUpper() != Request.Cookies["CheckCode"].Value)
            ExecuteFalse(1, "验证码错误！");

        string email = QF("email");
        string mobile = QF("mobile");
        string type = QF("type");
        string account = type == "1" ? mobile : email;

        if (AnyWeb.AW.Configs.GeneralConfigs.GetConfig().RegEnable == false)
            ExecuteFalse(5, "商城注册暂时已关闭！");

        if (type == "1")
        {
            if (mobile == "")
                ExecuteFalse(2, "请输入手机号码！");
            else if (Regex.IsMatch(mobile, @"\d{11}") == false)
                ExecuteFalse(2, "手机号码必须是11位数字！");
            else if (new AW_Member_dao().funcMobileExists(mobile))
                ExecuteFalse(4, "手机号码已被注册！");
        }
        else if (type == "2")
        {
            if (email == "")
                ExecuteFalse(2, "登陆邮箱不能为空！");
            else if (!Studio.Web.WebAgent.IsEmail(email))
                ExecuteFalse(3, "登陆邮箱格式不正确！");
            else if (new AW_Member_dao().funcEmailExists(email))
                ExecuteFalse(4, "登陆邮箱已被注册！");
        }
        else
        {
            ExecuteFalse(2, "参数错误！");
        }

        using (AW_Member_dao dao = new AW_Member_dao())
        {
            AW_Member_bean member = new AW_Member_bean();
            member.fdMembID = dao.funcNewID();
            if (type == "1")
            {
                member.fdMembEmail = mobile + "@" + Request.Url.Host;//默认以手机加上域名为邮箱地址
                member.fdMembName = mobile;
                member.fdMembMobile = mobile;
                while (dao.funcEmailExists(member.fdMembEmail))
                {
                    member.fdMembEmail = "temp" + (new Random()).Next(100000, 999999).ToString() + "@" + Request.Url.Host;
                }
            }
            else
            {
                member.fdMembEmail = email;
                member.fdMembName = email.Substring(0, email.IndexOf("@")); 
            }
            member.fdMembPwd = Studio.Security.Secure.Md5(QF("pwd"));
            member.fdMembStatus = 1;//设置状态
            int record = dao.funcInsert(member);
            if (record > 0 && dao.funcLogin(int.Parse(type), account, QF("pwd")) != null)
                ExecuteSucc("注册成功！");
            else
                ExecuteFalse(6, "注册失败！");
        }

    }
}
