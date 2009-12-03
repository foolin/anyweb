using System;
using System.Text.RegularExpressions;

namespace Studio.Web
{
	/// <summary>
	/// RegexString ��ժҪ˵����
	/// </summary>
	public class RegexString
	{
		public RegexString(){}

		/// <summary>
		/// HREF������
		/// </summary>
		public const string HREF_REGEX_STRING		= "href\\s*=\\s*(?:\"([^\"]*)\"|(\\S+))";
		/// <summary>
		/// ������
		/// </summary>
		public const string HTTP_REGEX_STRING		= "http://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?";
		/// <summary>
		/// ͼƬ������
		/// </summary>
		public const string IMGHTTP_REGEX_STRING	= "http://([\\w-]+\\.)+[\\w-]+((/[\\w-./?%&=]*)+(gif|jpg|png|bmp)+";
		/// <summary>
		/// ����
		/// </summary>
		public const string TITLE_REGEX_STRING		= "<title>[^<>]*</title>";
		/// <summary>
		/// �ű��������
		/// </summary>
		public const string SCRIPT_REGEX_STRING		= "<script[^>]*>([\\s\\S](?!<script))*?</script>";
		/// <summary>
		/// ����
		/// </summary>
		public const string DATE_REGEX_STRING		= "\\s*((\\d{4})|(\\d{2}))([-./])(\\d{1,2})\\4(\\d{1,2})\\s*$";
		/// <summary>
		/// �ʼ�
		/// </summary>
		public const string EMAIL_REGEX_STRING		= "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
		/// <summary>
		/// HTML��ǩBLOCKQUOTE
		/// </summary>
		public const string BLOCKQUOTE_REGEX_STRING	= "<blockquote>([\\s\\S])*</blockquote>";
		/// <summary>
		/// �������ַ�����
		/// </summary>
		public const string ABNOMAL_REGEX_STRING = "[~`!@#$%^&*()\\-_=\\+|\\\\{\\[}\\]:;\"'<,>\\.\\?\\/]+";


		/// <summary>
		/// ���˷������������
		/// </summary>
		/// <param name="input">Ҫ���˵��ļ�</param>
		/// <param name="pattern">���õ�����ʽ</param>
		/// <returns>���˺���ַ�</returns>
		public static string FilterContent(string input,string pattern)
		{
			return Regex.Replace(input,pattern,"",RegexOptions.IgnoreCase|RegexOptions.Compiled);
		}
		
		/// <summary>
		/// ��ȡ����������ʽ�ļ���
		/// </summary>
		/// <param name="input">��������</param>
		/// <param name="pattern">���õ�����ʽ</param>
		/// <returns>���ط���������ʽ�ļ���</returns>
		public static MatchCollection GetContent(string input,string pattern)
		{
			return Regex.Matches(input,pattern,RegexOptions.IgnoreCase|RegexOptions.Compiled);
		}

	}
}
