using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class User_LangSave : PageUser
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
            if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) || string.IsNullOrEmpty( QS( "langid" ) ) || !WebAgent.IsInt32( QS( "langid" ) ) )
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
            bean = new AW_Language_bean();
            bean.fdLangID = int.Parse( QS( "langid" ) );
            bean.fdLangResuID = int.Parse( QS( "id" ) );
            bean.fdLangType = int.Parse( QF( "Lang_Type" ) );
            bean.fdLangMaster = int.Parse( QF( "Lang_Master" ) );
            bean.fdLangRWAbility = int.Parse( QF( "Lang_RW" ) );
            bean.fdLangLiAbility = int.Parse( QF( "Lang_Listen" ) );

            new AW_Language_dao().funcInsert( bean );
            new AW_Resume_dao().funcUpdateResumeStatus( bean.fdLangResuID );
        }
        else if( type == "edit" )
        {
            if( string.IsNullOrEmpty( QS( "langid" ) ) || !WebAgent.IsInt32( QS( "langid" ) ) )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }
            bean = AW_Language_bean.funcGetByID( int.Parse( QS( "langid" ) ) );
            if( bean == null )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }
            AW_Resume_bean resume = new AW_Resume_dao().funcGetResumeById( bean.fdLangResuID );
            if( resume == null || resume.fdResuUserID != this.LoginUser.fdUserID )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }

            bean.fdLangType = int.Parse( QF( "Lang_Type" ) );
            bean.fdLangMaster = int.Parse( QF( "Lang_Master" ) );
            bean.fdLangRWAbility = int.Parse( QF( "Lang_RW" ) );
            bean.fdLangLiAbility = int.Parse( QF( "Lang_Listen" ) );

            new AW_Language_dao().funcUpdate( bean );
            new AW_Resume_dao().funcUpdateResumeStatus( bean.fdLangResuID );
        }
        else
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
    }

    private AW_Language_bean _bean;
    public AW_Language_bean bean
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
