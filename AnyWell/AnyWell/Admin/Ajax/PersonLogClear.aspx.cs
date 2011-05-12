using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Ajax_PersonLogClear : AjaxPageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        new AW_Log_dao().funcClearLog( AdminInfo.fdAdmiID );
        AddLog( EventType.Delete, "清空操作日志", string.Format( "清空管理员[{0}]操作日志", AdminInfo.fdAdmiAccount ) );
    }
}
