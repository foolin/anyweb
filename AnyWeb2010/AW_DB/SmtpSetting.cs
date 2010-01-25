using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Net.Mail;
using System.Net;

namespace FortuneAge.IBOX_UC
{
    public  class SmtpSetting
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">发送地址</param>
        /// <param name="subject">标题</param>
        /// <param name="body">内容</param>
        /// <param name="isHtml">是否为HTML格式</param>
        /// <param name="attachment"></param>
        /// <returns></returns>
        public bool SendMail(string to, string subject, string body, bool isHtml)
        {

            MailMessage message = new MailMessage("gudieaofei520@sina.com", to);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = isHtml;
            message.AlternateViews.Clear();

            SmtpClient client = new SmtpClient("smtp.sina.com", 25);
            client.EnableSsl = false;
            client.Credentials = new NetworkCredential("gudieaofei520@sina.com", "123456");

            try
            {
                client.Send(message);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
