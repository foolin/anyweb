using System;
using System.Threading;
using System.Globalization;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.Design;
using System.IO;
using System.Drawing;

namespace Studio.Web
{
    /// <summary>
    /// Name:TinyMce Html Editor
    /// Description:if page contain more than one TinyMce Control, then page should exists a header runat at server.
    /// Author:Earth
    /// CreateDate:2009-1-19
    /// </summary>
    [Designer(typeof(TinyMceDesigner))]
    public class TinyMce : WebControl, INamingContainer
    {
        string _ciKey = "FA_TinyMce";
        int _index = 0;
        public TinyMce()// : base(HtmlTextWriterTag.Div)
        {
            this.textArea = new HtmlTextArea();
            this.textArea.ID = this.ID + "_txt";
            this.Controls.Add(textArea);
            lock (Context)
            {
                ArrayList tinys = (ArrayList)Context.Items[_ciKey];
                if (tinys == null)
                {
                    tinys = new ArrayList();
                    Context.Items.Add(_ciKey, tinys);
                }
                tinys.Add(this);
                _index = tinys.Count - 1;
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// TeaxArea用于控制编辑器高度、宽度和HTML
        /// </summary>
        private HtmlTextArea textArea;

        private TinyMceLangueage _language = TinyMceLangueage.zh;
        /// <summary>
        /// 语言版本
        /// </summary>
        [CategoryAttribute("Appearance")]
        public TinyMceLangueage Langueage
        {
            get { return _language; }
            set { _language = value; }
        }

        private Unit _width = new Unit("100%");
        /// <summary>
        /// 宽度
        /// </summary>
        [CategoryAttribute("Appearance")]
        public override Unit Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                textArea.Style.Add("width", value.ToString());
            }
        }

        private Unit _height = new Unit("300px");
        /// <summary>
        /// 高度
        /// </summary>
        [CategoryAttribute("Appearance")]
        public override Unit Height
        {
            get { return _height; }
            set
            {
                _height = value;
                textArea.Style.Add("height", value.ToString());
            }
        }

        private string _text = string.Empty;
        /// <summary>
        /// HTML文本
        /// </summary>
        [CategoryAttribute("Output")]
        public string Text
        {
            get
            {
                if (_text == string.Empty)
                {
                    _text = textArea.InnerText;
                }
                return _text;
            }
            set
            {
                _text = value;
                textArea.InnerText = value;
            }
        }

        private string _htmltext = string.Empty;
        /// <summary>
        /// HTML文本
        /// </summary>
        [CategoryAttribute("Output")]
        public string HtmlText
        {
            get
            {
                if (_htmltext == string.Empty)
                {
                    _htmltext = textArea.InnerText;
                }
                return _htmltext;
            }
            set
            {
                _htmltext = value;
                textArea.InnerHtml = value;
            }
        }

        private bool _resizing;
        /// <summary>
        /// 允许改变编辑器大小
        /// </summary>
        [CategoryAttribute("Behavior")]
        public bool Resizing
        {
            get { return _resizing; }
            set { _resizing = value; }
        }

        private string _theme_advanced_buttons1 = string.Empty;
        /// <summary>
        /// 第一行按钮
        /// </summary>
        public string Buttons1
        {
            get { return _theme_advanced_buttons1; }
            set { _theme_advanced_buttons1 = value; }
        }

        private string _theme_advanced_buttons2 = string.Empty;
        /// <summary>
        /// 第二行代码
        /// </summary>
        public string Buttons2
        {
            get { return _theme_advanced_buttons2; }
            set { _theme_advanced_buttons2 = value; }
        }

        private string _theme_advanced_buttons3 = string.Empty;
        /// <summary>
        /// 第三行代码
        /// </summary>
        public string Buttons3
        {
            get { return _theme_advanced_buttons3; }
            set { _theme_advanced_buttons3 = value; }
        }

        private string _theme_advanced_buttons4 = string.Empty;
        /// <summary>
        /// 第四行代码
        /// </summary>
        public string Buttons4
        {
            get { return _theme_advanced_buttons4; }
            set { _theme_advanced_buttons4 = value; }
        }



