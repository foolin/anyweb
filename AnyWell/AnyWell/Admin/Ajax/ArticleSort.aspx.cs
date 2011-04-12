using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Ajax_ArticleSort : AjaxPageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int articleId = 0;
        int previewId = 0;
        int nextId = 0;

        int.TryParse( QS( "id" ), out articleId );

        int.TryParse( QS( "previewid" ), out previewId );

        int.TryParse( QS( "nextid" ), out nextId );

        if( articleId > 0 && ( previewId > 0 || nextId > 0 ) )
        {
            AW_Article_bean article = AW_Article_bean.funcGetByID( articleId );
            
            if( article == null )
            {
                RenderString("文章不存在，排序失败！");
            }

            AW_Article_bean next = nextId == 0 ? null : AW_Article_bean.funcGetByID( nextId, "fdArtiID,fdArtiSort" );
            AW_Article_bean preview = previewId == 0 ? null : AW_Article_bean.funcGetByID( previewId, "fdArtiID,fdArtiSort" );

            if( next == null && preview == null )
            {
                RenderString( "存在操作已删除文章，排序失败！" );
            }

            using( AW_Article_dao dao = new AW_Article_dao() )
            {
                if( dao.funcSortArticle( article, preview, next ) )
                {
                    this.AddLog( EventType.Update, "修改文档排序", "修改文档[" + article.fdArtiTitle + "]排序" );
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
            RenderString( "存在操作已删除文章，排序失败！" );
        }
    }
}
