using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_Setting_LinkSort : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds( -1 );
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
        Response.AppendHeader( "Pragma", "No-Cache" );

        int linkId = 0;
        int previewId = 0;
        int nextId = 0;

        if( QS( "id" ) != "" && WebAgent.IsInt32( QS( "id" ) ) )
            linkId = int.Parse( QS( "id" ) );

        if( QS( "previewid" ) != "" && WebAgent.IsInt32( QS( "previewid" ) ) )
            previewId = int.Parse( QS( "previewid" ) );

        if( QS( "nextid" ) != "" && WebAgent.IsInt32( QS( "nextid" ) ) )
            nextId = int.Parse( QS( "nextid" ) );

        if( linkId > 0 && ( previewId > 0 || nextId > 0 ) )
        {
            AW_Link_bean link = AW_Link_bean.funcGetByID( linkId );
            if( link == null )
            {
                return;
            }
            using( AW_Link_dao dao = new AW_Link_dao() )
            {
                dao.funcSortLink( linkId, nextId, previewId );
                this.AddLog( EventType.Update, "修改友情链接排序", "修改友情链接[" + link.fdLinkName + "]排序" );
                Response.Write( "ok" );
            }
        }
        else
        {
            Response.Write( "parmaters null" );
        }
    }
}
