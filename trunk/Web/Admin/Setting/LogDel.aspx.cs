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
using AnyWeb.AnyWeb_DL;
using Studio.Web;

public partial class Admin_Setting_LogDel : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (Request.UrlReferrer == null)
        {
            WebAgent.AlertAndBack("参数错误");
        }

        if (Request["id"] != null)
        {
            new EventLogAgent().DeleteLog(Request["id"].ToString());
            WebAgent.SuccAndGo("删除操作记录成功", "LogList.aspx");
        }
        else
        {
            WebAgent.FailAndGo("删除操作记录失败", "LogList.aspx");
        }
      
    }
}
