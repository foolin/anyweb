using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_NavigationDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        string backUrl = "NavigationList.aspx";

        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
        {
            WebAgent.AlertAndBack("导航栏编号错误！");
        }

        AW_Navigation_bean bean = AW_Navigation_bean.funcGetByID(int.Parse(QS("id")));
        if (bean == null)
        {
            WebAgent.AlertAndBack("导航栏不存在！");
        }

        (new AW_Navigation_dao()).funcDeleteNavigation(bean.fdNaviID);
        this.AddLog(EventType.Delete, "删除导航栏", "删除导航栏[" + bean.fdNaviTitle + "]");
        WebAgent.SuccAndGo("删除成功", backUrl);
    }
}
