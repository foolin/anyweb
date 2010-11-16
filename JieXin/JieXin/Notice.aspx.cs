using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.Configs;

public partial class AnyWell_Notice : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "公告列表" + GeneralConfigs.GetConfig().TitleExtension;
    }
}
