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
using Common.Common;
using Common.Agent;

public partial class Controls_GiftPackageDetails : ControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (string.IsNullOrEmpty(QS("pid")) || !WebAgent.IsInt32(QS("pid")))
            WebAgent.FailAndGo("参数错误！", "Index.aspx");
        giftPack = new GiftPackageAgent().GetGiftPackageByID(int.Parse(QS("pid")));
        if (giftPack == null)
            WebAgent.FailAndGo("大礼包不存在！", "Index.aspx");
        if (!giftPack.IsShow)
            WebAgent.FailAndGo("大礼包不开放！", "Index.aspx");
        this.Page.Title = giftPack.PackName;
        repList.DataSource = new GiftPackageAgent().GetGoodsListByPackID(giftPack.PackID);
        repList.DataBind();
    }

    private GiftPackage _giftPack;
    /// <summary>
    /// 大礼包
    /// </summary>
    public GiftPackage giftPack
    {
        get { return _giftPack; }
        set { _giftPack = value; }
    }
}
