using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_CompanyADDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        string id = QS("id");
        string url = Request.UrlReferrer == null ? "CompanyADList.aspx" : Request.UrlReferrer.AbsoluteUri;
        if (String.IsNullOrEmpty(id) || !Studio.Web.WebAgent.IsInt32(id))
        {
            WebAgent.AlertAndBack("企业图片编号错误！");
        }
        AW_AD_bean bean = AW_AD_bean.funcGetByID(int.Parse(id));
        if (bean == null)
        {
            WebAgent.AlertAndBack("企业图片不存在！");
        }
        int record = new AW_AD_dao().funcDelete(id);
        if (record > 0)
        {
            this.AddLog(EventType.Delete, "删除企业图片", "删除企业图片[" + bean.fdAdName + "]");
            Studio.Web.WebAgent.SuccAndGo("删除成功", url);
        }
    }
}
