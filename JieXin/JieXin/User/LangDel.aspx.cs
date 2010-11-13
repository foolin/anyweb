using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class User_LangDel : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "langid" ) ) || !WebAgent.IsInt32( QS( "langid" ) ) )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
        AW_Language_bean bean = AW_Language_bean.funcGetByID( int.Parse( QS( "langid" ) ) );
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
        new AW_Language_dao().funcDelete( bean.fdLangID );
    }
}
