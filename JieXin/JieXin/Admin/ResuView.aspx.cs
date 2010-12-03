using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_ResuView : PageAdmin
{
    protected override void OnPreRender( EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) )
        {
            WebAgent.FailAndGo( "简历不存在！", "/User/Index.aspx" );
        }

        AW_Resume_bean bean = new AW_Resume_dao().funcGetResume( int.Parse( QS( "id" ) ), false );
        if( bean == null )
        {
            WebAgent.FailAndGo( "简历不存在！", "/Admin/Index.aspx" );
        }
        new AW_Resume_dao().funcUpdateViewCount( bean.fdResuID );
        Context.Items.Add( "RESUME", bean );
    }
}
