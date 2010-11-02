using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Search : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int tag = 0;
        int areaid = 0;
        int type = 0;
        string key = QS( "key" );
        int.TryParse( QS( "tag" ), out tag );
        int.TryParse( QS( "areaid" ), out areaid );
        int.TryParse( QS( "type" ), out type );

        int recordCount = 0;
        rep.DataSource = new AW_Recruit_dao().funcGetRecruitList( tag, areaid, key, type, PN1.PageSize, PN1.PageIndex, out recordCount );
        rep.DataBind();
        PN1.SetPage( recordCount );
    }
}
