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

public partial class Login : System.Web.UI.Page
{
    protected string valcode = "1234";
    protected void Page_Load(object sender, EventArgs e)
    {
        valcode = (new Random()).Next(1000, 9999).ToString();
        imgVal.ImageUrl = "/imageval.aspx?id=" + valcode;
        imgVal.ImageAlign = ImageAlign.AbsBottom;
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string valcode1 = Request.Params["valcode"] + "";
        string val1 = txtCode.Text;

        if (valcode1 != "")
        {
            if (val1 == "")
                return;
            if (Studio.Security.Secure.Md5(valcode1).Replace("-", "").Replace("A", "").Replace("B", "").Replace("C", "").Replace("D", "").Replace("E", "").Replace("F", "").Substring(0, 4) != val1)
            {
                WebAgent.AlertAndBack("验证码错误!");
            }
        }
    }
}
