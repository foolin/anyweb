using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWeb.AW_DL;

public partial class Ajax_GoodsGetPriceByID : ShopAjaxBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.QS("id") == "") Response.End();
        int id = int.Parse(this.QS("id"));
        AW_Goods_bean goods = AW_Goods_bean.funcGetByID(id);
        if (goods != null)
        {
            float price = 0;
            if (goods.fdGoodIsPromotion == 1)
            {
                if ((goods.fdGoodPromStartAt < DateTime.Now) && (goods.fdGoodPromEndAt > DateTime.Now.AddDays(-1)))
                {
                    price = goods.fdGoodPromPrice;
                }
            }
            else
            {
                price = goods.fdGoodSalePrice;
            }
            this.ExecuteSucc(price.ToString());
        }
        else
        {
            this.ExecuteFalse(1, "不存在该商品");
        }
    }
}
