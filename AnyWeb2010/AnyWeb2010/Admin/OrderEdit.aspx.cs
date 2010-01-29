using System;
using System.IO;
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
using AnyWeb.AW.Configs;


public partial class Admin_OrderEdit : PageAdmin
{
    public AW_Order_bean Order;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.drpStatus.Attributes["onchange"] = "showDetails(this.value);";

        string id = QS("id");
        if (!WebAgent.IsInt32(id)) WebAgent.AlertAndBack("编号不正确!");

        this.Order = AW_Order_bean.funcGetByID(int.Parse(QS("id")));

        if (this.Order == null) WebAgent.AlertAndBack("该订单不存在!");
    }

    protected override void OnPreRender(EventArgs e)
    {
        //绑定所有控件
        this.txtPayPrice.Text = this.Order.fdOrdePayPrice.ToString();
        this.txtRemark.Text = this.Order.fdOrdeRemark;
        this.drpStatus.SelectedValue = this.Order.fdOrdeStatus.ToString();
        this.txtPayAt.Text = this.Order.fdOrdePayAt.ToString().IndexOf("1900") >= 0 ? DateTime.Now.Date.ToShortDateString() : this.Order.PayAtDate;
        this.txtDeliverTime.Text = this.Order.fdOrdeDeliverTime.ToString().IndexOf("1900") >= 0 ? DateTime.Now.Date.ToShortDateString() : this.Order.DeliverDate;
        this.txtCancelReson.Text = this.Order.fdOrdeCancelReson;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        using (AW_Order_dao dao = new AW_Order_dao())
        {
            this.Order.fdOrdePayPrice = float.Parse(this.txtPayPrice.Text);
            this.Order.fdOrdeRemark = this.txtRemark.Text;

            int oldStatus = this.Order.fdOrdeStatus;
            int newStatus = int.Parse(this.drpStatus.SelectedValue);

            //订单状态是否改变
            bool isStatusChange = oldStatus != newStatus;

            //是否需要改变积分
            bool isPointChange = false;

            //改变积分 加或减
            bool isAdd = false;

            if (

                   ( oldStatus == 1 && newStatus != oldStatus && (newStatus == 2 || newStatus == 3 || newStatus == 4)) //状态1到2、3、4加积分
                || ((oldStatus == 2 || oldStatus == 3 || oldStatus == 4) && (newStatus != 2 && newStatus != 3 && newStatus != 4)) //状态2、3、4到非2、3、4减积分
                || ((oldStatus == 5 || oldStatus == 6 || oldStatus == 7) && (newStatus != 1 &&  newStatus != 5 && newStatus != 6 && newStatus != 7)) //从状态5、6、7到非1、5、6、7加积分
                
            )
            {
                //有变化
                isPointChange = true;

                isAdd = (newStatus == 2 || newStatus == 3 || newStatus == 4);

            }

            this.Order.fdOrdeStatus = newStatus;

            
            if (newStatus == 2)
            {
                //付款时间(已支付待发货)
                this.Order.fdOrdePayAt = Convert.ToDateTime(this.txtPayAt.Text.Trim());
            }

            if (newStatus == 3)
            {
                //发货时间(已发货待确认)
                this.Order.fdOrdeDeliverTime = Convert.ToDateTime(this.txtDeliverTime.Text.Trim());
            }

            string msg = "修改订单成功!";

            if (isPointChange)
            { 
                //改变用户积分
                int addPoint = UpdateMemberPoint(isAdd);

                msg += "已" + (isAdd ? "增加" : "减少") + System.Math.Abs(addPoint) + "会员积分。";
            }
            
            dao.funcUpdate(this.Order);
            WebAgent.SuccAndGo(msg, "OrderList.aspx");
        }
    }

    /// <summary>
    /// 更改用户积分
    /// </summary>
    private int UpdateMemberPoint(bool isAdd)
    {

        int addPoint = 0;
        System.Collections.Generic.List<AW_Order_Item_bean> itemList = new AW_Order_Item_dao().funcGetListByOrderID(this.Order.fdOrdeID);
        foreach (AW_Order_Item_bean item in itemList)
        {
            addPoint += item.Goods.fdGoodPoint * item.fdItemQuantity ;
        }

        using (AW_Member_dao member_dao = new AW_Member_dao())
        {
            AW_Member_bean member = AW_Member_bean.funcGetByID(this.Order.fdOrdeMemberID);
            if (!isAdd)
            {
                //减积分
                addPoint = -addPoint;
            }
            member.fdMembPoint = member.fdMembPoint + addPoint;
            member_dao.funcUpdate(member);
        }
        return addPoint;
    }
}