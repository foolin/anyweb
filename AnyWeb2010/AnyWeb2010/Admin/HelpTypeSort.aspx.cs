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

public partial class Admin_HelpTypeSort : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string type = QS("type");
        int helpTypeId = int.Parse(QS("id"));
        AW_Help_Type_dao dao = new AW_Help_Type_dao();

        if (type == "up")
        {
            if (!dao.funcUp(helpTypeId))
                WebAgent.AlertAndBack("已经是最前了");
        }
        else if (type == "down")
        {
            if (!dao.funcDown(helpTypeId))
                WebAgent.AlertAndBack("已经是最后了");
        }

        Response.Redirect(Request.UrlReferrer == null ? "HelpTypeList.aspx" : Request.UrlReferrer.AbsoluteUri);
    }
}
