using System;
using System.IO;
using System.Web;
using System.Web.UI;

/// <summary>
/// URLRewrite 页面基类
/// </summary>
public class Page_URLRewrite : Page
{
    public Page_URLRewrite(){}

    private string _actionUrl = "";
    /// <summary>
    /// Url
    /// </summary>
    public string ActionUrl
    {
        get { return _actionUrl; }
        set { _actionUrl = value; }
    }

    protected override void Render(HtmlTextWriter writer)
    {
        if (this.ActionUrl == "")
        {
            writer = new FormFixerHtmlTextWriter(writer.InnerWriter);
        }
        else
        {
            writer = new FormFixerHtmlTextWriter(writer.InnerWriter, this.ActionUrl);
        }
        base.Render(writer);
    }
}

internal class FormFixerHtmlTextWriter : System.Web.UI.HtmlTextWriter
{
    private string _url;
    internal FormFixerHtmlTextWriter(TextWriter writer) : base(writer)
    {
        _url = HttpContext.Current.Request.RawUrl;
    }

    internal FormFixerHtmlTextWriter(TextWriter writer, string actionUrl) : base(writer)
    {
        _url = actionUrl;
    }

    public override void WriteAttribute(string name, string value, bool encode)
    {
        // 如果当前输出的属性为form标记的action属性，则将其值替换为重写后的虚假URL
        if (_url != null && string.Compare(name, "action", true) == 0)
        {
            value = _url;
        }
        base.WriteAttribute(name, value, encode);
    }
}
