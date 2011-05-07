using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Product_ProductRevoke : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string ids = QS( "ids" ).Trim();
        if( string.IsNullOrEmpty( ids ) )
        {
            ShowError( "请选择文档！" );
        }

        AW_Product_dao dao = new AW_Product_dao();
        List<AW_Product_bean> list = dao.funcGetProductList( ids );

        if( !IsPostBack )
        {
            repProducts.DataSource = list;
            repProducts.DataBind();
        }
        else
        {
            if( dao.funcRevokeProduct( ids ) > 0 )
            {
                foreach( AW_Product_bean bean in list )
                {
                    AddLog( EventType.Update, "恢复产品", string.Format( "恢复产品:{0}({1})", bean.fdProdName, bean.fdProdID ) );
                }
            }
            Response.Write( "<script type=text/javascript>parent.revokeProductOK();</script>" );
            Response.End();
        }
    }
}
