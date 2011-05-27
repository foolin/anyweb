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
                        //case PublishObjectType.Site:
                        //    {
                        //        FA_Site_bean site = new FA_Site_dao().funcGetSiteInfo( queue.fdQueuObjID );
                        //        if( site != null )
                        //        {
                        //            result = PublishSite( queue, site, queue.PublishType );
                        //        }
                        //        break;
                        //    }
                        //case QueueObjectType.Column:
                        //    {
                        //        FA_Column_bean column = new FA_Column_dao().funcGetColumnInfo( queue.fdQueuObjID );
                        //        if( column != null )
                        //        {
                        //            result = PublishColumn( queue, column, queue.PublishType );
                        //        }
                        //        break;
                        //    }
                        case PublishObjectType.Column:
                            {
                                AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( bean.fdPublObjID );
                                if( column != null )
                                {
                                    result = PublishColumn( bean, column, bean.PublishType );
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
                        //case QueueObjectType.Picture:
                        //    {
                        //        result = PublishPicture( queue, queue.Column, queue.fdQueuObjID, true, queue.PublishType );
                        //        break;
                        //    }
                        //case QueueObjectType.Video:
                        //    {
                        //        result = PublishVideo( queue, queue.Column, queue.fdQueuObjID, true, queue.PublishType );
                        //        break;
                        //    }
                        //case QueueObjectType.Song:
                        //    {
                        //        result = PublishSong( queue, queue.Column, queue.fdQueuObjID, true, queue.PublishType );
                        //        break;
                        //    }
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
                            PublishColumn( publish, column, PublishType.HomeOnly );
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

        if( article.fdArtiType == 4 )
        {
            return 0;
        }
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
        if( pubColumn ) //级联更新栏目首页
        {
            AW_Column_bean parent = column;
            while( parent != null )
            {
                PublishColumn( publish, column, PublishType.HomeOnly );
                parent = parent.Parent;
            }
        }
        new AW_Article_dao().funcPublishArticleByIds( article.fdArtiID.ToString(), 0 );
        return 0;
    }

    /// <summary>
    /// 发布单篇文档栏目
    /// </summary>
    /// <param name="publish"></param>
    /// <param name="docID"></param>
    /// <param name="pubType"></param>
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
                        exe = string.Format( "{0}?cid={1}&dpid={2}&urlprefix={3}", this.BuilderPath, column.fdColuID, pageID, column.Url.Replace( column.fdColuID.ToString(), column.fdColuID.ToString() + "__pid" ) );
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

    int PublishColumn( AW_Publish_bean publish, AW_Column_bean column, PublishType pubType )
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
                    exe += string.Format( "?cid={0}&urlprefix={1}", column.fdColuID.ToString(), column.Url.Replace( "index", "index__pid" ) );
                    string htmlFile = PublishPage( exe, saveTo, 1 );

                    string hasPagerReg = "(<AW:ARTICLELIST|<AW:PICTURELIST|<AW:PRODUCTLIST)[^>]+PAGERID=";
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

                        string getChildReg1 = "(<IBOX:ARTICLELIST|<IBOX:PICTURELIST|<IBOX:MULTIARTICLELIST)[^>]+PAGERID=[^>]+GETCHILD=['\"]TRUE['\"]";
                        string getChildReg2 = "(<IBOX:ARTICLELIST|<IBOX:PICTURELIST|<IBOX:MULTIARTICLELIST)[^>]+GETCHILD=['\"]TRUE['\"][^>]+PAGERID=";

                        bool getChild = false;
                        if( Regex.IsMatch( template.fdTempContent, getChildReg1, RegexOptions.IgnoreCase ) || Regex.IsMatch( template.fdTempContent, getChildReg1, RegexOptions.IgnoreCase ) )
                        {
                            getChild = true;
                        }

                        string getWhereReg1 = "(<AW:ARTICLELIST|<AW:PICTURELIST|<AW:PRODUCTLIST)[^>]+PAGERID=[^>]+WHERE=['\"]\\s+?['\"]";
                        string getWhereReg2 = "(<AW:ARTICLELIST|<AW:PICTURELIST|<AW:PRODUCTLIST)[^>]+WHERE=['\"]\\s+?['\"][^>]+PAGERID=";
                        
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
                            exe = string.Format( "{0}?cid={1}&urlprefix={2}&pid={3}", BuilderPath, column.fdColuID.ToString(), column.Url.Replace( "index", "index__pid" ), i );
                            htmlFile = PublishPage( exe, saveTo, i );

                        }
                    }
                    return 0;
                }
            default:
                return 0;
        }
    //    switch( pubType )
    //    {
    //        case PublishType.HomeOnly:
    //            {
    //                FA_Template_bean template = column.IndexTemplate;
    //                if( template == null )
    //                {
    //                    template = column.InheritedIndexTemplate;
    //                }
    //                //if (template == null)
    //                //{
    //                //    return 101;
    //                //}
    //                exe += "?queueid=" + queue.fdQueuID.ToString() + "&cid=" + column.fdColuID.ToString() + "&ttype=1&urlprefix=" + column.Url + "index__pid" + ( template == null ? ".ascx" : template.fdTempExtension );
    //                string htmlFile = PublishPage( exe, saveTo, 1, ( template == null ? ".ascx" : template.fdTempExtension ), column.Site.Setting.Encoding );

    //                if( template != null )
    //                {

    //                    string hasPagerReg = "(<IBOX:ARTICLELIST|<IBOX:PICTURELIST|<IBOX:MULTIARTICLELIST)[^>]+PAGERID=";
    //                    Match mPager = Regex.Match( template.fdTempContent, hasPagerReg, RegexOptions.IgnoreCase );
    //                    if( mPager.Success )
    //                    {
    //                        int pageSize = 20;
    //                        string pageSizeReg = "(?<=PAGESIZE=['\"])\\d+?(?=['\"])";
    //                        Match mPageSize = Regex.Match( template.fdTempContent, pageSizeReg, RegexOptions.IgnoreCase );
    //                        if( mPageSize.Success )
    //                        {
    //                            pageSize = int.Parse( mPageSize.Value );
    //                        }

    //                        string getChildReg1 = "(<IBOX:ARTICLELIST|<IBOX:PICTURELIST|<IBOX:MULTIARTICLELIST)[^>]+PAGERID=[^>]+GETCHILD=['\"]1['\"]";
    //                        string getChildReg2 = "(<IBOX:ARTICLELIST|<IBOX:PICTURELIST|<IBOX:MULTIARTICLELIST)[^>]+GETCHILD=['\"]1['\"][^>]+PAGERID=";

    //                        bool getChild = false;
    //                        if( Regex.IsMatch( template.fdTempContent, getChildReg1, RegexOptions.IgnoreCase ) ||
    //                            Regex.IsMatch( template.fdTempContent, getChildReg2, RegexOptions.IgnoreCase ) )
    //                        {
    //                            getChild = true;
    //                        }

    //                        int recordCount = new FA_Article_dao().funcGetArticleCount( column.fdColuID, getChild );
    //                        if( column.fdColuTypeEnum == ColumnType.Album )
    //                        {
    //                            recordCount = new FA_Picture_dao().funcGetPictureCount( column.fdColuID, getChild );
    //                        }
    //                        int pages = 1;
    //                        if( recordCount > pageSize )
    //                        {
    //                            if( recordCount % pageSize == 0 )
    //                                pages = recordCount / pageSize;
    //                            else
    //                                pages = recordCount / pageSize + 1;
    //                        }
    //                        for( int i = 2; i <= pages; i++ )
    //                        {
    //                            exe = this.BuilderPath + "?queueid=" + queue.fdQueuID.ToString() + "&cid=" + column.fdColuID.ToString() + "&pid=" + i.ToString() + "&ttype=1&urlprefix=" + column.Url + "index__pid" + template.fdTempExtension;
    //                            //saveTo = this.PublishPath + column.FullVirtualPath + "\\";
    //                            htmlFile = PublishPage( exe, saveTo, i, template.fdTempExtension, column.Site.Setting.Encoding );
                                
    //                        }
    //                    }
    //                }

    //                string imageFile = "", toImageFile = "";
    //                //发布栏目图标
    //                if( column.fdColuIcon != "" )
    //                {
    //                    imageFile = this.AdminDataPath + column.Site.fdSiteVirtualPath + column.fdColuIcon;
    //                    toImageFile = this.PublishPath + column.Site.fdSiteVirtualPath + column.fdColuIcon;
    //                    CopyFile( imageFile, toImageFile );
    //                    if( column.Site.Setting.NeedFTP == true ) //分发页面
    //                    {
    //                        queue.FtpQueues.Add( new FtpQueue( toImageFile, GetFtpPath( column.Site, toImageFile ), FtpMethod.Add, column.Site.Setting.FtpSites ) );
    //                    }
    //                }
    //                if( column.fdColuPict != "" )
    //                {
    //                    imageFile = this.AdminDataPath + column.Site.fdSiteVirtualPath + column.fdColuPict;
    //                    toImageFile = this.PublishPath + column.Site.fdSiteVirtualPath + column.fdColuPict;
    //                    CopyFile( imageFile, toImageFile );
    //                    if( column.Site.Setting.NeedFTP == true ) //分发页面
    //                    {
    //                        queue.FtpQueues.Add( new FtpQueue( toImageFile, GetFtpPath( column.Site, toImageFile ), FtpMethod.Add, column.Site.Setting.FtpSites ) );
    //                    }
    //                }
    //                //发布RSS
    //                //string rssFile = PublishRss(column, saveTo);
    //                //if (column.Site.Setting.NeedFTP == true) //分发页面
    //                //{
    //                //    queue.FtpQueues.Add(new FtpQueue(rssFile, GetFtpPath(column.Site, rssFile), FtpMethod.Add, column.Site.Setting.FtpSites));
    //                //}
    //                return 0;
    //            }
    //        case PublishType.Additional:
    //            {
    //                FA_Column_dao columnDao = new FA_Column_dao();
    //                switch( column.fdColuTypeEnum )
    //                {
    //                    case ColumnType.Article:
    //                        {
    //                            List<FA_Article_bean> articles = new FA_Article_dao().funcGetColumnArticleAdditional( column.fdColuIdPath );
    //                            string ids = "";

    //                            foreach( FA_Article_bean article in articles )
    //                            {
    //                                article.Column = columnDao.funcGetColumnInfo( article.fdArtiColuID );
    //                                int result = PublishDocument( queue, article.Column, article.fdArtiID, false, PublishType.Complete );
    //                                if( result > 0 )
    //                                {
    //                                    //return result;
    //                                }
    //                                else
    //                                {
    //                                    ids += article.fdArtiID.ToString() + ",";
    //                                }
    //                            }
    //                            if( ids.Length > 0 )
    //                            {
    //                                ids = ids.Remove( ids.Length - 1, 1 );
    //                                new FA_Article_dao().funcPublishArticleByIds( ids );
    //                            }
    //                            break;
    //                        }
    //                    case ColumnType.Album:
    //                        {
    //                            //图片
    //                            List<FA_Picture_bean> pictures = new FA_Picture_dao().funcGetColumnPictureAdditional( column.fdColuIdPath );
    //                            string ids = "";

    //                            foreach( FA_Picture_bean picture in pictures )
    //                            {
    //                                picture.Column = columnDao.funcGetColumnInfo( picture.fdPictColuID );
    //                                int result = PublishPicture( queue, picture.Column, picture.fdPictID, false, PublishType.Complete );
    //                                if( result > 0 )
    //                                {
    //                                    //return result;
    //                                }
    //                                else
    //                                {
    //                                    ids += picture.fdPictID.ToString() + ",";
    //                                }
    //                            }
    //                            if( ids.Length > 0 )
    //                            {
    //                                ids = ids.Remove( ids.Length - 1, 1 );
    //                                new FA_Picture_dao().funcPublishPictureByIds( ids );
    //                            }
    //                            break;
    //                        }
    //                    case ColumnType.Video:
    //                        {
    //                            //视频
    //                            List<FA_Video_bean> videos = new FA_Video_dao().funcGetColumnVideoAdditional( column.fdColuIdPath );
    //                            string ids = "";

    //                            foreach( FA_Video_bean video in videos )
    //                            {
    //                                video.Column = columnDao.funcGetColumnInfo( video.fdVideColuID );
    //                                int result = PublishVideo( queue, video.Column, video.fdVideID, false, PublishType.Complete );
    //                                if( result > 0 )
    //                                {
    //                                    //return result;
    //                                }
    //                                else
    //                                {
    //                                    ids += video.fdVideID.ToString() + ",";
    //                                }
    //                            }
    //                            if( ids.Length > 0 )
    //                            {
    //                                ids = ids.Remove( ids.Length - 1, 1 );
    //                                new FA_Video_dao().funcPublishVideoByIds( ids );
    //                            }
    //                            break;
    //                        }
    //                    case ColumnType.Product:
    //                        {
    //                            //产品
    //                            List<FA_Product_bean> products = new FA_Product_dao().funcGetColumnProductAdditional( column.fdColuIdPath );
    //                            string ids = "";

    //                            foreach( FA_Product_bean product in products )
    //                            {
    //                                product.Column = columnDao.funcGetColumnInfo( product.fdProdColuID );
    //                                int result = PublishProduct( queue, product.Column, product.fdProdID, false, PublishType.Complete );
    //                                if( result > 0 )
    //                                {
    //                                    //return result;
    //                                }
    //                                else
    //                                {
    //                                    ids += product.fdProdID.ToString() + ",";
    //                                }
    //                            }
    //                            if( ids.Length > 0 )
    //                            {
    //                                ids = ids.Remove( ids.Length - 1, 1 );
    //                                new FA_Product_dao().funcPublishProductByIds( ids );
    //                            }
    //                            break;
    //                        }
    //                    case ColumnType.Song:
    //                        {
    //                            //音频
    //                            List<FA_Song_bean> songs = new FA_Song_dao().funcGetColumnSongAdditional( column.fdColuIdPath );
    //                            string ids = "";

    //                            foreach( FA_Song_bean song in songs )
    //                            {
    //                                song.Column = columnDao.funcGetColumnInfo( song.fdSongColuID );
    //                                int result = PublishSong( queue, song.Column, song.fdSongID, false, PublishType.Complete );
    //                                if( result > 0 )
    //                                {
    //                                    //return result;
    //                                }
    //                                else
    //                                {
    //                                    ids += song.fdSongID.ToString() + ",";
    //                                }
    //                            }
    //                            if( ids.Length > 0 )
    //                            {
    //                                ids = ids.Remove( ids.Length - 1, 1 );
    //                                new FA_Song_dao().funcPublishSongByIds( ids );
    //                            }
    //                            break;
    //                        }
    //                }

    //                //:发布首页
    //                PublishColumn( queue, column, PublishType.HomeOnly );
    //                return 0;
    //            }
    //        case PublishType.Complete:
    //            {
    //                //step1:发布当前栏目的文档
    //                switch( column.fdColuTypeEnum )
    //                {
    //                    case ColumnType.Article:
    //                        {
    //                            List<FA_Article_bean> articles = new FA_Article_dao().funcGetColumnArticleForPub( column.fdColuID );
    //                            string ids = "";
    //                            foreach( FA_Article_bean article in articles )
    //                            {
    //                                int result = PublishDocument( queue, column, article.fdArtiID, false, PublishType.Complete );
    //                                if( result > 0 )
    //                                {
    //                                    //return result;
    //                                }
    //                                else
    //                                {
    //                                    ids += article.fdArtiID.ToString() + ",";
    //                                }
    //                            }
    //                            if( ids.Length > 0 )
    //                            {
    //                                ids = ids.Remove( ids.Length - 1, 1 );
    //                                new FA_Article_dao().funcPublishArticleByIds( ids );
    //                            }
    //                            break;
    //                        }
    //                    case ColumnType.Album:
    //                        {
    //                            List<FA_Picture_bean> pictures = new FA_Picture_dao().funcGetColumnPictureForPub( column.fdColuID );
    //                            string ids = "";
    //                            foreach( FA_Picture_bean picture in pictures )
    //                            {
    //                                int result = PublishPicture( queue, column, picture.fdPictID, false, PublishType.Complete );
    //                                if( result > 0 )
    //                                {
    //                                    //return result;
    //                                }
    //                                else
    //                                {
    //                                    ids += picture.fdPictID.ToString() + ",";
    //                                }
    //                            }
    //                            if( ids.Length > 0 )
    //                            {
    //                                ids = ids.Remove( ids.Length - 1, 1 );
    //                                new FA_Picture_dao().funcPublishPictureByIds( ids );
    //                            }
    //                            break;
    //                        }
    //                    case ColumnType.Video:
    //                        {
    //                            List<FA_Video_bean> videos = new FA_Video_dao().funcGetColumnVideoForPub( column.fdColuID );
    //                            string ids = "";
    //                            foreach( FA_Video_bean video in videos )
    //                            {
    //                                int result = PublishVideo( queue, column, video.fdVideID, false, PublishType.Complete );
    //                                if( result > 0 )
    //                                {
    //                                    //return result;
    //                                }
    //                                else
    //                                {
    //                                    ids += video.fdVideID.ToString() + ",";
    //                                }
    //                            }
    //                            if( ids.Length > 0 )
    //                            {
    //                                ids = ids.Remove( ids.Length - 1, 1 );
    //                                new FA_Video_dao().funcPublishVideoByIds( ids );
    //                            }
    //                            break;
    //                        }
    //                    case ColumnType.Product:
    //                        {
    //                            List<FA_Product_bean> products = new FA_Product_dao().funcGetColumnProductForPub( column.fdColuID );
    //                            string ids = "";
    //                            foreach( FA_Product_bean product in products )
    //                            {
    //                                int result = PublishProduct( queue, column, product.fdProdID, false, PublishType.Complete );
    //                                if( result > 0 )
    //                                {
    //                                    //return result;
    //                                }
    //                                else
    //                                {
    //                                    ids += product.fdProdID.ToString() + ",";
    //                                }
    //                            }
    //                            if( ids.Length > 0 )
    //                            {
    //                                ids = ids.Remove( ids.Length - 1, 1 );
    //                                new FA_Product_dao().funcPublishProductByIds( ids );
    //                            }
    //                            break;
    //                        }
    //                    case ColumnType.Song:
    //                        {
    //                            //音频
    //                            List<FA_Song_bean> songs = new FA_Song_dao().funcGetColumnSongForPub( column.fdColuID );
    //                            string ids = "";

    //                            foreach( FA_Song_bean song in songs )
    //                            {
    //                                int result = PublishSong( queue, column, song.fdSongID, false, PublishType.Complete );
    //                                if( result > 0 )
    //                                {
    //                                    //return result;
    //                                }
    //                                else
    //                                {
    //                                    ids += song.fdSongID.ToString() + ",";
    //                                }
    //                            }
    //                            if( ids.Length > 0 )
    //                            {
    //                                ids = ids.Remove( ids.Length - 1, 1 );
    //                                new FA_Song_dao().funcPublishSongByIds( ids );
    //                            }
    //                            break;
    //                        }

    //                }

    //                //step2:级联发布下级栏目
    //                foreach( FA_Column_bean childColumn in column.Childs )
    //                {
    //                    PublishColumn( queue, childColumn, PublishType.Complete );
    //                }
    //                //step3:发布首页
    //                PublishColumn( queue, column, PublishType.HomeOnly );
    //                return 0;
    //            }
    //        case PublishType.Cancel:
    //            {
    //                return this.CancelPublishColumn( queue, column );
    //            }
    //        case PublishType.Seo:
    //            {
    //                //发布RSS
    //                if( ( bool ) queue.Arguments[ "IsRss" ] )
    //                {
    //                    PublishRss( column, saveTo, ( int ) queue.Arguments[ "RssCount" ] );
    //                }
    //                return 0;
    //            }
    //        default:
    //            return 0;
    //    }
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

        //url = url + "&saveFile=" + HttpUtility.UrlEncode( saveTo );

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
