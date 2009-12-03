using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin.Framework;
using Common.Agent;

public partial class Admin_GoodsSort : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.UrlReferrer != null)
        {
            if (QS("action") == "up")
            {
                new GoodsAgent().GoodsUp(int.Parse(QS("id")));
            }
            else
            {
                new GoodsAgent().GoodsDown(int.Parse(QS("id")));
            }
            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
}
