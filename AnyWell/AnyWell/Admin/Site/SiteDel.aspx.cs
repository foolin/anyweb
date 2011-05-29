using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using System.IO;

public partial class Admin_Content_SiteDel : PageAdmin
{
    AW_Site_bean bean;

    protected void Page_Load( object sender, EventArgs e )
    {
        bean = ( new AW_Site_dao() ).funcGetSiteInfo( int.Parse( QS( "id" ) ) );
        if( bean == null )
        {
            ShowError( "站点不存在！" );
        }

        if( bean.Columns != null && bean.Columns.Count > 0 )
        {
            ShowError( "站点下存在栏目,请先删除栏目！" );
        }

        if( !IsPostBack )
        {
            lblName.Text = bean.fdSiteName;
        }
        else
        {
            new AW_Site_dao().funcDelSite( bean );
            DirectoryInfo dirSite = new DirectoryInfo( string.Format( "{0}\\{1}\\", Server.MapPath( "~/" ), bean.fdSitePath ) );
            if( dirSite.Exists )
            {
                dirSite.Delete( true );
            }
            AddLog( EventType.Delete, "删除站点", "删除站点:" + bean.fdSiteName );
            Response.Write( string.Format( "<script type=text/javascript>parent.delSiteOK({0});</script>", bean.fdSiteID ) );
            Response.End();
        }
    }
}
