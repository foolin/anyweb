<%@ Application Language="C#" %>
<%@ Import Namespace="System.IO" %>

<script RunAt="server">

    void Application_Start( object sender, EventArgs e )
    {
        //在应用程序启动时运行的代码

    }

    void Application_End( object sender, EventArgs e )
    {
        //在应用程序关闭时运行的代码

    }

    /// <summary>
    /// 错误日志
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Application_Error( object sender, EventArgs e )
    {
        if( ConfigurationManager.AppSettings[ "LogEnable" ] == "1" )
        {
            HttpContext Context = ( ( HttpApplication ) sender ).Context;
            foreach( Exception ex in Context.AllErrors )
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat( "Time:{0}\r\n", DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ) );
                if( HttpContext.Current != null && HttpContext.Current.Request != null )
                {
                    sb.AppendFormat( "IP:{0}\r\n", HttpContext.Current.Request.UserHostAddress )
                        .AppendFormat( "Url:{0}\r\n", HttpContext.Current.Request.RawUrl )
                        .AppendFormat( "UrlRef:{0}\r\n", HttpContext.Current.Request.UrlReferrer == null ? "" : HttpContext.Current.Request.UrlReferrer.ToString() )
                        .AppendFormat( "Message:{0}\r\n\r\n", ex.ToString() );
                }
                else
                {
                    sb.Append( ex.ToString() )
                        .Append( "\r\n" );
                }

                try
                {
                    FileInfo fi = new FileInfo( Server.MapPath( "/Error.log" ) );
                    if( fi.Exists && fi.Length > 1024 * 1024 * 100 )
                    {
                        fi.MoveTo( Server.MapPath( string.Format( "/Error_{0}.log", DateTime.Now.ToString( "yyyyMMddHHmmss" ) ) ) );
                    }
                    Studio.IO.FileAgent.WriteText( Server.MapPath( "/Error.log" ), sb.ToString(), true );
                }
                finally
                {
                }
            }
        }
    }

    void Session_Start( object sender, EventArgs e )
    {
        //在新会话启动时运行的代码

    }

    void Session_End( object sender, EventArgs e )
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。

    }

    protected void Application_BeginRequest( Object sender, EventArgs e )
    {
        string actualPath;
        AnalyseRequest( out actualPath );
        if( actualPath == string.Empty || actualPath == null )
            actualPath = "/index.aspx";
        Context.RewritePath( actualPath, Request.PathInfo, Request.QueryString.ToString() );
    }

    void AnalyseRequest( out string realPath )
    {
        realPath = "/index.aspx";
        string requestPath = Request.Path.ToLower();
        if( requestPath.IndexOf( "/admin" ) > -1 )  //管理后台
        {
            realPath = Request.Path;
            return;
        }
        if( requestPath.IndexOf( "/user" ) > -1 )   //会员后台
        {
            realPath = Request.Path;
            return;
        }
        foreach( string url in urls )
        {
            if( requestPath.Equals( url ) )
            {
                realPath = requestPath;
                return;
            }
        }
        requestPath = Request.Path.ToLower().Replace( "\\", "/" ).Replace( ".aspx", "" ).Substring( 1 );

        if( requestPath.EndsWith( "/" ) )
            requestPath = requestPath.Remove( requestPath.Length - 1, 1 );

        string[] urlInfo = requestPath.Split( '/' );
        if( urlInfo.Length < 2 )
        {
            realPath = "/Error.aspx";
        }
        switch( urlInfo[ 0 ] )
        {
            case "a":   //文章内容页
                {
                    realPath = "/Article.aspx";
                    Context.Items.Add( "ARTICLEID", urlInfo[ 1 ] );
                    break;
                }
            case "c":   //文章列表页
                {
                    realPath = "/Column.aspx";
                    Context.Items.Add( "COLUMNID", urlInfo[ 1 ] );
                    break;
                }
            case "n":   //公告内容页
                {
                    realPath = "/NoticeDetail.aspx";
                    Context.Items.Add( "NOTICEID", urlInfo[ 1 ] );
                    break;
                }
            case "r":   //招聘详情页
                {
                    realPath = "/Recruit.aspx";
                    Context.Items.Add( "RECRUITID", urlInfo[ 1 ] );
                    break;
                }
            case "s":
                {
                    realPath = "/SiteInfo.aspx";
                    Context.Items.Add( "SITEINFOID", urlInfo[ 1 ] );
                    break;
                }
            default:
                {
                    realPath = "/Error.aspx";
                    break;
                }
        }
    }

    string[] urls = { "/", "/index.aspx", "/login.aspx", "/import.aspx", "/User/Index.aspx", "/logout.aspx", "/search.aspx", "/register.aspx", "/notice.aspx", "/addfavorite.aspx", "/applyresume.aspx", "/applyresumes.aspx", "/refurbishall.aspx", "/recruitlist.aspx", "/getpassword.aspx", "/resetpwd.aspx", "/error.aspx", "/initarea.aspx", "/initmajor.aspx", "/initindustryweb.aspx", "/initindustry2.aspx", "/initposition.aspx", "/initpositionweb.aspx", "/initpositionweb2.aspx" };
       
</script>

