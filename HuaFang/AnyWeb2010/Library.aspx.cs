using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;
using AnyWell.Configs;

public partial class Library : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        library = AW_Library_bean.funcGetByID( int.Parse( ( string ) Context.Items[ "LIBRARYID" ] ) );
        if( library == null )
        {
            WebAgent.AlertAndBack( "页面不存在！" );
        }
        this.Title = string.Format( "{0}({1}){2}", library.fdLibrName, library.fdLibrEnName, GeneralConfigs.GetConfig().TitleExtension );

        preLibrary = new AW_Library_dao().funcGetPreLibrary( library );
        nextLibrary = new AW_Library_dao().funcGetNextLibrary( library );

        List<AW_Article_bean> list = new AW_Article_dao().funcGetArticleListByLibrary( -1, 11, "fdArtiType=0", library );
        rep.DataSource = list;
        rep.DataBind();

        List<AW_Library_bean> relatedList = new AW_Library_dao().funcGetLibraryList( library.fdLibrType, library.fdLibrFirLetter, library.fdLibrID, 6 );
        repRelated.DataSource = relatedList;
        repRelated.DataBind();

        List<AW_Article_bean> picList = new AW_Article_dao().funcGetArticleListByLibrary( -1, 21, "fdArtiType<>0", library );
        repPic.DataSource = picList;
        repPic.DataBind();
    }

    private AW_Library_bean _library;
    public AW_Library_bean library
    {
        get
        {
            return _library;
        }
        set
        {
            _library = value;
        }
    }

    private AW_Library_bean _preLibrary;
    public AW_Library_bean preLibrary
    {
        get
        {
            return _preLibrary;
        }
        set
        {
            _preLibrary = value;
        }
    }

    private AW_Library_bean _nextLibrary;
    public AW_Library_bean nextLibrary
    {
        get
        {
            return _nextLibrary;
        }
        set
        {
            _nextLibrary = value;
        }
    }

    public string typeName
    {
        get
        {
            switch( library.fdLibrType )
            {
                case 1:
                    return "名人馆";
                case 2:
                    return "品牌馆";
                default:
                    return "";
            }
        }
    }

    public string typeShortName
    {
        get
        {
            switch( library.fdLibrType )
            {
                case 1:
                    return "名人";
                case 2:
                    return "品牌";
                default:
                    return "";
            }
        }
    }
}
