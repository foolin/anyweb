using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin.Framework;
using Common.Agent;
using Studio.Web;

public partial class Admin_ShopService : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        txtContent.Text = ShopInfo.Service;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ShopInfo.Service = txtContent.Text;
        new ShopAgent().UpdateService(ShopInfo);
        WebAgent.SuccAndGo("保存成功.", "ShopService.aspx");
    }
}
