using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_TagSearch : PageAdmin
{
    protected override void OnPreRender( EventArgs e )
    {
        string key = QS( "key" ).Trim();
        int type = int.Parse( QS( "type" ) );
        int recordCount = 0;
        compRep.DataSource = new AW_Tag_dao().funcSearchTag( key, type, PN1.PageSize, PN1.PageIndex, out recordCount );
        compRep.DataBind();
        PN1.SetPage( recordCount );
    }
}
