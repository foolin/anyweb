using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_NoticeDel : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        string id = QS("id");
        string url = Request.UrlReferrer == null ? "NoticeList.aspx" : Request.UrlReferrer.AbsoluteUri;
        if (String.IsNullOrEmpty(id) || !Studio.Web.WebAgent.IsInt32(id))
        {
            WebAgent.AlertAndBack("公告编号错误！");
        }
        AW_Notice_bean bean = AW_Notice_bean.funcGetByID(int.Parse(id));
        if (bean == null)
        {
            WebAgent.AlertAndBack("公告不存在！");
        }
        int record = new AW_Notice_dao().funcDelete(id);
        if (record > 0)
        {
            this.AddLog(EventType.Delete, "删除公告", "删除公告[" + bean.fdNotiTitle + "]");
            Studio.Web.WebAgent.SuccAndGo("删除成功", url);
        }
    }
}
