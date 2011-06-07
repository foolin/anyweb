using System;
using System.Collections.Generic;
using System.Web;
using System.Timers;
using AnyWell.AW_DL;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// 发布服务
/// </summary>
public class PublishService
{
    Timer pubTimer;
    List<AW_Publish_bean> nPublish = new List<AW_Publish_bean>();//新任务队列
    List<AW_Publish_bean> pPublish = new List<AW_Publish_bean>();//当前执行中队列
    //List<AW_Publish_bean> cPublish = new List<AW_Publish_bean>();//当前已完成队列

    public PublishService()
    {
        //发布任务计时器
        pubTimer = new Timer( 1000 * 5 );
        pubTimer.Elapsed += new ElapsedEventHandler( pubTimer_Elapsed );
    }

    void pubTimer_Elapsed( object sender, ElapsedEventArgs e )
    {
        ( ( Timer ) sender ).Enabled = false;
        //执行发布任务
        try
        {
            ProcessPublish();
        }
        catch( Exception ex )
        {
            //string content = "\r\n" + DateTime.Now.ToString() + "\r\n";
            //content += ex.InnerException.ToString();
            //content += "\r\n\r\n";
            //FileAgent.WriteText( HttpContext.Current.Server.MapPath( "/log/pub.log" ), content, true );
            throw ex;
        }
        finally
        {
            ( ( Timer ) sender ).Enabled = true;
        }
    }

    /// <summary>
    /// 执行发布(状态码：0发布成功101未设置模板500发布命令页面错误)
    /// </summary>
    void ProcessPublish()
    {
        if( nPublish.Count == 0 )
        {
            return;
        }
        lock( this )
        {
            pPublish = new List<AW_Publish_bean>( nPublish );
            nPublish.Clear();
        }

        AW_Publish_dao publishDao = new AW_Publish_dao();

        foreach( AW_Publish_bean bean in pPublish )
        {
            if( bean.fdPublStatus != 4 )//发布任务未取消
            {
                bean.fdPublStatus = 1;
                int result = 0;
                bean.fdPublStartAt = DateTime.Now;
                publishDao.funcUpdateStatus( bean );
                string error = "";//错误信息
                try
                {
                    switch( bean.ObjectType )
                    {
                        case PublishObjectType.Site:
                            {
                                AW_Site_bean site = new AW_Site_dao().funcGetSiteInfo( bean.fdPublObjID );
                                if( site != null )
                                {
                                    result = PublishSite( bean, site, bean.PublishType );
                                }
                                break;
                            }
                        case PublishObjectType.Column:
                            {
                                bool pubSite = bean.PublishType == PublishType.HomeOnly ? false : true;
                                AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( bean.fdPublObjID );
                                if( column != null )
                                {
                                    result = PublishColumn( bean, column, pubSite, bean.PublishType );
                                }
                                break;
                            }
                        case PublishObjectType.Document:
                            {
                                result = PublishDocument( bean, bean.fdPublObjID, true, bean.PublishType );
                                break;
                            }
                        case PublishObjectType.Single:
                            {
                                result = PublishSingleDocument( bean, bean.fdPublObjID, bean.PublishType );
                                break;
                            }
                        //case QueueObjectType.Product:
                        //    {
                        //        result = PublishProduct( queue, queue.Column, queue.fdQueuObjID, true, queue.PublishType );
                        //        break;
                        //    }
                    }
                }
                catch( Exception ex )
                {
                    //Studio.IO.FileAgent.WriteText( IBOXSetting.GetSetting().LogPath + "\\PubError.log", DateTime.Now.ToString() + "发布错误：" + queue.fdQueuName + "\r\n" + ex.ToString() + "\r\n", true );
                    result = 500;
                    error = ex.Message;
                }
                bean.fdPublFinishAt = DateTime.Now;
                if( result == 101 )
                {
                    bean.fdPublError = "未设置模板";
                }
                else if( result == 500 )
                {
                    bean.fdPublError = string.Format( "{0}({1})", BuilderPath, error );
                }
                if( result == 0 )
                {
                    bean.fdPublStatus = 2;
                }
                else
                {
                    bean.fdPublStatus = 3;
                }
                publishDao.funcUpdateStatus( bean );
            }
            else
            {
                publishDao.funcDelete( bean.fdPublID );//删除发布任务
            }
        }
        lock( this )//转到已完成队列
        {
            //cPublish.AddRange( pPublish );
            pPublish.Clear();
        }
    }

