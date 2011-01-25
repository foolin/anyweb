using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class User_RewardsSave : PageUser
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
            if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) || string.IsNullOrEmpty( QS( "rewid" ) ) || !WebAgent.IsInt32( QS( "rewid" ) ) )
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
            bean = new AW_Rewards_bean();
            bean.fdRewaID = int.Parse( QS( "rewid" ) );
            bean.fdRewaResuID = int.Parse( QS( "id" ) );
            bean.fdRewaBegin = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Rew_FromYear" ), QF( "Rew_FromMonth" ) ) );
            if( QF( "Rew_ToYear" ) != "0" && QF( "Rew_ToMonth" ) != "0" )
                bean.fdRewaEnd = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Rew_ToYear" ), QF( "Rew_ToMonth" ) ) );
            else
                bean.fdRewaEnd = DateTime.Parse( "1900-01-01" );
            bean.fdRewaName = QF( "Rew_Name" ).Trim();
            bean.fdRewaLevel = QF( "Rew_Level" ).Trim();
            if( string.IsNullOrEmpty( QF( "Rew_IsShow" ) ) )
            {
                bean.fdRewaIsShow = 1;
            }
            else
            {
                bean.fdRewaIsShow = int.Parse( QF( "Rew_IsShow" ) );
            }

            new AW_Rewards_dao().funcInsert( bean );
            new AW_Resume_dao().funcUpdateResumeStatus( bean.fdRewaResuID );
        }
        else if( type == "edit" )
        {
            if( string.IsNullOrEmpty( QS( "rewid" ) ) || !WebAgent.IsInt32( QS( "rewid" ) ) )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }
            bean = AW_Rewards_bean.funcGetByID( int.Parse( QS( "rewid" ) ) );
            if( bean == null )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }
            AW_Resume_bean resume = new AW_Resume_dao().funcGetResumeById( bean.fdRewaResuID );
            if( resume == null || resume.fdResuUserID != this.LoginUser.fdUserID )
            {
                Response.Clear();
                Response.Write( "" );
                Response.End();
            }

            bean.fdRewaBegin = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Rew_FromYear" ), QF( "Rew_FromMonth" ) ) );
            if( QF( "Rew_ToYear" ) != "0" && QF( "Rew_ToMonth" ) != "0" )
                bean.fdRewaEnd = DateTime.Parse( string.Format( "{0}-{1}-1", QF( "Rew_ToYear" ), QF( "Rew_ToMonth" ) ) );
            else
                bean.fdRewaEnd = DateTime.Parse( "1900-01-01" );
            bean.fdRewaName = QF( "Rew_Name" ).Trim();
            bean.fdRewaLevel = QF( "Rew_Level" ).Trim();
            if( string.IsNullOrEmpty( QF( "Rew_IsShow" ) ) )
            {
                bean.fdRewaIsShow = 1;
            }
            else
            {
                bean.fdRewaIsShow = int.Parse( QF( "Rew_IsShow" ) );
            }

            new AW_Rewards_dao().funcUpdate( bean );
            new AW_Resume_dao().funcUpdateResumeStatus( bean.fdRewaResuID );
        }
        else
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
    }

    private AW_Rewards_bean _bean;
    public AW_Rewards_bean bean
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
