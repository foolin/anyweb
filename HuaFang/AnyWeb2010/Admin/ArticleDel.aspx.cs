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

public partial class Admin_ArticleDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        string id = QS("id");
        string url = Request.UrlReferrer == null ? "ArticleList.aspx" : Request.UrlReferrer.AbsoluteUri;
        if (String.IsNullOrEmpty(id) || !Studio.Web.WebAgent.IsInt32(id))
        {
            WebAgent.AlertAndBack("文章编号错误！");
            Response.Redirect(url);
        }
        AW_Article_bean bean = AW_Article_bean.funcGetByID(int.Parse(QS("id")));
        if (bean == null)
        {
            WebAgent.AlertAndBack("文章不存在！");
        }
        int record = new AW_Article_dao().funcDelete(bean.fdArtiID);
        if (record > 0)
        {
            this.AddLog(EventType.Delete, "删除文章", "删除文章[" + bean.fdArtiTitle + "]");
            Studio.Web.WebAgent.SuccAndGo("删除成功", url);
        }
    }
}