    /// <summary>
    /// 发布文档
    /// </summary>
    /// <param name="queue"></param>
    /// <param name="column"></param>
    /// <param name="docID"></param>
    /// <param name="pubColumn"></param>
    /// <param name="pubType"></param>
    /// <returns></returns>
    int PublishDocument( AW_Publish_bean publish, int docID, bool pubColumn, PublishType pubType )
    {
        switch( pubType )
        {
            case PublishType.Cancel:
                {
                    return this.CancelPublishDocument( publish, docID, true );
                }
            default:
                {
                    AW_Article_bean article = AW_Article_bean.funcGetByID( docID );
                    if( article == null )
                    {
                        return 100;
                    }
                    AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( article.fdArtiColuID );

                    if( column == null )
                    {
                        return 100;
                    }

                    article.Column = column;
                    if( article.fdArtiType == 4 )
                    {
                        PublishDocument( publish, article.fdArtiSourceID, pubColumn, pubType );
                    }
                    else
                    {
                        string exe, saveTo;
                        AW_Template_bean template = column.ContentTemplate;
                        if( template == null )
                        {
                            template = column.InheritedContentTemplate;
                        }

                        //发布文章页面，支持内容分页
                        for( int pageID = 1; pageID <= article.PageCount; pageID++ )
                        {
                            exe = string.Format( "{0}?cid={1}&did={2}&dpid={3}&urlprefix={4}", this.BuilderPath, column.fdColuID, article.fdArtiID, pageID, article.Url.Replace( article.fdArtiID.ToString(), article.fdArtiID.ToString() + "__pid" ) );
                            saveTo = string.Format( "{0}\\{1}\\{2}\\{3}", this.PublishPath, column.Site.fdSitePath, column.fdColuID, article.fdArtiID );
                            string htmlFile = PublishPage( exe, saveTo, pageID );
                        }
                    }
                    if( pubColumn ) //级联更新栏目首页
                    {
                        AW_Column_bean parent = column;
                        while( parent != null )
                        {
                            PublishColumn( publish, column, true, PublishType.HomeOnly );
                            parent = parent.Parent;
                        }
                    }
                    //更新文章状态
                    new AW_Article_dao().funcPublishArticleByIds( article.fdArtiID.ToString(), 2 );
                    return 0;
                }
        }
    }

    /// <summary>
    /// 撤消发布文档
    /// </summary>
    /// <param name="queue"></param>
    /// <param name="docID"></param>
    /// <param name="pubColumn"></param>
    /// <returns></returns>
    int CancelPublishDocument( AW_Publish_bean publish, int docID, bool pubColumn )
    {
        AW_Article_bean article = AW_Article_bean.funcGetByID( docID );
        if( article == null )
        {
            return 100;
        }
        AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( article.fdArtiColuID );
        if( column == null )
        {
            return 100;
        }

        if( article.fdArtiType != 4 )
        {
            string directory = string.Format( "{0}\\{1}\\{2}\\", this.PublishPath, column.Site.fdSitePath, column.fdColuID );
            DirectoryInfo dirPub = new DirectoryInfo( directory );
            if( !dirPub.Exists )
            {
                return 0;
            }

            FileInfo file = new FileInfo( directory + docID.ToString() + ".html" );
            if( file.Exists )
            {
                file.Delete();
            }
            FileInfo[] files = dirPub.GetFiles( docID.ToString() + "_*", SearchOption.TopDirectoryOnly );
            foreach( FileInfo f in files )
            {
                f.Delete();
            }
        }
        if( pubColumn ) //级联更新栏目首页
        {
            AW_Column_bean parent = column;
            while( parent != null )
            {
                PublishColumn( publish, column, true, PublishType.HomeOnly );
                parent = parent.Parent;
            }
        }
        new AW_Article_dao().funcPublishArticleByIds( article.fdArtiID.ToString(), 0 );
        return 0;
    }

