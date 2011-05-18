using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Person_InfoEdit : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( !IsPostBack )
        {
            lblAccount.Text = AdminInfo.fdAdmiAccount;
            txtName.Text = AdminInfo.fdAdmiName;
            txtEmail.Text = AdminInfo.fdAdmiEmail;
            txtQQ.Text = AdminInfo.fdAdmiQQ;
            txtMSN.Text = AdminInfo.fdAdmiMSN;
        }
    }

    protected void btnSave_Click( object sender, EventArgs e )
    {
        AdminInfo.fdAdmiName = txtName.Text.Trim();
        AdminInfo.fdAdmiEmail = txtEmail.Text.Trim();
        AdminInfo.fdAdmiQQ = txtQQ.Text.Trim();
        AdminInfo.fdAdmiMSN = txtMSN.Text.Trim();
        int result = new AW_Admin_dao().funcUpdate( AdminInfo );
        if( result > 0 )
        {
            AddLog( EventType.Update, "修改个人资料", string.Format( "修改管理员[{0}]个人资料", AdminInfo.fdAdmiAccount ) );
            Response.Write( "<script type=text/javascript>parent.editInfoOK();</script>" );
            Response.End();
        }
        else
        {
            Fail( "个人资料修改失败，请稍候再试！", true );
        }
    }
}
