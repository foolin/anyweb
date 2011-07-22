using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_Setting_LinkEdit : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string id = QS( "id" );

        if( !WebAgent.IsInt32( id ) )
            WebAgent.AlertAndBack( "编号不正确!" );

        AW_Link_bean bean = AW_Link_bean.funcGetByID( QS( "id" ) );
        if( bean == null )
            WebAgent.AlertAndBack( "链接不存在!" );

        txtTitle.Text = bean.fdLinkName;
        txtUrl.Text = bean.fdLinkUrl;
        txtSort.Text = bean.fdLinkSort.ToString();

        if( !this.IsPostBack && Request.UrlReferrer != null )
        {
            ViewState[ "REFURL" ] = Request.UrlReferrer.PathAndQuery;
        }
        else
        {
            ViewState[ "REFURL" ] = "LinkList.aspx";
        }
    }

    protected void btnOk_Click( object sender, EventArgs e )
    {
        AW_Link_dao dao = new AW_Link_dao();
        AW_Link_bean bean = AW_Link_bean.funcGetByID( QS( "id" ) );
        bean.fdLinkName = txtTitle.Text.Trim();
        bean.fdLinkUrl = txtUrl.Text.Trim();
        bean.fdLinkSort = int.Parse( txtSort.Text.Trim() );
        if( bean.fdLinkSort == 0 )
        {
            bean.fdLinkSort = bean.fdLinkID * 100;
        }
        dao.funcUpdate( bean );
        this.AddLog( EventType.Update, "修改友情链接", "修改友情链接[" + bean.fdLinkName + "]" );
        WebAgent.SuccAndGo( "修改友情链接成功", ViewState[ "REFURL" ].ToString() );
    }
}
