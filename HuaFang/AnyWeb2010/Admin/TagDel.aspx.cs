using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_TagDel : PageAdmin
{
    protected override void OnPreRender( EventArgs e )
    {
        string id = QS( "id" );
        string url = Request.UrlReferrer == null ? "TagList.aspx" : Request.UrlReferrer.AbsoluteUri;
        if( String.IsNullOrEmpty( id ) || !Studio.Web.WebAgent.IsInt32( id ) )
        {
            WebAgent.AlertAndBack( "标签编号错误！" );
            Response.Redirect( url );
        }
        AW_Tag_bean bean = AW_Tag_bean.funcGetByID( int.Parse( QS( "id" ) ) );
        if( bean == null )
        {
            WebAgent.AlertAndBack( "标签不存在！" );
        }
        int record = new AW_Tag_dao().funcDelete( bean.fdTagID );
        if( record > 0 )
        {
            this.AddLog( EventType.Delete, "删除标签", "删除标签[" + bean.fdTagName + "]" );
            Studio.Web.WebAgent.SuccAndGo( "删除成功", url );
        }
    }
}
