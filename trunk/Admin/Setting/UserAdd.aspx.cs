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
using Studio.Web;
using Studio.Security;

public partial class Setting_UserAdd : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        UserAgent agent = new UserAgent();
        if (!agent.CheckUserAcc(this.txtUserAcc.Text))
            WebAgent.AlertAndBack("用户帐号已存在");
        User u = new User();
        u.UserAcc = this.txtUserAcc.Text;
        u.UserName = this.txtUserName.Text;
        u.UserIsAdmin = false;
        u.UserPermission = "";
        u.UserStatus = 0;
        u.UserPass = Secure.Md5(this.txtUserPwd.Text);
        u.UserCreateAt = DateTime.Now;
        if (agent.AddUser(u))
        {
            EventLog log = new EventLog();
            log.EvenDesc = "添加用户帐号" + u.UserAcc + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            WebAgent.SuccAndGo("添加用户成功", "UserList.aspx");
        }
        else
            WebAgent.AlertAndBack("添加用户失败");
    }
}
