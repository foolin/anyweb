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
    /// Name:ajax单个对象结果页面
    /// Description:Ajax返回单条记录
    /// Author:谢康
    /// CreateDate:2008-02-15
    /// </summary>
    public class ObjPage : Page
    {
        /// <summary>
        /// 获取对象数据
        /// </summary>
        /// <returns>数据对象</returns>
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
