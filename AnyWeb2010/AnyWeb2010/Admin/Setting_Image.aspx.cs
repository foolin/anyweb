using System;
using System.Drawing;
using System.Drawing.Text;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Studio.Web;
using AnyWeb.AW_DL;
using AnyWeb.AW_DL;
using AnyWeb.AW.Configs;
using System.IO;


public partial class Admin_Setting_Image : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        foreach (ListItem item in radioWaterPosition.Items)
            item.Attributes["class"] = "checkbox";
        foreach (ListItem item in radioWaterType.Items)
            item.Attributes["class"] = "checkbox";
        

        drpWaterFontFamily.Items.Clear();
        InstalledFontCollection fonts = new InstalledFontCollection();
        foreach (FontFamily family in fonts.Families)
        {
            drpWaterFontFamily.Items.Add(new ListItem(family.Name, family.Name));
        }

        GeneralConfigInfo config = GeneralConfigs.GetConfig();
        txtBrandWdith.Text = config.BrandImageWidth.ToString();
        txtBrandHeight.Text = config.BrandImageHeight.ToString();
        txtGoodsHeight.Text = config.GoodsImageHeight.ToString();
        txtGoodsWidth.Text = config.GoodsImageWidth.ToString();
        txtGoodsListWidth.Text = config.GoodsListImageWidth.ToString();
        txtGoodsListHeight.Text = config.GoodsListImageHeight.ToString();
        txtMemberImageHeight.Text = config.MemberAvatorHeight.ToString();
        txtMemberImageWidth.Text = config.MemberAvatorWidth.ToString();
        txtFlashWidth.Text = config.FlashWidth.ToString();
        txtFlashHeight.Text = config.FlashHeight.ToString();

        ListItem li;
        li = radioWaterType.Items.FindByValue(config.GoodsImageWatermarkType.ToString());
        if (li != null) li.Selected = true;
        else radioWaterType.SelectedIndex = 0;
        li = radioWaterPosition.Items.FindByValue(config.GoodsImageWatermarkPosition.ToString());
        if (li != null) li.Selected = true;
        else radioWaterPosition.SelectedIndex = 8;
        li = drpWaterFontFamily.Items.FindByValue(config.GoodsImageWatermarkFontFamily);
        if (li != null) li.Selected = true;
        else drpWaterFontFamily.SelectedIndex = 8;

        imgWater.ImageUrl = config.GoodsImageWatermarkUrl;
        txtWaterFontSize.Text = config.GoodsImageWatermarkFontsize.ToString();
        txtTransparency.Text = config.GoodsImageWatermarkTransparency.ToString();
        txtWaterText.Text = config.GoodsImageWatermarkText;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        GeneralConfigInfo config = GeneralConfigs.GetConfig();

        config.BrandImageWidth = int.Parse(txtBrandWdith.Text);
        config.BrandImageHeight = int.Parse(txtBrandHeight.Text);
        config.GoodsImageHeight = int.Parse(txtGoodsHeight.Text);
        config.GoodsImageWidth = int.Parse(txtGoodsWidth.Text);
        config.GoodsListImageWidth = int.Parse(txtGoodsListWidth.Text);
        config.GoodsListImageHeight = int.Parse(txtGoodsListHeight.Text);
        config.MemberAvatorHeight = int.Parse(txtMemberImageHeight.Text);
        config.MemberAvatorWidth = int.Parse(txtMemberImageWidth.Text);
        config.FlashWidth = int.Parse(txtFlashWidth.Text);
        config.FlashHeight = int.Parse(txtFlashHeight.Text);
        config.GoodsImageWatermarkType = int.Parse(radioWaterType.SelectedValue);
        config.GoodsImageWatermarkPosition = int.Parse(radioWaterPosition.SelectedValue);

        config.GoodsImageWatermarkFontsize = int.Parse(txtWaterFontSize.Text);
        config.GoodsImageWatermarkTransparency = int.Parse(txtTransparency.Text);
        config.GoodsImageWatermarkText = txtWaterText.Text.Trim();


        if (fileWater.PostedFile.ContentLength > 0)
        {
            if (!fileWater.PostedFile.ContentType.ToLower().Contains("image"))
                WebAgent.AlertAndBack("您上传的文件不是图片格式");

            config.GoodsImageWatermarkUrl = "/Files/watermark." + Path.GetExtension(fileWater.PostedFile.FileName);
            fileWater.SaveAs(Server.MapPath(config.GoodsImageWatermarkUrl));
        }

        if (config.GoodsImageWatermarkType == 1 && config.GoodsImageWatermarkText == "")
            config.GoodsImageWatermarkType = 0;
        if (config.GoodsImageWatermarkType == 2 && config.GoodsImageWatermarkUrl == "")
            config.GoodsImageWatermarkType = 0;

        config.SetupConfigImage = true;

        GeneralConfigs.Serialiaze(GeneralConfigs.GetConfig(), DefaultConfigFileManager.ConfigFilePath);
        WebAgent.SuccAndGo("保存成功", "Setting_Image.aspx");
    }
}
