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

/// <summary>
/// Ajax获取更新商品点击数、获取商品点击数、收藏数、评分人数以及得分、评论数
/// </summary>
public partial class Ajax_GoodsInfo : ShopAjaxBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AW_Goods_bean goods = null;
        if( QS("id") != "" && WebAgent.IsInt32(QS("id")))
            goods = (new AW_Goods_dao()).funcGetGoodsAjaxInfo(int.Parse(QS("id")));

        if (goods == null)
            ExecuteFalse(1, "商品不存在");
        else
            ExecuteSucc(goods.fdGoodID.ToString() + "," + goods.fdGoodClickCount.ToString() + "," + goods.fdGoodFavCount.ToString() + "," + goods.fdGoodScoreCount.ToString() + "," + goods.fdGoodScoreAverage.ToString() + "," + goods.fdGoodCommentCount.ToString() + "," + goods.fdGoodStockNum.ToString());

    }
}
