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

using Studio.Web;
using AnyWeb.AW_DL;
using AnyWeb.AW_DL;
using System.Collections.Generic;


public partial class Admin_KeyWordsSort : ShopAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int keyWId = 0;
        int previewId = 0;
        int nextId = 0;

        if (QS("id") != "" && WebAgent.IsInt32(QS("id")))
            keyWId = int.Parse(QS("id"));

        if (QS("previewid") != "" && WebAgent.IsInt32(QS("previewid")))
            previewId = int.Parse(QS("previewid"));

        if (QS("nextid") != "" && WebAgent.IsInt32(QS("nextid")))
            nextId = int.Parse(QS("nextid"));

        if (keyWId > 0 && (previewId > 0 || nextId > 0))
        {
            using (AW_KeyWord_dao dao = new AW_KeyWord_dao())
            {
                dao.funcSortKeyWords(keyWId, nextId, previewId);
                Response.Write("ok");
            }
        }
        else
        {
            Response.Write("parmaters null");
        }

    }
}