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
using Common.Common;
using Common.Agent;
using Studio.Web;

public partial class MessageList : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
        btnDel.Attributes["onclick"] = "javascript:return confirm('确定删除,是否继续？');";
       
    }
    protected void ods3_Selected(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( e.OutputParameters["recordCount"] != null )
        {
            PN1.SetPage( (int)e.OutputParameters["recordCount"] );
        }
    }

    protected void btnDel_Click(object sender , EventArgs e)
    {

        if ( Request.Form["ids"] + "" != "" )
        {
            using ( MessageAgent ma=  new MessageAgent())
            {

                ma.DeleteMessage( Request.Form["ids"] , Request.Form["ids"].Split( ',' ).Length );

                this.AddLog( Common.Common.EventID.Delete , "批量删除留言" , "批量删除留言" );

                WebAgent.SuccAndGo( "删除成功。" , "MessageList.aspx" );
            }
        }
        else
        {
            WebAgent.FailAndGo( "请在要删除的项前打勾。" , "MessageList.aspx" );
        }
    }
}
