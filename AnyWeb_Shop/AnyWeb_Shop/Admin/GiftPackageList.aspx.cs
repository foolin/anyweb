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
using System.IO;

public partial class Admin_GiftPackageList : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        if (Request.Form["ids"] + "" == "")
        {
            WebAgent.AlertAndBack("请选择需要删除项");
        }
        string gpIds = Request.Form["ids"].ToString();
        using (GiftPackageAgent gpAgent = new GiftPackageAgent())
        {
            if (gpAgent.DeleteGiftPackage(gpIds) > 0)
            {
                this.AddLog(EventID.Delete, "删除大礼包产品", "批量删除大礼包，编号:" + gpIds);
                WebAgent.SuccAndGo("批量删除大礼包成功。", "GiftPackageList.aspx");
            }
            else
            {
                WebAgent.FailAndGo("批量删除大礼包失败！");
            }
        }
    }
}
