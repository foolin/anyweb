using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using AnyWell.AW_DL;

public partial class AnyWell_InitIndustry2 : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    protected void Page_Load( object sender, EventArgs e )
    {
        List<AW_Industry_bean> list = new AW_Industry_dao().funcGetList();
        foreach( AW_Industry_bean bean in list )
        {
            str.AppendLine( string.Format( "<li title=\"{1}\"><input type=\"checkbox\" id=\"industry_{0}\" value=\"{1}|{0}\" />{1}</li>", bean.fdInduID, bean.fdInduName ) );
        }
        Response.Write( str.ToString() );
    }
}
