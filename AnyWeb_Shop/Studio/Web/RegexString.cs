using System;
using System.Text.RegularExpressions;

namespace Studio.Web
{
	/// <summary>
	/// RegexString 的摘要说明。
	/// </summary>
	public class RegexString
	{
		public RegexString(){}

		/// <summary>
		/// HREF超联接
		/// </summary>
		public const string HREF_REGEX_STRING		= "href\\s*=\\s*(?:\"([^\"]*)\"|(\\S+))";
		/// <summary>
		/// 超联接
		/// </summary>
		public const string HTTP_REGEX_STRING		= "http://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?";
		/// <summary>
		/// 图片超联接
		/// </summary>
		public const string IMGHTTP_REGEX_STRING	= "http://([\\w-]+\\.)+[\\w-]+((/[\\w-./?%&=]*)+(gif|jpg|png|bmp)+";
		/// <summary>
		/// 标题
		/// </summary>
		public const string TITLE_REGEX_STRING		= "<title>[^<>]*</title>";
		/// <summary>
		/// 脚本代码代码
		/// </summary>
		public const string SCRIPT_REGEX_STRING		= "<script[^>]*>([\\s\\S](?!<script))*?</script>";
		/// <summary>
		/// 日期
		/// </summary>
		public const string DATE_REGEX_STRING		= "\\s*((\\d{4})|(\\d{2}))([-./])(\\d{1,2})\\4(\\d{1,2})\\s*$";
		/// <summary>
		/// 邮件
		/// </summary>
		public const string EMAIL_REGEX_STRING		= "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
		/// <summary>
		/// HTML标签BLOCKQUOTE
		/// </summary>
		public const string BLOCKQUOTE_REGEX_STRING	= "<blockquote>([\\s\\S])*</blockquote>";
		/// <summary>
		/// 不规则字符集合
		/// </summary>
		public const string ABNOMAL_REGEX_STRING = "[~`!@#$%^&*()\\-_=\\+|\\\\{\\[}\\]:;\"'<,>\\.\\?\\/]+";


		/// <summary>
		/// 过滤符合正则的数据
		/// </summary>
		/// <param name="input">要过滤的文件</param>
		/// <param name="pattern">采用的正则方式</param>
		/// <returns>过滤后的字符</returns>
		public static string FilterContent(string input,string pattern)
		{
			return Regex.Replace(input,pattern,"",RegexOptions.IgnoreCase|RegexOptions.Compiled);
		}
		
		/// <summary>
		/// 获取符合正则表达式的集合
		/// </summary>
		/// <param name="input">输入内容</param>
		/// <param name="pattern">采用的正则方式</param>
		/// <returns>返回符合正则表达式的集合</returns>
		public static MatchCollection GetContent(string input,string pattern)
		{
			return Regex.Matches(input,pattern,RegexOptions.IgnoreCase|RegexOptions.Compiled);
		}

	}
}
