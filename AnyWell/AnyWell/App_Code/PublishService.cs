using System;
using System.Collections.Generic;
using System.Web;
using System.Timers;

/// <summary>
/// 发布服务
/// </summary>
public class PublishService
{
    Timer pubTimer;

    public PublishService()
    {
        //发布任务计时器
        pubTimer = new Timer( 1000 * 5 );
        pubTimer.Elapsed += new ElapsedEventHandler( pubTimer_Elapsed );
    }

    void pubTimer_Elapsed( object sender, ElapsedEventArgs e )
    {
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
                string keys = "admin,app_code,app_data,bin";
                _protectionFolders = new List<string>();
                foreach( string key in keys.Split( ',' ) )
                    _protectionFolders.Add( key );
            }
            return _protectionFolders;
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
