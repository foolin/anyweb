using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Contorls_Exhibitor_Search_33 : UserControlBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int id = 0, record = 0;
        int.TryParse( QS( "id" ), out id );
        List<AW_Exhibitor_bean> list = new List<AW_Exhibitor_bean>();
        if( id > 0 )
        {
            AW_Exhibitor_bean bean = AW_Exhibitor_bean.funcGetByID( id );
            if( bean != null )
            {
                list.Add( bean );
            }
        }
        else
        {
            int type = 0;
            string name = QS( "name" ), enName = QS( "enName" ), number = QS( "number" );
            int.TryParse( QS( "type" ), out type );
            list = new AW_Exhibitor_dao().funcGetExhibitorList( 33, type, number, name, enName, PN1.PageID, PN1.PageSize, out record );
        }
        
        if( list.Count > 0 )
        {
            rep.DataSource = list;
            rep.DataBind();
            PN1.RecordCount = record;
        }
        else
        {
            noDatas.Visible = true;
        }
    }
}
