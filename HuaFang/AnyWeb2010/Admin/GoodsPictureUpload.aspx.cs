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
using AnyWell.AW;
using AnyWell.AW_DL;
using AnyWell.Configs;
using Studio.Web;

public partial class Admin_GoodsPictureUpload : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Files.Count == 0)
        {
            Response.Write("1:请上传文件");
        }
        else if (Request.Files[0].ContentLength == 0)
        {
            Response.Write("2:请上传文件");
        }
        else if (!Request.Files[0].ContentType.Contains("image"))
        {
            Response.Write("3:您传的文件不是图片格式");
        }
        else
        {
            string path = "/Files/Goods/S_" + DL_helper.funcGetTicks().ToString() + Path.GetExtension(Request.Files[0].FileName);
            WebAgent.SaveFile( Request.Files[ 0 ], Server.MapPath( path ), 0, 0 );
            Response.Write("0:"+ path);
        }
    }
}
