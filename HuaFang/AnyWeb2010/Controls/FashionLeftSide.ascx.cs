using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Controls_FashionLeftSide : System.Web.UI.UserControl
{
    protected int coluCount = 0;

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
    }
}