    /// <summary>
    /// 发布单篇文档栏目
    /// </summary>
    /// <param name="publish">发布任务</param>
    /// <param name="docID">栏目编号</param>
    /// <param name="pubType">发布类型</param>
    /// <returns></returns>
    int PublishSingleDocument( AW_Publish_bean publish, int docID, PublishType pubType )
    {
        switch( pubType )
        {
            case PublishType.Cancel:
                {
                    return this.CancelPublishSingleDocument( publish, docID );
                }
            default:
                {
                    AW_SingleArticle_bean article = new AW_SingleArticle_dao().funcGetSingleArticle( docID );
                    if( article == null )
                    {
                        return 100;
                    }
                    AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( docID );

                    if( column == null )
                    {
                        return 100;
                    }

                    article.Column = column;

                    string exe, saveTo;

                    for( int pageID = 1; pageID <= article.PageCount; pageID++ )
                    {
                        exe = string.Format( "{0}?sid={4}&cid={1}&dpid={2}&urlprefix={3}", this.BuilderPath, column.fdColuID, pageID, column.Url.Replace( column.fdColuID.ToString(), column.fdColuID.ToString() + "__pid" ), column.fdColuSiteID );
                        saveTo = string.Format( "{0}\\{1}\\{2}\\", this.PublishPath, column.Site.fdSitePath, column.fdColuID );
                        string htmlFile = PublishPage( exe, saveTo, pageID );
                    }
                    return 0;
                }
        }
    }

    /// <summary>
    /// 撤消发布单篇文档栏目
    /// </summary>
    /// <param name="publish"></param>
    /// <param name="docID"></param>
    /// <returns></returns>
    int CancelPublishSingleDocument( AW_Publish_bean publish, int docID )
    {
        AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( docID );
        if( column == null )
        {
            return 100;
        }
        string directory = string.Format( "{0}\\{1}\\{2}\\", this.PublishPath, column.Site.fdSitePath, column.fdColuID );
        DirectoryInfo dirPub = new DirectoryInfo( directory );
        if( !dirPub.Exists )
        {
            return 0;
        }

        FileInfo file = new FileInfo( directory + "index.html" );
        if( file.Exists )
        {
            file.Delete();
        }
        FileInfo[] files = dirPub.GetFiles( "index_*", SearchOption.TopDirectoryOnly );
        foreach( FileInfo f in files )
        {
            f.Delete();
        }
        return 0;
    }

