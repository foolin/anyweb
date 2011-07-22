using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.Configs;
using Studio.Web;
using AnyWell.AW_DL;

public partial class ArticleSearch : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = "资讯搜索" + GeneralConfigs.GetConfig().TitleExtension;
        if( string.IsNullOrEmpty( Request.QueryString[ "k" ] + "" ) )
        {
            WebAgent.AlertAndBack( "请输入搜索关键词！" );
        }
        string keyword = Request.QueryString[ "k" ];
        if( keyword.Contains( "%" ) )
        {
            keyword = keyword.Replace( "%", "[%]" );
        }
        if( keyword.Contains( "'" ) )
        {
            keyword = keyword.Replace( "'", "''" );
        }
        string querryString = SearchKeyWord.getQueryString( keyword );
        int record = 0;
        List<AW_Article_bean> list = new List<AW_Article_bean>();
        using( AW_Article_dao dao = new AW_Article_dao() )
        {
            list = dao.funcGetSearchArtcile( querryString, PN1.PageID, PN1.PageSize, out record );
        }
        if( record == 0 )
        {
            divSearch.Visible = false;
            divNull.Visible = true;
        }
        else
        {
            rep1.DataSource = list.Count > 5 ? list.GetRange( 0, 5 ) : list;
            rep1.DataBind();
            if( list.Count > 5 )
            {
                rep2.DataSource = list.GetRange( 5, list.Count >= 10 ? 5 : list.Count - 5 );
                rep2.DataBind();
            }
            else
            {
                div1.Visible = false;
            }
            if( list.Count > 10 )
            {
                rep3.DataSource = list.GetRange( 10, list.Count - 10 );
                rep3.DataBind();
            }
            else
            {
                div2.Visible = false;
            }
        }
        PN1.RecordCount = record;
        PN2.RecordCount = record;
    }
}
