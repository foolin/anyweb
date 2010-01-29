using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected override void OnPreRender(EventArgs e)
    {
        string templateFile = "/Control/首页.ascx";
        if (File.Exists(Server.MapPath(templateFile)))
        {
            Control templateControl = LoadControl(templateFile);
            Controls.Add(templateControl);
        }
    }

    protected override void Render(HtmlTextWriter writer)
    {
        TextWriter tempWriter = new StringWriter();
        base.Render(new HtmlTextWriter(tempWriter));
        string responseHTML = tempWriter.ToString();
        Response.Write(responseHTML);
    }
}
