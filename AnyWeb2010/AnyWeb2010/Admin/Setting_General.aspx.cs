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

public partial class Admin_Setting_General : ShopAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        GeneralConfigInfo config = GeneralConfigs.GetConfig();
        txtShopName.Text = config.ShopName;
        txtCompanyName.Text = config.CompanyName;
        txtAddress.Text = config.Address;
        txtEmail.Text = config.Email;
        txtFax.Text = config.Fax;
        txtIcp.Text = config.Icp;
        txtMobile.Text = config.Mobile;
        txtMsn.Text = config.MSN;
        txtPostcode.Text = config.Postcode;
        txtQQ.Text = config.QQ;
        txtTel.Text = config.Tel;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        GeneralConfigInfo config = GeneralConfigs.GetConfig();
        config.ShopName = txtShopName.Text;
        config.CompanyName = txtCompanyName.Text;
        config.Address = txtAddress.Text;
        config.Email = txtEmail.Text;
        config.Fax = txtFax.Text;
        config.Icp = txtIcp.Text;
        config.Mobile = txtMobile.Text;
        config.MSN = txtMsn.Text;
        config.Postcode = txtPostcode.Text;
        config.QQ = txtQQ.Text;
        config.Tel = txtTel.Text;
        config.SetupConfigGeneral = true;

        GeneralConfigs.Serialiaze(GeneralConfigs.GetConfig(), DefaultConfigFileManager.ConfigFilePath);
        WebAgent.SuccAndGo("保存成功", "Setting_General.aspx");
    }
}
