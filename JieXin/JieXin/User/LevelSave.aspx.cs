using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class User_LevelSave : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }

        resume = new AW_Resume_dao().funcGetLangLevel( int.Parse( QS( "id" ) ) );
        if( resume == null || resume.fdResuUserID != this.LoginUser.fdUserID )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
        resume.fdResuEnLevel = int.Parse( QF( "Level_EnLevel" ) );
        if( string.IsNullOrEmpty( QF( "Level_TOEFL" ) ) )
        {
            resume.fdResuTOEFL = 0;
        }
        else
        {
            resume.fdResuTOEFL = int.Parse( QF( "Level_TOEFL" ) );
        }
        if( string.IsNullOrEmpty( QF( "Level_GRE" ) ) )
        {
            resume.fdResuGRE = 0;
        }
        else
        {
            resume.fdResuGRE = int.Parse( QF( "Level_GRE" ) );
        }
        resume.fdResuJpLevel = int.Parse( QF( "Level_JpLevel" ) );
        if( string.IsNullOrEmpty( QF( "Level_GMAT" ) ) )
        {
            resume.fdResuGMAT = 0;
        }
        else
        {
            resume.fdResuGMAT = int.Parse( QF( "Level_GMAT" ) );
        }
        if( string.IsNullOrEmpty( QF( "Level_IELTS" ) ) )
        {
            resume.fdResuIELTS = 0;
        }
        else
        {
            resume.fdResuIELTS = int.Parse( QF( "Level_IELTS" ) );
        }

        resume.fdResuStatus = 0;

        new AW_Resume_dao().funcUpdateLangLevel( resume );
    }

    private AW_Resume_bean _resume;
    public AW_Resume_bean resume
    {
        get
        {
            return _resume;
        }
        set
        {
            _resume = value;
        }
    }
}
