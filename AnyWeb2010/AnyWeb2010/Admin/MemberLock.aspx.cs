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

public partial class Admin_MemberLock : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string id = QS("id"),status = QS("status");
        string url = Request.UrlReferrer == null ? "MemberList.aspx" : Request.UrlReferrer.AbsoluteUri;
        if (String.IsNullOrEmpty(id) || !WebAgent.IsInt32(id) || String.IsNullOrEmpty(status) || !WebAgent.IsInt32(status) )
        {
            Response.Redirect(url);
        }

        int record = new AW_Member_dao().funcLock(int.Parse(id), int.Parse(status));
        if (record > 0)
        {
            Studio.Web.WebAgent.SuccAndGo("设置成功", url);
        }

    }
}
