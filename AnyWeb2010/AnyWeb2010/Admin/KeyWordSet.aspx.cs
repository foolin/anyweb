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

using Studio.Web;
using AnyWeb.AW_DL;

public partial class Admin_KeyWordSet : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = QS("id"), status = QS("status");
        if (String.IsNullOrEmpty(id) || !WebAgent.IsInt32(id) || String.IsNullOrEmpty(status) || !WebAgent.IsInt32(status))
        {
            Response.Redirect("KeyWordList.aspx");
        }

        int record = new AW_KeyWord_dao().funcKeyWordSet(int.Parse(id), int.Parse(status));
        if (record > 0)
        {
            Studio.Web.WebAgent.SuccAndGo("设置成功！", RefUrl);
        }
    }
}
