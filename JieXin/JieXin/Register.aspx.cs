using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.Configs;
using Studio.Web;
using AnyWell.AW_DL;
using Studio.Security;

public partial class Register : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( IsPostBack )
        {
            using( AW_User_dao dao = new AW_User_dao() )
            {
                if( string.IsNullOrEmpty( txtEmail.Text.Trim() ) )
                {
                    WebAgent.AlertAndBack( "邮箱不能为空！" );
                }
                if( string.IsNullOrEmpty( txtName.Text.Trim() ) )
                {
                    WebAgent.AlertAndBack( "用户名不能为空！" );
                }
                if( string.IsNullOrEmpty( txtPassword.Text.Trim() ) )
                {
                    WebAgent.AlertAndBack( "密码不能为空！" );
                }
                if( txtPassword.Text.Trim().Length < 6 )
                {
                    WebAgent.AlertAndBack( "密码设置至少6位，且区分大小写！" );
                }                
                if( string.IsNullOrEmpty( txtPassword2.Text.Trim() ) )
                {
                    WebAgent.AlertAndBack( "重复密码不能为空！" );
                }
                if( txtPassword2.Text.Trim().Length < 6 )
                {
                    WebAgent.AlertAndBack( "重复密码设置至少6位，且区分大小写！" );
                }
                if( txtPassword.Text.Trim() != txtPassword2.Text.Trim() )
                {
                    WebAgent.AlertAndBack( "两次输入密码不一致！" );
                }

                if( !dao.funcCheckEmail( txtEmail.Text ) )
                {
                    WebAgent.FailAndGo( "邮箱已存在！" );
                }

                if( !dao.funcCheckAccount( txtName.Text ) )
                {
                    WebAgent.FailAndGo( "用户名已存在！" );
                }

                AW_User_bean bean = new AW_User_bean();
                bean.fdUserID = dao.funcNewID();
                bean.fdUserEmail = txtEmail.Text.Trim();
                bean.fdUserAccount = txtName.Text.Trim();
                bean.fdUserPwd = Secure.Md5( txtPassword.Text.Trim() );
                bean.fdUserStatus = 0;
                dao.funcInsert( bean );
                dao.funcLogin( bean.fdUserAccount.Trim(), txtPassword.Text.Trim(), false );
                Response.Redirect( "/User/Index.aspx" );
            }
        }
    }

    protected override void OnPreRender( EventArgs e )
    {
        GeneralConfigInfo config = GeneralConfigs.GetConfig();
        if( !config.RegEnable )
        {
            WebAgent.FailAndGo( "本网站暂停注册，有疑问请联系网站管理员！", "/index.aspx" );
        }
    }
}
