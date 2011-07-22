﻿using System;
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

public partial class Admin_FlashDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        string id = QS("id");
        string url = Request.UrlReferrer == null ? "FlashList.aspx" : Request.UrlReferrer.AbsoluteUri;
        if (String.IsNullOrEmpty(id) || !Studio.Web.WebAgent.IsInt32(id))
        {
            Response.Redirect(url);
        }

        int record = new AW_Flash_dao().funcDelete(int.Parse(id));
        if (record > 0)
        {
            Studio.Web.WebAgent.SuccAndGo("删除成功", url);
        }
    }
}
