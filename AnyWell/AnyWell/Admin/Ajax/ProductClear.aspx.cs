using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Ajax_ProductClear : AjaxPageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int cid = 0;
        int withChildren = 0;

        int.TryParse( QS( "cid" ), out cid );
        int.TryParse( QS( "ch" ), out withChildren );

        if( cid == 0 )
        {
            RenderString( "栏目不存在！" );
        }

        AW_Column_bean bean = new AW_Column_dao().funcGetColumnInfo( cid );

        if( bean == null )
        {
            RenderString( "栏目不存在！" );
        }

        new AW_Product_dao().funcClearRecycle( bean, withChildren == 1 ? true : false );

        if( withChildren == 1 )
        {
            AddLog( EventType.Delete, "清空回收站", string.Format( "清空栏目[{0}]以及子栏目回收站", bean.fdColuName ) );
        }
        else
        {
            AddLog( EventType.Delete, "清空回收站", string.Format( "清空栏目[{0}]回收站", bean.fdColuName ) );
        }
    }
}
