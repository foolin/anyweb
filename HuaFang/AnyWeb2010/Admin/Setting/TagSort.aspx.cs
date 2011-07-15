using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_Setting_TagSort : PageAdmin
{
    protected override void OnPreRender( EventArgs e )
    {
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds( -1 );
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
        Response.AppendHeader( "Pragma", "No-Cache" );

        int tagId = 0;
        int previewId = 0;
        int nextId = 0;

        if( QS( "id" ) != "" && WebAgent.IsInt32( QS( "id" ) ) )
            tagId = int.Parse( QS( "id" ) );

        if( QS( "previewid" ) != "" && WebAgent.IsInt32( QS( "previewid" ) ) )
            previewId = int.Parse( QS( "previewid" ) );

        if( QS( "nextid" ) != "" && WebAgent.IsInt32( QS( "nextid" ) ) )
            nextId = int.Parse( QS( "nextid" ) );

        if( tagId > 0 && ( previewId > 0 || nextId > 0 ) )
        {
            AW_Tag_bean tag = AW_Tag_bean.funcGetByID( tagId );
            if( tag == null )
            {
                return;
            }
            using( AW_Tag_dao dao = new AW_Tag_dao() )
            {
                dao.funcSortTag( tagId, nextId, previewId );
                this.AddLog( EventType.Update, "修改标签排序", "修改标签[" + tag.fdTagName + "]排序" );
                Response.Write( "ok" );
            }
        }
        else
        {
            Response.Write( "parmaters null" );
        }
    }
}
