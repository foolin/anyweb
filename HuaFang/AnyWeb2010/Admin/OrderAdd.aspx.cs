using System;
using System.Drawing;
using System.IO;
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
using Studio.Web;
using AnyWell.AW_DL;
using AnyWell.AW_DL;
using AnyWell.Configs;


public partial class Admin_OrderAdd : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.btnOk.Attributes["onclick"] = "return check();";
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        using (AW_Order_dao order_dao = new AW_Order_dao())
        {
            AW_Order_bean order = new AW_Order_bean();
            order.fdOrdeID = order_dao.funcNewID();
            //订单编号（保证唯一，用当前时间ToString("yyyyMMddHHmmss")加上4位随机数）
            order.fdOrdeNO = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2")
                           + DateTime.Now.Hour.ToString("D2") + DateTime.Now.Minute.ToString("D2") + DateTime.Now.Second.ToString("D2");
            Random r = new Random();
            for (int i = 0; i < 4; i++)
            {
                order.fdOrdeNO += r.Next(0, 10).ToString();
            }
            order.fdOrdeMemberID = int.Parse(this.txtMemberID.Text);
            order.fdOrdePayModeID = int.Parse(this.QF("rdPayMode"));
            order.fdOrdeDeliverModeID = int.Parse(this.QF("rdDeliverMode"));
            order.fdOrdeUserProvinceID = int.Parse(this.QF("drpProvince"));
            order.fdOrdeUserCityID = int.Parse(this.QF("drpCity"));
            order.fdOrdeUserAreaID = int.Parse(this.QF("drpArea"));
            order.fdOrdeUserAddress = this.txtAddr.Text;
            order.fdOrdeUserName = this.txtUserName.Text;
            order.fdOrdeUserPostcode = this.txtPostcode.Text;
            order.fdOrdeUserPhone = this.txtPhone.Text;
            //判断是否需要发票，并且添加发票抬头
            if (this.QF("drpIsInvoice") == "1")
            {
                order.fdOrdeInvoiceTitle = this.txtInvoiceTitle.Text;
            }
            order.fdOrderNote = this.txtNote.Text;
            order.fdOrdeGoodsPrice = float.Parse(this.QF("totalPrice"));
            order.fdOrdeDeliverPrice = float.Parse(this.QF("txtDeliverPrice"));
            order.fdOrdePayPrice = order.fdOrdeGoodsPrice + order.fdOrdeDeliverPrice;
            order_dao.funcInsert(order);

            //添加订单项
            using (AW_Order_Item_dao item_dao = new AW_Order_Item_dao())
            {
                AW_Order_Item_bean item = new AW_Order_Item_bean();
                for (int j = 1; j <= int.Parse(this.QF("goodsCount")); j++)
                {
                    //先判断是否存在该商品，因为有可能已被删除或者根本没有输入值
                    if (this.QF("txtGoodsID" + j) != "")
                    {
                        item.fdItemID = item_dao.funcNewID();
                        item.fdItemOrderID = order.fdOrdeID;
                        item.fdItemGoodsID = int.Parse(this.QF("txtGoodsID" + j));
                        item.fdItemGoodsPrice = float.Parse(this.QF("txtPrice" + j));
                        item.fdItemQuantity = int.Parse(this.QF("txtQuantity" + j));
                        item_dao.funcInsert(item);
                    }
                }
            }
            WebAgent.SuccAndGo("订单添加成功", "OrderList.aspx");
        }
    }
}
