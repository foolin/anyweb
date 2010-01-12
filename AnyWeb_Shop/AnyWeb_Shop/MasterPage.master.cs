using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public string QS(string key)
    {
        return Request.QueryString[key] + "";
    }

    /// <summary>
    /// 获取商店信息
    /// </summary>
    public Common.Common.Shop ShopInfo
    {
        get
        {
            return (Common.Common.Shop)Context.Items["SHOP_INFO"];
        }
    }
}
