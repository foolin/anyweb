using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Ajax_ColumnSort : AjaxPageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        AW_Column_dao dao = new AW_Column_dao();

        int cid = 0, nid = 0;
        int.TryParse( QS( "cid" ), out cid );
        int.TryParse( QS( "nid" ), out nid );

        if( cid == 0 || nid == 0 )
        {
            RenderString( "非法站点编号！" );
        }

        AW_Column_bean bean = dao.funcGetColumnInfo( cid );
        AW_Column_bean nextbean = null;
        if( nid > 0 )
        {
            nextbean = dao.funcGetColumnInfo( nid );
        }

        if( bean == null || ( nid > 0 && nextbean == null ) )
        {
            RenderString( "出现操作已删除栏目，此次排序不起效，系统将强行刷新页面！" );
        }

        if( !dao.funcSortColumn( bean, nextbean ) )
        {
            RenderString( "排序失败，请稍候再试！" );
        }
        else
        {
            AddLog( EventType.Update, "修改栏目排序", string.Format( "修改栏目排序:{0}({1})", bean.fdColuName, bean.fdColuID ) );
            RenderString( "success:parent.sortColumnOK()" );
        }
    }
}
