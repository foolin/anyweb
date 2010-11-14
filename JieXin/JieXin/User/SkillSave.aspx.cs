using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class User_SkillSave : PageUser
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
            if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) || string.IsNullOrEmpty( QS( "skillid" ) ) || !WebAgent.IsInt32( QS( "skillid" ) ) )
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
            bean = new  AW_Skills_bean();
            bean.fdSkilID = int.Parse( QS( "skillid" ) );
            bean.fdSkilResuID = int.Parse( QS( "id" ) );
            bean.fdSkilName = QF( "Skill_Name" ).Trim();
            bean.fdSkilMonth = int.Parse( QF( "Skill_Month" ) );
            bean.fdSkilLevel = int.Parse( QF( "Skill_Level" ) );

            new AW_Skills_dao().funcInsert( bean );
            new AW_Resume_dao().funcUpdateResumeStatus( bean.fdSkilResuID );
        }
        else if( type == "edit" )
        {
            if( string.IsNullOrEmpty( QS( "skillid" ) ) || !WebAgent.IsInt32( QS( "skillid" ) ) )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }
            bean = AW_Skills_bean.funcGetByID( int.Parse( QS( "skillid" ) ) );
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

            bean.fdSkilName = QF( "Skill_Name" ).Trim();
            bean.fdSkilMonth = int.Parse( QF( "Skill_Month" ) );
            bean.fdSkilLevel = int.Parse( QF( "Skill_Level" ) );

            new AW_Skills_dao().funcUpdate( bean );
            new AW_Resume_dao().funcUpdateResumeStatus( bean.fdSkilResuID );
        }
        else
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
    }

    private AW_Skills_bean _bean;
    public AW_Skills_bean bean
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
