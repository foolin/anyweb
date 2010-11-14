using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class User_AwarSave : PageUser
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
            if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) || string.IsNullOrEmpty( QS( "awarid" ) ) || !WebAgent.IsInt32( QS( "awarid" ) ) )
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
            bean = new AW_Awards_bean();
            bean.fdAwarID = int.Parse( QS( "awarid" ) );
            bean.fdAwarResuID = int.Parse( QS( "id" ) );
            bean.fdAwarDate = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Awar_Year" ), QF( "Awar_Month" ) ) );
            bean.fdAwarName = QF( "Awar_Name" ).Trim();

            new AW_Awards_dao().funcInsert( bean );
            new AW_Resume_dao().funcUpdateResumeStatus( bean.fdAwarResuID );
        }
        else if( type == "edit" )
        {
            if( string.IsNullOrEmpty( QS( "awarid" ) ) || !WebAgent.IsInt32( QS( "awarid" ) ) )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }
            bean = AW_Awards_bean.funcGetByID( int.Parse( QS( "awarid" ) ) );
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

            bean.fdAwarDate = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Awar_Year" ), QF( "Awar_Month" ) ) );
            bean.fdAwarName = QF( "Awar_Name" ).Trim();

            new AW_Awards_dao().funcUpdate( bean );
            new AW_Resume_dao().funcUpdateResumeStatus( bean.fdAwarResuID );
        }
        else
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
    }

    private AW_Awards_bean _bean;
    public AW_Awards_bean bean
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
