using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Common;
using Common.Agent;

public partial class Controls_RecommentGoods : ControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        Category c = (Category)Context.Items["CATEGORY"];
        int cateID = 0;
        if (c == null)
        {
            litTitle.Text = "热荐商品";
        }
        else
        {
            litTitle.Text = c.Name;
            cateID = c.ID;
        }
        int record = 0;
        repGoods.DataSource = new GoodsAgent().GetRecommentGoods(cateID, PN1.PageSize, PN1.PageIndex, out record);
        repGoods.DataBind();
        PN1.SetPage(record);
    }
}
