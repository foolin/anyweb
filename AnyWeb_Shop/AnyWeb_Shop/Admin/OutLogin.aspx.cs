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

public partial class OutLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["SHOPACC"].Expires = DateTime.Now.AddDays(-1);
        Response.Cookies["SHOPID"].Expires = DateTime.Now.AddDays(-1);

        WebAgent.Alert("注销成功!");
        Response.Write("<script language='javascript'>window.location='/Admin/Login.aspx';</script>");
        Response.End();
    }
}
