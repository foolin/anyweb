using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.IO;
using System.Web.UI;
using System.Text;

/// <summary>
///PageBase 的摘要说明
/// </summary>
public class PageBase : System.Web.UI.Page
{
    public PageBase()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    protected virtual void BuildPage( string templatePath )
    {
        string templateFile = Server.MapPath( templatePath );
        if( File.Exists( templateFile ) )
        {
            Control templateControl = LoadControl( templatePath );
            Controls.Add( templateControl );
        }
        else
        {
            Fail( string.Format( "模板文件[{0}]不存在！", templatePath ) );
        }
        Response.ContentEncoding = Encoding.UTF8;
    }

    private int _siteID;
    /// <summary>
    /// 站点编号
    /// </summary>
    public int SiteID
    {
        get
        {
            if( _siteID == 0 )
            {
                _siteID = int.Parse( ConfigurationManager.AppSettings[ "SiteID" ] );
            }
            return _siteID;
        }
    }

    protected string QS( string key )
    {
        return Request.QueryString[ key ] + "";
    }

    protected string QF( string key )
    {
        return Request.Form[ key ] + "";
    }

    protected virtual void Fail( string msg )
    {
        Response.Clear();
        Response.Write( msg );
        Response.End();
    }
}
