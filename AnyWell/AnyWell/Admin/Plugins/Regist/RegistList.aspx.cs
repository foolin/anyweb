using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_Plugins_Regist_RegistList : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int sid = 0;
        foreach( AW_Site_bean site in new AW_Site_dao().funcGetSites() )
        {
            drpSite.Items.Add( new ListItem( site.fdSiteName, site.fdSiteID.ToString() ) );
        }

        if( drpSite.Items.Count == 0 )
        {
            WebAgent.FailAndGo( "站点不存在，请先添加站点！", "/Admin/mainfra.html" );
        }

        int.TryParse( QS( "sid" ), out sid );
        if( sid != 0 )
        {
            drpSite.SelectedValue = sid.ToString();
        }

        int recordCount = 0;
        List<AW_Regist_bean> list = new AW_Regist_dao().funcGetRegistList( int.Parse( drpSite.SelectedValue ), PN1.PageIndex, PN1.PageSize, out recordCount );
        if( list.Count > 0 )
        {
            repRegist.DataSource = list;
            repRegist.DataBind();
            PN1.SetPage( recordCount );
            litRecords.Text = recordCount.ToString();
        }
        else
        {
            noDatas.Visible = true;
            tableFooter.Visible = false;
        }
    }

    public string GetSiteID()
    {
        return drpSite.SelectedValue;
    }
}
