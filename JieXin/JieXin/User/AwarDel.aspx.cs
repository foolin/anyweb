using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class User_AwarDel : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "awarid" ) ) || !WebAgent.IsInt32( QS( "awarid" ) ) )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
        AW_Awards_bean bean = AW_Awards_bean.funcGetByID( int.Parse( QS( "awarid" ) ) );
        if( bean == null )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
        AW_Resume_bean resume = new AW_Resume_dao().funcGetResumeById( bean.fdAwarResuID );
        if( resume == null || resume.fdResuUserID != this.LoginUser.fdUserID )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
        new AW_Awards_dao().funcDelete( bean.fdAwarID );
    }
}
