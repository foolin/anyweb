using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using AnyWell.Configs;

public partial class AnyWell_SiteInfo : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int infoid = 0;
        int.TryParse( Context.Items[ "SITEINFOID" ] + "", out infoid );
        if( infoid == 0 )
        {
            goErrorPage();
        }

        AW_SiteInfo_bean info = AW_SiteInfo_bean.funcGetByID( infoid );
        if( info == null )
        {
            goErrorPage();
        }
        HttpContext.Current.Items.Add( "SITEINFOID" + infoid, info );

        this.Title = info.fdSiInTitle + GeneralConfigs.GetConfig().TitleExtension;
    }
}
