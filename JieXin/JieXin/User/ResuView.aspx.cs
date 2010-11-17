using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;
using AnyWell.Configs;

public partial class User_ResuView : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) )
        {
            WebAgent.FailAndGo( "简历不存在！", "/User/Index.aspx" );
        }

        AW_Resume_bean bean = new AW_Resume_dao().funcGetResume( int.Parse( QS( "id" ) ), false );
        if( bean == null || bean.fdResuUserID != this.LoginUser.fdUserID )
        {
            WebAgent.FailAndGo( "简历不存在！", "/User/Index.aspx" );
        }

        Context.Items.Add( "RESUME", bean );

        this.Title = "我的简历" + GeneralConfigs.GetConfig().TitleExtension;        
    }
}
