using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class Admin_ShopStat : PageAdmin
{
    public int OrderCount = 0;       //订单数
    public float GoodsPrice = 0;//订单销售金额总和
    public float PayPrice = 0;  //订单付款金额总和
    
    //public float StockPriceCount = 0;//商品进货总价
    //public float Earnings = 0;       //收益总和

    protected override void OnPreRender(EventArgs e)
    {
        if (this.QS("status") != "")
        {
            this.drpStatus.SelectedValue = this.QS("status");
        }

        if (this.QS("startDate") != "")
        {
            this.txtStartDate.Text = this.QS("startDate");
        }

        if (this.QS("endDate") != "")
        {
            this.txtEndDate.Text = this.QS("endDate");
        }

        using (AW_Order_dao dao = new AW_Order_dao())
        {
            string sqlCount = " SELECT count(*) AS OrderCount FROM AW_Order";
            string sqlGoods = " SELECT SUM(fdOrdeGoodsPrice) AS GoodsPriceCount FROM AW_Order";
            string sqlPayment = " SELECT SUM(fdOrdeGoodsPrice) AS PayPriceCount FROM AW_Order WHERE fdOrdeStatus BETWEEN 2 AND 4";

            string sqlWhere = "";
            if (this.drpStatus.SelectedValue != "0")
            {
                sqlWhere += " AND fdOrdeStatus = " + this.drpStatus.SelectedValue;
            }

            if (this.txtStartDate.Text != "")
            {
                sqlWhere += " AND fdOrdeCreateAt >= '" + this.txtStartDate.Text + "'";
            }

            if (this.txtEndDate.Text != "")
            {
                sqlWhere += " AND fdOrdeCreateAt <= '" + this.txtEndDate.Text + "'";
            }

            if (sqlWhere != "")
            {
                sqlCount += " WHERE 1=1 " + sqlWhere;
                sqlGoods += " WHERE 1=1 " + sqlWhere;
                sqlPayment += sqlWhere;
            }

            DataSet ds = dao.funcGet(sqlCount + sqlGoods + sqlPayment);

            if (ds.Tables.Count == 3)
            {
                object countValue, goodsValue, paymentValue;
                countValue = (int)ds.Tables[0].Rows[0]["OrderCount"];
                goodsValue = ds.Tables[1].Rows[0]["GoodsPriceCount"];
                paymentValue = ds.Tables[2].Rows[0]["PayPriceCount"];

                this.OrderCount = Convert.IsDBNull(countValue) ? 0 : (int)countValue;
                this.GoodsPrice = Convert.IsDBNull(goodsValue) ? 0 : float.Parse(goodsValue.ToString());
                this.PayPrice = Convert.IsDBNull(paymentValue) ? 0 : float.Parse(paymentValue.ToString());
            }

        }
    }

}