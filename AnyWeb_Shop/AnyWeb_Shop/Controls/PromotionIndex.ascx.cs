using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Agent;
using Common.Common;

public partial class Controls_PromotionIndex : ControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        repRecomment.DataSource = new GoodsAgent().GetPromotGoodsByIndex();
        repRecomment.DataBind();
    }

    protected void repCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Category c = (Category)e.Item.DataItem;
        Repeater repgood = (Repeater)e.Item.FindControl("repGood");
        if (repgood != null)
        {
            List<Goods> list = new List<Goods>();
            if (c.PromotionList.Count > 0)
            {
                list.Add(c.PromotionList[0]);
                repgood.DataSource = list;
                repgood.DataBind();
            }
        }
        if (c.PromotionList.Count > 1)
        {
            Repeater replist = (Repeater)e.Item.FindControl("repList");
            if (replist != null && c.PromotionList.Count > 1)
            {
                replist.DataSource = c.PromotionList.GetRange(1, c.PromotionList.Count - 1);
                replist.DataBind();
            }
        }
    }
}
