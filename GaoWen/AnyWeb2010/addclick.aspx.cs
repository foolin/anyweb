using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWeb.AW_DL;

public partial class addclick : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        string artiID = Request.QueryString["id"] + "";
        if ((!string.IsNullOrEmpty(artiID)) && WebAgent.IsInt32(artiID))
        {
            new AW_Article_dao().funcAddClick(int.Parse(artiID));
        }
    }
}
