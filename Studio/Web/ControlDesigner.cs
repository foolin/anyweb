using System;
using System.Web.UI.Design;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace Studio.Web
{
    /// <summary>
    /// 自定义控件设计器
    /// </summary>
    public class SkinedControlDesigner : ControlDesigner
    {
        public override string GetDesignTimeHtml()
        {
            WebControl control = (WebControl)this.Component;

            StringBuilder sb = new StringBuilder(200);
            sb.Append("<table style='border:solid gray 1px;background-color:#cccccc;")
                .Append("width:" + control.Width.ToString() + ";")
                .Append("height:" + control.Height.ToString() + ";' cellspacing=0 cellpadding=0>")
                .Append("<tr><td align=center>")
                .Append(control.GetType().Name)
                .Append("</td><tr>")
                .Append("</table>");

            return sb.ToString();
        }

        protected override string GetErrorDesignTimeHtml(Exception e)
        {
            return CreatePlaceHolderDesignTimeHtml("error:" + e.Message + e.StackTrace);
        }
    }
}
