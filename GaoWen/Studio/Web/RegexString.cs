using System;
using System.Text.RegularExpressions;

namespace Studio.Web
{
	/// <summary>
	/// HTML���ݳ�������
	/// </summary>
	public class RegexString
	{
		public RegexString(){}

		/// <summary>
		/// HREF������
		/// </summary>
		public const string HREF		= "href\\s*=\\s*(?:\"([^\"]*)\"|(\\S+))";
		/// <summary>
		/// ������
		/// </summary>
		public const string URL		    = "http://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?";
		/// <summary>
		/// ͼƬ������
		/// </summary>
		public const string IMAGEURL	= "http://([\\w-]+\\.)+[\\w-]+((/[\\w-./?%&=]*)+(gif|jpg|png|bmp)+";
		/// <summary>
		/// ����
		/// </summary>
		public const string HTMLTITLE		= "<title>[^<>]*</title>";
		/// <summary>
		/// �ű��������
		/// </summary>
		public const string SCRIPT		= "<script[^>]*>([\\s\\S](?!<script))*?</script>";
		/// <summary>
		/// ����
		/// </summary>
		public const string DATE		= "\\s*((\\d{4})|(\\d{2}))([-./])(\\d{1,2})\\4(\\d{1,2})\\s*$";
		/// <summary>
		/// �ʼ�
		/// </summary>
		public const string EMAIL		= "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
		/// <summary>
		/// HTML��ǩBLOCKQUOTE
		/// </summary>
		public const string BLOCKQUOTE	= "<blockquote>([\\s\\S])*</blockquote>";
		/// <summary>
		/// �������ַ�����
		/// </summary>
		public const string ABNOMAL = "[~`!@#$%^&*()\\-_=\\+|\\\\{\\[}\\]:;\"'<,>\\.\\?\\/]+";


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
