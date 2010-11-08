using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;
using AnyWell.Configs;

public partial class AnyWell_GetPassword : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( IsPostBack )
        {
            using( AW_User_dao dao = new AW_User_dao() )
            {
                int userid = dao.funcGetUserId( txtName.Text.Trim(), txtEmail.Text.Trim() );
                if( userid == 0 )
                {
                    WebAgent.AlertAndBack( "用户名和Email不匹配，请重新输入！" );
                }
                string code = DL_helper.funcGetTicks().ToString();
                DateTime date = DateTime.Now;
                if( dao.funcGetPassword( userid, code, date ) )
                {
                    string html = string.Format( "<DIV>杰信人力资源--找回密码（重要）！<BR /><BR />重设密码地址：<A href=\"http://{0}/resetpwd.aspx?c={1}&u={2}\">http://{0}/resetpwd.aspx?c={1}&u={2}</A>,马上重设密码(三天内有效)！<BR /><BR />如果您没有进行过找回密码的操作，请不要点击上述链接，并删除此邮件。 </DIV>", Request.Url.Authority, code, txtName.Text.Trim() );
                    SmtpAgent.GetAgent().SendMail( txtEmail.Text.Trim(), "杰信人力资源--找回密码（重要）！", html, true, "" );
                    WebAgent.SuccAndGo( "找回密码的方法已经通过 Email 发送到您的信箱中，请在 3 天之内修改您的密码。", "/GetPassword.aspx" );
                }
                else
                {
                    WebAgent.AlertAndBack( "系统繁忙，请稍候再试！" );
                }
            }
        }
    }
}