        private string _helperScripts = "/tiny_mce";
        /// <summary>
        /// JavaScript文件路径
        /// </summary>
        [CategoryAttribute("Behavior")]
        public string HelperScripts
        {
            get { return _helperScripts; }
            set
            {
                _helperScripts = value;
                if (_helperScripts.Length > 1 && _helperScripts.StartsWith("~/") && Context != null)
                {
                    _helperScripts = HttpContext.Current.Request.ApplicationPath + _helperScripts.Substring(1);
                }
            }
        }

        private string _cssLink = string.Empty;
        /// <summary>
        /// 默认样式文件路径
        /// </summary>
        [CategoryAttribute("Behavior")]
        public string CssLink
        {
            get { return _cssLink; }
            set
            {
                _cssLink = value;
                if (_cssLink.Length > 1 && _cssLink.StartsWith("~/") && Context != null)
                {
                    _cssLink = HttpContext.Current.Request.ApplicationPath + _cssLink.Substring(1);
                }
            }
        }

        [CategoryAttribute("Output")]
        public string HtmlStrippedText
        {
            get
            {
                string text = this.Text;
                return Regex.Replace(text, "<(.|\n)+?>", " ", RegexOptions.IgnoreCase);
            }
        }

        private string _theme = "advanced";
        /// <summary>
        /// 控制显示方案
        /// </summary>
        public string Theme
        {
            get { return _theme; }
            set { _theme = value; }
        }


        private int _Mode = 0;
        /// <summary>
        /// 编辑器显示模式
        /// </summary>
        public int Mode
        {
            get { return _Mode; }
            set { _Mode = value; }
        }

        /// <summary>
        /// 如果页面需要多个Editor,页面必须有runat=server的Header
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            if (this.Page.Header != null && _index == 0)
            {
                Literal lit = (Literal)this.Page.Header.FindControl("litTinyMceJs");
                if (lit == null)
                {
                    lit = new Literal();
                    lit.Text = "<script type=\"text/javascript\" src=\"" + this.HelperScripts + "/tiny_mce.js\"></script>";
                    this.Page.Header.Controls.Add(lit);
                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.textArea.Style.Add("width", this.Width.ToString());
            this.textArea.Style.Add("height", this.Height.ToString());
            this.textArea.InnerHtml = this.Text;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (Context != null)
            {
                if (this.CssClass != "")
                {
                    writer.Write("<div class=\"" + this.CssClass + "\">");
                }
                else
                {
                    writer.Write("<div>");
                }

                ArrayList validators = (ArrayList)Context.Items[_ciKey];

                StringBuilder sb = new StringBuilder();
                if (this.Page.Header == null && _index == 0)
                {
                    sb.AppendLine("<script type=\"text/javascript\" src=\"" + this.HelperScripts + "/tiny_mce.js\"></script>");
                }
                sb.AppendLine("<script type=\"text/javascript\">");
                sb.AppendLine("tinyMCE.init({");
                sb.AppendLine("mode : \"exact\",");
                sb.AppendLine("verify_html : false,");
                sb.AppendLine("elements : \"" + this.textArea.ClientID + "\",");
                sb.AppendLine("theme : \"" + (this.Theme == "" ? "advanced" : this.Theme) + "\",");
                sb.AppendLine("language : \"" + this.Langueage + "\",");
                sb.AppendLine("plugins : \"safari,pagebreak,style,layer,table,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,profile,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,pageseparator,iboximage\",");
                //switch (_Mode)
                //{
                //    case 0:
                //        sb.AppendLine("plugins : \"safari,pagebreak,style,layer,table,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,profile,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras\",");
                //        break;
                //    case 1:
                //        sb.AppendLine("plugins : \"safari,pagebreak,style,layer,table,advhr,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras\",");
                //        break;
                //}
                if (this.Buttons1 != string.Empty)
                    sb.AppendLine("theme_advanced_buttons1 : \"" + this.Buttons1 + "\",");
                if (this.Buttons2 != string.Empty)
                    sb.AppendLine("theme_advanced_buttons2 : \"" + this.Buttons2 + "\",");
                if (this.Buttons3 != string.Empty)
                    sb.AppendLine("theme_advanced_buttons3 : \"" + this.Buttons3 + "\",");
                if (this.Buttons4 != string.Empty)
                    sb.AppendLine("theme_advanced_buttons4 : \"" + this.Buttons4 + "\",");
                if (this.Resizing)
                {
                    sb.AppendLine("theme_advanced_resizing : true,");
                }
                if (this.CssLink != string.Empty)
                {
                    sb.AppendLine("content_css : \"" + this.CssLink + "\",");
                }
                else
                {
                    sb.AppendLine("content_css : \"" + this.HelperScripts + "/css/content.css\",");
                }
                sb.AppendLine("template_external_list_url : \"" + this.HelperScripts + "/lists/template_list.js\",");
                sb.AppendLine("external_link_list_url : \"" + this.HelperScripts + "/lists/link_list.js\",");
                sb.AppendLine("external_image_list_url : \"" + this.HelperScripts + "/lists/image_list.js\",");
                sb.AppendLine("media_external_list_url : \"" + this.HelperScripts + "/lists/media_list.js\",");
                sb.AppendLine("template_replace_values : {");
                sb.AppendLine("username : \"Some User\",");
                sb.AppendLine("staffid : \"991234\"");
                sb.AppendLine("}");
                sb.AppendLine("});");
                sb.AppendLine("</script>");
                writer.Write(sb.ToString());
                this.textArea.RenderControl(writer);
                writer.Write("</div>");
            }
            else
            {
                writer.Write("TinyMce HtmlEditor V1.0");
            }
        }
    }