    /// <summary>
    /// 发布栏目
    /// </summary>
    /// <param name="publish">发布任务</param>
    /// <param name="column">发布的栏目</param>
    /// <param name="column">是否更新站点首页</param>
    /// <param name="pubType">发布类型</param>
    /// <returns></returns>
    int PublishColumn( AW_Publish_bean publish, AW_Column_bean column, bool pubSite, PublishType pubType )
    {
        string exe = this.BuilderPath;
        string saveTo = string.Format( "{0}\\{1}{2}", this.PublishPath, column.Site.fdSitePath, column.VirtualPath.Replace( "/", "\\" ) );
        switch( pubType )
        {
            case PublishType.HomeOnly:
                {
                    AW_Template_bean template = null;
                    if( column.IndexTemplate != null )
                    {
                        template = column.IndexTemplate;
                    }
                    else
                    {
                        template = column.InheritedIndexTemplate;
                    }
                    if( template == null )
                    {
                        return 101;
                    }
                    exe += string.Format( "?sid={0}&cid={1}&urlprefix={2}", column.fdColuSiteID, column.fdColuID.ToString(), column.Url.Replace( "index", "index__pid" ) );
                    string htmlFile = PublishPage( exe, saveTo, 1 );

                    string hasPagerReg = "(<AW:ARTICLELIST|<AW:PICTURELIST|<AW:PRODUCTLIST|<AW:EXHIBITORLIST)[^>]+PAGERID=";
                    Match mPager = Regex.Match( template.fdTempContent, hasPagerReg, RegexOptions.IgnoreCase );
                    if( mPager.Success )
                    {
                        int pageSize = 20;
                        string pageSizeReg = "(?<=PAGESIZE=['\"])\\d+?(?=['\"])";
                        Match mPageSize = Regex.Match( template.fdTempContent, pageSizeReg, RegexOptions.IgnoreCase );
                        if( mPageSize.Success )
                        {
                            pageSize = int.Parse( mPageSize.Value );
                        }

                        string getChildReg1 = "(<AW:ARTICLELIST|<AW:PICTURELIST|<AW:PRODUCTLIST|<AW:EXHIBITORLIST)[^>]+PAGERID=[^>]+GETCHILD=['\"]TRUE['\"]";
                        string getChildReg2 = "(<AW:ARTICLELIST|<AW:PICTURELIST|<AW:PRODUCTLIST|<AW:EXHIBITORLIST)[^>]+GETCHILD=['\"]TRUE['\"][^>]+PAGERID=";

                        bool getChild = false;
                        if( Regex.IsMatch( template.fdTempContent, getChildReg1, RegexOptions.IgnoreCase ) || Regex.IsMatch( template.fdTempContent, getChildReg1, RegexOptions.IgnoreCase ) )
                        {
                            getChild = true;
                        }

                        string getWhereReg1 = "(<AW:ARTICLELIST|<AW:PICTURELIST|<AW:PRODUCTLIST|<AW:EXHIBITORLIST)[^>]+PAGERID=[^>]+WHERE=['\"]\\s+?['\"]";
                        string getWhereReg2 = "(<AW:ARTICLELIST|<AW:PICTURELIST|<AW:PRODUCTLIST|<AW:EXHIBITORLIST)[^>]+WHERE=['\"]\\s+?['\"][^>]+PAGERID=";

                        string where = "";
                        Match mWhere = Regex.Match( template.fdTempContent, getWhereReg1, RegexOptions.IgnoreCase );
                        if( mWhere.Success )
                        {
                            where = mWhere.Value;
                        }

                        mWhere = Regex.Match( template.fdTempContent, getWhereReg2, RegexOptions.IgnoreCase );
                        if( mWhere.Success )
                        {
                            where = mWhere.Value;
                        }

                        int recordCount = 0;
                        switch( ( ColumnType ) column.fdColuType )
                        {
                            case ColumnType.Article:
                                recordCount = new AW_Article_dao().funcGetArticleCount( column.fdColuID, getChild, where );
                                break;
                            case ColumnType.Product:
                                recordCount = new AW_Product_dao().funcGetProductCount( column.fdColuID, getChild, where );
                                break;
                            default:
                                break;
                        }

                        int pages = 1;
                        if( recordCount > pageSize )
                        {
                            if( recordCount % pageSize == 0 )
                                pages = recordCount / pageSize;
                            else
                                pages = recordCount / pageSize + 1;
                        }
                        for( int i = 2; i <= pages; i++ )
                        {
                            exe = string.Format( "{0}?sid={4}&cid={1}&urlprefix={2}&pid={3}", BuilderPath, column.fdColuID.ToString(), column.Url.Replace( "index", "index__pid" ), i, column.fdColuSiteID );
                            htmlFile = PublishPage( exe, saveTo, i );

                        }
                    }
                    //发布站点首页
                    if( pubSite )
                    {
                        PublishSite( publish, column.Site, PublishType.HomeOnly );
                    }
                    return 0;
                }
            case PublishType.Additional:
                {
                    AW_Column_dao columnDao = new AW_Column_dao();
                    switch( ( ColumnType ) column.fdColuType )
                    {
                        case ColumnType.Article:
                            {
                                List<AW_Article_bean> articles = new AW_Article_dao().funcGetColumnArticleAdditional( column.fdColuID );
                                string ids = "";

                                foreach( AW_Article_bean article in articles )
                                {
                                    article.Column = columnDao.funcGetColumnInfo( article.fdArtiColuID );
                                    int result = PublishDocument( publish, article.fdArtiID, false, PublishType.Complete );
                                    if( result == 0 )
                                    {
                                        ids += article.fdArtiID.ToString() + ",";
                                    }
                                }
                                if( ids.Length > 0 )
                                {
                                    ids = ids.Remove( ids.Length - 1, 1 );
                                    new AW_Article_dao().funcPublishArticleByIds( ids, 2 );
                                }
                                break;
                            }
                        case ColumnType.Single:
                            {
                                PublishSingleDocument( publish, column.fdColuID, PublishType.Complete );
                                break;
                            }
                        //case ColumnType.Product:
                        //    {
                        //        //产品
                        //        List<AW_Product_bean> products = new AW_Product_dao().funcGetColumnProductAdditional( column.fdColuIdPath );
                        //        string ids = "";

                        //        foreach( FA_Product_bean product in products )
                        //        {
                        //            product.Column = columnDao.funcGetColumnInfo( product.fdProdColuID );
                        //            int result = PublishProduct( queue, product.Column, product.fdProdID, false, PublishType.Complete );
                        //            if( result > 0 )
                        //            {
                        //                //return result;
                        //            }
                        //            else
                        //            {
                        //                ids += product.fdProdID.ToString() + ",";
                        //            }
                        //        }
                        //        if( ids.Length > 0 )
                        //        {
                        //            ids = ids.Remove( ids.Length - 1, 1 );
                        //            new FA_Product_dao().funcPublishProductByIds( ids );
                        //        }
                        //        break;
                        //    }
                    }
                    //发布子栏目
                    foreach( AW_Column_bean childColumn in column.Children )
                    {
                        PublishColumn( publish, childColumn, false, PublishType.Additional );
                    }
                    //发布首页
                    PublishColumn( publish, column, false, PublishType.HomeOnly );
                    //发布站点首页
                    if( pubSite )
                    {
                        PublishSite( publish, column.Site, PublishType.HomeOnly );
                    }
                    return 0;
                }
            case PublishType.Complete:
                {
                    switch( ( ColumnType ) column.fdColuType )
                    {
                        case ColumnType.Article:
                            {
                                List<AW_Article_bean> articles = new AW_Article_dao().funcGetColumnArticleComplete( column.fdColuID );
                                string ids = "";
                                foreach( AW_Article_bean article in articles )
                                {
                                    int result = PublishDocument( publish, article.fdArtiID, false, PublishType.Complete );
                                    if( result == 0 )
                                    {
                                        ids += article.fdArtiID.ToString() + ",";
                                    }
                                }
                                if( ids.Length > 0 )
                                {
                                    ids = ids.Remove( ids.Length - 1, 1 );
                                    new AW_Article_dao().funcPublishArticleByIds( ids, 2 );
                                }
                                break;
                            }
                        case ColumnType.Single:
                            {
                                PublishSingleDocument( publish, column.fdColuID, PublishType.Complete );
                                break;
                            }
                        //case ColumnType.Product:
                        //    {
                        //        List<FA_Product_bean> products = new FA_Product_dao().funcGetColumnProductForPub( column.fdColuID );
                        //        string ids = "";
                        //        foreach( FA_Product_bean product in products )
                        //        {
                        //            int result = PublishProduct( queue, column, product.fdProdID, false, PublishType.Complete );
                        //            if( result > 0 )
                        //            {
                        //                //return result;
                        //            }
                        //            else
                        //            {
                        //                ids += product.fdProdID.ToString() + ",";
                        //            }
                        //        }
                        //        if( ids.Length > 0 )
                        //        {
                        //            ids = ids.Remove( ids.Length - 1, 1 );
                        //            new FA_Product_dao().funcPublishProductByIds( ids );
                        //        }
                        //        break;
                        //    }
                    }
                    //发布子栏目
                    foreach( AW_Column_bean childColumn in column.Children )
                    {
                        PublishColumn( publish, childColumn, false, PublishType.Complete );
                    }
                    //发布首页
                    PublishColumn( publish, column, false, PublishType.HomeOnly );
                    //发布站点首页
                    if( pubSite )
                    {
                        PublishSite( publish, column.Site, PublishType.HomeOnly );
                    }
                    return 0;
                }
            case PublishType.Cancel:
                {
                    return this.CancelPublishColumn( publish, column );
                }
            default:
                return 0;
        }
    }

