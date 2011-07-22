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

public partial class Admin_FlashEdit : PageAdmin
{

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        AW_Flash_bean flash = AW_Flash_bean.funcGetByID( int.Parse( QS( "id" ) ) );
        txtName.Text = flash.fdFlasName;
        txtUrl.Text = flash.fdFlasUrl;
        imgPicture.ImageUrl = flash.fdFlasPicture;
        txtDesc.Text = flash.fdFlashDesc;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (fileUpload.PostedFile.ContentLength > 0 && !fileUpload.PostedFile.ContentType.ToLower().Contains("image"))
            WebAgent.AlertAndBack("您上传的文件不是图片格式");

        if( txtDesc.Text.Length > 200 )
            WebAgent.AlertAndBack( "图片描述不能超出200字" );

        using( AW_Flash_dao dao = new AW_Flash_dao() )
        {
            AW_Flash_bean bean = AW_Flash_bean.funcGetByID( int.Parse( QS( "id" ) ) );
            bean.fdFlasName = txtName.Text;
            bean.fdFlasUrl = txtUrl.Text;
            bean.fdFlashDesc = txtDesc.Text;
            if (fileUpload.PostedFile.ContentLength > 0)
            {
                string fileName = DL_helper.funcGetTicks().ToString();
                string savePath = "/Files/Flash/";
                if( !Directory.Exists( Server.MapPath( savePath ) ) )
                {
                    Directory.CreateDirectory( Server.MapPath( savePath ) );
                }
                string path = savePath + fileName + Path.GetExtension(fileUpload.PostedFile.FileName);
                uploadPic(fileName, savePath, path);
                bean.fdFlasPicture = path;
            }
            dao.funcUpdate(bean);
            WebAgent.SuccAndGo("修改成功", "FlashList.aspx");
        }
    }

    protected void uploadPic(string fileName,string savePath,string path)
    {
        ImageWaterMark wm = new ImageWaterMark();
        switch (GeneralConfigs.GetConfig().ImageWatermarkType)
        {
            case 0:
                WebAgent.SaveFile(fileUpload.PostedFile, Server.MapPath(path), GeneralConfigs.GetConfig().FlashWidth, GeneralConfigs.GetConfig().FlashHeight);
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
                    GeneralConfigs.GetConfig().FlashWidth,
                    GeneralConfigs.GetConfig().FlashHeight,
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
                    GeneralConfigs.GetConfig().FlashWidth,
                    GeneralConfigs.GetConfig().FlashHeight,
                    0,
                    0,
                    false
                    );
                break;
            default:
                WebAgent.SaveFile(fileUpload.PostedFile, Server.MapPath(path), GeneralConfigs.GetConfig().FlashWidth, GeneralConfigs.GetConfig().FlashHeight);
                break;
        }
    }

}
