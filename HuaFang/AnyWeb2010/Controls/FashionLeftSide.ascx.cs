using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Controls_FashionLeftSide : System.Web.UI.UserControl
{
    protected int coluCount = 0;
    protected int col = 0, cate = 0, city = 0;

    protected void Page_Load( object sender, EventArgs e )
    {
        List<AW_Column_bean> list = new AW_Column_dao().funcGetColumnInfo( 124 ).Children;
        coluCount = list.Count;
        if( list.Count > 0 )
        {
            List<AW_Column_bean> newList = new List<AW_Column_bean>( list );
            newList.Reverse();

            repColumn.DataSource = newList;
            repColumn.DataBind();
        }

        int.TryParse( QS( "col" ), out col );
        int.TryParse( QS( "cate" ), out cate );
        int.TryParse( QS( "city" ), out city );
    }

    protected string QS( string key )
    {
        return Request.QueryString[ key ] + "";
    }

    protected string QF( string key )
    {
        return Request.Form[ key ] + "";
    }
}
