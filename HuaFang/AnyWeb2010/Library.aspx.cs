using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Library : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        library = AW_Library_bean.funcGetByID( int.Parse( ( string ) Context.Items[ "LIBRARYID" ] ) );
        if( library == null )
        {
            WebAgent.AlertAndBack( "页面不存在！" );
        }

        List<AW_Article_bean> list = new AW_Article_dao().funcGetArticleListByUC( -1, 14, true, string.Format( "fdArtiTitle='{0}' OR fdArtiTitle='{1}'", library.fdLibrName, library.fdLibrEnName ), "", "", false );
        if( list.Count > 0 )
        {
            rep1.DataSource = list.GetRange( 0, 1 );
            rep1.DataBind();
        }
        if( list.Count > 1 )
        {
            rep2.DataSource = list.GetRange( 1, list.Count > 3 ? 2 : list.Count - 1 );
            rep2.DataBind();
        }
        if( list.Count > 3 )
        {
            rep3.DataSource = list.GetRange( 3, list.Count - 3 );
            rep3.DataBind();
        }

        List<AW_Library_bean> relatedList = new AW_Library_dao().funcGetLibraryList( library.fdLibrType, library.fdLibrFirLetter, library.fdLibrID, 6 );
        repRelated.DataSource = relatedList;
        repRelated.DataBind();

        List<AW_Article_bean> picList = new AW_Article_dao().funcGetArticleListByUC( -1, 21, true, string.Format( "fdArtiType=1 AND (fdArtiTitle='{0}' OR fdArtiTitle='{1}')", library.fdLibrName, library.fdLibrEnName ), "", "", false );
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
