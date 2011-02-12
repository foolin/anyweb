using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Admin_ColumnPictureDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        string path = Request.QueryString["path"] + "";
        if (path != "")
        {
            if (path.Contains(":")) path = path.Substring(path.IndexOf(":") + 1);
            if (File.Exists(Server.MapPath(path)))
                File.Delete(Server.MapPath(path));
            if (File.Exists(Server.MapPath(path.Replace("S_", ""))))
                File.Delete(Server.MapPath(path.Replace("S_", "")));
        }

    }
}
