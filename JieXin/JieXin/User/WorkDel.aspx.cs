using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class User_WorkDel : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "workid" ) ) || !WebAgent.IsInt32( QS( "workid" ) ) )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
        AW_Work_bean bean = AW_Work_bean.funcGetByID( int.Parse( QS( "workid" ) ) );
        if( bean == null )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
        AW_Resume_bean resume = new AW_Resume_dao().funcGetResumeById( bean.fdWorkResuID );
        if( resume == null || resume.fdResuUserID != this.LoginUser.fdUserID )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
        new AW_Work_dao().funcDelete( bean.fdWorkID );
    }
}
