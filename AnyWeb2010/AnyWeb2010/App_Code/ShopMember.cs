using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using AnyWeb.AW_DL;
using AnyWeb.AW.Configs;
using AnyWeb.Configs;

/// <summary>
///ShopMember 的摘要说明
/// </summary>
public class ShopMember : Page
{
    private AW_Member_bean _member;

    public AW_Member_bean Member
    {
        get { return _member; }
        set { _member = value; }
    }

    public ShopMember()
    {
        using (AW_Member_dao dao = new AW_Member_dao())
        {
            _member = dao.funcGetMemberFromCookie();
            if (_member == null)
                HttpContext.Current.Response.Redirect("/Member/Login.aspx?refer=" + HttpContext.Current.Request.Url.AbsoluteUri);
        }
    }

    static ShopMember()
    {
        Studio.Web.Validator.ScriptSrc = "/public/js/validator1.2.js";
    }

    protected string QS(string key)
    {
        return Request.QueryString[key] + "";
    }

    protected string QF(string key)
    {
        return Request.Form[key] + "";
    }

    protected string RenderProvinceCityJs()
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

    protected void WriteScript(string script)
    {
        Literal ltlScript = (Literal)this.Master.FindControl("ltlScript");
        if (ltlScript != null)
            ltlScript.Text += String.Format("<script type=\"text/javascript\">{0}</script>", script);
    }

    protected void AlertScript(string msg)
    {
        Literal ltlScript = (Literal)this.Master.FindControl("ltlScript");
        if (ltlScript != null)
            ltlScript.Text += String.Format("<script type=\"text/javascript\">alert(\"{0}\")</script>", msg);
    }

}
