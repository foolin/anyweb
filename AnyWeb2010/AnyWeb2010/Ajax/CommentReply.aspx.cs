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
using AnyWeb.AW_DL;

public partial class Ajax_CommentReply : ShopAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

        int record = 0;
        string id = QS("id");
        string reply = Request.Form["reply"];
        if ( Studio.Web.WebAgent.IsInt32(id) )
        {
            record = new AW_Goods_Comment_dao().funcCommentReply(int.Parse(id),HttpUtility.UrlDecode( reply) );
        }
        Response.Clear();
        Response.Write(record);
        Response.End();
    }
}
