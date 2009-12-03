using System;
using System.Web;
using System.Web.UI;
using System.Xml;
using System.Collections;
using System.IO;

using Studio.Array;

namespace Studio.Ajax
{
	/// <summary>
	/// Name:Ajax��̨Listҳ��
	/// Description:Ajax��̨Listҳ�棬���ض����б�xml
	/// Author:л��
	/// CreateDate:2006-01-03
	/// </summary>
	public class ListPage : Page
	{
		/// <summary>
		/// ��ȡ�б�����
		/// </summary>
		/// <returns>���ݶ����б�</returns>
		protected virtual IList GetDataList()
		{
			return null;
		}

		/// <summary>
		/// �Ƿ񷵻�xml
		/// </summary>
		protected virtual bool ReturnXml
		{
			get{return true;}
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);

			if( this.ReturnXml == true)
			{
				IList objList = this.GetDataList();
			
				Response.ContentType = "text/xml";
				TextWriter sw = Response.Output;
				sw.WriteLine("<?xml version=\"1.0\" encoding=\"{0}\" ?>", "gb2312");
				sw.WriteLine("<objects>");
			
				if( objList != null && objList.Count > 0)
				{
					IEnumerator dic = objList.GetEnumerator();
					while( dic.MoveNext())
					{
						sw.WriteLine( (( IXmlable)dic.Current).ToXml() );
					}
				}

				sw.WriteLine("</objects>");
				sw.Flush();
				Response.End();
			}
		}
	}
}
