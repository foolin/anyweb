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
using AnyWell.AW_DL;
using System.Collections.Generic;

/// <summary>
///PageAdmin 的摘要说明
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
        if( _adminInfo == null || _adminInfo.fdAdmiStatus == 1 )
        {
            Response.Clear();
            Response.Write( "<script language=\"javascript\">parent.location.href=\"/Admin/Login.aspx\";</script>" );
            Response.End();
        }
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
        Validator.ScriptSrc = "/Admin/js/validator1.2.js";
    }

    protected string QS(string key)
    {
        return Request.QueryString[key] + "";
    }

    protected string QF(string key)
    {
        return Request.Form[key] + "";
    }

    protected virtual void Fail( string msg )
    {
        Response.Clear();
        Response.Write( string.Format( "<script type=text/javascript>alert(\"{0}\");</script>", msg ) );
        Response.End();
    }

    protected virtual void Fail( string msg, bool enableButton )
    {
        Response.Clear();
        if( enableButton )
        {
            Response.Write( string.Format( "<script type=text/javascript>alert(\"{0}\");parent.enableButton();</script>", msg ) );
        }
        else
        {
            Response.Write( string.Format( "<script type=text/javascript>alert(\"{0}\");</script>", msg ) );
        }
        Response.End();
    }

    protected virtual void ShowError( string msg )
    {
        Response.Clear();
        Response.Write( string.Format( "<script type=text/javascript>parent.showError(\"系统提示信息\",\"{0}\",485,223);</script>", msg ) );
        Response.End();
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
            log.fdLogAdminID = AdminInfo.fdAdmiID;
            log.fdLogIP = Request.UserHostAddress;
            log.fdLogCreateAt = DateTime.Now;
            dao.funcInsert(log);
        }
    }

    private AW_Site_bean _CurrentSite;
    /// <summary>
    /// 当前站点
    /// </summary>
    public AW_Site_bean CurrentSite
    {
        get
        {
            if( _CurrentSite == null && CurrentColumn != null )
            {
                _CurrentSite = CurrentColumn.Site;
            }
            return _CurrentSite;
        }
        set
        {
            _CurrentSite = value;
        }
    }

    private AW_Column_bean _CurrentColumn;
    /// <summary>
    /// 当前栏目
    /// </summary>
    public AW_Column_bean CurrentColumn
    {
        get
        {
            return _CurrentColumn;
        }
        set
        {
            _CurrentColumn = value;
        }
    }
}