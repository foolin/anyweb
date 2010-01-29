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
using System.Collections.Generic;

public partial class Admin_GoodsSet : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        if (IsPostBack) return;

        string action = QS("action"), status = QS("status"), ids = QF("ids");
        string refer = Request.UrlReferrer == null ? "GoodsList.aspx" : Request.UrlReferrer.AbsoluteUri;
        if (ids == "" || !WebAgent.IsInt32(status))
        {
            Response.Redirect(refer);
        }
        switch (action)
        {
            case "del":
                List<AW_Order_Item_bean> list = new AW_Order_Item_dao().funcGetListByGoodsIds(ids);
                if (list.Count > 0)
                {
                    //商品存在订单
                    System.Text.StringBuilder strbuilder = new System.Text.StringBuilder();
                    foreach (AW_Order_Item_bean bean in list)
                    {
                        strbuilder.AppendFormat("编号为{0}的商品已存在于订单[编号fdOrdeID为{1}],\\n", bean.fdItemGoodsID, bean.fdItemOrderID);
                    }
                    strbuilder.Append("系统不能删除!");
                    WebAgent.FailAndGo(strbuilder.ToString(), refer);
                }
                else
                {
                    new AW_Goods_dao().funcDeletes(ids);
                    WebAgent.SuccAndGo("删除成功！", refer);
                }
                break;
            case "status":
                new AW_Goods_dao().funcSetStatus(ids, int.Parse(status));
                WebAgent.SuccAndGo("设置成功！", refer);
                break;
            case "recommend":
                new AW_Goods_dao().funcSetRecommend(ids, int.Parse(status));
                WebAgent.SuccAndGo("设置成功！", refer);
                break;
            case "promotion":
                if (status == "1")
                {
                    //促销
                    linkRefer.NavigateUrl = refer;
                    repGoodses.DataSource = new AW_Goods_dao().funcGetGoodsByIDs(ids);
                    repGoodses.DataBind();
                }
                else
                {
                    //取消促销
                    new AW_Goods_dao().funcSetPromotion(ids);
                    WebAgent.SuccAndGo("取消促销成功！", refer);
                }
                break;
            default:
                Response.Redirect(refer);
                break;
        }
    }

    public void btnSave_Click(object source, EventArgs e)
    {
        List<AW_Goods_bean> list = new List<AW_Goods_bean>();
        foreach (RepeaterItem item in repGoodses.Items)
        {
            string goodsId = ((Label)item.FindControl("lblGoodsId")).Text;
            TextBox txtPromPrice = (TextBox)item.FindControl("txtPromPrice");
            TextBox txtPromStartAt = (TextBox)item.FindControl("txtPromStartAt");
            TextBox txtPromEndAt = (TextBox)item.FindControl("txtPromEndAt");
            float promPrice = 0;
            if (float.TryParse(txtPromPrice.Text, out promPrice) == false)
            {
                AlertScript("产品编号为" + goodsId + "的促销价格不正确！");
                txtPromPrice.Focus();
                return;
            }
            DateTime promStartAt = DateTime.MinValue, promEndAt = DateTime.MinValue;
            if (DateTime.TryParse(txtPromStartAt.Text, out promStartAt) == false)
            {
                AlertScript("产品编号为" + goodsId + "的促销开始时间不正确！");
                txtPromStartAt.Focus();
                return;
            }
            if (DateTime.TryParse(txtPromEndAt.Text, out promEndAt) == false)
            {
                AlertScript("产品编号为" + goodsId + "的促销结束时间不正确！");
                txtPromEndAt.Focus();
                return;
            }
            AW_Goods_bean bean = AW_Goods_bean.funcGetByID(goodsId);
            if (bean != null)
            {
                bean.fdGoodIsPromotion = 1;
                bean.fdGoodPromPrice = promPrice;
                bean.fdGoodPromStartAt = promStartAt;
                bean.fdGoodPromEndAt = promEndAt;
                list.Add(bean);
            }
        }
        foreach (AW_Goods_bean bean in list)
        {
            new AW_Goods_dao().funcUpdate(bean);
        }
        WebAgent.SuccAndGo("设置促销成功！", linkRefer.NavigateUrl);
    }

    protected void AlertScript(string msg)
    {
        ClientScript.RegisterStartupScript(this.GetType(), DateTime.Now.Ticks.ToString(), "alert('" + msg + "');", true);
    }

}
