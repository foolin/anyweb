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
    /// Name:ajax����������ҳ��
    /// Description:Ajax���ص�����¼
    /// Author:л��
    /// CreateDate:2008-02-15
    /// </summary>
    public class ObjPage : Page
    {
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns>���ݶ���</returns>
        protected virtual IXmlable GetObject()
        {
            return null;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            IXmlable obj = this.GetObject();

            Response.ContentType = "text/xml";
            TextWriter sw = Response.Output;
            sw.WriteLine("<?xml version=\"1.0\" encoding=\"{0}\" ?>", "gb2312");
            sw.WriteLine("<object>");

            if (obj != null)
            {
                sw.WriteLine(obj.ToXml());
            }

            sw.WriteLine("</object>");
            sw.Flush();
            Response.End();
        }
    }
}
