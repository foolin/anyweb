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

public partial class Admin_CommentDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        string ids = Request.Form["ids"];
        if (!String.IsNullOrEmpty(ids))
        {
            new AW_Goods_Comment_dao().funcDeletes(ids);
        }
        Response.Redirect(Request.UrlReferrer == null ? "CommentList.aspx" : Request.UrlReferrer.AbsoluteUri);
    }
}
