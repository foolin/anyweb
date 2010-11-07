using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class NoticeDetail : PageBase
{
    protected override void OnPreRender( EventArgs e )
    {
        int noticeid = 0;
        int.TryParse( Context.Items[ "NOTICEID" ] + "", out noticeid );
        if( noticeid == 0 )
        {
            goErrorPage();
        }

        AW_Notice_bean notice = AW_Notice_bean.funcGetByID( noticeid );
        if( notice == null )
        {
            goErrorPage();
        }
        HttpContext.Current.Items.Add( "NOTICEID_" + noticeid, notice );

        this.Title = "广州市杰信人力资源有限公司 - " + notice.fdNotiTitle;
    }
}
