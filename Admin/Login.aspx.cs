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
using Studio.Web;
using AnyWeb.AnyWeb_DL;
using Studio.Security;

public partial class Login : System.Web.UI.Page
{
    protected string valcode = "1234";
    protected void Page_Load(object sender, EventArgs e)
    {
        valcode = (new Random()).Next(1000, 9999).ToString();
        imgVal.ImageUrl = "/imageval.aspx?id=" + valcode;
        imgVal.ImageAlign = ImageAlign.AbsBottom;
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string valcode1 = Request.Params["valcode"] + "";
        string val1 = txtCode.Text;

        if (valcode1 != "")
        {
            if (val1 == "")
                return;
            if (Studio.Security.Secure.Md5(valcode1).Replace("-", "").Replace("A", "").Replace("B", "").Replace("C", "").Replace("D", "").Replace("E", "").Replace("F", "").Substring(0, 4) != val1)
            {
                WebAgent.AlertAndBack("验证码错误!");
            }
        }

        int UserID = new SiteAgent().Login(txtName.Text, Secure.Md5(txtPass.Text));

        if (UserID > 0)
        {
            HttpCookie co = new HttpCookie("USERINFO");
            co["UserID"] = UserID.ToString();
            co["UserAcc"] = txtName.Text;
            Response.SetCookie(co);

            EventLog log = new EventLog();
            log.EvenDesc = "管理员帐号" + txtName.Text + "登录成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = txtName.Text;
            new EventLogAgent().AddLog(log);

            Response.Redirect("/Default.aspx");
        }

        switch (UserID)
        {
            case 0: //用户不存在
                WebAgent.FailAndGo("用户不存在", "/login.aspx");
                break;
            case -1: //密码错误
                WebAgent.FailAndGo("密码错误", "/login.aspx");
                break;
            case -2: //锁定
                WebAgent.FailAndGo("用户已被锁定", "/login.aspx");
                break;
            default: //登录失败
                WebAgent.FailAndGo("登陆失败", "/login.aspx");
                break;
        }
    }
}
