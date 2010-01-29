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

public partial class Admin_Setting_Register : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        GeneralConfigInfo config = GeneralConfigs.GetConfig();
        boxEnable.Checked = config.RegEnable;
        boxMobileReg.Checked = config.RegMobile;
        txtAgreement.Text = config.RegAgreement;
        txtEmailBlocked.Text = config.RegEmailBlocked;
        txtEmailEnable.Text = config.RegEmailEnabled;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        GeneralConfigInfo config = GeneralConfigs.GetConfig();
        config.RegEnable = boxEnable.Checked;
        config.RegMobile = boxMobileReg.Checked;
        config.RegAgreement = txtAgreement.Text;
        config.RegEmailBlocked = txtEmailBlocked.Text;
        config.RegEmailEnabled = txtEmailEnable.Text;

        config.SetupConfigMember = true;

        GeneralConfigs.Serialiaze(GeneralConfigs.GetConfig(), DefaultConfigFileManager.ConfigFilePath);
        WebAgent.SuccAndGo("保存成功", "Setting_Register.aspx");
    }
}
