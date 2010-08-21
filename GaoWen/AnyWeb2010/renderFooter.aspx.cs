using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class renderFooter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string qs = Request.QueryString["id"] + "";
        if (!string.IsNullOrEmpty(qs))
        {
            if (File.Exists(Server.MapPath(string.Format("/{0}.txt", qs))))
            {
                lit.Text = File.ReadAllText(Server.MapPath(string.Format("/{0}.txt", qs)));
            }
        }
    }
}
