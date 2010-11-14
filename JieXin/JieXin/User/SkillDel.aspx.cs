using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class User_SkillDel : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "skillid" ) ) || !WebAgent.IsInt32( QS( "skillid" ) ) )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
        AW_Skills_bean bean = AW_Skills_bean.funcGetByID( int.Parse( QS( "skillid" ) ) );
        if( bean == null )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
        AW_Resume_bean resume = new AW_Resume_dao().funcGetResumeById( bean.fdSkilResuID );
        if( resume == null || resume.fdResuUserID != this.LoginUser.fdUserID )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
        new AW_Skills_dao().funcDelete( bean.fdSkilID );
    }
}
