using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Plugins_Exhibitor_ExhibitorAdd : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( !IsPostBack )
        {
            int sid = 0;
            foreach( AW_Site_bean site in new AW_Site_dao().funcGetSites() )
            {
                drpSite.Items.Add( new ListItem( site.fdSiteName, site.fdSiteID.ToString() ) );
            }
            int.TryParse( QS( "sid" ), out sid );
            if( sid != 0 )
            {
                drpSite.SelectedValue = sid.ToString();
            }
        }
        else
        {
            if( txtDesc.Text.Length > 50 )
            {
                Fail( "描述字数不能超过50个字！", true );
            }
            AW_Exhibitor_bean bean = new AW_Exhibitor_bean();
            AW_Exhibitor_dao dao = new AW_Exhibitor_dao();
            bean.fdExhiID = dao.funcNewID();
            bean.fdExhiSiteID = int.Parse( drpSite.SelectedValue );
            bean.fdExhiName = txtName.Text.Trim();
            bean.fdExhiEnName = txtEnName.Text.Trim();
            bean.fdExhiNumber = txtNumber.Text.Trim();
            bean.fdExhiType = int.Parse( drpType.SelectedValue );
            bean.fdExhiUrl = txtUrl.Text.Trim().ToLower();
            if( !bean.fdExhiUrl.StartsWith( "http://" ) )
            {
                bean.fdExhiUrl = "http://" + bean.fdExhiUrl;
            }
            if( bean.fdExhiUrl == "http://" )
            {
                bean.fdExhiUrl = "";
            }
            bean.fdExhiDesc = txtDesc.Text;
            bean.fdExhiCreateAt = DateTime.Now;
            bean.fdExhiSort = bean.fdExhiID * 10;
            if( dao.funcInsert( bean ) > 0 )
            {
                AddLog( EventType.Insert, "添加展商", string.Format( "添加展商:{0}({1})", bean.fdExhiName, bean.fdExhiID ) );
                Response.Write( string.Format( "<script type=text/javascript>parent.addExhibitorOK({0});</script>", bean.fdExhiSiteID ) );
                Response.End();
            }
        }
    }
}
