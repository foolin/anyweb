using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class User_WorkEdit : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
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
