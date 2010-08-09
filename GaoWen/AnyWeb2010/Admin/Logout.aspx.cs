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
using AnyWeb.AW_DL;

public partial class Shop_Admin_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (AW_Admin_dao dao = new AW_Admin_dao())
        {
            dao.funcLogout();
            Response.Redirect("login.aspx");
        }
    }
}
