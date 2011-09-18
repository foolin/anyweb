using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Controls_RightSide1 : System.Web.UI.UserControl
{
    protected void Page_Load( object sender, EventArgs e )
    {
        repNew1.DataSource = newList.Count > 0 ? newList.GetRange( 0, 1 ) : null;
        repNew1.DataBind();
        repNew2.DataSource = newList.Count > 1 ? newList.GetRange( 1, newList.Count - 1 ) : null;
        repNew2.DataBind();
    }

    private List<AW_Article_bean> _newList;
    /// <summary>
    /// 最新要闻
    /// </summary>
    public List<AW_Article_bean> newList
    {
        get
        {
            if( _newList == null )
            {
                _newList = new AW_Article_dao().funcGetArticleListByUC( -1, 5, true, "", "fdArtiCreateAt DESC,fdArtiID DESC", "", false );
            }
            return _newList;
        }
    }
}
