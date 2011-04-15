using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Content_ArticleRevoke : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string ids = QS( "ids" ).Trim();
        if( string.IsNullOrEmpty( ids ) )
        {
            ShowError( "请选择文档！" );
        }

        AW_Article_dao dao = new AW_Article_dao();
        List<AW_Article_bean> list = dao.funcGetArticleList( ids );

        if( !IsPostBack )
        {
            repArticles.DataSource = list;
            repArticles.DataBind();
        }
        else
        {
            if( dao.funcRevokeArticle( ids ) > 0 )
            {
                foreach( AW_Article_bean bean in list )
                {
                    AddLog( EventType.Delete, "恢复文档", string.Format( "恢复文档:{0}({1})", bean.fdArtiTitle, bean.fdArtiID ) );
                }
            }
            Response.Write( "<script type=text/javascript>parent.revokeArticleOK();</script>" );
            Response.End();
        }
    }
}
