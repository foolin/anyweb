using System;
using System.IO;
using System.Data;
using System.Xml;
using System.Collections;

namespace Studio.Xml
{
	/// <summary>
	/// Name:Xml���ݴ���
	/// Description:ʵ�ֳ���Xml���ݲ���
	/// Author:л��
	/// CreateDate:2005-07-11
	/// </summary>	
	public class XmlAgent
	{
		/// <summary>
		/// ��ȡһ����key,value��ɵ������ļ�
		/// </summary>
		/// <param name="nodeName">������ֵ�ԵĽڵ�����</param>
		/// <param name="fileName">�ļ�·��</param>
		/// <returns>�����������ݵĹ�ϣ��</returns>
		public static Hashtable GetKeyValueConfig(string nodeName, string fileName)
		{
			XmlTextReader xreader = new XmlTextReader(fileName);
			
			xreader.WhitespaceHandling = WhitespaceHandling.None;
			Hashtable ht = new Hashtable();
			string name = "", values = "";
			try
			{
				while(xreader.Read())
				{
					if(xreader.LocalName == nodeName)
					{
						name = ""; values = "";
						xreader.MoveToNextAttribute();
						
						if(xreader.LocalName == "key")
						{
							name = xreader.Value;
						}

						xreader.MoveToNextAttribute();
						values=xreader.Value;

						if(name!="")
						{
							ht.Add(name,values);
						}
					}
				}
			}
			catch
			{
				ht.Clear();
				return ht;
			}
			finally
			{
				if(xreader != null)
				{
					xreader.Close();
				}
			}

			return ht;
		}

		/// <summary>
		/// ��DataSet��ȡXml������Ϣ
		/// </summary>
		/// <param name="nodeName">������ֵ�ԵĽڵ�����</param>
		/// <param name="fileName">�ļ�·��</param>
		/// <returns>�����������ݵĹ�ϣ��</returns>
		public static Hashtable GetConfigFromFile(string nodeName, string fileName)
		{
			Hashtable ht = new Hashtable();
			if( !File.Exists( fileName))
			{
				return ht;
			}

			DataSet ds = new DataSet();
			
			try
			{
				ds.ReadXml(fileName);
			}
			catch{return ht;}

			if( ds.Tables.Count > 0 && ds.Tables[0].Columns.Count == 2 && ds.Tables[0].TableName == nodeName)
			{
				foreach( DataRow row in ds.Tables[0].Rows)
				{
					ht[row[0].ToString()] = row[1].ToString();
				}
			}
			ds.Dispose();
			return ht;
		}

		/// <summary>
		/// �������õ��ļ�
		/// </summary>
		/// <param name="config">��������</param>
		/// <param name="fileName">���浽���ļ�·��</param>
		/// <param name="elementName">���ýڵ�����</param>
		public static void SaveConfigToFile(Hashtable config, string fileName, string elementName)
		{
			XmlTextWriter xwriter = null;
			try
			{
				xwriter = new XmlTextWriter(fileName, System.Text.Encoding.Default);
				xwriter.Formatting = Formatting.Indented;
				xwriter.WriteStartDocument(true);
				xwriter.WriteStartElement("root");
				foreach(DictionaryEntry dic in config)
				{
					xwriter.WriteStartElement(elementName);
					xwriter.WriteAttributeString("key", dic.Key.ToString());
					xwriter.WriteString(dic.Value.ToString());
					xwriter.WriteEndElement();
				}
				xwriter.WriteEndElement();
				xwriter.Flush();
			}
			catch{}
			finally
			{
				if(xwriter != null) xwriter.Close();
			}
		}

	}
}
