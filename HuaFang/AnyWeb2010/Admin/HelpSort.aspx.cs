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

using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_HelpSort : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string type = QS("type");
        int helpId = int.Parse(QS("id")), helpTypeId = 0;
        AW_Help_dao dao = new AW_Help_dao();

        if (type == "up")
        {
            if (!dao.funcUp(helpId, helpTypeId))
                WebAgent.AlertAndBack("已经是最前了");
        }
        else if (type == "down")
        {
            if (!dao.funcDown(helpId,helpTypeId))
                WebAgent.AlertAndBack("已经是最后了");
        }

        Response.Redirect(Request.UrlReferrer == null ? "HelpList.aspx" : Request.UrlReferrer.AbsoluteUri);
    }
}
