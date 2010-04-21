using System;
using System.IO;
using System.Text;

namespace Studio.IO
{
	/// <summary>
	/// Name:�ļ�����
	/// Description:ʵ�ֻ������ı��ļ���д����
	/// Author:л��
	/// CreateDate:2005-07-11
	/// </summary>
	public class FileAgent
	{
		/// <summary>
		/// ��ȡ�ı��ļ�ȫ������
		/// </summary>
		/// <param name="fileName">�ļ�����·��</param>
		public static string ReadText( string fileName)
		{
			return ReadText( fileName, Encoding.Default);
		}

		/// <summary>
		/// ��ȡ�ı��ļ�ȫ������
		/// </summary>
		/// <param name="fileName">�ļ�����·��</param>
		/// <param name="coding">����</param>
		/// <returns></returns>
		public static string ReadText( string fileName, Encoding coding )
		{
			using( StreamReader sr = new StreamReader(fileName, coding))
			{
				return sr.ReadToEnd();
			}
		}

		/// <summary>
		/// ��ȡ�ı��ļ���һ������
		/// </summary>
		/// <param name="fileName">�ļ�����·��</param>
		public static string ReadLine( string fileName)
		{
			return ReadLine( fileName, Encoding.Default);
		}

		/// <summary>
		/// ��ȡ�ı��ļ���һ������
		/// </summary>x
		/// <param name="fileName">�ļ�����·��</param>
		/// <param name="coding">����</param>
		/// <returns></returns>
		public static string ReadLine( string fileName, Encoding coding )
		{
			using( StreamReader sr = new StreamReader(fileName, coding))
			{
				return sr.ReadLine();
			}
		}

		/// <summary>
		/// ���ı��ļ�д���ı�����
		/// </summary>
		/// <param name="fileName">�ļ�����·��</param>
		/// <param name="text">Ҫд�������</param>
		/// <param name="append">�Ƿ�����ı�,false��ʾ��д�ļ�</param>
		public static void WriteText( string fileName, string text, bool append)
		{
			WriteText(fileName, text, append, Encoding.Default);
		}

		/// <summary>
		/// ���ı��ļ�д���ı�����
		/// </summary>
		/// <param name="fileName">�ļ�����·��</param>
		/// <param name="text">Ҫд�������</param>
		/// <param name="append">�Ƿ�����ı�,false��ʾ��д�ļ�</param>
		/// <param name="coding">����</param>
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
		/// ��ȡָ���ļ��еĴ�С
		/// </summary>
		/// <param name="path">�ļ��о���·��</param>
		/// <param name="includeSubFolders">�Ƿ������Ŀ¼</param>
		/// <param name="onlyTypes">������ָ�������ļ�</param>
		/// <param name="exceptTypes">�ų�ָ�������ļ�</param>
		/// <returns>�ļ��д�С</returns>
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
