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

public partial class Shop_Admin_Desktop : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        //未回复商品评论条数
        ltlNoReplyCount.Text = new AW_Goods_Comment_dao().funcCommentNotReplyCount().ToString();

        //最新订单数量
        ltlNewOrderCount.Text = new AW_Order_dao().funcGetNewOrderCount().ToString();

        //最近3个月内订单总数量
        ltlTop3MonthOrderCount.Text = new AW_Order_dao().funcGetTop3MonthOrderCount().ToString();

        //库存不足商品数量
        ltlStockNotEnoughCount.Text = new AW_Goods_dao().funcStockNotEnoughCount().ToString();

    }

}
