using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_Setting_LinkDel : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string id = QS( "id" );
        string url = Request.UrlReferrer == null ? "LinkList.aspx" : Request.UrlReferrer.AbsoluteUri;
        if( String.IsNullOrEmpty( id ) || !Studio.Web.WebAgent.IsInt32( id ) )
        {
            WebAgent.AlertAndBack( "链接编号错误！" );
            Response.Redirect( url );
        }
        AW_Link_bean bean = AW_Link_bean.funcGetByID( int.Parse( QS( "id" ) ) );
        if( bean == null )
        {
            WebAgent.AlertAndBack( "友情链接不存在！" );
        }
        int record = new AW_Link_dao().funcDelete( bean.fdLinkID );
        if( record > 0 )
        {
            this.AddLog( EventType.Delete, "删除友情链接", "删除友情链接[" + bean.fdLinkName + "]" );
            Studio.Web.WebAgent.SuccAndGo( "删除成功", url );
        }
    }
}
