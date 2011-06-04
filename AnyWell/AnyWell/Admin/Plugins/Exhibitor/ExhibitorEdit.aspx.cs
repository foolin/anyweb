using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Plugins_Exhibitor_ExhibitorEdit : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int id = 0;
        int.TryParse( QS( "id" ), out id );
        if( id == 0 )
        {
            ShowError( "展商不存在！" );
        }
        AW_Exhibitor_bean bean = AW_Exhibitor_bean.funcGetByID( id );
        if(bean==null)
        {
            ShowError( "展商不存在！" );
        }
        if( !IsPostBack )
        {
            foreach( AW_Site_bean site in new AW_Site_dao().funcGetSites() )
            {
                drpSite.Items.Add( new ListItem( site.fdSiteName, site.fdSiteID.ToString() ) );
            }
            drpSite.SelectedValue = bean.fdExhiSiteID.ToString();
            txtName.Text = bean.fdExhiName;
            txtEnName.Text = bean.fdExhiEnName;
            txtNumber.Text = bean.fdExhiNumber;
            drpType.SelectedValue = bean.fdExhiType.ToString();
            txtUrl.Text = bean.fdExhiUrl;
            txtDesc.Text = bean.fdExhiDesc;
        }
        else
        {
            if( txtDesc.Text.Length > 50 )
            {
                Fail( "描述字数不能超过50个字！", true );
            }
            AW_Exhibitor_dao dao = new AW_Exhibitor_dao();
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
            if( dao.funcUpdate( bean ) > 0 )
            {
                AddLog( EventType.Insert, "修改展商", string.Format( "修改展商:{0}({1})", bean.fdExhiName, bean.fdExhiID ) );
                Response.Write( "<script type=text/javascript>parent.editExhibitorOK();</script>" );
                Response.End();
            }
        }
    }
}
