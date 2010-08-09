using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;
using AnyWeb.AW.Configs;
using System.IO;
using Studio.Web;

public partial class Admin_ColumnPictureUpload : PageAdmin
{
    ImageWaterMark wm = new ImageWaterMark();
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
            string savePath = "/Files/Articles/";
            string path = savePath + fileName + Path.GetExtension(Request.Files[0].FileName);
            ImageWaterMark wm = new ImageWaterMark();
            switch (GeneralConfigs.GetConfig().ImageWatermarkType)
            {
                case 0:
                    WebAgent.SaveFile(Request.Files[0], Server.MapPath(path), GeneralConfigs.GetConfig().ColumnImageWidth, GeneralConfigs.GetConfig().ColumnImageHeight);
                    break;
                case 1:
                    wm.SaveWaterMarkImageByText(
                        Request.Files[0],
                        fileName,
                        Server.MapPath(savePath),
                        GeneralConfigs.GetConfig().ImageWatermarkText,
                        GeneralConfigs.GetConfig().ImageWatermarkFontFamily,
                        GeneralConfigs.GetConfig().ImageWatermarkFontsize,
                        GeneralConfigs.GetConfig().ImageWatermarkFontColor,
                        GeneralConfigs.GetConfig().ImageWatermarkShadowColor,
                        wm.GetTextCSS(GeneralConfigs.GetConfig().ImageWatermarkFontCss),
                        GeneralConfigs.GetConfig().ImageWatermarkTransparency,
                        3,
                        -3,
                        GeneralConfigs.GetConfig().ImageWatermarkAngle,
                        wm.GetImageAlign(GeneralConfigs.GetConfig().ImageWatermarkPosition),
                        GeneralConfigs.GetConfig().ColumnImageWidth,
                        GeneralConfigs.GetConfig().ColumnImageHeight,
                        0,
                        0,
                        false
                        );
                    break;
                case 2:
                    wm.SaveWaterMarkImageByPic(
                        Request.Files[0],
                        fileName,
                        Server.MapPath(savePath),
                        Server.MapPath(GeneralConfigs.GetConfig().ImageWatermarkUrl),
                        GeneralConfigs.GetConfig().ImageWatermarkAngle,
                        wm.GetImageAlign(GeneralConfigs.GetConfig().ImageWatermarkPosition),
                        GeneralConfigs.GetConfig().ColumnImageWidth,
                        GeneralConfigs.GetConfig().ColumnImageHeight,
                        0,
                        0,
                        false
                        );
                    break;
                default:
                    WebAgent.SaveFile(Request.Files[0], Server.MapPath(path), GeneralConfigs.GetConfig().ColumnImageWidth, GeneralConfigs.GetConfig().ColumnImageHeight);
                    break;
            }
            
            Response.Write("0:" + path);
        }
    }
}
