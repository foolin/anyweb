using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Ajax_LogClear : AjaxPageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        new AW_Log_dao().funcClearLog( 0 );
        AddLog( EventType.Delete, "清空操作日志", "清空所有操作日志" );
    }
}
