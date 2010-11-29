using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class User_EduSave : PageUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string type = QS( "type" ).ToLower();
        if( string.IsNullOrEmpty( type ) )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
        if( type == "add" )
        {
            if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) || string.IsNullOrEmpty( QS( "eduid" ) ) || !WebAgent.IsInt32( QS( "eduid" ) ) )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }
            AW_Resume_bean resume = new AW_Resume_dao().funcGetResumeById( int.Parse( QS( "id" ) ) );
            if( resume == null || resume.fdResuUserID != this.LoginUser.fdUserID )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }
            bean = new AW_Education_bean();
            bean.fdEducID = int.Parse( QS( "eduid" ) );
            bean.fdEducResuID = int.Parse( QS( "id" ) );
            bean.fdEducBegin = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Edu_FromYear" ), QF( "Edu_FromMonth" ) ) );
            if( QF( "Edu_ToYear" ) != "0" && QF( "Edu_ToMonth" ) != "0" )
                bean.fdEducEnd = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Edu_ToYear" ), QF( "Edu_ToMonth" ) ) );
            else
                bean.fdEducEnd = DateTime.Parse( "1900-01-01" );
            bean.fdEducSchool = QF( "Edu_School" ).Trim();
            if( string.IsNullOrEmpty( QF( "Edu_SpecialityID" ).Trim() ) || QF( "Edu_SpecialityID" ).Trim() == "0" )
            {
                bean.fdEducSpecialityID = 0;
                bean.fdEducSpeciality = "";
                bean.fdEducOtherSpecialty = QF( "Edu_OtherSpeciality" ).Trim();
            }
            else
            {
                bean.fdEducSpecialityID = int.Parse( QF( "Edu_SpecialityID" ).Trim() );
                bean.fdEducSpeciality = QF( "Edu_Speciality" ).Trim();
                bean.fdEducOtherSpecialty = "";
            }
            bean.fdEducDegree = int.Parse( QF( "Edu_Degree" ) );
            bean.fdEducIntro = QF( "Edu_Intro" ).Trim();

            if( !string.IsNullOrEmpty( QF( "Edu_IsOverSeas" ) ) && WebAgent.IsInt32( QF( "Edu_IsOverSeas" ) ) )
            {
                bean.fdEducIsOverSeas = int.Parse( QF( "Edu_IsOverSeas" ) );
            }

            new AW_Education_dao().funcInsert( bean );
            new AW_Resume_dao().funcUpdateResumeStatus( bean.fdEducResuID );
        }
        else if( type == "edit" )
        {
            if( string.IsNullOrEmpty( QS( "eduid" ) ) || !WebAgent.IsInt32( QS( "eduid" ) ) )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }
            bean = AW_Education_bean.funcGetByID( int.Parse( QS( "eduid" ) ) );
            if( bean == null )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }
            AW_Resume_bean resume = new AW_Resume_dao().funcGetResumeById( bean.fdEducResuID );
            if( resume == null || resume.fdResuUserID != this.LoginUser.fdUserID )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }

            bean.fdEducBegin = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Edu_FromYear" ), QF( "Edu_FromMonth" ) ) );
            if( QF( "Edu_ToYear" ) != "0" && QF( "Edu_ToMonth" ) != "0" )
                bean.fdEducEnd = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Edu_ToYear" ), QF( "Edu_ToMonth" ) ) );
            else
                bean.fdEducEnd = DateTime.Parse( "1900-01-01" );
            bean.fdEducSchool = QF( "Edu_School" ).Trim();
            if( string.IsNullOrEmpty( QF( "Edu_SpecialityID" ).Trim() ) || QF( "Edu_SpecialityID" ).Trim() == "0" )
            {
                bean.fdEducSpecialityID = 0;
                bean.fdEducSpeciality = "";
                bean.fdEducOtherSpecialty = QF( "Edu_OtherSpeciality" ).Trim();
            }
            else
            {
                bean.fdEducSpecialityID = int.Parse( QF( "Edu_SpecialityID" ).Trim() );
                bean.fdEducSpeciality = QF( "Edu_Speciality" ).Trim();
                bean.fdEducOtherSpecialty = "";
            }
            bean.fdEducDegree = int.Parse( QF( "Edu_Degree" ) );
            bean.fdEducIntro = QF( "Edu_Intro" ).Trim();

            if( !string.IsNullOrEmpty( QF( "Edu_IsOverSeas" ) ) && WebAgent.IsInt32( QF( "Edu_IsOverSeas" ) ) )
            {
                bean.fdEducIsOverSeas = int.Parse( QF( "Edu_IsOverSeas" ) );
            }

            new AW_Education_dao().funcUpdate( bean );
            new AW_Resume_dao().funcUpdateResumeStatus( bean.fdEducResuID );
        }
        else
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
    }

    private AW_Education_bean _bean;
    public AW_Education_bean bean
    {
        get { return _bean; }
        set { _bean = value; }
    }
}
