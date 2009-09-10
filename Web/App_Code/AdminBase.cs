using System;
using System.Collections.Generic;
using System.Web;
using Studio.Web;
using AnyWeb.AnyWeb_DL;

/// <summary>
///AdminBase 的摘要说明
/// </summary>
public class AdminBase : System.Web.UI.Page
{
    public AdminBase()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    protected override void OnLoad(EventArgs e)
    {
        if (Request.Cookies["USERINFO"] == null || Request.Cookies["USERINFO"]["UserAcc"] == "")
        {
            WebAgent.FailAndGo("未登陆禁止查看该页！", "/Admin/Login.aspx");
        }

        if (!IsPostBack)
        {
            if (Request.UrlReferrer == null)
            {
                ViewState["BACK"] = "/Admin/Default.aspx";
            }
            else
            {
                ViewState["BACK"] = Request.UrlReferrer.ToString();
            }
        }
    }

    /// <summary>
    /// 获取地址栏参数
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected string QS(string key)
    {
        return Request.QueryString[key] + "";
    }


    protected Site SiteInfo
    {
        get
        {
            return (Site)Context.Items["SITEINFO"];
        }
    }

    protected User LoginUser
    {
        get
        {
            return (User)Context.Items["LOGIN_USER"];
        }
    }
}
