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
using Admin.Framework;
using Studio.Web;
using Common.Agent;

public partial class User_DeleteUser :AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected override void OnPreRender(EventArgs e)
    {
        if (WebAgent.IsInt32(QS("userid")))
        {
            
            if (QS("type") == "2")
            {
                (new UserAgent()).UpdateUserStatus(int.Parse(QS("userid")), 2);
                WebAgent.SuccAndGo("删除成功", ViewState["BACK"].ToString());
            }
            if (QS("type") == "0")
            {
                (new UserAgent()).UpdateUserStatus(int.Parse(QS("userid")), 0);
                WebAgent.SuccAndGo("恢复成功", ViewState["BACK"].ToString());
            }
            
        }
        
    }

    protected void btnSave_Click(object sender , EventArgs e)
    {
        if (WebAgent.IsInt32(QS("userid")))
        {
            if (QS("type") == "1")
            {

                if ( ( new UserAgent() ).SetFreezeUser( int.Parse( QS( "userid" ) ) , txtReason.Text ) > 0 )
                {
                    WebAgent.SuccAndGo( "冻结成功" , "UserList.aspx" );
                }
            }
        }
    }
}
