using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Shop_Admin_Login : System.Web.UI.Page
{
    protected void submit_Click(object sender, EventArgs e)
    {
        if( Session[ "CHECK_CODE" ] == null )
        {
            WebAgent.FailAndGo( "验证码输入错误！", "/Admin/Login.aspx" );
        }
        string code = Session["CHECK_CODE"].ToString();
        if (txtCode.Text.ToLower() != code)
        {
            WebAgent.AlertAndBack("验证码输入错误！");
        }
        using( AW_Admin_dao dao = new AW_Admin_dao() )
        {
            int adminId = dao.funcLogin( txtUserName.Text, txtPassword.Text );
            if( adminId == -1 )
            {
                WebAgent.AlertAndBack( "帐号已锁定" );
            }
            if( adminId > 0 )
            {
                this.AddLog( adminId, "管理登录", "管理员帐号" + txtUserName.Text + "登录成功" );
                Response.Redirect( "index.aspx" );
            }
            else
                WebAgent.AlertAndBack( "帐号或密码错误" );
        }
    }

    /// <summary>
    /// 添加操作日志
    /// </summary>
    /// <param name="account"></param>
    /// <param name="name"></param>
    /// <param name="description"></param>
    protected void AddLog(int adminId,string name, string description)
    {
        using (AW_Log_dao dao = new AW_Log_dao())
        {
            AW_Log_bean log = new AW_Log_bean();
            log.fdLogID = dao.funcNewID();
            log.fdLogType = (int)EventType.Login;
            log.fdLogName = name;
            log.fdLogDesc = description;
            log.fdLogAdminID = adminId;
            log.fdLogIP = Request.UserHostAddress;
            log.fdLogCreateAt = DateTime.Now;
            dao.funcInsert(log);
        }
    }
}
