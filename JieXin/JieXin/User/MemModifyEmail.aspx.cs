using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class User_MemModifyEmail : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( IsPostBack )
        {
            using( AW_User_dao dao = new AW_User_dao() )
            {
                if( dao.funcCheckEmail( this.LoginUser.fdUserID, txtEmail.Text.Trim() ) )
                {
                    WebAgent.AlertAndBack( "邮箱已存在，请重新输入！" );
                }
                this.LoginUser.fdUserEmail = txtEmail.Text.Trim();
                new AW_User_dao().funcUpdate( this.LoginUser );
                WebAgent.SuccAndGo( "保存成功！", "/User/MemModifyEmail.aspx" );
            }
        }
    }
}
