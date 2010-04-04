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
    public string keywords = "请输入关键词";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (!string.IsNullOrEmpty(QS("keywords")) && QS("keywords") != "请输入关键词")
        {
            int record = 0;
            int categoryId = 0;
            float lowPrice = 0f;
            float highPrice = 99999999f;

            keywords = QS("keywords");
            if (keywords.Contains("%"))
            {
                keywords = keywords.Replace("%", "[%]");
            }
            if (keywords.Contains("'"))
            {
                keywords = keywords.Replace("'", "''");
            }
            if (!string.IsNullOrEmpty(QS("category")) || (!string.IsNullOrEmpty(QS("lowprice")) && !string.IsNullOrEmpty(QS("highprice"))))
            {
                if (!int.TryParse(QS("category").ToString(), out categoryId))
                {
                    categoryId = 0;
                }
                if (!float.TryParse(QS("lowPrice").ToString(), out  lowPrice))
                {
                    lowPrice = 0f;
                }
                if (!float.TryParse(QS("highPrice").ToString(), out  highPrice))
                {
                    highPrice = 99999999f;
                }
                if (highPrice < lowPrice)
                {
                    WebAgent.FailAndGo("请输入的价格范围：最高价格(" + highPrice.ToString() + ")＜最低价格(" + lowPrice.ToString() + ")，请重新输入！");
                }
                repGoods.DataSource = new GoodsAgent().GetGoodsBySearch(PN1.PageSize, PN1.PageIndex, keywords, categoryId, lowPrice, highPrice, out record);
            }
            else
            {
                repGoods.DataSource = new GoodsAgent().GetGoodsBySearch(PN1.PageSize, PN1.PageIndex, keywords, out record);
            }
            repGoods.DataBind();
            PN1.SetPage(record);
            litKeywords.Text = keywords;
            litRecord.Text = record.ToString();

        }
        else
        {
            WebAgent.AlertAndBack("请输入搜索关键词！");
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
