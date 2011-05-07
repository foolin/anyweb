using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Content_SiteEdit : PageAdmin
{
    protected AW_Site_bean bean;

    protected void Page_Load( object sender, EventArgs e )
    {
        bean = ( new AW_Site_dao() ).funcGetSiteInfo( int.Parse( QS( "id" ) ) );
        if( !IsPostBack )
        {
            txtName.Text = bean.fdSiteName;
            txtUrl.Text = string.IsNullOrEmpty( bean.fdSiteUrl ) ? "http://" : bean.fdSiteUrl;
            lblPath.Text = bean.fdSitePath;
            txtDesc.Text = bean.fdSiteDesc;
        }
        else
        {
            AW_Site_dao dao = new AW_Site_dao();
            if( dao.funcUrlExist( txtUrl.Text.Trim(), bean.fdSiteID ) > 0 )
            {
                Fail( "站点访问域名已被其它站点占用！", true );
            }

            bean.fdSiteName = txtName.Text.Trim();

            string url = txtUrl.Text.Trim().ToLower();
            if( !url.StartsWith( "http://" ) )
            {
                url = "http://" + url;
            }
            if( url == "http://" )
            {
                url = "";
            }
            if( url.EndsWith( "/" ) )
            {
                url = url.Remove( url.Length - 1, 1 );
            }
            bean.fdSiteUrl = url;
            bean.fdSiteDesc = txtDesc.Text;
            if( bean.fdSiteDesc.Length > 200 )
            {
                Fail( "站点描述长度不能超出200个字！", true );
            }

            if( dao.funcUpdate( bean ) > 0 )
            {
                AddLog( EventType.Update, "修改站点", string.Format( "修改站点:{0}({1})", bean.fdSiteName, bean.fdSiteID ) );
                Response.Write( string.Format( "<script type=text/javascript>parent.editSiteOK({0},\"{1}\");</script>", bean.fdSiteID, bean.fdSiteName ) );
                Response.End();
            }
        }
    }
}
