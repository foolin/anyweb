using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_TagTopGet : PageAdmin
{
    protected override void OnPreRender( EventArgs e )
    {
        compRep.DataSource = new AW_Tag_dao().funcGetTopTag();
        compRep.DataBind();
    }
}
