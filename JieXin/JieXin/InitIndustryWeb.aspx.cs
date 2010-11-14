using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using AnyWell.AW_DL;

public partial class AnyWell_InitIndustryWeb : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    protected void Page_Load( object sender, EventArgs e )
    {
        List<AW_Industry_bean> list = new AW_Industry_dao().funcGetList();
        foreach( AW_Industry_bean bean in list )
        {
            str.AppendLine( string.Format( "<li><a href=\"javascript:void(0);\" onclick=\"AreaName(this,{0});\">{1}</a></li>", bean.fdInduID, bean.fdInduName ) );
        }
        Response.Write( str.ToString() );
    }
}
