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

using Admin.Framework;
using Studio.Web;
using Common.Agent;
using Common.Common;

public partial class Admin_GiftPackSetShow  : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string packID = Request.Params["pid"] + "";
        if (packID  == "" || Request.Params["type"] == null)
        {
            Response.Write("0");
            Response.End();
        }
        bool t = Request.Params["type"].ToLower() == "1" ? false : true;
        GiftPackageAgent gpAgent = new GiftPackageAgent();
        GiftPackage gp = gpAgent.GetGiftPackageByID(int.Parse(packID));
        if (gp == null)
        {
            Response.Write("0");
            Response.End();
        }
        gp.IsShow = t;
        if (gpAgent.UpdateGiftPackage(gp) > 0)
        {
            Response.Write("1");
            Response.End();
        }
        else
        {
            Response.Write("0");
            Response.End();
        }

    }
}
