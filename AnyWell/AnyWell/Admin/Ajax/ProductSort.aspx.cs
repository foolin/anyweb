using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Ajax_ProductSort : AjaxPageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int productId = 0;
        int previewId = 0;
        int nextId = 0;

        int.TryParse( QS( "id" ), out productId );

        int.TryParse( QS( "previewid" ), out previewId );

        int.TryParse( QS( "nextid" ), out nextId );

        if( productId > 0 && ( previewId > 0 || nextId > 0 ) )
        {
            AW_Product_bean product = AW_Product_bean.funcGetByID( productId );

            if( product == null )
            {
                RenderString( "产品不存在，排序失败！" );
            }

            AW_Product_bean next = nextId == 0 ? null : AW_Product_bean.funcGetByID( nextId, "fdProdID,fdProdSort" );
            AW_Product_bean preview = previewId == 0 ? null : AW_Product_bean.funcGetByID( previewId, "fdProdID,fdProdSort" );

            if( next == null && preview == null )
            {
                RenderString( "存在操作已删除产品，排序失败！" );
            }

            using( AW_Product_dao dao = new AW_Product_dao() )
            {
                if( dao.funcSortProduct( product, preview, next ) )
                {
                    this.AddLog( EventType.Update, "修改产品排序", "修改产品[" + product.fdProdName + "]排序" );
                    RenderString( "" );
                }
                else
                {
                    RenderString( "排序失败，请稍候再试！" );
                }
            }
        }
        else
        {
            RenderString( "存在操作已删除产品，排序失败！" );
        }
    }
}
