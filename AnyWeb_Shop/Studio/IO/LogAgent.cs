using System;
using System.Diagnostics;

namespace Studio.IO
{
	/// <summary>
	/// Name:��־����
	/// Description:ʵ��д���ı���־�ļ���Windowsϵͳ��־
	/// Author:л��
	/// CreateDate:2005-07-11
	/// </summary>	
	public class LogAgent
	{
		/// <summary>
		/// д��־�ļ�
		/// </summary>
		/// <param name="fileName">��־�ļ�·��</param>
		/// <param name="message">��־��Ϣ</param>
		public static void WriteLogFile( string fileName, string message)
		{
			FileAgent.WriteText(fileName, message, true);
		}

		/// <summary>
		/// дϵͳ��־
		/// </summary>
		/// <param name="logName">��־����</param>
		/// <param name="eventSrc">��־Դ</param>
		/// <param name="type">��־����</param>
		/// <param name="message">��Ϣ</param>
		public static void WriteEventLog( string logName, string eventSrc, EventLogEntryType type, string message)
		{
			if( !EventLog.Exists( logName ))
			{
				EventLog.CreateEventSource(eventSrc, logName);
			}

			using( EventLog log = new EventLog( logName))
			{
				log.Source = eventSrc;
				log.WriteEntry(message, type);
			}
		}
	}
}
