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
using Studio.Web;
using AnyWeb.AW_DL;
using AnyWeb.AW_DL;
using AnyWeb.AW.Configs;

public partial class Admin_Setting_Seo : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        GeneralConfigInfo config = GeneralConfigs.GetConfig();
        txtMetaDescription.Text = config.MetaDescription;
        txtMetaKeywords.Text = config.MetaKeywords;
        txtTitleExt.Text = config.TitleExtension;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        GeneralConfigInfo config = GeneralConfigs.GetConfig();
        config.TitleExtension = txtTitleExt.Text;
        config.MetaDescription = txtMetaDescription.Text;
        config.MetaKeywords = txtMetaKeywords.Text;

        config.SetupConfigSeo = true;

        GeneralConfigs.Serialiaze(GeneralConfigs.GetConfig(), DefaultConfigFileManager.ConfigFilePath);
        WebAgent.SuccAndGo("保存成功", "Setting_Seo.aspx");
    }
}
