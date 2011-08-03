using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using AnyWell.Configs;

public partial class c_124 : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = "秀场直击" + GeneralConfigs.GetConfig().TitleExtension;

        repHot.DataSource = new AW_Article_dao().funcGetArticleListByUC( 124, 10, true, "fdArtiRecommend=1", "", "", false );
        repHot.DataBind();

        AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( 124 );
        if( column.Children.Count > 0 )
        {
            column1.column = column.Children[ column.Children.Count - 1 ];
        }
        if( column.Children.Count > 1 )
        {
            column2.column = column.Children[ column.Children.Count - 2 ];
        }
        if( column.Children.Count > 2 )
        {
            column3.column = column.Children[ column.Children.Count - 3 ];
        }
        if( column.Children.Count > 3 )
        {
            column4.column = column.Children[ column.Children.Count - 4 ];
        }
    }
}
