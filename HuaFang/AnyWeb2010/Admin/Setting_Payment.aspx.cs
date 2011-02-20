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

public partial class Admin_Setting_Payment : System.Web.UI.Page
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        GeneralConfigInfo config = GeneralConfigs.GetConfig();

        //初始化支付宝设置
        this.cbWay1.Checked = config.IsAliPay;
        this.txtWay1_acc.Text = config.AliPay_Acc;
        this.txtWay1_partnerID.Text = config.AliPay_PartnerID;
        this.txtWay1_key.Text = config.AliPay_Key;
        this.drpWay1_service.SelectedValue = config.AliPay_Service;

        //初始化网银在线设置
        this.cbWay2.Checked = config.IsNetBank;
        this.txtWay2_id.Text = config.NetBank_ID;
        this.txtWay2_key.Text = config.NetBank_Key;

        //初始化银行转帐设置
        this.cbWay3.Checked = config.IsBank;
        this.txtWay3_des.Text = config.Bank_Des;

        //初始化货到付款设置
        this.cbWay4.Checked = config.IsFacePay;
        this.txtWay4_des.Text = config.FacePay_Des;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        GeneralConfigInfo config = GeneralConfigs.GetConfig();

        //选择支付宝
        config.IsAliPay = this.cbWay1.Checked;
        config.AliPay_Acc = this.txtWay1_acc.Text;
        config.AliPay_PartnerID = this.txtWay1_partnerID.Text;
        config.AliPay_Key = this.txtWay1_key.Text;
        config.AliPay_Service = this.drpWay1_service.SelectedValue;

        //选择网银在线
        config.IsNetBank = this.cbWay2.Checked;
        config.NetBank_ID = this.txtWay2_id.Text;
        config.NetBank_Key = this.txtWay2_key.Text;

        //选择银行转帐
        config.IsBank = this.cbWay3.Checked;
        config.Bank_Des = this.txtWay3_des.Text;

        //选择货到付款
        config.IsFacePay = this.cbWay4.Checked;
        config.FacePay_Des = this.txtWay4_des.Text;

        config.SetupConfigPayment = true;

        GeneralConfigs.Serialiaze(GeneralConfigs.GetConfig(), DefaultConfigFileManager.ConfigFilePath);
        WebAgent.SuccAndGo("保存成功", "Setting_Payment.aspx");
    }
}
