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

public partial class _Default : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected override void OnPreRender(EventArgs e)
    {
        this.LoginUserTips.Text = "欢迎" + this.LoginUser.UserName + "(" +this.LoginUser.UserAcc + ")进入系统管理后台！";
    }
}
