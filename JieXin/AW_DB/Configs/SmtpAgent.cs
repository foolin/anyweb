using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Studio.Array;
using System.Xml;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.IO;
using Studio.IO;

namespace AnyWell.Configs
{
    /// <summary>
    /// 邮件代理
    /// </summary>
    public class SmtpAgent
    {
        private System.Timers.Timer smtpTimer = new System.Timers.Timer(6000);
        private DateTime _lastModidyAt;

        public SmtpAgent()
        {
            Init();

            smtpTimer.AutoReset = true;
            smtpTimer.Enabled = true;
            smtpTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            smtpTimer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            FileInfo fi = new FileInfo(_smtpFile);
            if (fi.Exists)
            {
                if (fi.LastWriteTime > _lastModidyAt)
                {
                    Init();
                }
            }
            else
            {
                this.Save();
                _lastModidyAt = DateTime.Now;
            }
        }


        public void Init()
        {
            _smtps = new List<Smtp>();

            XmlDocument xml = new XmlDocument();
            xml.Load(_smtpFile);
            XmlNode root = xml.SelectSingleNode("Smtps");

            foreach (XmlNode node in root.ChildNodes)
            {
                Smtp smtp = new Smtp();
                smtp.ID = int.Parse(node.SelectSingleNode("ID").InnerText);
                smtp.Sender = node.SelectSingleNode("Sender").InnerText;
                smtp.Port = int.Parse(node.SelectSingleNode("Port").InnerText);
                smtp.ServerAddress = node.SelectSingleNode("ServerAddress").InnerText;
                smtp.UserName = node.SelectSingleNode("UserName").InnerText;
                smtp.Password = node.SelectSingleNode("Password").InnerText;
                smtp.EnableSsl = node.SelectSingleNode("EnableSsl").InnerText == "1";
                _smtps.Add(smtp);
            }

            _lastModidyAt = DateTime.Now;
            _smtpIndex = 0;
        }

        public void Save()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"gb2312\" ?>");
            sb.AppendLine("<Smtps>");
            foreach (Smtp smtp in _smtps)
            {
                sb.AppendLine(" <Smtp>");
                sb.AppendLine("  <ID>" + smtp.ID.ToString() + "</ID>");
                sb.AppendLine("  <Sender>" + smtp.Sender + "</Sender>");
                sb.AppendLine("  <Port>" + smtp.Port.ToString() + "</Port>");
                sb.AppendLine("  <ServerAddress>" + smtp.ServerAddress + "</ServerAddress>");
                sb.AppendLine("  <UserName>" + smtp.UserName + "</UserName>");
                sb.AppendLine("  <Password>" + smtp.Password + "</Password>");
                sb.AppendLine("  <EnableSsl>" + (smtp.EnableSsl ? "1" : "0") + "</EnableSsl>");
                sb.AppendLine(" </Smtp>");
            }
            sb.Append("</Smtps>");
            FileAgent.WriteText(_smtpFile, sb.ToString(), false, Encoding.GetEncoding("gb2312"));
            _lastModidyAt = DateTime.Now;

            if (GeneralConfigs.GetConfig().SetupConfigSmtps == false)
            {
                GeneralConfigs.GetConfig().SetupConfigSmtps = true;
                GeneralConfigs.Serialiaze(GeneralConfigs.GetConfig(), DefaultConfigFileManager.ConfigFilePath);
            }
        }

        /// <summary>
        /// 轮换使用Smtp配置发送邮件
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="isHtml"></param>
        /// <param name="cc"></param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        public bool SendMail(string to, string subject, string body, bool isHtml, string attachment)
        {
            if (_smtps == null || _smtps.Count == 0)
                return false;

            //string ipAddress = HttpContext.Current.Request.ServerVariables["Local_Addr"];
            //if( ipAddress.StartsWith( "192." ) || ipAddress.StartsWith( "127." ) || ipAddress.StartsWith( "localhost" ) )
            //{
            //    return false;
            //}


            Smtp smtp = _smtps[_smtpIndex];

            MailMessage message = new MailMessage( smtp.Sender, to );
            message.SubjectEncoding = Encoding.UTF8;
            message.Subject = subject;
            message.IsBodyHtml = isHtml;
            message.BodyEncoding = Encoding.UTF8;
            message.Body = body;

            SmtpClient client = new SmtpClient( smtp.ServerAddress, smtp.Port );
            client.EnableSsl = smtp.EnableSsl;
            client.Credentials = new NetworkCredential( smtp.UserName, smtp.Password );

            _smtpIndex++;
            if( _smtpIndex + 1 >= _smtps.Count )
                _smtpIndex = 0;

            try
            {
                client.Send( message );
                return true;
            }
            catch( Exception ex )
            {
                return false;
            }   
        }


        private static object lockHelper = new object();
        private static volatile SmtpAgent instance = null;
        string _smtpFile = HttpContext.Current.Server.MapPath("~/App_Data/Smtps.xml");
        int _smtpIndex = 0;


        public static SmtpAgent GetAgent()
        {
            if (instance == null)
            {
                lock (lockHelper)
                {
                    if (instance == null)
                    {
                        instance = new SmtpAgent();
                    }
                }
            }
            return instance;

        }

        public static void SetInstance(SmtpAgent anInstance)
        {
            if (anInstance != null)
                instance = anInstance;
        }

        public static void SetInstance()
        {
            SetInstance(new SmtpAgent());
        }

        private List<Smtp> _smtps;
        /// <summary>
        /// 邮件服务器阵列
        /// </summary>
        public List<Smtp> Smtps
        {
            get { return _smtps; }
            set { _smtps = value; }
        }
	
    }

    public class Smtp
    {
        private int _id;
        /// <summary>
        /// 编号
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
	

        private string _sender;
        /// <summary>
        /// 发送者邮件
        /// </summary>
        public string Sender
        {
            get { return _sender; }
            set { _sender = value; }
        }

        private string _serverAddress;
        /// <summary>
        /// SMTP服务器地址
        /// </summary>
        public string ServerAddress
        {
            get { return _serverAddress; }
            set { _serverAddress = value; }
        }

        private string _username;
        /// <summary>
        /// 登录名
        /// </summary>
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private bool _enableSsl = false;
        /// <summary>
        /// 是否启用SSL验证(Gmail启用)
        /// </summary>
        public bool EnableSsl
        {
            get { return _enableSsl; }
            set { _enableSsl = value; }
        }

        private int _port = 25;
        /// <summary>
        /// 端口号(Gmail使用587)
        /// </summary>
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }
	
    }
}
