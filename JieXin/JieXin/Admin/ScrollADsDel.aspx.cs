using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_ScrollADsDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        string ids = QF("ids");
        string url = Request.UrlReferrer == null ? "CompanyADList.aspx" : Request.UrlReferrer.AbsoluteUri;
        if (String.IsNullOrEmpty(ids))
        {
            Response.Redirect(url);
        }

        int record = new AW_AD_dao().funcDeletes(ids);
        if (record > 0)
        {
            WebAgent.SuccAndGo("删除成功", url);
        }
    }
}
