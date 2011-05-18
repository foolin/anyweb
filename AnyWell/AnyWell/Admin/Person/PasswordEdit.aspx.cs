using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Person_PasswordEdit : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {

    }

    protected void btnSave_Click( object sender, EventArgs e )
    {
        if( Studio.Security.Secure.Md5( txtOldPassword.Text.Trim() ) != AdminInfo.fdAdmiPwd )
        {
            Fail( "原密码错误！", true );
        }
        AdminInfo.fdAdmiPwd = Studio.Security.Secure.Md5( txtPassword.Text.Trim() );
        int result = new AW_Admin_dao().funcUpdate( AdminInfo );
        if( result > 0 )
        {
            AddLog( EventType.Update, "修改密码", string.Format( "修改管理员[{0}]密码", AdminInfo.fdAdmiAccount ) );
            Response.Write( "<script type=text/javascript>parent.editPasswordOK();</script>" );
            Response.End();
        }
        else
        {
            Fail( "密码修改失败，请稍候再试！", true );
        }
    }
}
