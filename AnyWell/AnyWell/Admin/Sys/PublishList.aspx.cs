using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Sys_PublishList : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        //设置页面不缓存
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddSeconds( -1 );
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
        Response.AddHeader( "Pragma", "No-Cache" );

        int status = 0, adminId = 0;
        bool owner = false;
        int.TryParse( QS( "status" ), out status );
        bool.TryParse( QS( "owner" ), out owner );
        if( owner )
        {
            adminId = AdminInfo.fdAdmiID;
        }

        int record = 0;
        List<AW_Publish_bean> list = new AW_Publish_dao().funcGetPublishList( adminId, status, PN1.PageIndex, PN1.PageSize, out record );

        if( list.Count > 0 )
        {
            repPublish.DataSource = list;
            repPublish.DataBind();
            PN1.SetPage( record );
            litRecords.Text = record.ToString();
        }
        else
        {
            noDatas.Visible = true;
            tableFooter.Visible = false;
        }
    }
}
