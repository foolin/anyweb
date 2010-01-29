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
using AnyWeb.AW.Configs;

/// <summary>
///ShopAdmin 的摘要说明
/// </summary>
public class ShopAdmin : Page
{
    protected static string ShopMasterPageFile = "~/Admin/AdminPage.master";
    public ShopAdmin()
    {
        this.Load += new EventHandler(ShopAdmin_Load);
    }

    protected override void OnLoad(EventArgs e)
    {
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
        Response.AppendHeader("Pragma", "No-Cache");
    }

    protected override void OnPreInit(EventArgs e)
    {
        if (this.Master != null)
        {
            this.MasterPageFile = ShopMasterPageFile;
        }
        base.OnPreInit(e);
    }

    void ShopAdmin_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack && Request.UrlReferrer != null)
        {
            ViewState["REFURL"] = Request.UrlReferrer.PathAndQuery;
        }
    }
    protected string RefUrl
    {
        get
        {
            return (string)ViewState["REFURL"];
        }
    }

    static ShopAdmin()
    {
        Validator.ScriptSrc = "/public/js/validator1.2.js";
        if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["AW_AdminMasterPage"]) == false)
        {
            ShopMasterPageFile = ConfigurationManager.AppSettings["AW_AdminMasterPage"];
        }
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
}
