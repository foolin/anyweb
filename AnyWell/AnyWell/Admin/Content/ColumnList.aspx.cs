using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Content_ColumnList : PageAdmin
{
    protected AW_Column_bean bean;

    protected void Page_Load( object sender, EventArgs e )
    {
        int cid = 0;

        int.TryParse( QS( "cid" ), out cid );

        if( cid == 0 )
        {
            ShowError( "请选择栏目！" );
        }

        AW_Column_dao dao=new AW_Column_dao();
        bean = dao.funcGetColumnInfo( cid );
        if( bean == null )
        {
            ShowError( "栏目不存在！" );
        }

        if( bean.Children.Count == 0 )
        {
            noDatas.Visible = true;
        }
        else
        {
            repColumns.DataSource = bean.Children;
            repColumns.DataBind();
        }
    }
}