    /// <summary>
    /// Designer for TinyMce HtmlEditor
    /// </summary>
    public class TinyMceDesigner : ControlDesigner
    {
        private TinyMce tiny = null;
        string message = "";
        public override void Initialize(IComponent component)
        {
            if (component == null)
            {
                message = "Component is null";
            }
            else
            {
                message = "";
                tiny = (TinyMce)component;
                base.Initialize(tiny);
                base.Initialize(component);
            }
        }

        public override string GetDesignTimeHtml()
        {
            if (message != "")
            {
                return message;
            }

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            HtmlTable t = new HtmlTable();
            t.CellPadding = 3;
            t.CellSpacing = 0;
            t.BorderColor = "#ccc";
            t.BgColor = "#fff";
            t.Width = tiny.Width.ToString();
            t.Height = tiny.Height.ToString();
            HtmlTableRow tr = new HtmlTableRow();
            HtmlTableCell td = new HtmlTableCell();
            td.VAlign = "top";
            td.Align = "center";

            HtmlTable iframe = new HtmlTable();
            iframe.BgColor = "#FFFFFF";
            iframe.Width = "100%";
            iframe.Height = "100%";
            iframe.CellPadding = 0;
            iframe.CellSpacing = 0;
            iframe.Style.Add("border", "1 solid #ccc");
            HtmlTableRow tr2 = new HtmlTableRow();
            HtmlTableCell td2 = new HtmlTableCell();
            td2.VAlign = "middle";
            td2.Align = "center";
            td2.Controls.Add(new LiteralControl("<b><font face=arial size=2><font color=green>TinyMce</font>Html Editor:</b> " + tiny.ID + "</font><br/>If page contain more than one TinyMce editor, then page should exists a header runat at server."));
            tr2.Cells.Add(td2);
            iframe.Rows.Add(tr2);

            td.Controls.Add(iframe);
            //td.Controls.Add(new LiteralControl("<br><br><br> "));
            tr.Cells.Add(td);
            t.Rows.Add(tr);
            t.RenderControl(htw);
            return sw.ToString();
        }

        protected override string GetErrorDesignTimeHtml(Exception e)
        {
            return CreatePlaceHolderDesignTimeHtml("error:" + e.Message + e.StackTrace);
        }
    }

    /// <summary>
    /// Langueage for TinyMce HtmlEditor
    /// </summary>
    public enum TinyMceLangueage
    {
        zh = 0,
        en = 1
    }
}