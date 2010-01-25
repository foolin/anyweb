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
using Studio.Web;
using AnyWeb.AW_DL;
using AnyWeb.AW_DL;

public partial class Admin_GoodsDel : ShopAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        if (Request.UrlReferrer == null)
            return;

        using (AW_Goods_dao dao = new AW_Goods_dao())
        {
            AW_Goods_bean bean = AW_Goods_bean.funcGetByID(int.Parse(QS("id")));

            if (bean == null)
                WebAgent.AlertAndBack("商品不存在");

            if (dao.funcCheckGoodsExistOrderItem(bean.fdGoodID))
                WebAgent.AlertAndBack("商品存在订单,不能删除");

            dao.funcDelete(bean.fdGoodID);
        }

        Response.Redirect(Request.UrlReferrer == null ? "goodslist.aspx" : Request.UrlReferrer.AbsoluteUri);
    }
}
