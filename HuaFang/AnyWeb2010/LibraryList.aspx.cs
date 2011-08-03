using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using AnyWell.Configs;

public partial class LibraryList : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = typeName + GeneralConfigs.GetConfig().TitleExtension;
        using( AW_Library_dao dao = new AW_Library_dao() )
        {
            rep.DataSource = dao.funcGetLibrary( type, cate, PN1.PageSize, PN1.PageID );
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
                    return "名人馆";
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
}
