using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using AnyWell.AW_DL;

public partial class AnyWell_InitPositionWeb2 : System.Web.UI.Page
{
    StringBuilder str = new StringBuilder();
    protected void Page_Load( object sender, EventArgs e )
    {
        List<AW_Job_bean> list = new AW_Job_dao().funcInitJob();
        foreach( AW_Job_bean bean in list )
        {
            if( bean.Children.Count > 0 )
            {
                str.AppendLine( string.Format( "<li><a href=\"javascript:void(0);\" class=\"prov\" onmouseover=\"overDetail2(this,{0},'subwPos2_',wPos);\">{1}</a></li>", bean.fdJobID, bean.fdJobName ) );
            }
            else
            {
                str.AppendLine( string.Format( "<li><a href=\"javascript:void(0);\" onclick=\"AreaName(this,{0});return false;\">{1}</a></li>", bean.fdJobID, bean.fdJobName ) );
            }
        }
        Response.Write( str.ToString() );
    }
}
