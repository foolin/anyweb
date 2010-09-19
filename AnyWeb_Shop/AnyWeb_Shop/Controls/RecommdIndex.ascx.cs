﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Common;
using Common.Agent;
using System.Collections;

public partial class Controls_RecommdIndex : ControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        ArrayList list = new GoodsAgent().GetRecommentGoodsByIndex();
        if (list.Count > 12)
        {
            list = list.GetRange(0, 11);
        }
        repRecomment.DataSource = list;
        repRecomment.DataBind();
    }

    protected void repCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Category c = (Category)e.Item.DataItem;
        Repeater repgood = (Repeater)e.Item.FindControl("repGood");
        if (repgood != null)
        {
            List<Goods> list = new List<Goods>();
            if (c.RecommentList.Count > 0)
            {
                list.Add(c.RecommentList[0]);
                repgood.DataSource = list;
                repgood.DataBind();
            }
        }
        if (c.RecommentList.Count > 1)
        {
            Repeater replist = (Repeater)e.Item.FindControl("repList");
            if (replist != null && c.RecommentList.Count > 1)
            {
                if (c.RecommentList.Count < 3)
                {
                    replist.DataSource = c.RecommentList.GetRange(1, c.RecommentList.Count - 1);
                    replist.DataBind();
                }
                else
                {
                    replist.DataSource = c.RecommentList.GetRange(1, 2);
                    replist.DataBind();
                }
            }
        }
    }
}