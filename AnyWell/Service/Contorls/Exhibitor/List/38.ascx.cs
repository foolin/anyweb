using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Contorls_Exhibitor_List_38 : UserControlBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        rep.DataSource = new AW_Exhibitor_dao().funcGetExhibitorList( 38, 30, 0, "", "", "" );
        rep.DataBind();
    }
}
