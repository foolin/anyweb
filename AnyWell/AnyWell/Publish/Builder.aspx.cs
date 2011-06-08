using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

public partial class Publish_Builder : System.Web.UI.Page
{
    string templatePath = "/Files/Template";
    bool view = false;

    protected void Page_Load( object sender, EventArgs e )
    {
        int sid = 0, cid = 0, did = 0;
        int.TryParse( QS( "sid" ), out sid );
        int.TryParse( QS( "cid" ), out cid );
        int.TryParse( QS( "did" ), out did );
        bool.TryParse( QS( "view" ), out view );
        string type = QS( "type" ).Trim().ToLower();

        Context.Items.Add( "OBJECTTYPE", null );

        if( type.Equals( "site" ) )
        {
            if( sid == 0 )
            {
                Fail( "站点不存在！" );
            }
            CurrentSite = new AW_Site_dao().funcGetSiteInfo( sid );
            if( CurrentSite == null )
            {
                Fail( "站点不存在！" );
            }
            if( CurrentSite.IndexTemplate == null )
            {
                Fail( "站点未设置首页模板！" );
            }
            BuildPage( CurrentSite.IndexTemplate );
            return;
        }
        else
        {
            if( cid == 0 )
            {
                Fail( "栏目不存在！" );
            }

            CurrentColumn = new AW_Column_dao().funcGetColumnInfo( cid );
            if( CurrentColumn == null )
            {
                Fail( "栏目不存在！" );
            }

            AW_Template_bean template = null;
            if( did > 0 )   //内容页
            {
                if( CurrentColumn.ContentTemplate != null )
                {
                    template = CurrentColumn.ContentTemplate;
                }
                else
                {
                    template = CurrentColumn.InheritedContentTemplate;
                }
                if( template == null )
                {
                    Fail( "栏目未设置内容模板！" );
                }
                AW_Template_bean currentTemplate = CurrentColumn.ContentTemplate == null ? CurrentSite.ContentTemplate : CurrentColumn.ContentTemplate;
                Context.Items[ "OBJECTTYPE" ] = CurrentColumn.fdColuType;
                switch( ( ColumnType ) CurrentColumn.fdColuType )
                {
                    case ColumnType.Article:
                        AW_Article_bean article = AW_Article_bean.funcGetByID( did );
                        if( article == null )
                        {
                            Fail( "文档不存在！" );
                        }
                        if( view )
                        {
                            if( article.fdArtiType == 2 || article.fdArtiType == 3 )
                            {
                                Response.Redirect( article.fdArtiLink );
                            }
                            if( article.fdArtiType == 4 )
                            {
                                Response.Redirect( string.Format( "Builder.aspx?view=true&sid={0}&cid={1}&did={2}", sid, cid, article.fdArtiSourceID ) );
                            }
                        }
                        break;
                    default:
                        return;
                }
                BuildPage( currentTemplate );
            }
            else   //栏目页
            {
                if( CurrentColumn.IndexTemplate != null )
                {
                    template = CurrentColumn.IndexTemplate;
                }
                else
                {
                    template = CurrentColumn.InheritedIndexTemplate;
                }
                if( template == null )
                {
                    Fail( "栏目未设置栏目模板！" );
                }
                if( CurrentColumn.fdColuType == ( int ) ColumnType.Single )
                {
                    Context.Items[ "OBJECTTYPE" ] = CurrentColumn.fdColuType;
                }
                BuildPage( template );
            }
        }
    }

    /// <summary>
    /// 生成页面
    /// </summary>
    /// <param name="template"></param>
    private void BuildPage( AW_Template_bean template )
    {
        string templateName = string.Format( "{0}/{1}/{2}.ascx", templatePath, CurrentSite.fdSiteID, template.fdTempName );
        string templateFile = Server.MapPath( templateName );
        if( File.Exists( templateFile ) )
        {
            Control templateControl = LoadControl( templateName );
            Controls.Add( templateControl );
        }
        else
        {
            Fail( string.Format( "模板文件[{0}]不存在！", template.fdTempName ) );
        }
        Response.ContentEncoding = Encoding.UTF8;
    }

    protected override void Render( HtmlTextWriter writer )
    {
        if( view )
        {
            TextWriter tempWriter = new StringWriter();
            base.Render( new HtmlTextWriter( tempWriter ) );
            string responseHTML = tempWriter.ToString();

            //样式文件
            string f1 = "<link.*href=\"(.+)\".*/>", t1 = string.Format( "<link rel=\"stylesheet\" type=\"text/css\" href=\"/{0}$1\"/>", CurrentSite.fdSitePath );
            //脚本文件
            string f2 = "<script.*src=\"(.+)\".*></script>", t2 = string.Format( "<script type=\"text/javascript\" src=\"/{0}$1\"></script>", CurrentSite.fdSitePath );
            //图片文件
            string f3 = "/*images", t3 = string.Format( "/{0}/images", CurrentSite.fdSitePath );
            responseHTML = Regex.Replace( responseHTML, f1, t1, RegexOptions.IgnoreCase );
            responseHTML = Regex.Replace( responseHTML, f2, t2, RegexOptions.IgnoreCase );
            responseHTML = Regex.Replace( responseHTML, f3, t3, RegexOptions.IgnoreCase );
            Response.Write( responseHTML );
        }
        else
        {
            base.Render( writer );
        }
    }

    private string QS( string key )
    {
        return Request.QueryString[ key ] + "";
    }

    private void Fail( string msg )
    {
        Response.Clear();
        Response.Write( msg );
        Response.End();
    }

    private AW_Site_bean _CurrentSite;
    /// <summary>
    /// 当前站点
    /// </summary>
    public AW_Site_bean CurrentSite
    {
        get
        {
            if( CurrentColumn != null )
            {
                _CurrentSite = CurrentColumn.Site;
            }
            return _CurrentSite;
        }
        set
        {
            _CurrentSite = value;
        }
    }

    private AW_Column_bean _CurrentColumn;
    /// <summary>
    /// 当前栏目
    /// </summary>
    public AW_Column_bean CurrentColumn
    {
        get
        {
            return _CurrentColumn;
        }
        set
        {
            _CurrentColumn = value;
        }
    }
}
