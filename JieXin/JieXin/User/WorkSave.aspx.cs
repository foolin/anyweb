using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class User_WorkSave : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
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
            if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) || string.IsNullOrEmpty( QS( "workid" ) ) || !WebAgent.IsInt32( QS( "workid" ) ) )
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
            bean = new AW_Work_bean();
            bean.fdWorkID = int.Parse( QS( "workid" ) );
            bean.fdWorkResuID = int.Parse( QS( "id" ) );
            bean.fdWorkBegin = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Work_FromYear" ), QF( "Work_FromMonth" ) ) );
            if( QF( "Work_ToYear" ) != "0" && QF( "Work_ToMonth" ) != "0" )
                bean.fdWorkEnd = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Work_ToYear" ), QF( "Work_ToMonth" ) ) );
            else
                bean.fdWorkEnd = DateTime.Parse( "1900-01-01" );
            bean.fdWorkName = QF( "Work_Name" ).Trim();

            if( !string.IsNullOrEmpty( QF( "Work_IndustryID" ).Trim() ) || !string.IsNullOrEmpty( QF( "Work_Industry" ).Trim() ) )
            {
                bean.fdWorkIndustryID = int.Parse( QF( "Work_IndustryID" ) );
                bean.fdWorkIndustry = QF( "Work_Industry" );
            }

            bean.fdWorkDimension = int.Parse( QF( "Work_Dimension" ) );
            bean.fdWorkType = int.Parse( QF( "Work_Type" ) );
            bean.fdWorkDepartment = QF( "Work_Department" ).Trim();

            if( string.IsNullOrEmpty( QF( "Work_JobID" ).Trim() ) || QF( "Work_JobID" ).Trim() == "0" )
            {
                bean.fdWorkJobID = 0;
                bean.fdWorkJob = "";
                bean.fdWorkOtherJob = QF( "Work_OtherJob" ).Trim();
            }
            else
            {
                bean.fdWorkJobID = int.Parse( QF( "Work_JobID" ).Trim() );
                bean.fdWorkJob = QF( "Work_Job" ).Trim();
                bean.fdWorkOtherJob = "";
            }

            bean.fdWorkIntro = QF( "Work_Intro" ).Trim();
            bean.fdWorkIsOverSeas = int.Parse( QF( "Work_IsOverSeas" ) );

            new AW_Work_dao().funcInsert( bean );
            new AW_Resume_dao().funcUpdateResumeStatus( bean.fdWorkResuID );
        }
        else if( type == "edit" )
        {
            if( string.IsNullOrEmpty( QS( "workid" ) ) || !WebAgent.IsInt32( QS( "workid" ) ) )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }
            bean = AW_Work_bean.funcGetByID( int.Parse( QS( "workid" ) ) );
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

            bean.fdWorkBegin = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Work_FromYear" ), QF( "Work_FromMonth" ) ) );
            if( QF( "Work_ToYear" ) != "0" && QF( "Work_ToMonth" ) != "0" )
                bean.fdWorkEnd = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Work_ToYear" ), QF( "Work_ToMonth" ) ) );
            else
                bean.fdWorkEnd = DateTime.Parse( "1900-01-01" );
            bean.fdWorkName = QF( "Work_Name" ).Trim();

            if( !string.IsNullOrEmpty( QF( "Work_IndustryID" ).Trim() ) || !string.IsNullOrEmpty( QF( "Work_Industry" ).Trim() ) )
            {
                bean.fdWorkIndustryID = int.Parse( QF( "Work_IndustryID" ) );
                bean.fdWorkIndustry = QF( "Work_Industry" );
            }

            bean.fdWorkDimension = int.Parse( QF( "Work_Dimension" ) );
            bean.fdWorkType = int.Parse( QF( "Work_Type" ) );
            bean.fdWorkDepartment = QF( "Work_Department" ).Trim();

            if( string.IsNullOrEmpty( QF( "Work_JobID" ).Trim() ) || QF( "Work_JobID" ).Trim() == "0" )
            {
                bean.fdWorkJobID = 0;
                bean.fdWorkJob = "";
                bean.fdWorkOtherJob = QF( "Work_OtherJob" ).Trim();
            }
            else
            {
                bean.fdWorkJobID = int.Parse( QF( "Work_JobID" ).Trim() );
                bean.fdWorkJob = QF( "Work_Job" ).Trim();
                bean.fdWorkOtherJob = "";
            }

            bean.fdWorkIntro = QF( "Work_Intro" ).Trim();
            bean.fdWorkIsOverSeas = int.Parse( QF( "Work_IsOverSeas" ) );

            new AW_Work_dao().funcUpdate( bean );
            new AW_Resume_dao().funcUpdateResumeStatus( bean.fdWorkResuID );
        }
        else
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
    }

    private AW_Work_bean _bean;
    public AW_Work_bean bean
    {
        get
        {
            return _bean;
        }
        set
        {
            _bean = value;
        }
    }
}
