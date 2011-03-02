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

public partial class Admin_BrandSort : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        if (Request.UrlReferrer == null)
            return;

        string type = QS("type");
        int brandID = int.Parse(QS("id"));
        AW_Brand_dao dao = new AW_Brand_dao();
        AW_Brand_bean brand = AW_Brand_bean.funcGetByID(brandID);
        if (brand == null)
        {
            return;
        }
        if (type == "up")
        {
            if (!dao.funcUp(brandID))
                WebAgent.AlertAndBack("已经是最前了");
        }
        else if (type == "down")
        {
            if (!dao.funcDown(brandID))
                WebAgent.AlertAndBack("已经是最后了");
        }
        this.AddLog(EventType.Update, "修改品牌排序", "修改品牌[" + brand.fdBranName + "]排序");
        Response.Redirect(Request.UrlReferrer == null ? "brandlist.aspx" : Request.UrlReferrer.AbsoluteUri);
    }
}
