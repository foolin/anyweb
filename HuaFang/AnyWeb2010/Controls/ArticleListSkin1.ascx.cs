using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Controls_ArticleListSkin1 : System.Web.UI.UserControl
{
    protected int articleCount = 0;
    protected void Page_Load( object sender, EventArgs e )
    {
        List<AW_Article_bean> list = new AW_Article_dao().funcGetArticleListByUC( columnID, 7, true, "", "", "", false );
        articleCount = list.Count > 0 ? list.Count - 1 : 0;
        if( list.Count > 0 )
        {
            rep1.DataSource = list.GetRange( 0, 1 );
            rep1.DataBind();
        }
        if( list.Count > 1 )
        {
            rep2.DataSource = list.GetRange( 1, list.Count - 1 );
            rep2.DataBind();
        }
    }

    private int _columnID;
    /// <summary>
    /// 栏目编号
    /// </summary>
    public int columnID
    {
        get
        {
            return _columnID;
        }
        set
        {
            _columnID = value;
        }
    }
}
