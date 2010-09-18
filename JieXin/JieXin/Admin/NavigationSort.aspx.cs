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
        int columnId = int.Parse(QS("id"));
        AW_Navigation_dao dao = new AW_Navigation_dao();

        if (type == "up")
        {
            if (!dao.funcUp(columnId))
                WebAgent.AlertAndBack("已经是最前了");
        }
        else if (type == "down")
        {
            if (!dao.funcDown(columnId))
                WebAgent.AlertAndBack("已经是最后了");
        }

        Response.Redirect(Request.UrlReferrer == null ? "NavigationList.aspx" : Request.UrlReferrer.AbsoluteUri);
    }
}
