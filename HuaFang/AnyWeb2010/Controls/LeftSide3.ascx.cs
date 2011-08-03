using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Controls_LeftSide3 : System.Web.UI.UserControl
{
    protected void Page_Load( object sender, EventArgs e )
    {
        repRecomment1.DataSource = recommentList.Count > 0 ? recommentList.GetRange( 0, 1 ) : null;
        repRecomment1.DataBind();
        repRecomment2.DataSource = recommentList.Count > 1 ? recommentList.GetRange( 1, recommentList.Count - 1 ) : null;
        repRecomment2.DataBind();
    }

    private List<AW_Article_bean> _recommentList;
    /// <summary>
    /// 特别推介
    /// </summary>
    public List<AW_Article_bean> recommentList
    {
        get
        {
            if( _recommentList == null )
            {
                _recommentList = new AW_Article_dao().funcGetArticleListByUC( -1, 5, true, "fdArtiRecommend=1", "fdArtiSort DESC,fdArtiID DESC", "", false );
            }
            return _recommentList;
        }
    }
}
