using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_Product_ProductMove : PageAdmin
{
    protected int type;
    protected void Page_Load( object sender, EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "type" ) ) || !WebAgent.IsInt32( QS( "type" ) ) )
        {
            ShowError( "参数错误！" );
        }

        type = int.Parse( QS( "type" ) );

        string ids = QS( "ids" ).Trim();
        if( string.IsNullOrEmpty( ids ) )
        {
            ShowError( "请选择产品！" );
        }

        AW_Product_dao dao = new AW_Product_dao();

        if( IsPostBack )
        {
            int cid = 0;
            int.TryParse( QF( "cids" ), out cid );

            if( cid == 0 )
            {
                Fail( "请选择栏目！", true );
            }

            AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( cid );
            if( column == null )
            {
                ShowError( "栏目不存在！" );
            }

            if( dao.funcMoveProduct( ids, column.fdColuID ) > 0 )
            {
                List<AW_Product_bean> list = dao.funcGetProductList( ids );
                foreach( AW_Product_bean bean in list )
                {
                    AddLog( EventType.Update, "移动产品", string.Format( "移动产品[{0}]到栏目[{1}]", bean.fdProdName, column.fdColuName ) );
                }
            }

            Response.Write( "<script type=text/javascript>parent.moveProductOK();</script>" );
            Response.End();
        }
    }
}
