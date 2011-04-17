using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_Content_SiteArticleSearch : PageAdmin
{
    private string field = "";
    private string orderBy = "";
    protected string key = "";
    protected int type = -1;
    protected DateTime from, to;

    protected void Page_Load( object sender, EventArgs e )
    {
        int sid = 0;

        int.TryParse( QS( "id" ), out sid );

        if( sid == 0 )
        {
            ShowError( "请选择站点！" );
        }

        CurrentSite = new AW_Site_dao().funcGetSiteInfo( sid );
        if( CurrentSite == null )
        {
            ShowError( "站点不存在！" );
        }

        key = QS( "key" ).Trim();

        if( !string.IsNullOrEmpty( QS( "from" ) ) )
        {
            if( !DateTime.TryParse( QS( "from" ), out from ) )
            {
                WebAgent.AlertAndBack( "起始时间格式错误！" );
            }
        }
        else
        {
            from = DateTime.Parse( "1900-01-01" );
        }

        if( !string.IsNullOrEmpty( QS( "to" ) ) )
        {
            if( !DateTime.TryParse( QS( "to" ), out to ) )
            {
                WebAgent.AlertAndBack( "结束时间格式错误！" );
            }
        }
        else
        {
            to = DateTime.Parse( "2099-01-01" );
        }

        if( from > to )
        {
            WebAgent.AlertAndBack( "起始时间不能大于结束时间！" );
        }

        if( !string.IsNullOrEmpty( QS( "type" ) ) && WebAgent.IsInt32( QS( "type" ) ) )
        {
            type = int.Parse( QS( "type" ) );
        }

        if( string.IsNullOrEmpty( key ) && from == DateTime.Parse( "1900-01-01" ) && to == DateTime.Parse( "2099-01-01" ) && type == -1 )
        {
            noDatas.Visible = true;
            noDatas.InnerHtml = "请输入搜索条件";
            tableFooter.Visible = false;
        }
        else
        {
            field = QS( "field" );
            orderBy = QS( "orderby" ) == "1" ? "ASC" : "DESC";
            int recordCount = 0;
            List<AW_Article_bean> list = new AW_Article_dao().funcSearchSiteArticle( CurrentSite.fdSiteID, key, from, to, type, field, orderBy, PN1.PageIndex, PN1.PageSize, out recordCount );
            if( list.Count > 0 )
            {
                repArticles.DataSource = list;
                repArticles.DataBind();
                PN1.SetPage( recordCount );
                litRecords.Text = recordCount.ToString();
            }
            else
            {
                noDatas.Visible = true;
                noDatas.InnerHtml = "找不到任何文档";
                tableFooter.Visible = false;
            }
        }
    }

    /// <summary>
    /// 获取排序JS函数
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected string getOrderJs( string orderField )
    {
        return string.Format( "setArticleOrder('{0}',{1})", orderField, field == orderField ? orderBy == "ASC" ? 0 : 1 : 1 );
    }

    /// <summary>
    /// 获取排序样式
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    protected string getOrderCssClass( string orderField )
    {
        if( field == orderField )
        {
            return orderBy.ToLower();
        }
        else
        {
            return "";
        }
    }
}
