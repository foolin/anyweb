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
using AnyWell.Configs;
using AnyWell.AW_DL;

/// <summary>
///ShopAdmin 的摘要说明
/// </summary>
public class PageAdmin : Page
{
    private AW_Admin_bean _adminInfo;
    /// <summary>
    /// 管理员信息
    /// </summary>
    public AW_Admin_bean AdminInfo
    {
        get { return _adminInfo; }
        set { _adminInfo = value; }
    }

    protected override void OnPreLoad( EventArgs e )
    {
        if( !this.IsPostBack && Request.UrlReferrer != null )
        {
            ViewState[ "REFURL" ] = Request.UrlReferrer.PathAndQuery;
        }
    }

    protected override void OnPreInit( EventArgs e )
    {
        _adminInfo = (new AW_Admin_dao()).funcGetAdminFromCookie();
        if (_adminInfo == null)
            Response.Redirect("~/Admin/Login.aspx");
    }

    protected string RefUrl
    {
        get
        {
            return (string)ViewState["REFURL"];
        }
    }

    static PageAdmin()
    {
        Validator.ScriptSrc = "js/validator1.2.js";
    }

    protected string QS(string key)
    {
        return Request.QueryString[key] + "";
    }

    protected string QF(string key)
    {
        return Request.Form[key] + "";
    }

    protected void SetUploadForm()
    {
        HtmlForm form1 = (HtmlForm)this.Master.FindControl("form1");
        form1.Enctype = "multipart/form-data";
    }

    /// <summary>
    /// 添加操作日志
    /// </summary>
    /// <param name="type"></param>
    /// <param name="name"></param>
    /// <param name="description"></param>
    protected void AddLog(EventType type, string name, string description)
    {
        using (AW_Log_dao dao = new AW_Log_dao())
        {
            AW_Log_bean log = new AW_Log_bean();
            log.fdLogID = dao.funcNewID();
            log.fdLogType = (int)type;
            log.fdLogName = name;
            log.fdLogDesc = description;
            log.fdLogAccount = AdminInfo.fdAdmiAccount;
            log.fdLogIP = Request.UserHostAddress;
            log.fdLogCreateAt = DateTime.Now;
            dao.funcInsert(log);
        }
    }
}