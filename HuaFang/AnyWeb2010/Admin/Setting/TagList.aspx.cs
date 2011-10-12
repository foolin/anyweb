using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_TagList : PageAdmin
{
    protected int orderType = 0;
    protected override void OnPreRender( EventArgs e )
    {
        txtKey.Text = QS( "key" ).Trim();
        int.TryParse( QS( "order" ), out orderType );
        drpOrder.SelectedValue = orderType.ToString();
        int recordCount = 0;
        compRep.DataSource = new AW_Tag_dao().funcGetTagList( txtKey.Text, orderType, PN1.PageSize, PN1.PageIndex, out recordCount );
        compRep.DataBind();
        PN1.SetPage( recordCount );
    }
}
