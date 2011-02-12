using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_ArticlesMove : PageAdmin
{
    protected override void OnPreRender( EventArgs e )
    {
        base.OnPreRender( e );
        if( string.IsNullOrEmpty( QF( "ids" ) ) )
        {
            WebAgent.AlertAndBack( "请选择文章" );
        }
        else
        {
            txtIds.Text = QF( "ids" );
        }
        int i = 0;
        List<AW_Column_bean> coluList = new AW_Column_dao().funcGetColumns();
        if( coluList.Count == 0 )
        {
            WebAgent.FailAndGo( "文章栏目为空，请先添加文章栏目！", "ColumnAdd.aspx" );
        }
        foreach( AW_Column_bean bean1 in coluList )
        {
            drpColumn.Items.Add( new ListItem( bean1.fdColuName, bean1.fdColuID.ToString() ) );
            litJs.Text += string.Format( "child[{0}] = new Array;", i );
            int j = 0;
            foreach( AW_Column_bean bean2 in bean1.Children )
            {
                litJs.Text += string.Format( "child[{0}][{1}] = \"{2}:{3}\";", i, j, bean2.fdColuID, bean2.fdColuName );
                j++;
            }
            i++;
        }

        ListItem li = drpColumn.Items.FindByValue( QS( "cid" ) );
        if( li != null )
            li.Selected = true;

        if( !this.IsPostBack && Request.UrlReferrer != null )
        {
            ViewState[ "REFURL" ] = Request.UrlReferrer.PathAndQuery;
        }
        else
        {
            ViewState[ "REFURL" ] = "ArticleList.aspx";
        }
    }

    protected void btnOk_Click( object sender, EventArgs e )
    {
        string childColumn = Request.Form[ "drpChild" ] + "";
        int columnID = 0;
        if( childColumn != "0" )
        {
            columnID = int.Parse( childColumn );
        }
        else
        {
            columnID = int.Parse( drpColumn.SelectedValue );
        }
        AW_Column_bean bean = AW_Column_bean.funcGetByID( columnID );
        if( bean == null )
        {
            WebAgent.AlertAndBack( "栏目不存在！" );
        }
        new AW_Article_dao().funcMoveArticle( bean.fdColuID, txtIds.Text.Trim() );
        this.AddLog( EventType.Update, "批量移动文章", "批量移动文章编号[" + txtIds.Text.Trim() + "]" );
        WebAgent.SuccAndGo( "文章移动成功！", ( string ) ViewState[ "REFURL" ] );
    }
}
