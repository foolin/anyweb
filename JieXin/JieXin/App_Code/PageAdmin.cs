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

    protected override void OnLoad(EventArgs e)
    {
        if (!this.IsPostBack && Request.UrlReferrer != null)
        {
            ViewState["REFURL"] = Request.UrlReferrer.PathAndQuery;
        }
    }

    protected override void OnInit(EventArgs e)
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

    protected string RenderAreaJs()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append("[999999,0,'--请选择--',''],");
        builder.Append("[999998,999999,'--请选择--',''],");
        builder.Append("[999997,999998,'--请选择--',''],");
        foreach (Province p in AreaConfigs.GetConfigs().Provinces)
        {
            builder.AppendFormat("[{0},0,'{1}','{0}'],", p.ID, p.Name);
            foreach (City c in p.Cities)
            {
                builder.AppendFormat("[{0},{1},'{2}','{0}'],", c.ID, p.ID, c.Name);
                foreach (Area a in c.Areas)
                {
                    builder.AppendFormat("[{0},{1},'{2}','{0}'],", a.ID, c.ID, a.Name);
                }
            }
        }
        builder.Append("[]");
        return builder.ToString();
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
    /// 获取工作年限
    /// </summary>
    /// <param name="expId"></param>
    /// <returns></returns>
    protected string getExpString( int expId )
    {
        switch( expId )
        {
            case 1:
                return "1年以下";
            case 2:
                return "1-2年";
            case 3:
                return "2-5年";
            case 4:
                return "5-10年";
            case 5:
                return "10年以上";
            default:
                return "";
        }
    }

    /// <summary>
    /// 获取学历
    /// </summary>
    /// <param name="degreeId"></param>
    /// <returns></returns>
    protected string getDegreeString( int degreeId )
    {
        switch( degreeId )
        {
            case 1:
                return "初中";
            case 2:
                return "高中";
            case 3:
                return "中技";
            case 4:
                return "中专";
            case 5:
                return "大专";
            case 6:
                return "本科";
            case 7:
                return "MBA";
            case 8:
                return "硕士";
            case 9:
                return "博士";
            case 10:
                return "其他";
            default:
                return "";
        }
    }
}