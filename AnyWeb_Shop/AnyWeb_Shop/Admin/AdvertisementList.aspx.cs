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

public partial class AdvertisementList : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {

    }
    protected void ods3_Selected(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( e.OutputParameters["recordcount"] != null )
        {
            int record = (int)e.OutputParameters["recordcount"];
            PN1.SetPage( record );

        }
    }
}
