﻿using System;
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
using Common.Agent;
using Common.Common;

public partial class Search : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (!string.IsNullOrEmpty(QS("keywords")))
        {
            string keywords = QS("keywords");
            int record = 0;
            repGoods.DataSource = new GoodsAgent().GetGoodsBySearch(PN1.PageSize, PN1.PageIndex, keywords, out record);
            repGoods.DataBind();
            PN1.SetPage(record);
            litKeywords.Text = keywords;
            litRecord.Text = record.ToString();

        }
        else
        {
            WebAgent.FailAndGo("请输入搜索关键词！", "index.aspx");
        }
    }

    public string GetGoodCount(int status)
    {
        switch (status)
        {
            case 1:
                return "有货";
            case 2:
                return "缺货";
            case 3:
                return "过期";
            default:
                return "缺货";
        }
    }


}
