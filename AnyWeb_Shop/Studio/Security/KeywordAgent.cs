using System;
using System.Web;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace Studio.Security
{
	/// <summary>
	/// 关键字数据代理
	/// </summary>
	public class KeywordAgent
	{

		public static bool _replaceKeyword = System.Configuration.ConfigurationSettings.AppSettings["FilterReplace"] != "0";
		public static string _connectionString = Secure.GetAppSetting("FilterConnectionString");
		public static string _keyString = String.Empty;
		public static string[] _keywords;
		/// <summary>
		/// 读取关键字列表
		/// </summary>
		/// <param name="path">关键字文件路径(xml)</param>
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
		/// 检查是否包含关键字
		/// </summary>
		/// <param name="input">要检查的字符串</param>
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
		/// 检查字符串,如果包含关键字,返回第一个
		/// </summary>
		/// <param name="input">要检查的字符串</param>
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
		/// 检查字符串,返回所有包含的关键字
		/// </summary>
		/// <param name="input">要检查的字符串</param>
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
		/// 去除字符串中的关键字
		/// </summary>
		/// <param name="input">要检查的字符串</param>
		/// <param name="replaceTo">替换后的字符</param>
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
		/// 以默认字符替换关键字
		/// </summary>
		/// <param name="input">要检查的字符串</param>
		/// <returns></returns>
		public static string RemoveKeyword( string input)
		{
			return RemoveKeyword( input, "*");
		}

		/// <summary>
		/// 扫描，如果截获关键字的话，记录日志，并返回替换后的字符串
		/// </summary>
		/// <param name="content">扫描的内容</param>
		/// <param name="url">内容公网访问地址</param>
		/// <param name="domain">内容所属域名</param>
		/// <param name="columnId">内容类别编号（对照表）</param>
		/// <param name="contentId">内容对象编号（整数）</param>
		/// <param name="siteName">站点名</param>
		/// <param name="userId">操作人员编号</param>
		/// <param name="userName">操作人员名称</param>
		/// <returns></returns>
		public static string Filtrate(string content, string url, string domain, int columnId, int contentId, string siteName, int userId, string userName)
		{
			return Filtrate(content, url, domain, columnId, contentId.ToString(), siteName, userId, userName);
		}

		/// <summary>
		/// 扫描，如果截获关键字的话，记录日志，并返回替换后的字符串
		/// </summary>
		/// <param name="content">扫描的内容</param>
		/// <param name="url">内容公网访问地址</param>
		/// <param name="domain">内容所属域名</param>
		/// <param name="columnId">内容类别编号（对照表）</param>
		/// <param name="contentId">内容对象编号（字符）</param>
		/// <param name="siteName">站点名</param>
		/// <param name="userId">操作人员编号</param>
		/// <param name="userName">操作人员名称</param>
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
		/// 添加图片日志，每新上传一张图片均记录日志
		/// </summary>
		/// <param name="fileName">图片文件名</param>
		/// <param name="url">图片绝对url地址</param>
		/// <param name="domain">网站域名</param>
		/// <param name="columnId">对应类别</param>
		/// <param name="userId">用户ID</param>
		/// <param name="userName">用户名称</param>
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
        /// 上传图片
        /// </summary>
        /// <param name="content">图片链接地址</param>
        /// <param name="url">图片完整URL地址</param>
        /// <param name="domain">图片所在文章、相册、帖子或产品地址</param>
        /// <param name="columnId">内容类别编号（对照表）</param>
        /// <param name="contentId">内容对象编号（字符）</param>
        /// <param name="siteName">站点名称</param>
        /// <param name="userId">通行证</param>
        /// <param name="userName">帐号</param>
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
