using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Content_ColumnDel : PageAdmin
{
    AW_Column_dao dao = new AW_Column_dao();

    protected void Page_Load( object sender, EventArgs e )
    {
        int cid = 0;
        int.TryParse( QS( "cid" ), out cid );

        if( cid == 0 )
        {
            ShowError( "请选择栏目！" );
        }

        AW_Column_bean bean = dao.funcGetColumnInfo( cid );

        if( bean == null )
        {
            ShowError( "栏目不存在！" );
        }

        if( !IsPostBack )
        {
            List<AW_Column_bean> columns = new List<AW_Column_bean>();
            columns.Add( bean );
            repColumns.DataSource = columns;
            repColumns.DataBind();
        }
        else
        {
            if( dao.funcDelete( cid ) > 0 )
            {
                AddLog( EventType.Delete, "删除栏目", string.Format( "删除栏目:{0}({1})", bean.fdColuName, bean.fdColuID ) );
                Response.Write( string.Format( "<script type=text/javascript>parent.delColumnOK('{0}');</script>", bean.fdColuID ) );
                Response.End();
            }
            else
            {
                Fail( "栏目删除失败，请稍候再试！", true );
            }
        }
    }
}
