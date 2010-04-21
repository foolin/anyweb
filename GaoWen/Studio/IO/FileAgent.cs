using System;
using System.IO;
using System.Text;

namespace Studio.IO
{
	/// <summary>
	/// Name:文件代理
	/// Description:实现基本的文本文件读写操作
	/// Author:谢康
	/// CreateDate:2005-07-11
	/// </summary>
	public class FileAgent
	{
		/// <summary>
		/// 读取文本文件全部内容
		/// </summary>
		/// <param name="fileName">文件绝对路径</param>
		public static string ReadText( string fileName)
		{
			return ReadText( fileName, Encoding.Default);
		}

		/// <summary>
		/// 读取文本文件全部内容
		/// </summary>
		/// <param name="fileName">文件绝对路径</param>
		/// <param name="coding">编码</param>
		/// <returns></returns>
		public static string ReadText( string fileName, Encoding coding )
		{
			using( StreamReader sr = new StreamReader(fileName, coding))
			{
				return sr.ReadToEnd();
			}
		}

		/// <summary>
		/// 读取文本文件第一行内容
		/// </summary>
		/// <param name="fileName">文件绝对路径</param>
		public static string ReadLine( string fileName)
		{
			return ReadLine( fileName, Encoding.Default);
		}

		/// <summary>
		/// 读取文本文件第一行内容
		/// </summary>x
		/// <param name="fileName">文件绝对路径</param>
		/// <param name="coding">编码</param>
		/// <returns></returns>
		public static string ReadLine( string fileName, Encoding coding )
		{
			using( StreamReader sr = new StreamReader(fileName, coding))
			{
				return sr.ReadLine();
			}
		}

		/// <summary>
		/// 向文本文件写入文本内容
		/// </summary>
		/// <param name="fileName">文件绝对路径</param>
		/// <param name="text">要写入的内容</param>
		/// <param name="append">是否添加文本,false表示重写文件</param>
		public static void WriteText( string fileName, string text, bool append)
		{
			WriteText(fileName, text, append, Encoding.Default);
		}

		/// <summary>
		/// 向文本文件写入文本内容
		/// </summary>
		/// <param name="fileName">文件绝对路径</param>
		/// <param name="text">要写入的内容</param>
		/// <param name="append">是否添加文本,false表示重写文件</param>
		/// <param name="coding">编码</param>
		public static void WriteText( string fileName, string text, bool append, Encoding coding)
		{
			using( StreamWriter sw = new StreamWriter(fileName, append, coding))
			{
                try
                {
                    sw.WriteLine(text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sw.Close();
                }
			}
		}

		public static long GetFolderSize( string path)
		{
			return GetFolderSize( path, true, "", "");
		}

		public static long GetFolderSize( string path, bool includeSubFolders)
		{
			return GetFolderSize( path, includeSubFolders, "", "");
		}

		public static long GetFolderSize( string path, bool includeSubFolders, string onlyTypes)
		{
			return GetFolderSize( path, includeSubFolders, onlyTypes, "");
		}

		/// <summary>
		/// 获取指定文件夹的大小
		/// </summary>
		/// <param name="path">文件夹绝对路径</param>
		/// <param name="includeSubFolders">是否包含子目录</param>
		/// <param name="onlyTypes">仅计算指定类型文件</param>
		/// <param name="exceptTypes">排除指定类型文件</param>
		/// <returns>文件夹大小</returns>
		public static long GetFolderSize( string path, bool includeSubFolders, string onlyTypes, string exceptTypes)
		{
			return ComputeFolderSize( new DirectoryInfo( path), includeSubFolders, onlyTypes, exceptTypes);
		}

		private static long ComputeFolderSize(DirectoryInfo d, bool includeSubFolders, string onlyTypes, string exceptTypes)
		{
			if( d.Exists == false)
			{
				return 0;
			}

			long length = 0;
			foreach( FileInfo f in d.GetFiles() )
			{
				if( (onlyTypes == "" || onlyTypes.ToLower().IndexOf(f.Extension.ToLower()) >=0)
					&& (exceptTypes == "" ||  exceptTypes.ToLower().IndexOf(f.Extension.ToLower()) <0))
				{
					length += f.Length;
				}
			}

			if( includeSubFolders == true)
			{
				foreach(DirectoryInfo subd in d.GetDirectories())
				{
					length += ComputeFolderSize(subd, includeSubFolders, onlyTypes, exceptTypes);
				}
			}
			return length;
		}
	}
}
