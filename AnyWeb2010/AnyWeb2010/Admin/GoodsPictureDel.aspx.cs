using System;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using AnyWeb.AW;
using AnyWeb.AW_DL;
using AnyWeb.AW.Configs;

public partial class Admin_GoodsPictureDel : ShopAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string path = QS("path");
        if (path != "")
        {
            if( path.Contains(":")) path = path.Substring(path.IndexOf(":")+1);
            if (File.Exists(Server.MapPath(path)))
                File.Delete(Server.MapPath(path));
            if (File.Exists(Server.MapPath(path.Replace("S_",""))))
                File.Delete(Server.MapPath(path.Replace("S_", "")));
        }

    }
}