    /// <summary>
    /// 撤消栏目发布
    /// </summary>
    /// <param name="publish">发布任务</param>
    /// <param name="column">撤消的栏目</param>
    /// <returns></returns>
    int CancelPublishColumn( AW_Publish_bean publish, AW_Column_bean column )
    {
        DirectoryInfo dirColumn = new DirectoryInfo( string.Format( "{0}\\{1}\\{2}\\", this.PublishPath, column.Site.fdSitePath, column.fdColuID ) );
        if( dirColumn.Exists )
        {
            dirColumn.Delete( true );
        }
        //级联删除所有子栏目页
        foreach( AW_Column_bean childColumn in column.Children )
        {
            CancelPublishColumn( publish, childColumn );
        }
        //更新文档发布状态
        new AW_Article_dao().funcCancelPublishArticleByColumnID( column.fdColuID );
        return 0;
    }

    /// <summary>
    /// 发布站点
    /// </summary>
    /// <param name="publish">发布任务</param>
    /// <param name="site">发布的站点</param>
    /// <param name="pubType">发布类型</param>
    /// <returns></returns>
    int PublishSite( AW_Publish_bean publish, AW_Site_bean site, PublishType pubType )
    {
        string exe = this.BuilderPath;
        string saveTo = string.Format( "{0}\\{1}\\", this.PublishPath, site.fdSitePath );
        switch( pubType )
        {
            case PublishType.HomeOnly:
                {
                    if( site.IndexTemplate == null )
                    {
                        return 101;
                    }
                    exe += string.Format( "?sid={0}&type=site", site.fdSiteID );
                    string htmlFile = PublishPage( exe, saveTo, 1 );
                    return 0;
                }
            case PublishType.Additional:
                {
                    foreach( AW_Column_bean column in site.Columns )
                    {
                        PublishColumn( publish, column, false, PublishType.Additional );
                    }
                    PublishSite( publish, site, PublishType.HomeOnly );
                    return 0;
                }
            case PublishType.Complete:
                {
                    foreach( AW_Column_bean column in site.Columns )
                    {
                        PublishColumn( publish, column, false, PublishType.Complete );
                    }
                    PublishSite( publish, site, PublishType.HomeOnly );

                    return 0;
                }
            case PublishType.Cancel:
                {
                    return this.CancelPublishSite( publish, site );
                }
            default:
                {
                    return 0;
                }
        }
    }

