using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Content_ArticleRecycle : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string ids = QS( "ids" ).Trim();
        if( string.IsNullOrEmpty( ids ) )
        {
            ShowError( "请选择文档！" );
        }

        AW_Article_dao dao = new AW_Article_dao();
        AW_Publish_dao publishDao = new AW_Publish_dao();
        List<AW_Article_bean> list = dao.funcGetArticleList( ids );

        if( !IsPostBack )
        {
            repArticles.DataSource = list;
            repArticles.DataBind();
        }
        else
        {
            if( dao.funcRecycleArticle( ids ) > 0 )
            {
                foreach( AW_Article_bean bean in list )
                {
                    if( bean.fdArtiStatus == 2 )
                    {
                        AW_Publish_bean publish = new AW_Publish_bean();
                        publish.fdPublID = publishDao.funcNewID();
                        publish.fdPublName = "撤销发布文档:[" + bean.fdArtiTitle + "]";
                        publish.fdPublCreateAt = DateTime.Now;
                        publish.fdPublAdminID = AdminInfo.fdAdmiID;
                        publish.fdPublObjID = bean.fdArtiID;
                        publish.fdPublObjType = 3;
                        publish.fdPublType = 4;
                        publish.fdPublStatus = 0;

                        publishDao.funcInsert( publish );
                        PublishService.GetService().AddPublish( publish );
                    }
                    AddLog( EventType.Delete, "删除文档", string.Format( "删除文档:{0}({1})", bean.fdArtiTitle, bean.fdArtiID ) );
                }
            }
            Response.Write( "<script type=text/javascript>parent.recycleArticleOK();</script>" );
            Response.End();
        }
    }
}
