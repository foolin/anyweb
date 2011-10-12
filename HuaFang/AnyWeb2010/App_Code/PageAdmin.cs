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
using System.Collections.Generic;

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
        if( _adminInfo == null )
        {
            Response.Clear();
            Response.Write( "<script language=\"javascript\">parent.location.href=\"/Admin/Login.aspx\";</script>" );
            Response.End();
        }
            //Response.Redirect("~/Admin/Login.aspx");
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

    /// <summary>
    /// 重写提示信息
    /// </summary>
    /// <param name="msg"></param>
    protected void Success( string msg, string goUrl )
    {
        Response.Clear();
        Response.Write( string.Format( "<script type=text/javascript>alert('{0}');parent.window.location='{1}';</script>", msg, goUrl ) );
        Response.End();
    }

    protected void Fail( string msg )
    {
        Response.Clear();
        Response.Write( string.Format( "<script type=text/javascript>alert('{0}');</script>", msg ) );
        Response.End();
    }

    protected string RenderAreaJs()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append( "[999999,0,'--请选择--','']," );
        builder.Append( "[999998,999999,'--请选择--','']," );
        builder.Append( "[999997,999998,'--请选择--','']," );
        foreach( Province p in AreaConfigs.GetConfigs().Provinces )
        {
            builder.AppendFormat( "[{0},0,'{1}','{0}'],", p.ID, p.Name );
            foreach( City c in p.Cities )
            {
                builder.AppendFormat( "[{0},{1},'{2}','{0}'],", c.ID, p.ID, c.Name );
                foreach( Area a in c.Areas )
                {
                    builder.AppendFormat( "[{0},{1},'{2}','{0}'],", a.ID, c.ID, a.Name );
                }
            }
        }
        builder.Append( "[]" );
        return builder.ToString();
    }
}