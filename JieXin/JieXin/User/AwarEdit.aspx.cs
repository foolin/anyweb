using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class User_AwarEdit : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
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
