using System;
using System.IO;
using System.Web.Mail;

namespace Studio.Web
{

	/// <summary>
	/// �����ʼ�����
	/// </summary>
	public class Mails
	{
		/// <summary>
		/// �����ʼ�
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

			// �����ʼ��ķ��ͼ����յ�ַ
			email.From		= from;
			email.To		= sendto;

			email.Subject	= subject;
			email.Body		= content;

			// html��ʽ���ʼ�
			email.BodyFormat = isHtml ? MailFormat.Html : MailFormat.Text;

			// ����Ϊ�߼�����Ȩ
			email.Priority = MailPriority.Normal;

			// Ϊ�ʼ���Ӹ���
			if( att != "" && File.Exists(att))
				email.Attachments.Add( new MailAttachment(att) );

			// ʹ��SmtpMail�������ʼ�
			email.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1"); //������Ҫ��֤
			email.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", username); //�û���
			email.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", password); //����

			SmtpMail.SmtpServer = mailserver; 
			SmtpMail.Send(email);
		}


		/// <summary>
		/// �����ʼ�
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
