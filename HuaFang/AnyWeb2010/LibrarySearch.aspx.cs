using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.Configs;
using Studio.Web;
using AnyWell.AW_DL;

public partial class LibrarySearch : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = typeName + "搜索" + GeneralConfigs.GetConfig().TitleExtension;
        if( string.IsNullOrEmpty( QS("k") ) )
        {
            WebAgent.AlertAndBack( "请输入搜索关键词！" );
        }
        string keyword = QS( "k" );
        if( keyword.Contains( "%" ) )
        {
            keyword = keyword.Replace( "%", "[%]" );
        }
        if( keyword.Contains( "'" ) )
        {
            keyword = keyword.Replace( "'", "''" );
        }
        using( AW_Library_dao dao = new AW_Library_dao() )
        {
            rep.DataSource = dao.funcGetLibrary( type, keyword, PN1.PageSize, PN1.PageID );
            rep.DataBind();
            PN1.RecordCount = PN2.RecordCount = dao.propCount;
        }
    }

    private int _type;
    public int type
    {
        get
        {
            int.TryParse( ( string ) Context.Items[ "LIBRARYTYPE" ], out _type );
            return _type;
        }
        set
        {
            _type = value;
        }
    }

    public string typeName
    {
        get
        {
            switch( type )
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
