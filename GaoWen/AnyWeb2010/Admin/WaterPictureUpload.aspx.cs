using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;
using System.IO;
using Studio.Web;

public partial class Admin_WaterPictureUpload : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
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
            string path = "/Files/Water/" + DL_helper.funcGetTicks().ToString() + Path.GetExtension(Request.Files[0].FileName);
            Request.Files[0].SaveAs(Server.MapPath(path));
            Response.Write("0:" + path);
        }
    }
}
