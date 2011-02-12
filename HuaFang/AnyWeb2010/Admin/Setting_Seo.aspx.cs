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
using AnyWell.AW_DL;
using AnyWell.Configs;

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
        this.AddLog(EventType.Update, "修改搜索引擎优化", "修改搜索引擎优化");
        WebAgent.SuccAndGo("保存成功", "Setting_Seo.aspx");
    }
}
