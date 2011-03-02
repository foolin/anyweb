using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_LogClear : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        new AW_Log_dao().funcClearLog();
        this.AddLog(EventType.Delete, "清除日志", "清除所有日志");
        Response.Redirect("LogList.aspx");
    }
}
