using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.Configs;

public partial class c_125 : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = "明星名媛" + GeneralConfigs.GetConfig().TitleExtension;
    }
}
