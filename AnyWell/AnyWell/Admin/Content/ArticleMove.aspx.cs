using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_Content_ArticleMove : PageAdmin
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
            ShowError( "请选择文档！" );
        }

        AW_Article_dao dao = new AW_Article_dao();

        if(IsPostBack)
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

            if( dao.funcMoveArticle( ids, column.fdColuID ) > 0 )
            {
                List<AW_Article_bean> list = dao.funcGetArticleList( ids );
                foreach( AW_Article_bean bean in list )
                {
                    AddLog( EventType.Delete, "移动文档", string.Format( "移动文档[{0}]到栏目[{1}]", bean.fdArtiTitle, column.fdColuName ) );
                }
            }

            Response.Write( "<script type=text/javascript>parent.moveArticleOK();</script>" );
            Response.End();
        }
    }
}
