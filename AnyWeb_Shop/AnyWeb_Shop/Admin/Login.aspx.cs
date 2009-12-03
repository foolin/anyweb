using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Studio.Web;
using Common.Agent;
using Common.Common;
using Studio.Security;
using Admin.Framework;

public partial class Login1 : System.Web.UI.Page
{

    protected void submit_Click(object sender, EventArgs e)
    {
        string valcode1 = Request.Params["valcode"] + "";
        string val1 = Request.Params["val"] + "";

        if (valcode1 != "")
        {
            if (val1 == "")
                return;
            if (Studio.Security.Secure.Md5(valcode1).Replace("-", "").Replace("A", "").Replace("B", "").Replace("C", "").Replace("D", "").Replace("E", "").Replace("F", "").Substring(0, 4) != val1)
            {
                WebAgent.AlertAndBack("验证码错误!");
            }
        }

        int shopid = (new ShopAgent()).AdminLogin(txtUserName.Text,txtPassword.Text);


        if (shopid > 10000)
        {
            HttpCookie co = new HttpCookie("USERACC");
            co.Value = txtUserName.Text;
            Response.SetCookie(co);

            HttpCookie co1 = new HttpCookie("USERPASS");
            co1.Value = Secure.Md5(txtPassword.Text);
            Response.SetCookie(co1);

            HttpCookie co2 = new HttpCookie("SHOPID");
            co2.Value = shopid.ToString();
            Response.SetCookie(co2);

            Shop s = (new ShopAgent()).GetShopInfo(shopid);

            if ( Context.Items["SHOP_INFO"] == null )
            {
                Context.Items.Add( "SHOP_INFO" , s );
            }
            else
            {
                Context.Items["SHOP_INFO"] = s;
            }

            this.AddLog(EventID.Login, s, "管理员登陆", "管理员登陆");

            Response.Redirect("/Admin/Default.aspx");
        }

        switch ( shopid )
        {
            case 1: //用户不存在

                WebAgent.FailAndGo( "帐号不存在" , Request.RawUrl );
                break;
            case 2: //密码错误
                WebAgent.FailAndGo( "密码错误" , Request.RawUrl );
                break;
            case 3: //未开通

                WebAgent.FailAndGo("商城暂未开通", Request.RawUrl);
                break;
            case 4: //锁定
                WebAgent.FailAndGo( "商城已被锁定" , Request.RawUrl );
                break;
            case 5: //过期
                WebAgent.FailAndGo( "商城已过期" , Request.RawUrl );
                break;
            default: //登录失败
                WebAgent.FailAndGo( "登陆失败" , Request.RawUrl );
                break;
        }

    }
    protected string valcode = "1234";
    protected void Page_Load(object sender, EventArgs e)
    {
        valcode = (new Random()).Next(1000, 9999).ToString();
        imgVal.ImageUrl = "imageval.aspx?id=" + valcode;
        imgVal.ImageAlign = ImageAlign.AbsBottom;
    }

    /// <summary>
    /// 添加日志
    /// </summary>
    /// <param name="eventtype">类型</param>
    /// <param name="eventname">名称</param>
    /// <param name="description">描述</param>
    protected void AddLog(EventID eventtype, Shop ShopInfo, string eventname, string description)
    {
        EventLog el = new EventLog();

        el.ShopID = ShopInfo.ID;
        el.FromIP = System.Web.HttpContext.Current.Request.UserHostAddress;
        el.EventName = eventname;
        el.EventType = eventtype;
        el.Description = description;

        (new EventLogAgent()).AddLog(el);
    }
}
