using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Content_SiteArticleRecycleList : PageAdmin
{
    private string field = "";
    private string orderBy = "";

    protected void Page_Load( object sender, EventArgs e )
    {
        int sid = 0;

        int.TryParse( QS( "id" ), out sid );

        if( sid == 0 )
        {
            ShowError( "请选择站点！" );
        }

        AW_Site_dao dao = new AW_Site_dao();
        CurrentSite = dao.funcGetSiteInfo( sid );
        if( CurrentSite == null )
        {
            ShowError( "站点不存在！" );
        }

        field = QS( "field" );

        orderBy = QS( "orderby" ) == "1" ? "ASC" : "DESC";

        int recordCount = 0;
        List<AW_Article_bean> list = new AW_Article_dao().funcGetSiteArticleRecycleList( CurrentSite.fdSiteID, field, orderBy, PN1.PageIndex, PN1.PageSize, out recordCount );
        if( list.Count == 0 )
        {
            noDatas.Visible = true;
            tableFooter.Visible = false;
        }
        else
        {
            repArticles.DataSource = list;
            repArticles.DataBind();
            PN1.SetPage( recordCount );
            litRecords.Text = recordCount.ToString();
        }
    }

    /// <summary>
    /// 获取排序JS函数
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected string getOrderJs( string key )
    {
        return string.Format( "setArticleOrder('{0}',{1})", key, key == field ? orderBy == "ASC" ? 0 : 1 : 1 );
    }

    /// <summary>
    /// 获取排序样式
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected string getOrderCssClass( string key )
    {
        if( field == key )
        {
            return orderBy.ToLower();
        }
        else
        {
            return "";
        }
    }
}
