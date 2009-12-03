using System;
using System.Collections;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace Studio.Mail
{
	/// <summary>
	/// Name:�����ʼ����
	/// Description:ʵ�ֵ����ʼ�����
	/// Author:л��
	/// CreateDate:2005-07-11
	/// </summary>
	public class MailAgent
	{
		TcpClient tcp = null;
		bool isLogin = false;
		ArrayList mails = new ArrayList();

		public MailAgent()
		{
		}
		/// <summary>
		/// SMTP����������
		/// </summary>
		public string Server 
		{
			get { return server; }
			set { if (value != server) server = value; }
		} 
		private string server = "";

		/// <summary>
		/// SMTP�������˿� [Ĭ��Ϊ25]
		/// </summary>
		public int Port 
		{
			get { return port; }
			set { if (value != port) port = value; }
		} 
		private int port = 25;

		/// <summary>
		/// �û��� [�����Ҫ�����֤�Ļ�]
		/// </summary>
		public string UserName 
		{
			get { return userName; }
			set { if (value != userName) userName = value; }
		} 
		private string userName = "";

		/// <summary>
		/// ���� [�����Ҫ�����֤�Ļ�]
		/// </summary>
		public string Password 
		{
			get { return password; }
			set { if (value != password) password = value; }
		} 
		private string password = "";

		/// <summary>
		/// �����˵�ַ
		/// </summary>
		public string From 
		{
			get { return from; }
			set { if (value != from) from = value;}
		} 
		private string from = "";

		/// <summary>
		/// �ռ��˵�ַ
		/// </summary>
		public string To 
		{
			get { return to; }
			set { if (value != to) to = value;}
		} 
		private string to = "";

		/// <summary>
		/// ����������
		/// </summary>
		public string FromName 
		{
			get { return fromName; }
			set { if (value != fromName) fromName = value; }
		} 
		private string fromName = "";

		/// <summary>
		/// �ռ�������
		/// </summary>
		public string ToName 
		{
			get { return toName; }
			set { if (value != toName) toName = value; }
		} 
		private string toName = "";

		/// <summary>
		/// �ʼ�������
		/// </summary>
		public string Subject 
		{
			get { return subject; }
			set { if (value != subject) subject = value; }
		} 
		private string subject = "";

		/// <summary>
		/// �ʼ�����
		/// </summary>
		public string Body 
		{
			get { return body; }
			set { if (value != body) body = value; }
		} 
		private string body = "";

		/// <summary>
		/// ���ı���ʽ���ʼ�����
		/// </summary>
		public string HtmlBody 
		{
			get { return htmlBody; }
			set { if (value != htmlBody) htmlBody = value; }
		} 
		private string htmlBody = "";

		/// <summary>
		/// �Ƿ���html��ʽ���ʼ�
		/// </summary>
		public bool IsHtml 
		{
			get { return isHtml; }
			set { if (value != isHtml) isHtml = value; }
		}
		private bool isHtml = false;

		/// <summary>
		/// ���Ա��� [Ĭ��ΪGB2312]
		/// </summary>
		public string LanguageEncoding 
		{
			get { return languageEncoding; }
			set { if (value != languageEncoding) languageEncoding = value; }
		}
		private string languageEncoding = "GB2312";

		/// <summary>
		/// �ʼ����� [Ĭ��Ϊ8bit]
		/// </summary>
		public string MailEncoding 
		{
			get { return encoding; }
			set { if (value != encoding) encoding = value; }
		} 
		private string encoding = "8bit";

		/// <summary>
		/// �ʼ����ȼ� [Ĭ��Ϊ3]
		/// </summary>
		public int Priority 
		{
			get { return priority; }
			set { if (value != priority) priority = value; }
		} 
		private int priority = 3;

		/// <summary>
		/// ���� [AttachmentInfo]
		/// </summary>
		public IList Attachments 
		{
			get { return attachments; }
			//   set { if (value != attachments) attachments = value; }
		} 
		private ArrayList attachments = new ArrayList ();


		public void Login()
		{
			isLogin = false;
			try
			{
				tcp = new TcpClient (server, port);
			}
			catch (Exception)
			{
				throw new Exception ("�޷����ӷ�����");
			}

			ReadString (tcp.GetStream());//��ȡ������Ϣ

			// ��ʼ���з�������֤
			// ���״̬����250���ʾ�����ɹ�
			if (!Command (tcp.GetStream(), "EHLO Localhost", "250"))
				throw new Exception ("��½�׶�ʧ��");

			if (userName != "")
			{
				// ��Ҫ�����֤
				if (!Command (tcp.GetStream(), "AUTH LOGIN", "334"))
					throw new Exception ("�����֤�׶�ʧ��");
				string nameB64 = ToBase64 (userName); // �˴���usernameת��ΪBase64��
				if (!Command (tcp.GetStream(), nameB64, "334"))
					throw new Exception ("�����֤�׶�ʧ��");
				string passB64 = ToBase64 (password); // �˴���passwordת��ΪBase64��
				if (!Command (tcp.GetStream(), passB64, "235"))
					throw new Exception ("�����֤�׶�ʧ��");
			}
			isLogin = true;
			if(mails.Count > 0)SendMail();
		}

		public void AddMail(Mail mail)
		{
			mails.Add(mail);
		}
		public void Close()
		{
			tcp.Close();
			isLogin = false;
		}
		/// <summary>
		/// �����ʼ�
		/// </summary>
		public void SendMail ()
		{
			// ����TcpClient���� ����������
			if( !this.isLogin) 
			{
				this.Login();
				return;
			}
			while(mails.Count > 0)
			{
				Mail mail = (Mail)mails[0];
				// ׼������
				WriteString (tcp.GetStream(), "mail From: " + from);
				WriteString (tcp.GetStream(), "rcpt to: " + mail.To);
				WriteString (tcp.GetStream(), "data");

				// �����ʼ�ͷ
				WriteString (tcp.GetStream(), "Date: " + DateTime.Now); // ʱ��
				WriteString (tcp.GetStream(), "From: " + fromName + "<" + from + ">"); // ������
				WriteString (tcp.GetStream(), "Subject: " + subject); // ����
				WriteString (tcp.GetStream(), "To:" + mail.ToName + "<" + mail.To + ">"); // �ռ���

				//�ʼ���ʽ 
				WriteString (tcp.GetStream(), "Content-Type: multipart/mixed; boundary=\"unique-boundary-1\"");
				WriteString (tcp.GetStream(), "Reply-To:" + from); // �ظ���ַ
				WriteString (tcp.GetStream(), "X-Priority:" + priority); // ���ȼ�
				WriteString (tcp.GetStream(), "MIME-Version:1.0"); // MIME�汾

				// ����ID,����
				//   WriteString (tcp.GetStream(), "Message-Id: " + DateTime.Now.ToFileTime() + "@security.com");
				WriteString (tcp.GetStream(), "Content-Transfer-Encoding:" + encoding); // ���ݱ���
				WriteString (tcp.GetStream(), "X-Mailer:JcPersonal.Utility.MailSender"); // �ʼ�������
				WriteString (tcp.GetStream(), "");

				WriteString (tcp.GetStream(), ToBase64 ("This is a multi-part message in MIME format.")); 
				WriteString (tcp.GetStream(), ""); 

				// �Ӵ˴���ʼ���зָ�����
				WriteString (tcp.GetStream(), "--unique-boundary-1");

				// �ڴ˴�����ڶ����ָ���
				WriteString (tcp.GetStream(), "Content-Type: multipart/alternative;Boundary=\"unique-boundary-2\"");
				WriteString (tcp.GetStream(), "");

				if(!isHtml)
				{
					// �ı���Ϣ
					WriteString (tcp.GetStream(), "--unique-boundary-2");
					WriteString (tcp.GetStream(), "Content-Type: text/plain;charset=" + languageEncoding);
					WriteString (tcp.GetStream(), "Content-Transfer-Encoding:" + encoding);
					WriteString (tcp.GetStream(), "");
					WriteString (tcp.GetStream(), body);
					WriteString (tcp.GetStream(), "");//һ������д��֮���д�����Ϣ���ֶ�
					WriteString (tcp.GetStream(), "--unique-boundary-2--");//�ָ����Ľ������ţ�β�ͺ������--
					WriteString (tcp.GetStream(), "");
				}
				else
				{
					//html��Ϣ
					WriteString (tcp.GetStream(), "--unique-boundary-2"); 
					WriteString (tcp.GetStream(), "Content-Type: text/html;charset=" + languageEncoding); 
					WriteString (tcp.GetStream(), "Content-Transfer-Encoding:" + encoding); 
					WriteString (tcp.GetStream(), ""); 
					//WriteString (tcp.GetStream(), htmlBody); 
					WriteString (tcp.GetStream(), mail.Content); 
					WriteString (tcp.GetStream(), ""); 
					WriteString (tcp.GetStream(), "--unique-boundary-2--");//�ָ����Ľ������ţ�β�ͺ������-- 
					WriteString (tcp.GetStream(), ""); 
				}

				WriteString (tcp.GetStream(), "--unique-boundary-1--");
				// ���͸���
				// ���ļ��б���ѭ��
				for (int i = 0; i < attachments.Count; i++)
				{
					WriteString (tcp.GetStream(), "--unique-boundary-1"); // �ʼ����ݷָ���
					WriteString (tcp.GetStream(), "Content-Type: application/octet-stream;name=\"" + ((AttachmentInfo)attachments[i]).FileName + "\""); // �ļ���ʽ
					WriteString (tcp.GetStream(), "Content-Transfer-Encoding: base64"); // ���ݵı���
					WriteString (tcp.GetStream(), "Content-Disposition:attachment;filename=\"" + ((AttachmentInfo)attachments[i]).FileName + "\""); // �ļ���
					WriteString (tcp.GetStream(), "");
					WriteString (tcp.GetStream(), ((AttachmentInfo)attachments[i]).Bytes); // д���ļ�������
					WriteString (tcp.GetStream(), "");
				}

				Command (tcp.GetStream(), ".", "250"); // ���д���ˣ�����"."
				mails.RemoveAt(0);
				//mails.Clear();
			}
			// �ر�����
			//tcp.Close ();
		}

		/// <summary>
		/// ������д���ַ�
		/// </summary>
		/// <param name="netStream">����TcpClient����</param>
		/// <param name="str">д����ַ�</param>
		protected void WriteString (NetworkStream netStream, string str)
		{
			str = str + "\r\n"; // ���뻻�з�

			// ��������ת��Ϊbyte[]
			byte[] bWrite = Encoding.GetEncoding(languageEncoding).GetBytes(str.ToCharArray());

			// ����ÿ��д������ݴ�С�������Ƶģ���ô���ǽ�ÿ��д������ݳ��ȶ��ڣ������ֽڣ�һ������ȳ����ˣ������ͷֲ�д�롣
			int start=0;
			int length=bWrite.Length;
			int page=0;
			int size=75;
			int count=size;
			try
			{
				if (length>75)
				{
					// ���ݷ�ҳ
					if ((length/size)*size<length)
						page=length/size+1;
					else
						page=length/size;
					for (int i=0;i<page;i++)
					{
						start=i*size;
						if (i==page-1)
							count=length-(i*size);
						netStream.Write(bWrite,start,count);// ������д�뵽��������
					}
				}
				else
					netStream.Write(bWrite,0,bWrite.Length);
			}
			catch(Exception)
			{
				// ���Դ���
			}
		}

		/// <summary>
		/// �����ж�ȡ�ַ�
		/// </summary>
		/// <param name="netStream">����TcpClient����</param>
		/// <returns>��ȡ���ַ�</returns>
		protected string ReadString (NetworkStream netStream)
		{
			string sp = null;
			byte[] by = new byte[1024];
			int size = netStream.Read(by,0,by.Length);// ��ȡ������
			if (size > 0)
			{
				sp = Encoding.Default.GetString(by);// ת��ΪString
			}
			return sp;
		}

		/// <summary>
		/// ��������жϷ�����Ϣ�Ƿ���ȷ
		/// </summary>
		/// <param name="netStream">����TcpClient����</param>
		/// <param name="command">����</param>
		/// <param name="state">��ȷ��״̬��</param>
		/// <returns>�Ƿ���ȷ</returns>
		protected bool Command (NetworkStream netStream, string command, string state)
		{
			string sp=null;
			bool success=false;
			try
			{
				WriteString (netStream, command);// д������
				sp = ReadString (netStream);// ���ܷ�����Ϣ
				if (sp.IndexOf(state) != -1)// �ж�״̬���Ƿ���ȷ
					success=true;
			}
			catch(Exception)
			{
				// ���Դ���
			}
			return success;
		}

		/// <summary>
		/// �ַ�������ΪBase64
		/// </summary>
		/// <param name="str">�ַ���</param>
		/// <returns>Base64������ַ���</returns>
		protected string ToBase64 (string str)
		{
			try
			{
				byte[] by = Encoding.Default.GetBytes (str.ToCharArray());
				str = Convert.ToBase64String (by);
			}
			catch(Exception)
			{
				// ���Դ���
			}
			return str;
		}

		/// <summary>
		/// һ������ʼ�
		/// </summary>
		public class Mail
		{
			string _to = String.Empty;
			string _toName = String.Empty;
			string _content = String.Empty;

			public Mail(){}
			public Mail(string to, string toName, string content)
			{
				_to = to;
				_toName = toName;
				_content = content;
			}
			public string To
			{
				get{return _to;}
				set{_to = value;}
			}

			public string ToName
			{
				get{return _toName;}
				set{_toName = value;}
			}

			public string Content
			{
				get{return _content;}
				set{_content = value;}
			}
		}
		/// <summary>
		/// ������Ϣ
		/// </summary>
		public struct AttachmentInfo
		{
			/// <summary>
			/// �������ļ��� [�������·�������Զ�ת��Ϊ�ļ���]
			/// </summary>
			public string FileName 
			{
				get { return fileName; }
				set { fileName = Path.GetFileName(value); }
			} private string fileName;

			/// <summary>
			/// ���������� [�ɾ�Base64������ֽ����]
			/// </summary>
			public string Bytes 
			{
				get { return bytes; }
				set { if (value != bytes) bytes = value; }
			} private string bytes;

			/// <summary>
			/// �����ж�ȡ�������ݲ�����
			/// </summary>
			/// <param name="ifileName">�������ļ���</param>
			/// <param name="stream">��</param>
			public AttachmentInfo (string ifileName, Stream stream)
			{
				fileName = Path.GetFileName (ifileName);
				byte[] by = new byte [stream.Length];
				stream.Read (by,0,(int)stream.Length); // ��ȡ�ļ�����
				//��ʽת��
				bytes = Convert.ToBase64String (by); // ת��Ϊbase64����
			}

			/// <summary>
			/// ���ո������ֽڹ��츽��
			/// </summary>
			/// <param name="ifileName">�������ļ���</param>
			/// <param name="ibytes">���������� [�ֽ�]</param>
			public AttachmentInfo (string ifileName, byte[] ibytes)
			{
				fileName = Path.GetFileName (ifileName);
				bytes = Convert.ToBase64String (ibytes); // ת��Ϊbase64����
			}

			/// <summary>
			/// ���ļ����벢����
			/// </summary>
			/// <param name="path"></param>
			public AttachmentInfo (string path)
			{
				fileName = Path.GetFileName (path);
				FileStream file = new FileStream (path, FileMode.Open);
				byte[] by = new byte [file.Length];
				file.Read (by,0,(int)file.Length); // ��ȡ�ļ�����
				//��ʽת��
				bytes = Convert.ToBase64String (by); // ת��Ϊbase64����
				file.Close ();
			}
		}
	}
}
