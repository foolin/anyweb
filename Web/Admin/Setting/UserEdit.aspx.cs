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

public partial class Setting_UserEdit : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
            WebAgent.AlertAndBack("参数错误");
        User u = new UserAgent().GetUserInfo(int.Parse(QS("id")));
        if (u == null)
            WebAgent.AlertAndBack("用户不存在");
        txtUserAcc.Text = u.UserAcc;
        txtUserName.Text = u.UserName;
        if(!this.LoginUser.UserIsAdmin)
            lit.Text = "<script type=\"text/jscript\">isAdmin();</script>"; 
    }

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        User u = new UserAgent().GetUserInfo(int.Parse(QS("id")));
        if (this.LoginUser.UserIsAdmin)
        {
            if (!string.IsNullOrEmpty(txtUserPwd.Text) || !string.IsNullOrEmpty(txtUserPwd2.Text))
            {
                if (txtUserPwd.Text != txtUserPwd2.Text)
                    WebAgent.AlertAndBack("两次输入的密码不相同");
                else
                    u.UserPass = Secure.Md5(txtUserPwd.Text).Substring(0, 20);
            }
        }
        u.UserName = txtUserName.Text;
        u.UserIsAdmin = false;
        if (new UserAgent().UpdateUserInfo(u) > 0)
        {
            EventLog log = new EventLog();
            log.EvenDesc = "修改用户帐号" + u.UserAcc + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            if(this.LoginUser.UserID == u.UserID && (this.LoginUser.UserIsAdmin != u.UserIsAdmin) )
                WebAgent.SuccAndGo("你已经修改了自己的权限，请重新登录...", "../Logout.aspx");
            else
                WebAgent.SuccAndGo("修改用户成功", "UserList.aspx");
                
        }
        else
            WebAgent.AlertAndBack("修改用户失败");
    }
}
