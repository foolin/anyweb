using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_NoticesDel : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        string ids = QF("ids");
        string url = Request.UrlReferrer == null ? "NoticeList.aspx" : Request.UrlReferrer.AbsoluteUri;
        if (String.IsNullOrEmpty(ids))
        {
            Response.Redirect(url);
        }

        int record = new AW_Notice_dao().funcDeletes(ids);
        if (record > 0)
        {
            Studio.Web.WebAgent.SuccAndGo("删除成功", url);
        }
    }
}
