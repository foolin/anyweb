using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Fashion : PageBase
{
    protected int col = 0, cate = 0, city = 0, sort = 0;
    protected void Page_Load( object sender, EventArgs e )
    {
        int.TryParse( QS( "col" ), out col );
        int.TryParse( QS( "cate" ), out cate );
        int.TryParse( QS( "city" ), out city );
        int.TryParse( QS( "sort" ), out sort );

        if( col == 0 )
        {
            col = 124;
        }

        string order = "";
        if( sort > 0 )
        {
            order = "ORDER BY fdArtiTitle ASC";
        }

        string keyword = QS( "t" );
        if( keyword.Contains( "%" ) )
        {
            keyword = keyword.Replace( "%", "[%]" );
        }
        if( keyword.Contains( "'" ) )
        {
            keyword = keyword.Replace( "'", "''" );
        }

        int record = 0;
        rep.DataSource = new AW_Article_dao().funcGetFashionArticleList( col, cate, city, keyword, order, PN1.PageID, PN1.PageSize, out record );
        rep.DataBind();
        PN1.RecordCount = PN2.RecordCount = record;
    }
}
