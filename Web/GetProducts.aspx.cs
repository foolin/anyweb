using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Studio.Net;

public partial class GetProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        result = "";
        if (Cache["HotSellRankListShow"] != null)
        {
            result = (string)Cache["HotSellRankListShow"];
        }
        else
        {
            try
            {
                string url = "";
                if (ConfigurationManager.AppSettings["ShopHost"] + "" == "")
                {
                    url = "http://shop.thshcoop.com/GetHotSell.aspx";
                }
                else
                {
                    url = ConfigurationManager.AppSettings["ShopHost"] + "/GetHotSell.aspx";
                }
                result = HttpAgent.ReadRemoteFile(url);
                HttpRuntime.Cache.Insert("HotSellRankListShow", result, null, DateTime.Now.AddHours(2), TimeSpan.Zero);
            }
            catch (Exception ex)
            {
                result = "数据正在维护中。。。";
            }
        }
    }

    protected string result;
}
