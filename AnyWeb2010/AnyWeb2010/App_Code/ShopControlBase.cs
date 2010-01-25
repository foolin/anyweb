using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Studio.Web;
using AnyWeb.AW_DL;

/// <summary>
///ShopControlBase 的摘要说明
/// </summary>
public class ShopControlBase : UserControl
{
    protected string QS(string key)
    {
        return Request.QueryString[key] + "";
    }

    protected string QF(string key)
    {
        return Request.Form[key] + "";
    }

    private AW_Category_bean _currentCategory;
    /// <summary>
    /// 当前分类
    /// </summary>
    public AW_Category_bean CurrentCategory
    {
        get { return _currentCategory; }
        set { _currentCategory = value; }
    }

    private AW_Brand_bean _currentBrand;
    /// <summary>
    /// 当前品牌
    /// </summary>
    public AW_Brand_bean CurrentBrand
    {
        get { return _currentBrand; }
        set { _currentBrand = value; }
    }
}
