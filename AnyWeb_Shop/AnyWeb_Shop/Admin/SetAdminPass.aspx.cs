using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Studio.Web;
using Admin.Framework;
using Studio.Security;
using Common.Common;

public partial class SetAdminPass : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {

    }

    protected void ods3_Updated(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Update , "修改登陆密码" , "修改登陆密码" );
            
            WebAgent.SuccAndGo( "修改成功。" , "SetAdminPass.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "修改失败。" , "SetAdminPass.aspx" );
        }
       
    }

    protected void ods3_Updating(object sender , ObjectDataSourceMethodEventArgs e)
    {
        Shop s=(Shop)e.InputParameters[0];

        HiddenField hidAdminpass = (HiddenField)this.fv1.FindControl( "hidAdminpass" );
        TextBox txtUserPwd = (TextBox)this.fv1.FindControl( "txtUserPwd" );

        if ( hidAdminpass != null && txtUserPwd != null )
        {
            s.AdminPass = txtUserPwd.Text == "" ? hidAdminpass.Value : Secure.Md5( txtUserPwd.Text );
            
        }
    }
}
