using System;
using System.IO;
using System.Web.Mail;

namespace Studio.Web
{

	/// <summary>
	/// 电子邮件发送
	/// </summary>
	public class Mails
	{
		/// <summary>
		/// 发送邮件
		/// </summary>
		/// <param name="subject"></param>
		/// <param name="content"></param>
		/// <param name="isHtml"></param>
		/// <param name="att"></param>
		/// <param name="mailserver"></param>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <param name="from"></param>
		/// <param name="sendto"></param>
		public static void SendMail (string subject,string content, string att, bool isHtml, string sendto,string mailserver,string username,string password,string from)
		{
			MailMessage email = new MailMessage();

			// 设置邮件的发送及接收地址
			email.From		= from;
			email.To		= sendto;

			email.Subject	= subject;
			email.Body		= content;

			// html格式的邮件
			email.BodyFormat = isHtml ? MailFormat.Html : MailFormat.Text;

			// 设置为高级优先权
			email.Priority = MailPriority.Normal;

			// 为邮件添加附件
			if( att != "" && File.Exists(att))
				email.Attachments.Add( new MailAttachment(att) );

			// 使用SmtpMail对象发送邮件
			email.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1"); //设置需要验证
			email.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", username); //用户名
			email.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", password); //密码

			SmtpMail.SmtpServer = mailserver; 
			SmtpMail.Send(email);
		}


		/// <summary>
		/// 发送邮件
		/// </summary>
		/// <param name="subject"></param>
		/// <param name="content"></param>
		/// <param name="att"></param>
		/// <param name="isHtml"></param>
		/// <param name="to"></param>
		public static void SendMail(string subject, string content, string att, bool isHtml,string sendto)
		{
			SendMail(
				subject,
				content,
				att,   
				isHtml,
				sendto,
				System.Configuration.ConfigurationSettings.AppSettings["SmtpServer"], 
				System.Configuration.ConfigurationSettings.AppSettings["SmtpUserName"],
				System.Configuration.ConfigurationSettings.AppSettings["SmtpPassword"], 
				System.Configuration.ConfigurationSettings.AppSettings["SmtpFrom"]
				);
		}
		
	}

}
