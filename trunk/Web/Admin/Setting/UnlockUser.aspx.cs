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

public partial class Setting_UnlockUser : AdminBase
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
        if (new UserAgent().UnlockUser(int.Parse(QS("id"))) > 0)
        {
            EventLog log = new EventLog();
            log.EvenDesc = "解冻用户帐号" + u.UserAcc + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            WebAgent.SuccAndGo("解冻用户成功", "LockedUserList.aspx");
        }
        else
            WebAgent.AlertAndBack("解冻用户失败");
    }
}
