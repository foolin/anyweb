using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int tag = 0;
        int areaid = 0;
        string key = QS( "key" );
        int.TryParse( QS( "tag" ), out tag );
        int.TryParse( QS( "areaid" ), out areaid );
    }
}
