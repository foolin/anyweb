using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_User_UserEdit : PageAdmin
{
    AW_Admin_bean bean;
    protected void Page_Load( object sender, EventArgs e )
    {
        int id = 0;
        int.TryParse( QS( "id" ), out id );
        if( id == 0 )
        {
            Fail( "用户不存在！" );
        }
        bean = new AW_Admin_dao().funcGetAdminInfo( id );
        if( bean == null )
        {
            Fail( "用户不存在！" );
        }

        if( !IsPostBack )
        {
            lblAccount.Text = bean.fdAdmiAccount;
            txtName.Text = bean.fdAdmiName;
            txtEmail.Text = bean.fdAdmiEmail;
            txtQQ.Text = bean.fdAdmiQQ;
            txtMSN.Text = bean.fdAdmiMSN;
            chkLocked.Checked = bean.fdAdmiStatus == 1 ? true : false;
        }
    }

    protected void btnSave_Click( object sender, EventArgs e )
    {
        if( bean.fdAdmiID == AdminInfo.fdAdmiID && chkLocked.Checked )
        {
            Fail( "不能锁定自己的帐号！", true );
        }

        bean.fdAdmiName = txtName.Text.Trim();
        bean.fdAdmiEmail = txtEmail.Text.Trim();
        bean.fdAdmiQQ = txtQQ.Text.Trim();
        bean.fdAdmiMSN = txtMSN.Text.Trim();
        bean.fdAdmiStatus = chkLocked.Checked ? 1 : 0;
        if( !string.IsNullOrEmpty( txtPassword.Text.Trim() ) )
        {
            bean.fdAdmiPwd = Studio.Security.Secure.Md5( txtPassword.Text.Trim() );
        }
        int result = new AW_Admin_dao().funcUpdate( bean );
        if( result > 0 )
        {
            AddLog( EventType.Update, "修改用户", string.Format( "修改用户[{0}]", bean.fdAdmiAccount ) );
            Response.Write( "<script type=text/javascript>parent.editUserOK();</script>" );
            Response.End();
        }
        else
        {
            Fail( "用户修改失败，请稍候再试！", true );
        }
    }
}
