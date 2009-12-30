using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using Common.Common;
using Common.Agent;

public partial class Controls_ProductInfo : ControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (string.IsNullOrEmpty(QS("gid")) || !WebAgent.IsInt32(QS("gid")))
            WebAgent.FailAndGo("参数错误！", "index.aspx");
        good = new GoodsAgent().GetGoodsByID(int.Parse(QS("gid")));
        if (good == null)
            WebAgent.FailAndGo("产品不存在！", "index.aspx");
        if (good.Status == 4)
            WebAgent.FailAndGo("产品不存在！", "index.aspx");
        this.Page.Title = good.GoodsName;
    }

    private Goods _good;
    public Goods good
    {
        get { return _good; }
        set { _good = value; }
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
