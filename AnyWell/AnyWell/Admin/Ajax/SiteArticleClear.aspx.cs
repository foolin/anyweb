using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Ajax_SiteArticleClear : AjaxPageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int sid = 0;

        int.TryParse( QS( "id" ), out sid );

        if( sid == 0 )
        {
            RenderString( "站点不存在！" );
        }

        AW_Site_bean bean = new AW_Site_dao().funcGetSiteInfo( sid );

        if( bean == null )
        {
            RenderString( "站点不存在！" );
        }

        new AW_Article_dao().funcClearSiteRecycle( bean.fdSiteID );

        AddLog( EventType.Delete, "清空回收站", string.Format( "清空站点[{0}]回收站", bean.fdSiteName ) );
    }
}
