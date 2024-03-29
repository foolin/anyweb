using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using Studio.IO;
using System.Diagnostics;

namespace AnyWeb.AnyWeb_DL
{
    public class SysAgent
    {
        public SysAgent()
        { }

        string _errorLog = "";
        string[] _excepts = { "Invalid_Viewstate", "Maximum request length exceeded", "Cannot use a leading .. to exit above the top directory" };
        //��¼������־
        public void WriteError(Exception ex)
        {
            foreach (string except in _excepts)
            {
                if (ex.InnerException.Message.Contains(except))
                    return;
            }

            if (_errorLog == "")
            {
                _errorLog = HttpContext.Current.Server.MapPath("/Error.log");
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Time:{0}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (HttpContext.Current != null && HttpContext.Current.Request != null)
            {
                sb.AppendFormat("IP:{0}\r\n", HttpContext.Current.Request.UserHostAddress)
                    .AppendFormat("Url:http://{0}{1}\r\n", HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.RawUrl)
                    .AppendFormat("UrlRef:{0}\r\n", HttpContext.Current.Request.UrlReferrer == null ? "" : HttpContext.Current.Request.UrlReferrer.ToString())
                    .AppendFormat("Message:{0}\r\n\r\n", ex.InnerException.ToString());
            }
            else
            {
                sb.Append(ex.InnerException.ToString())
                    .Append("\r\n");
            }

            using (StreamWriter sw = new StreamWriter(_errorLog, true, Encoding.Default))
            {
                sw.WriteLine(sb.ToString());
            }
        }

        public void WriteEventLog(string message)
        {
            WriteEventLog(message, EventLevel.Information);
        }

        public void WriteEventLog(string message, EventLevel logType)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("IP:{0}\n", HttpContext.Current.Request.UserHostAddress)
                .AppendFormat("Domain:{0}\n", HttpContext.Current.Request.Url.Host)
                .AppendFormat("Message:\n{0}", message);

            LogAgent.WriteEventLog("ANYP", "Blog", ConvertLogType(logType), sb.ToString());
        }

        EventLogEntryType ConvertLogType(EventLevel level)
        {
            switch (level)
            {
                case EventLevel.Error: return EventLogEntryType.Error;
                case EventLevel.Information: return EventLogEntryType.Information;
                case EventLevel.Warning: return EventLogEntryType.Warning;
                default: return EventLogEntryType.Information;
            }
        }

        public void WriteLogFile(string toFile, string message)
        {
            LogAgent.WriteLogFile(toFile, message);
        }

        public static SysAgent GetAgent()
        {
            return Nested.instance;
        }
        class Nested
        {
            static Nested() { }
            internal static readonly SysAgent instance = new SysAgent();
        }
    }

    public enum EventLevel
    {
        Information,
        Warning,
        Error
    }
}
