using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.Configs;

public partial class User_MemPhoto : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = "形象照片管理" + GeneralConfigs.GetConfig().TitleExtension;
    }
}
