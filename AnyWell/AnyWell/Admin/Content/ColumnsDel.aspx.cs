using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Content_ColumnsDel : PageAdmin
{
    AW_Column_dao dao = new AW_Column_dao();

    protected void Page_Load( object sender, EventArgs e )
    {
        string ids = QS( "ids" ).Trim();
        if( string.IsNullOrEmpty( ids ) )
        {
            ShowError( "请选择栏目！" );
        }

        if( !IsPostBack )
        {
            List<AW_Column_bean> columns = new List<AW_Column_bean>();
            foreach( string str in ids.Split( ',' ) )
            {
                if( str == "" )
                    continue;
                columns.Add( dao.funcGetColumnInfo( int.Parse( str ) ) );
            }
            repColumns.DataSource = columns;
            repColumns.DataBind();
        }
        else
        {
            if( dao.funcDeleteColumns( ids ) > 0 )
            {
                AddLog( EventType.Delete, "删除栏目", string.Format( "删除栏目[编号：{0}]", ids ) );
                Response.Write( string.Format( "<script type=text/javascript>parent.delColumnsOK('{0}');</script>", ids ) );
                Response.End();
            }
            else
            {
                Fail( "栏目删除失败，请稍候再试！", true );
            }
        }
    }
}
