using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_ArticleSort : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
        Response.AppendHeader("Pragma", "No-Cache");

        int articleId = 0;
        int previewId = 0;
        int nextId = 0;

        if (QS("id") != "" && WebAgent.IsInt32(QS("id")))
            articleId = int.Parse(QS("id"));

        if (QS("previewid") != "" && WebAgent.IsInt32(QS("previewid")))
            previewId = int.Parse(QS("previewid"));

        if (QS("nextid") != "" && WebAgent.IsInt32(QS("nextid")))
            nextId = int.Parse(QS("nextid"));

        if (articleId > 0 && (previewId > 0 || nextId > 0))
        {
            using (AW_Article_dao dao = new AW_Article_dao())
            {
                dao.funcSortArticle(articleId, nextId, previewId);
                Response.Write("ok");
            }
        }
        else
        {
            Response.Write("parmaters null");
        }
    }
}
