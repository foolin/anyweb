using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Plugins_Subscribe_SubscribeEdit : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        int.TryParse( QS( "id" ), out id );
        if( id == 0 )
        {
            ShowError( "订阅不存在！" );
        }
        AW_Subscribe_bean bean = AW_Subscribe_bean.funcGetByID( id );
        if(bean==null)
        {
            ShowError( "订阅不存在！" );
        }
        if( !IsPostBack )
        {
            foreach( AW_Site_bean site in new AW_Site_dao().funcGetSites() )
            {
                drpSite.Items.Add( new ListItem( site.fdSiteName, site.fdSiteID.ToString() ) );
            }
            drpSite.SelectedValue = bean.fdSubsSiteID.ToString();
            txtCompany.Text = bean.fdSubsCompany;
            txtSurname.Text = bean.fdSubsSurname;
            txtName.Text = bean.fdSubsName;
            txtEmail.Text = bean.fdSubsEmail;
        }
        else
        {
            AW_Subscribe_dao dao = new AW_Subscribe_dao();
            bean.fdSubsSiteID = int.Parse(drpSite.SelectedValue);
            bean.fdSubsCompany = txtCompany.Text.Trim();
            bean.fdSubsSurname = txtSurname.Text.Trim();
            bean.fdSubsName = txtName.Text.Trim();
            bean.fdSubsEmail = txtEmail.Text.Trim().ToLower();
            if( dao.funcUpdate( bean ) > 0 )
            {
                AddLog( EventType.Insert, "修改订阅", string.Format( "修改订阅:{0}({1})", bean.fdSubsCompany, bean.fdSubsID ) );
                Response.Write( "<script type=text/javascript>parent.editSubscribeOK();</script>" );
                Response.End();
            }
        }
    }
}
