using System;
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
using AnyWeb.AW_DL;
using AnyWeb.AW_DL;
using AnyWeb.AW.Configs;


public partial class Admin_OrderDetails : PageAdmin
{
    public AW_Order_bean Order;

    protected void Page_Load(object sender, EventArgs e)
    {
        string id = QS("id");
        if (!WebAgent.IsInt32(id)) WebAgent.AlertAndBack("编号不正确!");

        this.Order = AW_Order_bean.funcGetByID(int.Parse(QS("id")));

        if (this.Order == null) WebAgent.AlertAndBack("该订单不存在!");

        //绑定订单项
        this.Order.Items = (new AW_Order_Item_dao()).funcGetListByOrderID(this.Order.fdOrdeID);
        this.repGoods.DataSource = this.Order.Items;
        this.repGoods.DataBind();
    }
}