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
using Studio.Web;

public partial class Admin_CategoryDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        if (Request.UrlReferrer == null)
            return;

        using (AW_Category_dao dao = new AW_Category_dao())
        {
            AW_Category_bean bean = dao.funcGetCategoryInfo(int.Parse(QS("id")));
            if (bean.Children != null && bean.Children.Count > 0)
                WebAgent.AlertAndBack("该分类存在子分类,不能删除");
            if (dao.funcCheckCategoryExistGoods(bean.fdCateID))
                WebAgent.AlertAndBack("该分类存在商品,不能删除");
            dao.funcDelete(bean.fdCateID);

        }

        Response.Redirect(Request.UrlReferrer == null ? "categorylist.aspx" : Request.UrlReferrer.AbsoluteUri);
    }
}
