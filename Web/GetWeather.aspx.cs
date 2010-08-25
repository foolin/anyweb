using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Net;
using System.Text.RegularExpressions;

public partial class GetWeather : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (Request.QueryString["id"] + "" == "") 
        {
            return;
        }
        try
        {
            string resText = HttpAgent.ReadRemoteFile(string.Format("http://www.265.com/weather/{0}.htm", Request.QueryString["id"]));
            string reg = @"(?<=show_weather\().+(?=\);)";
            Match m = Regex.Match(resText, reg);
            if (m.Success)
            {
                Response.Write(string.Format("show_weather({0});", m.Value));
            }
            else
            {
                return;
            }
        }
        catch
        {
            return;
        }
        
    }
}
