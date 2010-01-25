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

public partial class Ajax_MemberPwdFind : ShopAjaxBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string email = this.QF("email"), question = this.QF("question"), answer = this.QF("answer");

        if (String.IsNullOrEmpty(email))
        {
            ExecuteFalse(1, "请输入登录邮箱！");
        }

        AW_Member_dao dao = new AW_Member_dao();
        bool exist = dao.funcEmailExists(email);
        if (exist == false)
        {
            ExecuteFalse(2, "登陆邮箱不存在！");
        }
        AW_Member_bean member = dao.funcGetMember(email, question, answer);
        if (member == null)
        {
            ExecuteFalse(3, "提示问题或答案不正确！");
        }

        int password = new Random().Next(100000, 99999999);
        int record = dao.funcChangePwd(member.fdMembID, FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToString(), "MD5"));
        if (record == 0)
        {
            ExecuteFalse(4, "找回密码失败！");
        }
        bool isSend = AnyWeb.AW.Configs.SmtpAgent.GetAgent().SendMail(email, "找回密码", "你的密码为：" + password, false, null);
        if (isSend == false)
        {
            ExecuteFalse(5, "由于网络等原因发送密码到邮件时失败，请重试!");
        }
        ExecuteSucc("密码已经发送到邮箱 "+email+" ，请注意查收。");
    }
}