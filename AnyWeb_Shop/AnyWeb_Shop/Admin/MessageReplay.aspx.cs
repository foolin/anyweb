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

public partial class MessageReplay : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {

    }
    protected void ods3_Updated(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( Common.Common.EventID.Update , "回复留言" , "回复留言,留言编号：" + QS("mid") );

            WebAgent.SuccAndGo("回复成功.","MessageList.aspx");
        }
    }
}
