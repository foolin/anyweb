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

using Admin.Framework;
using Studio.Web;
using Common.Common;
using Common.Agent;

public partial class Admin_HotSellRankSort : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.UrlReferrer == null)
            return;

        string type = QS("type");
        int goodsID = int.Parse(QS("id"));
        HotSellRankAgent hsr = new HotSellRankAgent();

        if (type == "up")
        {
            if (!hsr.GoodsSortUp(goodsID))
                WebAgent.AlertAndBack("已经是最前了");
        }
        else if (type == "down")
        {
            if (!hsr.GoodsSortDown(goodsID))
                WebAgent.AlertAndBack("已经是最后了");
        }

        Response.Redirect(Request.UrlReferrer == null ? "HotSellRankList.aspx" : Request.UrlReferrer.AbsoluteUri);
    }
}
