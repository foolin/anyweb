using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class User_PositionSave : PageUser
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
            if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) || string.IsNullOrEmpty( QS( "posid" ) ) || !WebAgent.IsInt32( QS( "posid" ) ) )
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
            bean = new AW_Position_bean();
            bean.fdPosiID = int.Parse( QS( "posid" ) );
            bean.fdPosiResuID = int.Parse( QS( "id" ) );
            bean.fdPosiBegin = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Pos_FromYear" ), QF( "Pos_FromMonth" ) ) );
            if( QF( "Pos_ToYear" ) != "0" && QF( "Pos_ToMonth" ) != "0" )
                bean.fdPosiEnd = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Pos_ToYear" ), QF( "Pos_ToMonth" ) ) );
            else
                bean.fdPosiEnd = DateTime.Parse( "1900-01-01" );
            bean.fdPosiName = QF( "Pos_Name" ).Trim();
            bean.fdPosiOrg = QF( "Pos_Org" ).Trim();
            bean.fdPosiIntro = QF( "Pos_Intro" ).Trim();
            if( string.IsNullOrEmpty( QF( "Pos_IsShow" ) ) || QF( "Pos_IsShow" ) != "0" )
            {
                bean.fdPosiIsShow = 1;
            }
            else
            {
                bean.fdPosiIsShow = 0;
            }

            new AW_Position_dao().funcInsert( bean );
            new AW_Resume_dao().funcUpdateResumeStatus( bean.fdPosiResuID );
        }
        else if( type == "edit" )
        {
            if( string.IsNullOrEmpty( QS( "posid" ) ) || !WebAgent.IsInt32( QS( "posid" ) ) )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }
            bean = AW_Position_bean.funcGetByID( int.Parse( QS( "posid" ) ) );
            if( bean == null )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }
            AW_Resume_bean resume = new AW_Resume_dao().funcGetResumeById( bean.fdPosiResuID );
            if( resume == null || resume.fdResuUserID != this.LoginUser.fdUserID )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }

            bean.fdPosiBegin = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Pos_FromYear" ), QF( "Pos_FromMonth" ) ) );
            if( QF( "Pos_ToYear" ) != "0" && QF( "Pos_ToMonth" ) != "0" )
                bean.fdPosiEnd = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Pos_ToYear" ), QF( "Pos_ToMonth" ) ) );
            else
                bean.fdPosiEnd = DateTime.Parse( "1900-01-01" );
            bean.fdPosiName = QF( "Pos_Name" ).Trim();
            bean.fdPosiOrg = QF( "Pos_Org" ).Trim();
            bean.fdPosiIntro = QF( "Pos_Intro" ).Trim();
            if( string.IsNullOrEmpty( QF( "Pos_IsShow" ) ) || QF( "Pos_IsShow" ) != "0" )
            {
                bean.fdPosiIsShow = 1;
            }
            else
            {
                bean.fdPosiIsShow = 0;
            }

            new AW_Position_dao().funcUpdate( bean );
            new AW_Resume_dao().funcUpdateResumeStatus( bean.fdPosiResuID );
        }
        else
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
    }

    private AW_Position_bean _bean;
    public AW_Position_bean bean
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
