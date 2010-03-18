using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Admin_HotSellRankList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string CheckStatus(int status)
    {
        string s = "";
        if (status == 1)
        {
            s = "<font color='green'>有货</font>";
        }
        if (status == 2)
        {
            s = "<font color='red'>缺货</font>";
        }
        if (status == 3)
        {
            s = "<font color='gray'>过期</font>";
        }
        if (status == 4)
        {
            s = "<font color='gray'>不显示在首页</font>";
        }
        return s;
    }

}
