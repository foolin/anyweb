﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;
using AnyWeb.AW.Configs;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        repHot.DataSource = new AW_Article_dao().funcGetHotArticle(3);
        repHot.DataBind();
    }

    public GeneralConfigInfo config
    {
        get 
        {
            return GeneralConfigs.GetConfig();
        }
    }
}
