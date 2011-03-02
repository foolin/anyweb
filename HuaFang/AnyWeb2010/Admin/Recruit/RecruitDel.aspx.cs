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
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_RecruitDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        string id = QS("id");
        string url = Request.UrlReferrer == null ? "RecruitList.aspx" : Request.UrlReferrer.AbsoluteUri;
        if (String.IsNullOrEmpty(id) || !Studio.Web.WebAgent.IsInt32(id))
        {
            WebAgent.AlertAndBack("招聘编号错误！");
            Response.Redirect(url);
        }
        AW_Recruit_bean bean = AW_Recruit_bean.funcGetByID(int.Parse(QS("id")));
        if (bean == null)
        {
            WebAgent.AlertAndBack("招聘不存在！");
        }
        int record = new AW_Recruit_dao().funcDelete(bean.fdRecrID);
        if (record > 0)
        {
            this.AddLog(EventType.Delete, "删除招聘", "删除招聘[" + bean.fdRecrTitle + "]");
            Studio.Web.WebAgent.SuccAndGo("删除成功", url);
        }
    }
}
