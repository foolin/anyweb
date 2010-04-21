using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;
using System.IO;

public partial class Index : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    string url = Request.Path.ToLower();;
    //    if (url.StartsWith("/"))
    //    {
    //        url = url.Substring(1);
    //    }
    //    AW_Mapping_bean mapping = GetControl(url);
    //    LoadControl(mapping);
    //}

    //protected AW_Mapping_bean GetControl(string url)
    //{
    //    AW_Mapping_bean mapping = new AW_Mapping_dao().funcGetMapping(url);
    //    //映射不存在，返回400
    //    if (mapping == null)
    //    {
    //        Error();
    //    }
    //    return mapping;
    //}

    //protected void LoadControl(AW_Mapping_bean bean)
    //{
    //    string templateFile = string.Format("~/Control/{0}.ascx", bean.Template.fdTempName);
    //    if (File.Exists(Server.MapPath(templateFile)))
    //    {
    //        Control templateControl = LoadControl(templateFile);
    //        Controls.Add(templateControl);
    //    }
    //    else
    //    {
    //        Error();
    //    }
    //}

    //protected override void Render(HtmlTextWriter writer)
    //{
    //    TextWriter tempWriter = new StringWriter();
    //    base.Render(new HtmlTextWriter(tempWriter));
    //    string responseHTML = tempWriter.ToString();
    //    Response.Write(responseHTML);
    //}

    //protected void Error()
    //{
    //    HttpContext.Current.Response.Status = "404 - Bad Request";
    //    HttpContext.Current.Response.End();
    //}
}
