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
            this.LoginUser.fdUserEmail = txtEmail.Text.Trim();
            new AW_User_dao().funcUpdate( this.LoginUser );
            WebAgent.SuccAndGo( "保存成功！", "/User/MemModifyEmail.aspx" );
        }
    }
}
