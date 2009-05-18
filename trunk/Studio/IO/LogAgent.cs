using System;
using System.Diagnostics;

namespace Studio.IO
{
    /// <summary>
    /// Name:日志代理
    /// Description:实现写入文本日志文件和Windows系统日志
    /// </summary>	
    public class LogAgent
    {
        /// <summary>
        /// 写日志文件
        /// </summary>
        /// <param name="fileName">日志文件路径</param>
        /// <param name="message">日志消息</param>
        public static void WriteLogFile(string fileName, string message)
        {
            FileAgent.WriteText(fileName, message, true);
        }

        /// <summary>
        /// 写系统日志
        /// </summary>
        /// <param name="logName">日志名称</param>
        /// <param name="eventSrc">日志源</param>
        /// <param name="type">日志类型</param>
        /// <param name="message">消息</param>
        public static void WriteEventLog(string logName, string eventSrc, EventLogEntryType type, string message)
        {
            if (!EventLog.Exists(logName))
            {
                EventLog.CreateEventSource(eventSrc, logName);
            }

            using (EventLog log = new EventLog(logName))
            {
                log.Source = eventSrc;
                log.WriteEntry(message, type);
            }
        }
    }
}
