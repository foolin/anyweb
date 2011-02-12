using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_GoodsDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        if (Request.UrlReferrer == null)
            return;

        AW_Goods_bean bean = AW_Goods_bean.funcGetByID( int.Parse( QS( "id" ) ) );

        if( bean == null )
            WebAgent.AlertAndBack( "商品不存在" );

        using (AW_Goods_dao dao = new AW_Goods_dao())
        {
            if( dao.funcCheckGoodsExistOrderItem( bean.fdGoodID ) )
                WebAgent.AlertAndBack( "商品存在订单,不能删除" );
            new AW_Goods_dao().funcDelete( bean.fdGoodID );
        }
        this.AddLog( EventType.Delete, "删除商品", "删除商品[" + bean.fdGoodName + "]" );
        WebAgent.SuccAndGo("删除成功！", Request.UrlReferrer == null ? "goodslist.aspx" : Request.UrlReferrer.AbsoluteUri);
    }
}
