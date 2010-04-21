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

/// <summary>
///ShopAjaxBase 的摘要说明
/// </summary>
public class ShopAjaxBase : Page
{
    protected string QS(string key)
    {
        return Request.QueryString[key] + "";
    }

    protected string QF(string key)
    {
        return Request.Form[key] + "";
    }

    protected void ExecuteSucc(string msg)
    {
        Response.Clear();
        Response.Write("0:" + msg);
        Response.End();
    }

    protected void ExecuteFalse(int code, string msg)
    {
        if (code == 0)
            code = 1;
        Response.Clear();
        Response.Write(code.ToString() + ":" + msg);
        Response.End();
    }
}