    /// <summary>
    /// 撤消站点发布
    /// </summary>
    /// <param name="publish">发布任务</param>
    /// <param name="site">撤消的站点</param>
    /// <returns></returns>
    int CancelPublishSite( AW_Publish_bean publish, AW_Site_bean site )
    {
        DirectoryInfo dirSite = new DirectoryInfo( string.Format( "{0}\\{1}\\", this.PublishPath, site.fdSitePath ) );
        if( !dirSite.Exists )
        {
            return 0;
        }
        foreach( AW_Column_bean column in site.Columns )
        {
            CancelPublishColumn( publish, column );
        }
        FileInfo[] indexFiles = dirSite.GetFiles( "index*.html", SearchOption.TopDirectoryOnly );
        foreach( FileInfo indexFile in indexFiles )
        {
            indexFile.Delete();
        }
        return 0;
    }

    /// <summary>
    /// 执行页面并保存结果，然后返回保存的页面文件名
    /// </summary>
    /// <param name="url">要执行的页面地址</param>
    /// <param name="saveTo">保存路径</param>
    /// <param name="pageID">页码</param>
    /// <returns>保存的页面文件物理地址</returns>
    string PublishPage( string url, string saveTo, int pageID )
    {
        string extension = ".html";
        Encoding encoding = Encoding.UTF8;
        if( saveTo.EndsWith( "\\" ) )
        {
            saveTo += "index";
        }
        if( pageID == 1 )
        {
            saveTo += extension;
        }
        else
        {
            saveTo += "_" + pageID.ToString() + extension;
        }
        FileInfo fi = new FileInfo( saveTo );
        if( !fi.Directory.Exists )
        {
            fi.Directory.Create();
        }

        string result = ReadRemoteFile( url, encoding );
        using( StreamWriter sw = new StreamWriter( saveTo, false, encoding ) )
        {
            sw.Write( result );
        }
        return saveTo;
    }

