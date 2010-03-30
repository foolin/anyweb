using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin.Framework;
using Common.Agent;
using Studio.Web;

public partial class Admin_LogClear : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        new EventLogAgent().ClearLog();
        WebAgent.SuccAndGo("清空日志成功！", "LogList.aspx");
    }
}
