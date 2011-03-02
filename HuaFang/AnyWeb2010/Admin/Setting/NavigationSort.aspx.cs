using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_NavigationSort : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        string type = QS("type");
        int naviId = int.Parse(QS("id"));

        AW_Navigation_bean bean = AW_Navigation_bean.funcGetByID(naviId);
        if (bean == null)
        {
            WebAgent.AlertAndBack("导航栏不存在！");
        }
        AW_Navigation_dao dao = new AW_Navigation_dao();

        if (type == "up")
        {
            if (!dao.funcUp(bean.fdNaviID))
                WebAgent.AlertAndBack("已经是最前了");
        }
        else if (type == "down")
        {
            if (!dao.funcDown(bean.fdNaviID))
                WebAgent.AlertAndBack("已经是最后了");
        }
        this.AddLog(EventType.Update, "修改导航栏排序", "修改导航栏[" + bean.fdNaviTitle + "]排序");
        Response.Redirect(Request.UrlReferrer == null ? "NavigationList.aspx" : Request.UrlReferrer.AbsoluteUri);
    }
}