    /// <summary>
    /// 使用指定的编码读取远程文件
    /// </summary>
    /// <param name="url"></param>
    /// <param name="encode"></param>
    /// <returns></returns>
    string ReadRemoteFile( string url, Encoding encoding )
    {
        HttpWebRequest req = ( HttpWebRequest ) WebRequest.Create( url );
        HttpWebResponse res = ( HttpWebResponse ) req.GetResponse();

        StreamReader sr = new StreamReader( res.GetResponseStream(), encoding );
        string contentString = String.Empty;
        contentString = sr.ReadToEnd();
        return contentString;
    }

    public bool Start()
    {
        if( HttpContext.Current != null )
        {
            this.BuilderPath = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port.ToString() + "/Publish/Builder.aspx";
            this.PublishPath = HttpContext.Current.Server.MapPath( "~/" );
            pubTimer.Enabled = true;
            this.Started = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    private List<string> _protectionFolders = null;
    /// <summary>
    /// 系统目录保留名称列表
    /// </summary>
    public List<string> ProtectionFolders
    {
        get
        {
            if( _protectionFolders == null )
            {
                string keys = "admin,app_code,app_data,bin,clientbin,files,publish,tiny_mce";
                _protectionFolders = new List<string>();
                foreach( string key in keys.Split( ',' ) )
                    _protectionFolders.Add( key );
            }
            return _protectionFolders;
        }
    }

    public void AddPublish( AW_Publish_bean bean )
    {
        lock( this )
        {
            nPublish.Add( bean );//加入队列

            if( this.Started == false )//启动服务
            {
                this.Start();
            }
        }
    }

    /// <summary>
    /// 服务状态
    /// </summary>
    private bool _started;
    public bool Started
    {
        get
        {
            return _started;
        }
        set
        {
            _started = value;
        }
    }

    private string _builderPath;
    /// <summary>
    /// 命令文件路径
    /// </summary>
    public string BuilderPath
    {
        get
        {
            return _builderPath;
        }
        set
        {
            _builderPath = value;
        }
    }

    private string _publishPath;
    /// <summary>
    /// 发布目录根路径
    /// </summary>
    public string PublishPath
    {
        get
        {
            return _publishPath;
        }
        set
        {
            _publishPath = value;
        }
    }

    public static PublishService GetService()
    {
        return Nested.instance;
    }

    class Nested
    {
        internal static readonly PublishService instance = new PublishService();
    }
}
