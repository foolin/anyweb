using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Content_ColumnList : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int cid = 0;

        int.TryParse( QS( "cid" ), out cid );

        if( cid == 0 )
        {
            ShowError( "请选择栏目！" );
        }

        AW_Column_dao dao=new AW_Column_dao();
        CurrentColumn = dao.funcGetColumnInfo( cid );
        if( CurrentColumn == null )
        {
            ShowError( "栏目不存在！" );
        }

        if( CurrentColumn.Children.Count == 0 )
        {
            noDatas.Visible = true;
        }
        else
        {
            repColumns.DataSource = CurrentColumn.Children;
            repColumns.DataBind();
        }
    }
}
