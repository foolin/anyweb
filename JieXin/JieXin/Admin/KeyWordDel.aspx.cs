using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_KeyWordDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        if (Request.UrlReferrer == null)
            return;

        AW_KeyWord_bean bean = AW_KeyWord_bean.funcGetByID(int.Parse(QS("id")));

        if (bean == null)
            WebAgent.AlertAndBack("关键词不存在");

        new AW_KeyWord_dao().funcDelete(bean.fdKeyWID);

        this.AddLog(EventType.Delete, "删除关键词", "删除关键词[" + bean.fdKeyWName + "]");
        Studio.Web.WebAgent.SuccAndGo("删除成功", Request.UrlReferrer == null ? "KeyWordList.aspx" : Request.UrlReferrer.AbsoluteUri);
    }
}