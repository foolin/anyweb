using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using System.IO;
using Studio.Web;

public partial class Admin_ADPicUpload : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

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
            string fileName = DL_helper.funcGetTicks().ToString();
            string savePath = "/Files/AD/";
            if (!Directory.Exists(Server.MapPath(savePath)))
            {
                Directory.CreateDirectory(Server.MapPath(savePath));
            }
            string path = savePath + fileName + Path.GetExtension(Request.Files[0].FileName);
            WebAgent.SaveFile(Request.Files[0], Server.MapPath(path), 0, 0);
            Response.Write("0:" + path);
        }
    }
}
