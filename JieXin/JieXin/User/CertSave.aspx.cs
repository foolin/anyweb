using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class User_CertSave : PageUser
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
            if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) || string.IsNullOrEmpty( QS( "certid" ) ) || !WebAgent.IsInt32( QS( "certid" ) ) )
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
            bean = new AW_Cert_bean();
            bean.fdCertID = int.Parse( QS( "certid" ) );
            bean.fdCertResuID = int.Parse( QS( "id" ) );
            bean.fdCertDate = DateTime.Parse( string.Format( "{0}-{1}-01", QF( "Cert_Year" ), QF( "Cert_Month" ) ) );
            bean.fdCertName = QF( "Cert_Name" ).Trim();
            if( string.IsNullOrEmpty( QF( "Cert_Scores" ) ) )
            {
                bean.fdCertScore = 0;
            }
            else
            {
                bean.fdCertScore = int.Parse( QF( "Cert_Scores" ) );
            }

            new AW_Cert_dao().funcInsert( bean );
            new AW_Resume_dao().funcUpdateResumeStatus( bean.fdCertResuID );
        }
        else if( type == "edit" )
        {
            if( string.IsNullOrEmpty( QS( "certid" ) ) || !WebAgent.IsInt32( QS( "certid" ) ) )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }
            bean = AW_Cert_bean.funcGetByID( int.Parse( QS( "certid" ) ) );
            if( bean == null )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }
            AW_Resume_bean resume = new AW_Resume_dao().funcGetResumeById( bean.fdCertResuID );
            if( resume == null || resume.fdResuUserID != this.LoginUser.fdUserID )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }

            bean.fdCertDate = DateTime.Parse( string.Format( "{0}-{1}-01", QF( "Cert_Year" ), QF( "Cert_Month" ) ) );
            bean.fdCertName = QF( "Cert_Name" ).Trim();
            if( string.IsNullOrEmpty( QF( "Cert_Scores" ) ) )
            {
                bean.fdCertScore = 0;
            }
            else
            {
                bean.fdCertScore = int.Parse( QF( "Cert_Scores" ) );
            }

            new AW_Cert_dao().funcUpdate( bean );
            new AW_Resume_dao().funcUpdateResumeStatus( bean.fdCertResuID );
        }
        else
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
    }

    private AW_Cert_bean _bean;
    public AW_Cert_bean bean
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
