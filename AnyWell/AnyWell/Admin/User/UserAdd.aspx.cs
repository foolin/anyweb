using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_User_UserAdd : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {

    }

    protected void btnSave_Click( object sender, EventArgs e )
    {
        AW_Admin_dao dao = new AW_Admin_dao();
        if( dao.funcCheckAccountExists( txtAccount.Text.Trim(), 0 ) )
        {
            Fail( "用户帐号已经存在！", true );
        }
        AW_Admin_bean bean = new AW_Admin_bean();
        bean.fdAdmiID = dao.funcNewID();
        bean.fdAdmiAccount = txtAccount.Text.Trim();
        bean.fdAdmiName = txtName.Text.Trim();
        bean.fdAdmiPwd = Studio.Security.Secure.Md5( txtPassword.Text.Trim() );
        bean.fdAdmiEmail = txtEmail.Text.Trim();
        bean.fdAdmiQQ = txtQQ.Text.Trim();
        bean.fdAdmiMSN = txtMSN.Text.Trim();
        bean.fdAdmiStatus = chkLocked.Checked ? 1 : 0;
        bean.fdAdmiLevel = 1;
        bean.fdAdmiCreateAt = DateTime.Now;
        bean.fdAdmiLoginAt = DateTime.Parse( "1900-01-01" );
        int result = dao.funcInsert( bean );
        if( result > 0 )
        {
            AddLog( EventType.Update, "添加用户", string.Format( "添加用户[{0}]", bean.fdAdmiAccount ) );
            Response.Write( "<script type=text/javascript>parent.addUserOK();</script>" );
            Response.End();
        }
        else
        {
            Fail( "用户添加失败，请稍候再试！", true );
        }
    }
}
