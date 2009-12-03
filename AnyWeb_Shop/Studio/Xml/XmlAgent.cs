using System;
using System.IO;
using System.Data;
using System.Xml;
using System.Collections;

namespace Studio.Xml
{
	/// <summary>
	/// Name:Xml数据代理
	/// Description:实现常用Xml数据操作
	/// Author:谢康
	/// CreateDate:2005-07-11
	/// </summary>	
	public class XmlAgent
	{
		/// <summary>
		/// 获取一个由key,value组成的配置文件
		/// </summary>
		/// <param name="nodeName">包含键值对的节点名称</param>
		/// <param name="fileName">文件路径</param>
		/// <returns>包含配置数据的哈希表</returns>
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
		/// 用DataSet读取Xml配置信息
		/// </summary>
		/// <param name="nodeName">包含键值对的节点名称</param>
		/// <param name="fileName">文件路径</param>
		/// <returns>包含配置数据的哈希表</returns>
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
		/// 保存配置到文件
		/// </summary>
		/// <param name="config">配置数据</param>
		/// <param name="fileName">保存到的文件路径</param>
		/// <param name="elementName">配置节点名称</param>
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
