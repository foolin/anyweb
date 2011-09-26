using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PictureCleaner
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "开始清理临时图片文件..." );
            StartClean();
        }

        static void StartClean()
        {
            foreach( PathBean bean in PathAgent.GetAgent().Pathes )
            {
                CleanFiles( bean.RootPath, bean.Prefix );
            }
        }

        static void CleanFiles( string dir, string prefix )
        {
            DirectoryInfo Dir = new DirectoryInfo( dir );
            if( !Dir.Exists )
            {
                return;
            }
            foreach( DirectoryInfo d in Dir.GetDirectories() )
            {
                CleanFiles( d.FullName, prefix );
            }
            foreach( FileInfo f in Dir.GetFiles( prefix + "*" ) )
            {
                try
                {
                    f.Delete();
                    Console.WriteLine( "清理：" + f.FullName );
                }
                catch( Exception ex )
                {
                    Console.WriteLine( ex.Message );
                }
            }
        }
    }
}
