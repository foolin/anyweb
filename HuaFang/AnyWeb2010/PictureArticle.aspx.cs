using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;
using AnyWell.Configs;

public partial class PictureArticle : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int aid = 0;
        int.TryParse( ( string ) Context.Items[ "ARTICLEID" ], out aid );
        if( aid == 0 )
        {
            WebAgent.AlertAndBack( "页面不存在！" );
        }
        bean = new AW_Article_dao().funcGetArticleById( aid, true );
        if( bean == null )
        {
            WebAgent.AlertAndBack( "页面不存在！" );
        }
        bean.Column = new AW_Column_dao().funcGetColumnInfo( bean.fdArtiColumnID );
        //用于面包屑
        Context.Items.Add( "COLUMNID", bean.fdArtiColumnID.ToString() );

        this.Title = bean.fdArtiTitle + GeneralConfigs.GetConfig().TitleExtension;

        repPicList.DataSource = bean.PictureList;
        repPicList.DataBind();

        repTag1.DataSource = bean.TagList;
        repTag1.DataBind();
        repTag2.DataSource = bean.TagList;
        repTag2.DataBind();

        string tagIds = "";
        foreach( AW_Tag_bean tag in bean.TagList )
        {
            tagIds += "," + tag.fdTagID;
        }

        if( tagIds.Length > 0 )
        {
            repOther.DataSource = new AW_Article_dao().funcGetArticleListByTag( bean.fdArtiID, tagIds.Substring( 1 ), 12 );
            repOther.DataBind();
        }

        if( otherPicList.Count > 0 )
        {
            rep3.DataSource = otherPicList;
            rep3.DataBind();
        }

        //更新点击数
        new AW_Article_dao().funcUpdateClick( aid );
    }

    private AW_Article_bean _bean;
    public AW_Article_bean bean
    {
        get
        {
            return _bean;
        }
        set
        {
            _bean = value;
        }
    }

    private AW_Article_bean _preArticle;
    public AW_Article_bean preArticle
    {
        get
        {
            if( _preArticle == null )
            {
                int id = new AW_Article_dao().funcGetPreviousArticleIDByUC( bean.fdArtiID );
                if( id == 0 )
                    return null;
                _preArticle = AW_Article_bean.funcGetByID( id, "fdArtiID,fdArtiTitle,fdArtiType" );
            }
            return _preArticle;
        }
    }

    private AW_Article_bean _nextArticle;
    public AW_Article_bean nextArticle
    {
        get
        {
            if( _nextArticle == null )
            {
                int id = new AW_Article_dao().funcGetNextArticleIDByUC( bean.fdArtiID );
                if( id == 0 )
                    return null;
                _nextArticle = AW_Article_bean.funcGetByID( id, "fdArtiID,fdArtiTitle,fdArtiType" );
            }
            return _nextArticle;
        }
    }

    private List<AW_Article_bean> _otherPicList;
    public List<AW_Article_bean> otherPicList
    {
        get
        {
            if( _otherPicList == null )
            {
                _otherPicList = new AW_Article_dao().funcGetArticleListByUC( bean.fdArtiColumnID, 3, true, string.Format( "fdArtiID<>{0} AND fdArtiType=1", bean.fdArtiID ), "", "", false );
            }
            return _otherPicList;
        }
    }
}
