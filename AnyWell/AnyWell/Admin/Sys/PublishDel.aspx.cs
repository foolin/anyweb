using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Sys_PublishDel : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string ids = QS( "ids" ).Trim();
        if( string.IsNullOrEmpty( ids ) )
        {
            ShowError( "请选择发布日志！" );
        }

        AW_Publish_dao dao = new AW_Publish_dao();
        List<AW_Publish_bean> list = dao.funcGetPublishList( ids );

        if( !IsPostBack )
        {
            repPublish.DataSource = list;
            repPublish.DataBind();
        }
        else
        {
            dao.funcDeletePublish( ids );
            AddLog( EventType.Delete, "删除发布日志", "删除发布日志" );
            Response.Write( "<script type=text/javascript>parent.deletePublishOK();</script>" );
            Response.End();
        }
    }
}
