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

public partial class Admin_HelpTypeDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        string id = QS("id");
        if (String.IsNullOrEmpty(id) || !Studio.Web.WebAgent.IsInt32(id))
        {
            Response.Redirect("HelpTypeList.aspx");
        }

        int record = new AW_Help_Type_dao().funcDelete(id);
        if (record > 0)
        {
            Studio.Web.WebAgent.SuccAndGo("删除成功", "HelpTypeList.aspx");
        }
    }
}
