using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using AnyWell.Configs;
using Studio.Web;

public partial class LibraryList : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = typeName + GeneralConfigs.GetConfig().TitleExtension;
        using( AW_Library_dao dao = new AW_Library_dao() )
        {
            rep.DataSource = dao.funcGetLibrary( type, celebrityType, cate, sort, PN1.PageSize, PN1.PageID );
            rep.DataBind();
            PN1.RecordCount = dao.propCount;
            PN2.RecordCount = dao.propCount;
        }
    }

    private int _type;
    public int type
    {
        get
        {
            string context = ( string ) Context.Items[ "LIBRARYTYPE" ];
            if( context.IndexOf( "-" ) > -1 )
            {
                _type = 1;
                if( !int.TryParse( context.Substring( context.IndexOf( "-" ) + 1, 1 ), out _celebrityType ) )
                {
                    WebAgent.FailAndGo( "页面不存在！", "/index.aspx" );
                }
                if( celebrityType < 1 || celebrityType > 5 )
                {
                    WebAgent.FailAndGo( "页面不存在！", "/index.aspx" );
                }
            }
            else
            {
                _type = 2;
            }
            return _type;
        }
        set
        {
            _type = value;
        }
    }

    private int _celebrityType;
    public int celebrityType
    {
        get
        {
            return _celebrityType;
        }
        set
        {
            _celebrityType = value;
        }
    }

    public string typeName
    {
        get
        {
            switch( type )
            {
                case 1:
                    switch( celebrityType )
                    {
                        case 1:
                            return "明星库";
                        case 2:
                            return "潮人库";
                        case 3:
                            return "大师库";
                        case 4:
                            return "超模库";
                        case 5:
                            return "圈中人";
                        default:
                            return "";
                    }
                case 2:
                    return "品牌馆";
                default:
                    return "";
            }
        }
    }

    private int _cate;
    public int cate
    {
        get
        {
            int.TryParse( QS( "c" ), out _cate );
            return _cate;
        }
        set
        {
            _cate = value;
        }
    }

    private int _sort;
    public int sort
    {
        get
        {
            int.TryParse( QS( "s" ), out _sort );
            return _sort;
        }
        set
        {
            _sort = value;
        }
    }

    public string cateName
    {
        get
        {
            switch( cate )
            {
                case 0:
                    return "A";
                case 1:
                    return "B";
                case 2:
                    return "C";
                case 3:
                    return "D";
                case 4:
                    return "E";
                case 5:
                    return "F";
                case 6:
                    return "G";
                case 7:
                    return "H";
                case 8:
                    return "I";
                case 9:
                    return "J";
                case 10:
                    return "K";
                case 11:
                    return "L";
                case 12:
                    return "M";
                case 13:
                    return "N";
                case 14:
                    return "O";
                case 15:
                    return "P";
                case 16:
                    return "Q";
                case 17:
                    return "R";
                case 18:
                    return "S";
                case 19:
                    return "T";
                case 20:
                    return "U";
                case 21:
                    return "V";
                case 22:
                    return "W";
                case 23:
                    return "X";
                case 24:
                    return "Y";
                case 25:
                    return "Z";
                default:
                    return "其他";
            }
        }
    }

    private string _currentLink;
    public string currentLink
    {
        get
        {
            if( string.IsNullOrEmpty( _currentLink ) )
            {
                if( type == 1 )
                {
                    _currentLink = string.Format( "/l/1-{0}.aspx", celebrityType );
                }
                else
                {
                    _currentLink = "/l/2.aspx";
                }
            }
            return _currentLink;
        }
        set
        {
            _currentLink = value;
        }
    }
}
