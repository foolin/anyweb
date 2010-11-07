using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class AnyWell_Column : PageBase
{
    protected override void OnPreRender( EventArgs e )
    {
        int columnid = 0;
        int.TryParse( Context.Items[ "COLUMNID" ] + "", out columnid );
        if( columnid == 0 )
        {
            goErrorPage();
        }

        AW_Column_bean column = AW_Column_bean.funcGetByID( columnid );
        if( column == null )
        {
            goErrorPage();
        }
        HttpContext.Current.Items.Add( "COLUMN_" + columnid, column );

        this.Title = "广州市杰信人力资源有限公司 - " + column.fdColuName;
    }
}
