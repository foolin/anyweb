using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.HtmlControls;
using AnyWell.AW_DL;


public class ArticleBase : PageAdmin
{
    protected override void OnLoad( EventArgs e )
    {
        base.OnLoad( e );
        HtmlForm form = ( HtmlForm ) this.Master.FindControl( "form1" );
        if( form != null )
        {
            form.Target = "ifrSelf";
        }
    }

    /// <summary>
    /// 设置文章标签
    /// </summary>
    /// <param name="article"></param>
    /// <param name="tags"></param>
    protected void SetTags( AW_Article_bean article, string tags )
    {
        AW_Tag_dao tagdao = new AW_Tag_dao();
        AW_Tag_Associated_dao dao = new AW_Tag_Associated_dao();
        if( article.TagList.Count == 0 )
        {
            if( tags.Length > 0 )
            {
                foreach( string tag in tags.Split( ',' ) )
                {
                    int tagId = tagdao.funcGetTagByName( tag );
                    if( tagId > 0 ) //标签已存在                             
                    {
                        AW_Tag_Associated_bean bean = new AW_Tag_Associated_bean();
                        bean.fdTaAsID = dao.funcNewID();
                        bean.fdTaAsTagID = tagId;
                        bean.fdTaAsDataID = article.fdArtiID;
                        bean.fdTaAsType = 0;
                        dao.funcInsert( bean );
                    }
                    else
                    {
                        //添加标签
                        AW_Tag_bean tagbean = new AW_Tag_bean();
                        tagbean.fdTagID = tagdao.funcNewID();
                        tagbean.fdTagName = tag;
                        tagbean.fdTagSort = tagbean.fdTagID * 100;
                        tagdao.funcInsert( tagbean );
                        //添加关联
                        AW_Tag_Associated_bean bean = new AW_Tag_Associated_bean();
                        bean.fdTaAsID = dao.funcNewID();
                        bean.fdTaAsTagID = tagbean.fdTagID;
                        bean.fdTaAsDataID = article.fdArtiID;
                        bean.fdTaAsType = 0;
                        dao.funcInsert( bean );
                    }
                }
            }
        }
        else
        {
            //添除已删除的标签关联
            List<AW_Tag_bean> listTemp = new List<AW_Tag_bean>( article.TagList );
            foreach( AW_Tag_bean tagbean in article.TagList )
            {
                bool exist = false;
                foreach( string tag in tags.Split( ',' ) )
                {
                    if( tagbean.fdTagName == tag )
                    {
                        exist = true;
                        break;
                    }
                }
                if( !exist )
                {
                    dao.funcDelAssociated( tagbean.fdTagID, article.fdArtiID, 0 );
                    listTemp.Remove( tagbean );
                }
            }
            article.TagList = listTemp;
            //增加新标签关联
            foreach( string tag in tags.Split( ',' ) )
            {
                bool exist = false;
                foreach( AW_Tag_bean tagbean in article.TagList )
                {
                    if( tagbean.fdTagName == tag )
                    {
                        exist = true;
                        break;
                    }
                }
                if( !exist )
                {
                    int tagId = tagdao.funcGetTagByName( tag );
                    if( tagId > 0 ) //标签已存在                             
                    {
                        AW_Tag_Associated_bean bean = new AW_Tag_Associated_bean();
                        bean.fdTaAsID = dao.funcNewID();
                        bean.fdTaAsTagID = tagId;
                        bean.fdTaAsDataID = article.fdArtiID;
                        bean.fdTaAsType = 0;
                        dao.funcInsert( bean );
                    }
                    else
                    {
                        //添加标签
                        AW_Tag_bean tagbean = new AW_Tag_bean();
                        tagbean.fdTagID = tagdao.funcNewID();
                        tagbean.fdTagName = tag;
                        tagbean.fdTagSort = tagbean.fdTagID * 100;
                        tagdao.funcInsert( tagbean );
                        //添加关联
                        AW_Tag_Associated_bean bean = new AW_Tag_Associated_bean();
                        bean.fdTaAsID = dao.funcNewID();
                        bean.fdTaAsTagID = tagbean.fdTagID;
                        bean.fdTaAsDataID = article.fdArtiID;
                        bean.fdTaAsType = 0;
                        dao.funcInsert( bean );
                    }
                }
            }
        }
    }
}
