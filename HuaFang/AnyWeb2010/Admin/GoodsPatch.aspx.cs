using System;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Studio.Web;
using AnyWell.AW_DL;
using AnyWell.AW_DL;
using AnyWell.Configs;

public partial class Admin_GoodsPatch : PageAdmin
{

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        step1.Visible = false;
        step2.Visible = true;
    }
}
