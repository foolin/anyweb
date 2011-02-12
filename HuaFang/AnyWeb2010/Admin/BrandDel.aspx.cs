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


public partial class Admin_BrandDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        if (Request.UrlReferrer == null)
            return;

        using (AW_Brand_dao dao = new AW_Brand_dao())
        {
            AW_Brand_bean bean = dao.funcGetBrandInfo(int.Parse(QS("id")));
            if (bean.Children != null && bean.Children.Count > 0)
                WebAgent.AlertAndBack("该品牌存在子品牌,不能删除");
            dao.funcDelete(bean.fdBranID);
            this.AddLog(EventType.Delete, "删除品牌", "删除品牌[" + bean.fdBranName + "]");
        }
        WebAgent.SuccAndGo("删除成功！", Request.UrlReferrer == null ? "brandlist.aspx" : Request.UrlReferrer.AbsoluteUri);
    }
}
