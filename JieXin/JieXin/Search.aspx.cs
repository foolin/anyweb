using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using AnyWell.Configs;

public partial class Search : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = "职位搜索" + GeneralConfigs.GetConfig().TitleExtension;
    }
}
