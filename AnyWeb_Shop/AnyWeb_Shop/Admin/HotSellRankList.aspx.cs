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

using Admin.Framework;
using Studio.Web;
using Common.Common;
using Common.Agent;

public partial class Admin_HotSellRankList : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnDel.Attributes["onclick"] = "javascript:return confirm('确定删除,是否继续？');";
        int count = 0;
        count = new HotSellRankAgent().GetGoodsCount();
        lblTips.Text = "一共有" + count.ToString() + "条记录";
    }

    public string CheckStatus(int status)
    {
        string s = "";
        if (status == 1)
        {
            s = "<font color='green'>有货</font>";
        }
        if (status == 2)
        {
            s = "<font color='red'>缺货</font>";
        }
        if (status == 3)
        {
            s = "<font color='gray'>过期</font>";
        }
        if (status == 4)
        {
            s = "<font color='gray'>不显示在首页</font>";
        }
        return s;
    }

    protected void btnDel_Click(object sender, EventArgs e)
    {
        if (Request.Form["ids"] + "" != "")
        {
            using (HotSellRankAgent hsr = new HotSellRankAgent())
            {
                hsr.DeleteGoods(Request.Form["ids"]);
                this.AddLog(EventID.Delete, "批量删除畅销产品", "批量删除产品，编号:" + Request.Form["ids"]);

                WebAgent.SuccAndGo("删除成功。", "HotSellRankList.aspx");
            }
        }
        else
        {
            WebAgent.FailAndGo("请在要删除的项前打勾。", "HotSellRankList.aspx");
        }
    }
    protected void btnClearCache_Click(object sender, EventArgs e)
    {
        if (Cache["HotSellRankListShow"] != null && Cache["HotSellRankListTime"] != null)
        {
            HttpRuntime.Cache.Remove("HotSellRankListShow");
            HttpRuntime.Cache.Remove("HotSellRankListTime");
        }
        WebAgent.AlertAndBack("更新缓存成功！");
    }

}
