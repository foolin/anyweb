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

public partial class Setting_UserInfo : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        User u = this.LoginUser;
        txtUserAcc.Text = u.UserAcc;
        txtUserName.Text = u.UserName;
    }

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        User u = this.LoginUser;
        if (txtUserPwd.Text != "")
        {
            if (txtUserOldPwd.Text != "")
            {
                if (Secure.Md5(txtUserOldPwd.Text).Substring(0, 20) != u.UserPass)
                {
                    WebAgent.AlertAndBack("密码不正确，请重新输入！");
                }
                u.UserPass = Secure.Md5(txtUserPwd.Text);
            }
            else
            {
                WebAgent.AlertAndBack("请输入旧密码！");
            }
            string UserOld = Secure.Md5(txtUserOldPwd.Text).Substring(0, 20);
        }
        u.UserName = txtUserName.Text;
        if (new UserAgent().UpdateUserInfo(u) > 0)
        {
            EventLog log = new EventLog();
            log.EvenDesc = "修改个人信息" + u.UserAcc + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            WebAgent.SuccAndGo("修改个人信息成功,请注销后重新登陆加载新个人信息", "UserList.aspx");
        }
        else
            WebAgent.AlertAndBack("修改个人信息失败");
    }
}
