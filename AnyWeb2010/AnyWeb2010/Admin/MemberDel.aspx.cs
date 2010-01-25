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

using AnyWeb.AW_DL;
using Studio.Web;

public partial class Admin_MemberDel :ShopAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        string id = QS("id");
        string url = Request.UrlReferrer == null ? "MemberList.aspx" : Request.UrlReferrer.AbsoluteUri;
        if (String.IsNullOrEmpty(id) || !WebAgent.IsInt32(id))
        {
            Response.Redirect(url);
        }

        if (id == "1000")
        {
            WebAgent.AlertAndBack("系统预设会员账号不允许删除！");
        }

        int orderCount = new AW_Order_dao().funcGetOrderCount(int.Parse(id));
        if (orderCount > 0)
        {
            WebAgent.AlertAndBack("该会员已有" + orderCount + "张订单，所以不允许删除！");
        }

        using (AW_Member_dao dao = new AW_Member_dao())
        {

            if (dao.funcDelete(id) > 0)
            {
                Studio.Web.WebAgent.SuccAndGo("删除成功", url);
            }
            else
            {
                WebAgent.AlertAndBack("会员不存在！");
            }
        }
    }
}
