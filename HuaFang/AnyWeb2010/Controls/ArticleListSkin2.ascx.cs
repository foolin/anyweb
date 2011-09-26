using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Controls_ArticleListSkin2 : System.Web.UI.UserControl
{
    protected int articleCount = 0;
    protected void Page_Load( object sender, EventArgs e )
    {
        List<AW_Article_bean> list = new AW_Article_dao().funcGetArticleListByUC( columnID, 14, true, "", "", "", false );
        articleCount = list.Count > 6 ? 6 : list.Count;
        rep1.DataSource = list.Count > 6 ? list.GetRange( 0, 6 ) : list;
        rep1.DataBind();
        rep2.DataSource = list.Count > 6 ? list.GetRange( 6, list.Count - 6 ) : null;
        rep2.DataBind();
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
