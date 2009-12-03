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
using Studio.Web;

public partial class User_ChangeNote : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {

    }

    protected void ods3_Selecting(object sender , ObjectDataSourceSelectingEventArgs e)
    {
        if ( WebAgent.IsInt32( QS( "uid" ) ) )
        {
            e.InputParameters["userid"] = QS( "uid" );
        }
    }
    protected void ods3_Selected(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( e.OutputParameters["recordCount"] != null )
        {
            int record = (int)e.OutputParameters["recordCount"];
            PN1.SetPage( record );
        }
    }
}
