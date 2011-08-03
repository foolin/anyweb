using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.Configs;

public partial class c_126 : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = "潮人街拍" + GeneralConfigs.GetConfig().TitleExtension;
    }
}
