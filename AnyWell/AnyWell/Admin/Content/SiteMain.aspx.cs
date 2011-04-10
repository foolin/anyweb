using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Content_SiteMain : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int sid = 0;

        int.TryParse( QS( "id" ), out sid );

        if( sid == 0 )
        {
            ShowError( "请选择站点！" );
        }

        AW_Site_dao dao = new AW_Site_dao();
        CurrentSite = dao.funcGetSiteInfo( sid );
        if( CurrentSite == null )
        {
            ShowError( "站点不存在！" );
        }

        if( CurrentSite.Columns.Count == 0 )
        {
            noDatas.Visible = true;
        }
        else
        {
            repColumns.DataSource = CurrentSite.Columns;
            repColumns.DataBind();
        }
    }
}
