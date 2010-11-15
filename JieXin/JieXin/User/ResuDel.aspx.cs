using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class User_ResuDel : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) )
        {
            WebAgent.FailAndGo( "简历不存在！", "/User/Index.aspx" );
        }

        using( AW_Resume_dao dao = new AW_Resume_dao() )
        {
            AW_Resume_bean bean = dao.funcGetResumeById( int.Parse( QS( "id" ) ) );
            if( bean == null || bean.fdResuUserID != this.LoginUser.fdUserID )
            {
                WebAgent.FailAndGo( "简历不存在！", "/User/Index.aspx" );
            }
            dao.funcDelete( bean.fdResuID );
            WebAgent.SuccAndGo( "删除成功！", "/User/Index.aspx" );
        }
    }
}
