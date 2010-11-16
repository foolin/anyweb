using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.Configs;
using Studio.Web;
using AnyWell.AW_DL;
using Studio.Security;

public partial class User_MemModifyPwd : PageUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            using (AW_User_dao dao = new AW_User_dao())
            {
                if( Secure.Md5( txtOldPwd.Text.Trim() ) == this.LoginUser.fdUserPwd )
                    this.LoginUser.fdUserPwd = Secure.Md5( txtNewPwd1.Text.Trim() );
                else
                    WebAgent.AlertAndBack( "旧密码不正确，请重新输入！" );
                dao.funcUpdate( this.LoginUser );
                WebAgent.SuccAndGo( "保存成功！", "/User/MemModifyPwd.aspx" );
            }
        }

        this.Title = "密码管理" + GeneralConfigs.GetConfig().TitleExtension;
    }
}
