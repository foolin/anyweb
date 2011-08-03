using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using System.Text.RegularExpressions;

public partial class Controls_FashionArticleListSkin2 : System.Web.UI.UserControl
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( column == null )
        {
            return;
        }

        List<AW_Article_bean> list = new AW_Article_dao().funcGetArticleListByUC( column.fdColuID, 9, false, "", "", "", false );
        if( list.Count > 0 )
        {
            rep1.DataSource = list.GetRange( 0, list.Count > 8 ? 8 : list.Count );
            rep1.DataBind();
        }
        if( list.Count > 8 )
        {
            rep2.DataSource = list.GetRange( 8, 1 );
            rep2.DataBind();
        }
    }

    private AW_Column_bean _column;
    public AW_Column_bean column
    {
        get
        {
            return _column;
        }
        set
        {
            _column = value;
        }
    }

    public string[] splitName
    {
        get
        {
            string[] str = new string[ 2 ];
            string ch = "[\u4e00-\u9fa5]+";
            string en = "[^\u4e00-\u9fa5]+";
            Regex reg = new Regex( ch );
            str[ 0 ] = reg.Match( column.fdColuName ).Value;
            Regex reg2 = new Regex( en );
            str[ 1 ] = reg2.Match( column.fdColuName ).Value;
            return str;
        }
    }
}
