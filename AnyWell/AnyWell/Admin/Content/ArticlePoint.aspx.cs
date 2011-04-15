using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_Content_ArticlePoint : PageAdmin
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
        AW_Column_dao coluumDao = new AW_Column_dao();

        if( IsPostBack )
        {
            string cids = QF( "cids" );

            if( string.IsNullOrEmpty( cids ) )
            {
                Fail( "请选择栏目！", true );
            }

            if( dao.funcPointArticle( ids, cids ) )
            {
                AddLog( EventType.Insert, "引用文档", string.Format( "引用文档[编号:{0}]到栏目[编号:{1}]", ids, cids ) );
            }

            Response.Write( "<script type=text/javascript>parent.pointArticleOK();</script>" );
            Response.End();
        }
    }
}
