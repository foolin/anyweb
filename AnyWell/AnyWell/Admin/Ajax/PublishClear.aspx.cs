using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Ajax_PublishClear : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        new AW_Publish_dao().funcClearPublish();
        AddLog( EventType.Delete, "清空发布日志", "清空发布日志" );
    }
}
