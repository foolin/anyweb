using System;
using System.Web;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace Studio.Security
{
	/// <summary>
	/// �ؼ������ݴ���
	/// </summary>
	public class KeywordAgent
	{

		public static bool _replaceKeyword = System.Configuration.ConfigurationSettings.AppSettings["FilterReplace"] != "0";
		public static string _connectionString = Secure.GetAppSetting("FilterConnectionString");
		public static string _keyString = String.Empty;
		public static string[] _keywords;
		/// <summary>
		/// ��ȡ�ؼ����б�
		/// </summary>
		/// <param name="path">�ؼ����ļ�·��(xml)</param>
		/// <returns></returns>
		public static bool RetrieveKeywords( string path)
		{
			ArrayList list = new ArrayList();
			XmlTextReader xr = new XmlTextReader( path );
			try
			{
				while( xr.Read())
				{
					if( xr.NodeType == XmlNodeType.Element && xr.Name == "word")
					{
						string key = xr.ReadElementString();
						list.Add( key);
						_keyString += key + "|";
					}
					
				}
				if( _keyString.Length > 0)
					_keyString = _keyString.Remove(_keyString.Length - 1, 1);
			}
			catch
			{
				return false;
			}
			finally
			{
				xr.Close();
			}
			
			_keywords = (string[])list.ToArray( typeof( string));


			return true;
		}

		/// <summary>
		/// ����Ƿ�����ؼ���
		/// </summary>
		/// <param name="input">Ҫ�����ַ���</param>
		/// <returns></returns>
		public static bool ContainsKeywords( string input)
		{
			if( _keywords != null)
			{
				foreach( string key in _keywords)
				{
					if( input.IndexOf( key ) >= 0)
						return true;
				}
			}
			return false;
		}

		/// <summary>
		/// ����ַ���,��������ؼ���,���ص�һ��
		/// </summary>
		/// <param name="input">Ҫ�����ַ���</param>
		/// <returns></returns>
		public static string GetFirstKeywords( string input)
		{
			if( _keywords != null)
			{
				foreach( string key in _keywords)
				{
					if( input.IndexOf( key ) >= 0)
						return key;
				}
			}

			return String.Empty;
		}

		/// <summary>
		/// ����ַ���,�������а����Ĺؼ���
		/// </summary>
		/// <param name="input">Ҫ�����ַ���</param>
		/// <returns></returns>
		public static string[] GetAllKeywords( string input)
		{
			ArrayList keys = new ArrayList();

			if( _keywords != null)
			{
				foreach( string key in _keywords)
				{
					if( input.IndexOf( key ) >= 0)
						keys.Add( key);
				}
			}

			return (string[])keys.ToArray(typeof(string));
		}

		/// <summary>
		/// ȥ���ַ����еĹؼ���
		/// </summary>
		/// <param name="input">Ҫ�����ַ���</param>
		/// <param name="replaceTo">�滻����ַ�</param>
		/// <returns></returns>
		public static string RemoveKeyword( string input, string replaceTo)
		{
			if( _keywords != null)
			{
				foreach( string key in _keywords)
				{
					input = input.Replace( key, replaceTo);
				}
			}

			return input;
		}

		/// <summary>
		/// ��Ĭ���ַ��滻�ؼ���
		/// </summary>
		/// <param name="input">Ҫ�����ַ���</param>
		/// <returns></returns>
		public static string RemoveKeyword( string input)
		{
			return RemoveKeyword( input, "*");
		}

		/// <summary>
		/// ɨ�裬����ػ�ؼ��ֵĻ�����¼��־���������滻����ַ���
		/// </summary>
		/// <param name="content">ɨ�������</param>
		/// <param name="url">���ݹ������ʵ�ַ</param>
		/// <param name="domain">������������</param>
		/// <param name="columnId">��������ţ����ձ�</param>
		/// <param name="contentId">���ݶ����ţ�������</param>
		/// <param name="siteName">վ����</param>
		/// <param name="userId">������Ա���</param>
		/// <param name="userName">������Ա����</param>
		/// <returns></returns>
		public static string Filtrate(string content, string url, string domain, int columnId, int contentId, string siteName, int userId, string userName)
		{
			return Filtrate(content, url, domain, columnId, contentId.ToString(), siteName, userId, userName);
		}

		/// <summary>
		/// ɨ�裬����ػ�ؼ��ֵĻ�����¼��־���������滻����ַ���
		/// </summary>
		/// <param name="content">ɨ�������</param>
		/// <param name="url">���ݹ������ʵ�ַ</param>
		/// <param name="domain">������������</param>
		/// <param name="columnId">��������ţ����ձ�</param>
		/// <param name="contentId">���ݶ����ţ��ַ���</param>
		/// <param name="siteName">վ����</param>
		/// <param name="userId">������Ա���</param>
		/// <param name="userName">������Ա����</param>
		/// <returns></returns>
		public static string Filtrate(string content, string url, string domain, int columnId, string contentId, string siteName, int userId, string userName)
		{
			MatchCollection mc = Regex.Matches(content, _keyString);
			if( mc.Count > 0)
			{
				string keywords = "";
				foreach(Match m in mc)
				{
					keywords += m.Value + ",";
				}
				keywords = keywords.Remove(keywords.Length - 1, 1);

				KeywordFilter fi = new KeywordFilter();
				fi.ColumnID = columnId;
				fi.Content = content;
				fi.Url = url;
				fi.Keyword = keywords;
				fi.Domain = domain;
				if( HttpContext.Current != null)
				{
					fi.IP = HttpContext.Current.Request.UserHostAddress;
				}
				else
				{
					fi.IP = "127.0.0.1";
				}
				fi.SiteName = siteName;
				fi.ContentID = 0;
				fi.StringID = contentId;
				fi.UserCode = userId;
				fi.UserName = userName;

				KeywordFilterAgent agent = new KeywordFilterAgent();
				agent.SetConnection(_connectionString);
                try
                {
                    agent.AddFilter(fi);
                }
                catch
                { }
				if( _replaceKeyword)
				{
					string output = Regex.Replace(content, _keyString, "*");
					return output;
				}
			}
            
			return content;
		}

        public static string HighLightKeyword(string input)
        {
            return Regex.Replace(input, _keyString, "<font class=\"hl\">$0</font>");
        }


		/// <summary>
		/// ���ͼƬ��־��ÿ���ϴ�һ��ͼƬ����¼��־
		/// </summary>
		/// <param name="fileName">ͼƬ�ļ���</param>
		/// <param name="url">ͼƬ����url��ַ</param>
		/// <param name="domain">��վ����</param>
		/// <param name="columnId">��Ӧ���</param>
		/// <param name="userId">�û�ID</param>
		/// <param name="userName">�û�����</param>
		public static void AddImageLog(string fileName, string url, string domain, string siteName, int columnId, int userId, string userName)
		{
			KeywordFilter fi = new KeywordFilter();
			fi.ColumnID = columnId;
			fi.Content = url;
			fi.Url = url;
			fi.Keyword = "";
			fi.Domain = domain;
			if( HttpContext.Current != null)
			{
				fi.IP = HttpContext.Current.Request.UserHostAddress;
			}
			else
			{
				fi.IP = "127.0.0.1";
			}
			fi.SiteName = siteName;
			fi.StringID = fileName;
			fi.ContentID = 0;
			fi.UserCode = userId;
			fi.UserName = userName;

			KeywordFilterAgent agent = new KeywordFilterAgent();
			agent.SetConnection(_connectionString);
			agent.AddFilter(fi);
		}

        /// <summary>
        /// �ϴ�ͼƬ
        /// </summary>
        /// <param name="content">ͼƬ���ӵ�ַ</param>
        /// <param name="url">ͼƬ����URL��ַ</param>
        /// <param name="domain">ͼƬ�������¡���ᡢ���ӻ��Ʒ��ַ</param>
        /// <param name="columnId">��������ţ����ձ�</param>
        /// <param name="contentId">���ݶ����ţ��ַ���</param>
        /// <param name="siteName">վ������</param>
        /// <param name="userId">ͨ��֤</param>
        /// <param name="userName">�ʺ�</param>
        public static void PhotoFiltrate(string content, string url, string domain, int columnId, string contentId, string siteName, int userId, string userName)
        {
            KeywordFilter fi = new KeywordFilter();
            fi.ColumnID = columnId;
            fi.Content = content;
            fi.Url = url;
            fi.Domain = domain;
            fi.IP = HttpContext.Current.Request.UserHostAddress;
            fi.SiteName = siteName;
            fi.ContentID = 0;
            fi.StringID = contentId;
            fi.UserCode = userId;
            fi.UserName = userName;
            KeywordFilterAgent agent = new KeywordFilterAgent();
            agent.SetConnection(_connectionString);
            agent.AddFilter(fi);
        }
    }
}
