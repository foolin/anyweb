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
        txtpassword.Text = u.UserPass;
        if (u.UserIsAdmin)
            drpPerss.SelectedValue = "1";
        else
            drpPerss.SelectedValue = "0";
    }

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        User u = new User();
        u.UserID = int.Parse(QS("id"));
        u.UserName = txtUserName.Text;
        if (txtUserPwd.Text != "")
            u.UserPass = Secure.Md5(txtUserPwd.Text).Substring(0,20);
        else
            u.UserPass = txtpassword.Text;
        if (drpPerss.SelectedValue == "1")
            u.UserIsAdmin = true;
        else
            u.UserIsAdmin = false;
        if (new UserAgent().UpdateUserInfo(u) > 0)
        {
            EventLog log = new EventLog();
            log.EvenDesc = "修改用户帐号" + u.UserAcc + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            WebAgent.SuccAndGo("修改用户成功", "UserList.aspx");
        }
        else
            WebAgent.AlertAndBack("修改用户失败");
    }
}
