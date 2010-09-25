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
        this.lt_description.Text = string.Format("<meta name=\"description\" content=\"{0}\" />", GeneralConfigs.GetConfig().MetaDescription);
        this.lt_keywords.Text = string.Format("<meta name=\"keywords\" content=\"{0}\" />", GeneralConfigs.GetConfig().MetaKeywords);
    }
}
