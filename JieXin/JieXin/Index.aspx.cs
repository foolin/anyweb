using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;
using AnyWell.Configs;

public partial class Index : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( IsPostBack )
        {
            string error = "";
            if( string.IsNullOrEmpty( txtUserName.Text.Trim() ) )
            {
                error += "会员名不能为空！\\n";
            }
            if( string.IsNullOrEmpty( txtPassword.Text.Trim() ) )
            {
                error += "密码不能为空！\\n";
            }
            if( error.Length > 0 )
                WebAgent.AlertAndBack( error );

            using( AW_User_dao dao = new AW_User_dao() )
            {
                AW_User_bean bean = dao.funcLogin( txtUserName.Text, txtPassword.Text, autoLogin.Checked );
                if( bean == null || bean.fdUserStatus == 2 )
                {
                    WebAgent.AlertAndBack( "会员名或密码错误！" );
                }
                else if( bean.fdUserStatus == 1 )
                {
                    WebAgent.AlertAndBack( "会员已被冻结！" );
                }
                else
                {
                    Response.Redirect( "/User/Index.aspx" );
                }
            }
        }

        this.Title = "广州市杰信人力资源有限公司" + GeneralConfigs.GetConfig().TitleExtension;
    }
}
