using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

/// <summary>
///PageBase 的摘要说明
/// </summary>
public class PageBase : Page
{
    public PageBase()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 获取参数
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected string QS(string key)
    {
        if (Request.QueryString[key] == null)
        {
            return "";
        }
        else
        {
            return Request.QueryString[key].ToString();
        }
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
