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
using AnyWeb.AW.Configs;
using System.IO;


public partial class Admin_Setting_Image : PageAdmin
{
    public bool hasPic;
    public string picUrl;
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
        //txtBrandWdith.Text = config.BrandImageWidth.ToString();
        //txtBrandHeight.Text = config.BrandImageHeight.ToString();
        //txtGoodsHeight.Text = config.GoodsImageHeight.ToString();
        //txtGoodsWidth.Text = config.GoodsImageWidth.ToString();
        //txtGoodsListWidth.Text = config.GoodsListImageWidth.ToString();
        //txtGoodsListHeight.Text = config.GoodsListImageHeight.ToString();
        //txtMemberImageHeight.Text = config.MemberAvatorHeight.ToString();
        //txtMemberImageWidth.Text = config.MemberAvatorWidth.ToString();
        txtColumnWidth.Text = config.ColumnImageWidth.ToString();
        txtColumnHeight.Text = config.ColumnImageHeight.ToString();
        txtFlashWidth.Text = config.FlashWidth.ToString();
        txtFlashHeight.Text = config.FlashHeight.ToString();

        ListItem li;
        li = radioWaterType.Items.FindByValue(config.ImageWatermarkType.ToString());
        if (li != null) li.Selected = true;
        else radioWaterType.SelectedIndex = 0;
        li = radioWaterPosition.Items.FindByValue(config.ImageWatermarkPosition.ToString());
        if (li != null) li.Selected = true;
        else radioWaterPosition.SelectedIndex = 8;
        li = drpWaterFontFamily.Items.FindByValue(config.ImageWatermarkFontFamily);
        if (li != null) li.Selected = true;
        else drpWaterFontFamily.SelectedIndex = 8;

        if (!string.IsNullOrEmpty(config.ImageWatermarkUrl))
        {
            hasPic = true;
            picUrl = config.ImageWatermarkUrl;
        }
        else
        {
            hasPic = false;
            picUrl = "";
        }
        txtWaterFontSize.Text = config.ImageWatermarkFontsize.ToString();
        txtTransparency.Text = config.ImageWatermarkTransparency.ToString();
        txtWaterText.Text = config.ImageWatermarkText;
        txtFontColor.Text = config.ImageWatermarkFontColor;
        txtFontColor.BackColor = System.Drawing.ColorTranslator.FromHtml(config.ImageWatermarkFontColor);
        txtFontColor.ForeColor = System.Drawing.ColorTranslator.FromHtml(config.ImageWatermarkFontColor);
        txtShadowColor.Text = config.ImageWatermarkShadowColor;
        txtShadowColor.BackColor = System.Drawing.ColorTranslator.FromHtml(config.ImageWatermarkShadowColor);
        txtShadowColor.ForeColor = System.Drawing.ColorTranslator.FromHtml(config.ImageWatermarkShadowColor);
        txtAngle.Text = config.ImageWatermarkAngle.ToString();
        drpFontCss.SelectedValue = config.ImageWatermarkFontCss;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        GeneralConfigInfo config = GeneralConfigs.GetConfig();
        int number = 0;
        string pics = Request.Form["pics"] + "";
        //config.BrandImageWidth = int.Parse(txtBrandWdith.Text);
        //config.BrandImageHeight = int.Parse(txtBrandHeight.Text);
        //config.GoodsImageHeight = int.Parse(txtGoodsHeight.Text);
        //config.GoodsImageWidth = int.Parse(txtGoodsWidth.Text);
        //config.GoodsListImageWidth = int.Parse(txtGoodsListWidth.Text);
        //config.GoodsListImageHeight = int.Parse(txtGoodsListHeight.Text);
        //config.MemberAvatorHeight = int.Parse(txtMemberImageHeight.Text);
        //config.MemberAvatorWidth = int.Parse(txtMemberImageWidth.Text);
        if (int.TryParse(txtColumnHeight.Text, out number))
        {
            config.ColumnImageHeight = number;
        }
        if (int.TryParse(txtColumnWidth.Text, out number))
        {
            config.ColumnImageWidth = number;
        }
        if (int.TryParse(txtFlashWidth.Text, out number))
        {
            config.FlashWidth = number;
        }
        if (int.TryParse(txtFlashHeight.Text, out number))
        {
            config.FlashHeight = number;
        }
        config.ImageWatermarkType = int.Parse(radioWaterType.SelectedValue);
        config.ImageWatermarkPosition = int.Parse(radioWaterPosition.SelectedValue);
        if (int.TryParse(txtWaterFontSize.Text, out number))
        {
            config.ImageWatermarkFontsize = number;
        }
        if (int.TryParse(txtTransparency.Text, out number))
        {
            config.ImageWatermarkTransparency = number;
        }
        config.ImageWatermarkText = txtWaterText.Text.Trim();

        config.ImageWatermarkUrl = pics;

        if (config.ImageWatermarkType == 1 && config.ImageWatermarkText == "")
            config.ImageWatermarkType = 0;
        if (config.ImageWatermarkType == 2 && config.ImageWatermarkUrl == "")
            config.ImageWatermarkType = 0;

        config.SetupConfigImage = true;
        config.ImageWatermarkFontColor = txtFontColor.Text;
        config.ImageWatermarkShadowColor = txtShadowColor.Text;
        config.ImageWatermarkAngle = int.Parse(txtAngle.Text);
        config.ImageWatermarkFontCss = drpFontCss.SelectedValue;

        GeneralConfigs.Serialiaze(GeneralConfigs.GetConfig(), DefaultConfigFileManager.ConfigFilePath);
        WebAgent.SuccAndGo("保存成功", "Setting_Image.aspx");
    }
}
