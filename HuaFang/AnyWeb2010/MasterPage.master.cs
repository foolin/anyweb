using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.Configs;
using AnyWell.AW_DL;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load( object sender, EventArgs e )
    {
        this.lt_description.Text = string.Format( "<meta name=\"description\" content=\"{0}\" />", GeneralConfigs.GetConfig().MetaDescription );
        this.lt_keywords.Text = string.Format( "<meta name=\"keywords\" content=\"{0}\" />", GeneralConfigs.GetConfig().MetaKeywords );

        repLink.DataSource = new AW_Link_dao().funcGetLinkList();
        repLink.DataBind();

        //童装
        if( kidList.Count > 0 )
        {
            repKid1.DataSource = kidList.GetRange( 0, 1 );
            repKid1.DataBind();
        }
        repKid2.DataSource = kidList;
        repKid2.DataBind();

        //潮人街拍
        if( streetList.Count > 0 )
        {
            repStreet1.DataSource = streetList.GetRange( 0, 1 );
            repStreet1.DataBind();
        }
        repStreet2.DataSource = streetList;
        repStreet2.DataBind();

        //美妆美容
        if( beautyList.Count > 0 )
        {
            repBeauty1.DataSource = beautyList.GetRange( 0, 1 );
            repBeauty1.DataBind();
        }
        repBeauty2.DataSource = beautyList;
        repBeauty2.DataBind();

        //服装配饰
        if( accessoryList.Count > 0 )
        {
            repAccessory1.DataSource = accessoryList.GetRange( 0, 1 );
            repAccessory1.DataBind();
        }
        repAccessory2.DataSource = accessoryList;
        repAccessory2.DataBind();

        //时尚活动
        if( eventsList.Count > 0 )
        {
            repEvents1.DataSource = eventsList.GetRange( 0, 1 );
            repEvents1.DataBind();
        }
        repEvents2.DataSource = eventsList;
        repEvents2.DataBind();

        //高清大片
        if( editorialList.Count > 0 )
        {
            repEditorial1.DataSource = editorialList.GetRange( 0, 1 );
            repEditorial1.DataBind();
        }
        repEditorial2.DataSource = editorialList;
        repEditorial2.DataBind();

        //品牌新闻
        if( newsList.Count > 0 )
        {
            repNews1.DataSource = newsList.GetRange( 0, 1 );
            repNews1.DataBind();
        }
        repNews2.DataSource = newsList;
        repNews2.DataBind();
    }

    private List<AW_Article_bean> _kidList;
    public List<AW_Article_bean> kidList
    {
        get
        {
            if( _kidList == null )
            {
                _kidList = new AW_Article_dao().funcGetArticleListByUC( 121, 3, true, "", "", "", false );
            }
            return _kidList;
        }
    }

    private List<AW_Article_bean> _streetList;
    public List<AW_Article_bean> streetList
    {
        get
        {
            if( _streetList == null )
            {
                _streetList = new AW_Article_dao().funcGetArticleListByUC( 126, 3, true, "", "", "", false );
            }
            return _streetList;
        }
    }

    private List<AW_Article_bean> _newsList;
    public List<AW_Article_bean> newsList
    {
        get
        {
            if( _newsList == null )
            {
                _newsList = new AW_Article_dao().funcGetArticleListByUC( 130, 3, true, "", "", "", false );
            }
            return _newsList;
        }
    }

    private List<AW_Article_bean> _beautyList;
    public List<AW_Article_bean> beautyList
    {
        get
        {
            if( _beautyList == null )
            {
                _beautyList = new AW_Article_dao().funcGetArticleListByUC( 149, 3, true, "", "", "", false );
            }
            return _beautyList;
        }
    }

    private List<AW_Article_bean> _accessoryList;
    public List<AW_Article_bean> accessoryList
    {
        get
        {
            if( _accessoryList == null )
            {
                _accessoryList = new AW_Article_dao().funcGetArticleListByUC( 150, 3, true, "", "", "", false );
            }
            return _accessoryList;
        }
    }

    private List<AW_Article_bean> _eventsList;
    public List<AW_Article_bean> eventsList
    {
        get
        {
            if( _eventsList == null )
            {
                _eventsList = new AW_Article_dao().funcGetArticleListByUC( 151, 3, true, "", "", "", false );
            }
            return _eventsList;
        }
    }

    private List<AW_Article_bean> _editorialList;
    public List<AW_Article_bean> editorialList
    {
        get
        {
            if( _editorialList == null )
            {
                _editorialList = new AW_Article_dao().funcGetArticleListByUC( 128, 3, true, "", "", "", false );
            }
            return _editorialList;
        }
    }
}
