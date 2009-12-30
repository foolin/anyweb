using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Agent;
using Common.Common;

public partial class Controls_PromotionCate : ControlBase
{
    protected override void OnPreRender(EventArgs e)
    {
        repCate.DataSource = new CategoryAgent().GetCategoryList();
        repCate.DataBind();
    }

    protected void repCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        Category c = (Category)e.Item.DataItem;
        Repeater rep2 = (Repeater)e.Item.FindControl("repChiled");
        if (rep2 != null)
        {
            using (CategoryAgent ca = new CategoryAgent())
            {
                rep2.DataSource = ca.GetCategoryChildren(c.ID);
                rep2.DataBind();
            }

        }
    }
}
