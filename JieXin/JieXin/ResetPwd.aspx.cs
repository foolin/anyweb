using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;
using Studio.Security;
using AnyWell.Configs;

public partial class AnyWell_ResetPwd : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string code = QS( "c" );
        string account = QS( "u" );

        if( IsPostBack )
        {

            using( AW_User_dao dao = new AW_User_dao() )
            {

                if( dao.funcResetPwd( account, Secure.Md5( txtPwd1.Text.Trim() ) ) )
                {
                    WebAgent.SuccAndGo( "密码重置成功！", "/Index.aspx" );
                }
                else
                {
                    WebAgent.AlertAndBack( "密码重置失败，请稍候再试！" );
                }
            }
        }
        else
        {
            if( string.IsNullOrEmpty( code ) || string.IsNullOrEmpty( account ) )
            {
                WebAgent.FailAndGo( "链接无效！", "/Index.aspx" );
            }
            using( AW_User_dao dao = new AW_User_dao() )
            {
                DateTime date = dao.funcGetDateOfResetPwd( account, code );
                if( date.Equals( DateTime.Parse( "1900-01-01" ) ) )
                {
                    WebAgent.FailAndGo( "链接无效！", "/Index.aspx" );
                }
                if( date.AddDays( 3 ) < DateTime.Now )
                {
                    WebAgent.FailAndGo( "链接已超过有效期，请重新找回密码！", "/Index.aspx" );
                }
            }
        }

        this.Title = "重置密码" + GeneralConfigs.GetConfig().TitleExtension;
    }
}
