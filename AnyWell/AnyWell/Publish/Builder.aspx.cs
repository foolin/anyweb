using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using System.IO;

public partial class Publish_Builder : System.Web.UI.Page
{
    string templatePath = "/Files/Template";

    protected void Page_Load( object sender, EventArgs e )
    {
        int sid = 0, cid = 0, did = 0;
        int.TryParse( QS( "sid" ), out sid );
        int.TryParse( QS( "cid" ), out cid );
        int.TryParse( QS( "did" ), out did );
        string type = QS( "type" ).Trim().ToLower();

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

            if( did > 0 )   //内容页
            {
                if( CurrentColumn.ContentTemplate == null && CurrentSite.ContentTemplate == null )
                {
                    Fail( "栏目未设置内容模板！" );
                }
                AW_Template_bean currentTemplate = CurrentColumn.ContentTemplate == null ? CurrentSite.ContentTemplate : CurrentColumn.ContentTemplate;
                switch( ( ColumnType ) CurrentColumn.fdColuType )
                {
                    case ColumnType.Article:
                        AW_Article_bean article = AW_Article_bean.funcGetByID( did );
                        if( article == null )
                        {
                            Fail( "文档不存在！" );
                        }
                        break;
                    default:
                        return;
                }
                BuildPage( currentTemplate );
            }
            else   //栏目页
            {
                if( CurrentColumn.IndexTemplate == null )
                {
                    Fail( "栏目未设置栏目模板！" );
                }
                BuildPage( CurrentColumn.IndexTemplate );
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
