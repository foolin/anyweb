using System;
using System.Collections.Generic;
using System.Web;
using System.Timers;
using AnyWell.AW_DL;
using System.IO;
using System.Net;
using System.Text;

/// <summary>
/// 发布服务
/// </summary>
public class PublishService
{
    Timer pubTimer;
    List<AW_Publish_bean> nPublish = new List<AW_Publish_bean>();//新任务队列
    List<AW_Publish_bean> pPublish = new List<AW_Publish_bean>();//当前执行中队列
    List<AW_Publish_bean> cPublish = new List<AW_Publish_bean>();//当前已完成队列

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
                        case PublishObjectType.Document:
                            {
                                result = PublishDocument( bean, bean.fdPublObjID, true, bean.PublishType );
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
            cPublish.AddRange( pPublish );
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
                            exe = string.Format( "{0}?cid={1}&did={2}&dpid={3}", this.BuilderPath, column.fdColuID, article.fdArtiID, pageID );
                            saveTo = string.Format( "{0}/{1}/{2}/{3}", this.PublishPath, column.Site.fdSitePath, column.fdColuID, article.fdArtiID );
                            string htmlFile = PublishPage( exe, saveTo, pageID );
                        }

                        //if( pubColumn )//级联更新栏目首页
                        //{
                        //    FA_Column_bean parent = column;
                        //    while( parent != null )
                        //    {
                        //        PublishColumn( queue, parent, PublishType.HomeOnly );
                        //        parent = parent.Parent;
                        //    }
                        //}
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
        string directory = string.Format( "{0}/{1}/{2}/", this.PublishPath, column.Site.fdSitePath, column.fdColuID );
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

        //if( pubColumn == true )//级联更新栏目首页
        //{
        //    new FA_Article_dao().funcPublishCancelArticleByIds( docID.ToString() );
        //    PublishColumn( queue, column, PublishType.HomeOnly );
        //}
        new AW_Article_dao().funcPublishArticleByIds( article.fdArtiID.ToString(), 0 );
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
