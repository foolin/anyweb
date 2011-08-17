using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;
using AnyWell.Configs;

public partial class FashionArticle : PageBase
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
        bean.Column = AW_Column_bean.funcGetByID( bean.fdArtiColumnID );
        //用于面包屑
        Context.Items.Add( "COLUMNID", bean.fdArtiColumnID.ToString() );

        repCatWalk.DataSource = bean.CatWalkList;
        repCatWalk.DataBind();
        repCloseUp.DataSource = bean.CloseUpList;
        repCloseUp.DataBind();
        repBackStage.DataSource = bean.BackStageList;
        repBackStage.DataBind();
        repFrontRow.DataSource = bean.FrontRowList;
        repFrontRow.DataBind();

        repMore.DataSource = new AW_Article_dao().funcGetFashionMoreArticleList( 124, bean.fdArtiID, bean.fdArtiTitle, 6 );
        repMore.DataBind();

        repColumn.DataSource = new AW_Article_dao().funcGetArticleListByUC( bean.fdArtiColumnID, 6, true, string.Format( "fdArtiID<>{0} AND fdArtiType=2", bean.fdArtiID ), "", "", false );
        repColumn.DataBind();

        repCity.DataSource = new AW_Article_dao().funcGetArticleListByUC( 124, 6, true, string.Format( "fdArtiCity={0} AND fdArtiType=2 AND fdArtiID<>{1}", bean.fdArtiCity, bean.fdArtiID ), "", "", false );
        repCity.DataBind();

        this.Title = bean.fdArtiTitle + GeneralConfigs.GetConfig().TitleExtension;
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
}
