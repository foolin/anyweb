using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Ajax_PublishAdd : AjaxPageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int objID = 0, objType = 0, pubType = 1;
        int.TryParse( QF( "id" ), out objID );//对象ID
        int.TryParse( QF( "type" ), out objType );//1:站点;2:栏目;3:文档;4:单篇文档;5:产品;10:展商;
        int.TryParse( QF( "ptype" ), out pubType );//1:仅发布首页,2:增量发布,3:完整发布,4:撤销发布

        if( objID > 0 && objType > 0 && pubType > 0 )
        {
            using( AW_Publish_dao dao = new AW_Publish_dao() )
            {
                AW_Publish_bean bean = new AW_Publish_bean();
                bean.fdPublID = dao.funcNewID();
                bean.fdPublName = GetPublishName( objType, getObjName( objType, objID ), pubType );
                bean.fdPublCreateAt = DateTime.Now;
                bean.fdPublAdminID = AdminInfo.fdAdmiID;
                bean.fdPublObjID = objID;
                bean.fdPublObjType = objType;
                bean.fdPublType = pubType;
                bean.fdPublStatus = 0;

                dao.funcInsert( bean );

                PublishService.GetService().AddPublish( bean );
                RenderString( "发布操作已提交." );
            }
        }
        else
        {
            RenderString( "参数错误!" );
        }
    }

    string GetPublishName( int objType, string objName, int pubType )
    {
        string objTypeName, pubName;
        switch( ( PublishObjectType ) objType )
        {
            case PublishObjectType.Site:
                objTypeName = "站点";
                break;
            case PublishObjectType.Column:
                objTypeName = "栏目";
                break;
            case PublishObjectType.Document:
                objTypeName = "文档";
                break;
            case PublishObjectType.Single:
                objTypeName = "单篇文档栏目";
                break;
            case PublishObjectType.Product:
                objTypeName = "产品";
                break;
            case PublishObjectType.Exhibitor:
                objTypeName = "展商";
                break;
            default:
                objTypeName = "未知";
                break;
        }
        switch( ( PublishType ) pubType )
        {
            case PublishType.HomeOnly:
                {
                    pubName = string.Format( "发布{0}[{1}]首页", objTypeName, objName );
                    break;
                }
            case PublishType.Additional:
                {
                    pubName = string.Format( "增量发布{0}[{1}]", objTypeName, objName );
                    break;
                }
            case PublishType.Complete:
                {
                    pubName = string.Format( "完全发布{0}[{1}]", objTypeName, objName );
                    break;
                }
            case PublishType.Cancel:
                {
                    pubName = string.Format( "撤销发布{0}[{1}]", objTypeName, objName );
                    break;
                }
            default:
                {
                    pubName = "未知发布";
                    break;
                }
        }
        return pubName;
    }

    /// <summary>
    /// 获取对象名称
    /// </summary>
    /// <param name="objType"></param>
    /// <param name="objID"></param>
    /// <returns></returns>
    string getObjName( int objType, int objID )
    {
        switch( ( PublishObjectType ) objType )
        {
            case PublishObjectType.Site:
                AW_Site_bean site = new AW_Site_dao().funcGetSiteInfo( objID );
                if( site != null )
                    return site.fdSiteName;
                else
                    RenderString( "站点不存在！" );
                break;
            case PublishObjectType.Column:
                AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( objID );
                if( column != null )
                    return column.fdColuName;
                else
                    RenderString( "栏目不存在！" );
                break;
            case PublishObjectType.Document:
                AW_Article_bean article = AW_Article_bean.funcGetByID( objID );
                if( article != null )
                    return article.fdArtiTitle;
                else
                    RenderString( "文档不存在！" );
                break;
            case PublishObjectType.Single:
                AW_SingleArticle_bean singleArticle = new AW_SingleArticle_dao().funcGetSingleArticle( objID );
                if( singleArticle != null )
                    return singleArticle.fdSingTitle;
                else
                    RenderString( "单篇文档栏目不存在！" );
                break;
            case PublishObjectType.Product:
                AW_Product_bean product = AW_Product_bean.funcGetByID( objID );
                if( product != null )
                    return product.fdProdName;
                else
                    RenderString( "产品不存在！" );
                break;
            case PublishObjectType.Exhibitor:
                AW_Exhibitor_bean exhibitor = AW_Exhibitor_bean.funcGetByID( objID );
                if( exhibitor != null )
                    return exhibitor.fdExhiName;
                else
                    RenderString( "展商不存在！" );
                break;
            default:
                RenderString( "未知发布类型！" );
                break;
        }
        return "";
    }
}
