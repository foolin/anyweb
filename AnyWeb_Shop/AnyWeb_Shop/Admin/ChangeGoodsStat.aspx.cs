using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.Framework;

public partial class ChangeGoodsStat :AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {

    }
    protected void ods1_Selecting(object sender , ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["changename"] = QS( "cname" );
    }
    protected void ods1_Selected(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( e.OutputParameters["recordCount"] != null )
        {
            int record = (int)e.OutputParameters["recordCount"];
            PN1.SetPage( record );
        }
    }
    protected void btnSearch_Click(object sender , EventArgs e)
    {
        Response.Redirect( "ChangeGoodsStat.aspx?cname=" + txtName.Text );
    }
}
