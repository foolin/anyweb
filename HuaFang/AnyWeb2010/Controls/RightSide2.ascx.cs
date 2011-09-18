using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Controls_RightSide2 : System.Web.UI.UserControl
{
    protected void Page_Load( object sender, EventArgs e )
    {
        repHot1.DataSource = hotList.Count > 0 ? hotList.GetRange( 0, 1 ) : null;
        repHot1.DataBind();
        repHot2.DataSource = hotList.Count > 1 ? hotList.GetRange( 1, hotList.Count - 1 ) : null;
        repHot2.DataBind();
    }

    private List<AW_Article_bean> _hotList;
    /// <summary>
    /// 近期热点
    /// </summary>
    public List<AW_Article_bean> hotList
    {
        get
        {
            if( _hotList == null )
            {
                _hotList = new AW_Article_dao().funcGetArticleListByUC( -1, 5, true, "", "fdArtiClick DESC", "", false );
            }
            return _hotList;
        }
    }
}
