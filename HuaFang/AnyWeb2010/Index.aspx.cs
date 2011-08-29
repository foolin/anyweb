using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using AnyWell.Configs;

public partial class Index : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = "首页" + GeneralConfigs.GetConfig().TitleExtension;

        List<AW_Flash_bean> list = flashList;
        repFlash.DataSource = list;
        repFlash.DataBind();

        //明星名媛
        repCelebs.DataSource = celebsList;
        repCelebs.DataBind();

        //潮流街拍
        repStreet.DataSource = streetStyle.Count > 6 ? streetStyle.GetRange( 0, 6 ) : streetStyle;
        repStreet.DataBind();
        repStreetMore.DataSource = streetStyle.Count > 6 ? streetStyle.GetRange( 6, streetStyle.Count - 6 ) : null;
        repStreetMore.DataBind();

        //流行趋势
        repFashion.DataSource = fashionRends;
        repFashion.DataBind();
        repFashionButton.DataSource = fashionRends;
        repFashionButton.DataBind();

        //秀场直击
        repFashionShow.DataSource = fashionShow.Count > 0 ? fashionShow.GetRange( 0, 1 ) : null;
        repFashionShow.DataBind();
        repFashionShowMore.DataSource = fashionShow.Count > 1 ? fashionShow.GetRange( 1, fashionShow.Count - 1 ) : null;
        repFashionShowMore.DataBind();

        //时尚生活
        repFashionLife1.DataSource = fashionLife.Count > 2 ? fashionLife.GetRange( 0, 2 ) : fashionLife;
        repFashionLife1.DataBind();
        if( fashionLife.Count > 2 )
        {
            repFashionLife2.DataSource = fashionLife.GetRange( 2, fashionLife.Count > 5 ? 3 : fashionLife.Count - 2 );
            repFashionLife2.DataBind();
        }
        if( fashionLife.Count > 5 )
        {
            repFashionLife3.DataSource = fashionLife.GetRange( 5, fashionLife.Count - 5 );
            repFashionLife3.DataBind();
        }

        //高清大片
        repEditorial.DataSource = new AW_Article_dao().funcGetArticleListByUC( 128, 20, true, "", "", "", false );
        repEditorial.DataBind();

        //秀场直击搜索
        List<AW_Column_bean> columnList = new AW_Column_dao().funcGetColumnInfo( 124 ).Children;
        List<AW_Column_bean> fashionList = new List<AW_Column_bean>();
        for( int i = columnList.Count - 1; i >= 0; i-- )
        {
            fashionList.Add( columnList[ i ] );
            if( fashionList.Count >= 2 )
            {
                break;
            }
        }
        repFashionColumn.DataSource = fashionList;
        repFashionColumn.DataBind();
    }

    private List<AW_Flash_bean> _flashList;
    public List<AW_Flash_bean> flashList
    {
        get
        {
            if( _flashList == null )
            {
                _flashList = new AW_Flash_dao().funcGetFlashList();
            }
            return _flashList;
        }
    }

    public string flashName
    {
        get
        {
            string name = "";
            foreach( AW_Flash_bean bean in _flashList )
            {
                name += string.Format( ",\"{0}\"", bean.fdFlasName );
            }
            return name.Length > 0 ? name.Substring( 1 ) : name;
        }
    }

    private List<AW_Article_bean> _celebsList;
    /// <summary>
    /// 明星名媛
    /// </summary>
    public List<AW_Article_bean> celebsList
    {
        get
        {
            if( _celebsList == null )
            {
                _celebsList = new AW_Article_dao().funcGetArticleListByUC( 125, 6, true, "", "", "", false );
            }
            return _celebsList;
        }
    }

    public int celebsCount
    {
        get
        {
            return _celebsList.Count;
        }
    }

    private List<AW_Article_bean> _streetStyle;
    /// <summary>
    /// 潮流街拍
    /// </summary>
    public List<AW_Article_bean> streetStyle
    {
        get
        {
            if( _streetStyle == null )
            {
                _streetStyle = new AW_Article_dao().funcGetArticleListByUC( 126, 12, true, "", "", "", false );
            }
            return _streetStyle;
        }
    }

    public int streetStyleCount
    {
        get
        {
            return streetStyle.Count > 6 ? 6 : streetStyle.Count;
        }
    }

    private List<AW_Article_bean> _fashionRends;
    /// <summary>
    /// 流行趋势
    /// </summary>
    public List<AW_Article_bean> fashionRends
    {
        get
        {
            if( _fashionRends == null )
            {
                _fashionRends = new AW_Article_dao().funcGetArticleListByUC( 118, 4, true, "", "", "", false );
            }
            return _fashionRends;
        }
    }

    private List<AW_Article_bean> _fashionShow;
    /// <summary>
    /// 秀场直击
    /// </summary>
    public List<AW_Article_bean> fashionShow
    {
        get
        {
            if( _fashionShow == null )
            {
                _fashionShow = new AW_Article_dao().funcGetArticleListByUC( 124, 9, true, "", "", "", false );
            }
            return _fashionShow;
        }
    }

    private List<AW_Article_bean> _fashionLife;
    /// <summary>
    /// 秀场直击
    /// </summary>
    public List<AW_Article_bean> fashionLife
    {
        get
        {
            if( _fashionLife == null )
            {
                _fashionLife = new AW_Article_dao().funcGetArticleListByUC( 127, 9, true, "", "", "", false );
            }
            return _fashionLife;
        }
    }
}
