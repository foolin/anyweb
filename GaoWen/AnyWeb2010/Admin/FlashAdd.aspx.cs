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

using AnyWeb.AW_DL;
using System.IO;
using Studio.Web;
using AnyWeb.AW.Configs;

public partial class Admin_FlashAdd : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        if (new AW_FlaAW_dao().funcGetFlashCount() >= 5) {
            WebAgent.AlertAndBack("幻灯图片数最多不能超过五张");
        }    
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (fileUpload.PostedFile.ContentLength == 0)
            WebAgent.AlertAndBack("请上传图片文件");

        if (!fileUpload.PostedFile.ContentType.ToLower().Contains("image"))
            WebAgent.AlertAndBack("您上次的文件不是图片格式");

        string fileName = DL_helper.funcGetTicks().ToString();
        string savePath = "/Files/Flash/";
        string path = savePath + fileName + Path.GetExtension(fileUpload.PostedFile.FileName);

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

        using (AW_FlaAW_dao dao = new AW_FlaAW_dao())
        {
            AW_FlaAW_bean bean = new AW_FlaAW_bean();
            bean.fdFlasName = txtName.Text;
            if (txtUrl.Text.ToLower().StartsWith("http://"))
            {
                bean.fdFlasUrl = txtUrl.Text;
            }
            else
            {
                bean.fdFlasUrl = "http://" + txtUrl.Text;
            }
            bean.fdFlasPicture = path;
            bean.fdFlasID = dao.funcNewID();
            bean.fdFlasSort = bean.fdFlasID;
            int record = dao.funcInsert(bean);
            if (record > 0)
            {
                Studio.Web.WebAgent.SuccAndGo("添加成功", "FlashList.aspx");
            }
        }
    }
}
