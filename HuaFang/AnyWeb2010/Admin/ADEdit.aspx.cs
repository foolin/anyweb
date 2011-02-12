using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using AnyWell.AW_DL;
using Studio.Web;
using System.IO;
using AnyWell.Configs;

public partial class Admin_ADEdit : PageAdmin
{

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        AW_AD_bean bean = AW_AD_bean.funcGetByID(int.Parse(QS("id")));
        txtName.Text = bean.fdAdName;
        txtUrl.Text = bean.fdAdLink;
        imgPicture.ImageUrl = bean.fdAdPic;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (fileUpload.PostedFile.ContentLength > 0 && !fileUpload.PostedFile.ContentType.ToLower().Contains("image"))
            WebAgent.AlertAndBack("您上传的文件不是图片格式");


        using (AW_AD_dao dao = new AW_AD_dao())
        {
            AW_AD_bean bean = AW_AD_bean.funcGetByID(int.Parse(QS("id")));
            bean.fdAdName = txtName.Text;
            bean.fdAdLink = txtUrl.Text.Trim().ToLower();
            if (!bean.fdAdLink.StartsWith("http://"))
            {
                bean.fdAdLink = "http://" + bean.fdAdLink;
            }
            if (fileUpload.PostedFile.ContentLength > 0)
            {
                string fileName = DL_helper.funcGetTicks().ToString();
                string savePath = "/Files/AD/";
                if (!Directory.Exists(Server.MapPath(savePath)))
                {
                    Directory.CreateDirectory(Server.MapPath(savePath));
                }
                string path = savePath + fileName + Path.GetExtension(fileUpload.PostedFile.FileName);
                uploadPic(fileName, savePath, path);
                bean.fdAdPic = path;
            }
            dao.funcUpdate(bean);
            WebAgent.SuccAndGo("修改成功", "ADList.aspx");
        }
    }

    protected void uploadPic(string fileName,string savePath,string path)
    {
        int width, heigth;
        if (int.Parse(QS("id")) == 1)
        {
            width = GeneralConfigs.GetConfig().BigADImageWidth;
            heigth = GeneralConfigs.GetConfig().BigADImageHeight;
        }
        else
        {
            width = GeneralConfigs.GetConfig().SmallADImageWidth;
            heigth = GeneralConfigs.GetConfig().SmallADImageHeight;
        }
        ImageWaterMark wm = new ImageWaterMark();
        switch (GeneralConfigs.GetConfig().ImageWatermarkType)
        {
            case 0:
                WebAgent.SaveFile(fileUpload.PostedFile, Server.MapPath(path), width, heigth);
                break;
            case 1:
                wm.SaveWaterMarkImageByText(
                    fileUpload.PostedFile,
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
                    width,
                    heigth,
                    0,
                    0,
                    false
                    );
                break;
            case 2:
                wm.SaveWaterMarkImageByPic(
                    fileUpload.PostedFile,
                    fileName,
                    Server.MapPath(savePath),
                    Server.MapPath(GeneralConfigs.GetConfig().ImageWatermarkUrl),
                    GeneralConfigs.GetConfig().ImageWatermarkAngle,
                    wm.GetImageAlign(GeneralConfigs.GetConfig().ImageWatermarkPosition),
                    width,
                    heigth,
                    0,
                    0,
                    false
                    );
                break;
            default:
                WebAgent.SaveFile(fileUpload.PostedFile, Server.MapPath(path), width, heigth);
                break;
        }
    }

}
