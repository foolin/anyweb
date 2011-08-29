using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Controls_TagList : System.Web.UI.UserControl
{
    protected void Page_Load( object sender, EventArgs e )
    {
        repTag.DataSource = new AW_Tag_dao().funcGetTopIndexTagList( 40 );  //原先20个
        repTag.DataBind();
    }
}
