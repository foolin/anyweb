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

public partial class Admin_Content_NoticeEdit : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected override void OnPreRender(EventArgs e)
    {
        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
            WebAgent.AlertAndBack("参数错误");
        Notice notice = new NoticeAgent().GetNoticeInfo(int.Parse(QS("id")));
        if (notice == null)
            WebAgent.AlertAndBack("流动通知不存在");
        txtTitle.Text = notice.Title;
        txtOrder.Text = notice.NotiOrder.ToString();
    }

    protected void btnAddNotice_Click(object sender, EventArgs e)
    {
        Notice notice = new NoticeAgent().GetNoticeInfo(int.Parse(QS("id")));
        notice.NotiOrder = int.Parse(txtOrder.Text);
        if (new NoticeAgent().UpdateNotice(notice) > 0)
        {
            EventLog log = new EventLog();
            log.EvenDesc = "修改流动通知" + notice.Title + "成功.";
            log.EvenAt = DateTime.Now;
            log.EvenIP = HttpContext.Current.Request.UserHostAddress;
            log.EvenUserAcc = this.LoginUser.UserAcc;
            new EventLogAgent().AddLog(log);
            if (ViewState["BACK"].ToString() == "/Admin/Default.aspx")
                WebAgent.SuccAndGo("修改流动通知成功", "NoticeList.aspx");
            else
                WebAgent.SuccAndGo("修改流动通知成功", ViewState["BACK"].ToString());
        }
        else
            WebAgent.AlertAndBack("修改流动通知失败");
    }
}

