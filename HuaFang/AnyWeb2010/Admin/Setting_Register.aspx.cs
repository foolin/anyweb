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

public partial class Admin_Setting_Register : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        GeneralConfigInfo config = GeneralConfigs.GetConfig();
        boxEnable.Checked = config.RegEnable;
        txtAgreement.Text = config.RegAgreement;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        GeneralConfigInfo config = GeneralConfigs.GetConfig();
        config.RegEnable = boxEnable.Checked;
        config.RegAgreement = txtAgreement.Text;

        config.SetupConfigMember = true;

        GeneralConfigs.Serialiaze(GeneralConfigs.GetConfig(), DefaultConfigFileManager.ConfigFilePath);
        this.AddLog(EventType.Update, "修改用户注册设置", "修改用户注册设置");
        WebAgent.SuccAndGo("保存成功", "Setting_Register.aspx");
    }
}
