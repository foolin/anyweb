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


public partial class Admin_CategorySort : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        if (Request.UrlReferrer == null)
            return;

        string type = QS("type");
        int cateID = int.Parse(QS("id"));
        AW_Category_dao dao = new AW_Category_dao();
        AW_Category_bean category = AW_Category_bean.funcGetByID(cateID);
        if (category == null)
        {
            return;
        }
        if (type == "up")
        {
            if (!dao.funcUp(cateID))
                WebAgent.AlertAndBack("已经是最前了");
        }
        else if (type == "down")
        {
            if (!dao.funcDown(cateID))
                WebAgent.AlertAndBack("已经是最后了");
        }
        this.AddLog(EventType.Update, "修改分类排序", "修改分类[" + category.fdCateName + "]排序");
        Response.Redirect(Request.UrlReferrer == null ? "categorylist.aspx" : Request.UrlReferrer.AbsoluteUri);
    }
}
