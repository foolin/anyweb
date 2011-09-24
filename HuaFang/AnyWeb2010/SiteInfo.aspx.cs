using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;
using AnyWell.Configs;

public partial class Asp_SiteInfo : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int id = 0;
        int.TryParse( ( string ) Context.Items[ "SITEINFOID" ], out id );
        if( id == 0 )
        {
            WebAgent.AlertAndBack( "页面不存在！" );
        }
        bean = AW_SiteInfo_bean.funcGetByID( id );
        if( bean == null )
        {
            WebAgent.AlertAndBack( "页面不存在！" );
        }

        this.Title = bean.fdSiInTitle + GeneralConfigs.GetConfig().TitleExtension;
    }

    private AW_SiteInfo_bean _bean;
    public AW_SiteInfo_bean bean
    {
        get
        {
            return _bean;
        }
        set
        {
            _bean = value;
        }
    }
}
