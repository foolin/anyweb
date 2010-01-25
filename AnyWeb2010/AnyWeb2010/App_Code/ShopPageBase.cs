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
using AnyWeb.AW.Configs;

/// <summary>
///ShopPageBase 的摘要说明
/// </summary>
public class ShopPageBase : Page
{
    protected string QS(string key)
    {
        return Request.QueryString[key] + "";
    }

    protected string QF(string key)
    {
        return Request.Form[key] + "";
    }

    protected void RedirectIndex()
    {
        Response.Redirect("~/");
    }

    private AW_Member_bean _member;
    /// <summary>
    /// 已登录会员
    /// </summary>
    public AW_Member_bean Member
    {
        get 
        {
            using (AW_Member_dao dao = new AW_Member_dao())
            {
                _member = dao.funcGetMemberFromCookie();
                if (_member == null)
                {
                    _member = new AW_Member_bean();
                    _member.funcFromDataRow(dao.funcGetByID(1000).Tables[0].Rows[0]);
                }
            }
            return _member; 
        }
    }

    protected string RenderProvinceCityJs()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append("[999999,0,'--请选择--',''],");
        builder.Append("[999998,999999,'--请选择--',''],");
        foreach (Province p in AreaConfigs.GetConfigs().Provinces)
        {
            builder.AppendFormat("[{0},0,'{1}','{0}'],", p.ID, p.Name);
            foreach (City c in p.Cities)
            {
                builder.AppendFormat("[{0},{1},'{2}','{0}'],", c.ID, p.ID, c.Name);
            }
        }
        builder.Append("[]");
        return builder.ToString();
    }
}
