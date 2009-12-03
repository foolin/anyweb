using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common.Common;
using Common.Agent;
using Admin.Framework;

public partial class SetCommendAgio :AdminBase
{
    private static int _atype;
    Agio a;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.rdnull.Attributes.Add("onclick", "javascript:GetAgioMode(0)");
        this.rd1.Attributes.Add("onclick", "javascript:GetAgioMode(1)");
        this.rd2.Attributes.Add("onclick", "javascript:GetAgioMode(2)");

        a = (new AgioAgent()).GetAgio(0,ShopInfo.ID);
    }

    protected override void OnPreRender(EventArgs e)
    {
        if (a == null)
        {
            return;
        }

        _atype = a.Type;

        if (a.Type == 0)
        {
            rdnull.Checked = true;
        }
        if (a.Type == 1)
        {
            rd1.Checked = true;
            this.txtAgio.Text = a.Agiomoney.ToString();
            this.form1.Attributes.Add("onload", "javascript:GetAgioMode(1)");
        }
        if (a.Type == 2)
        {
            rd2.Checked = true;
            this.txtMoney.Text = a.Money.ToString();
            this.txtAgio.Text = a.Agiomoney.ToString();
            this.form1.Attributes.Add("onload", "javascript:GetAgioMode(2)");
        }
    }
    public int Atype
    {
        get { return _atype; }
        set { _atype = value; }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (a == null)
        {
            a = new Agio();

            a.ID = 0;
        }
        a.Money = double.Parse(this.txtMoney.Text == "" ? "0" : this.txtMoney.Text);

        if (rdnull.Checked)
            a.Type = 0;
        if (rd1.Checked)
            a.Type = 1;
        if (rd2.Checked)
            a.Type = 2;

        a.Category = 0;
        a.Agiomoney = Convert.ToDouble(txtAgio.Text == "" ? "0" : this.txtAgio.Text);

        if (txtAgio.Text == "")
        {
            a.Agiomoney = 0;
        }
        else 
        {

            if (Convert.ToDouble(txtAgio.Text) > 10)
            {
                Studio.Web.WebAgent.FailAndGo("折扣价格必须小于10", "SetCommendAgio.aspx");
                return;
            } 
            
            a.Agiomoney = Convert.ToDouble(txtAgio.Text);
        }

        if ((new AgioAgent()).SetAgio(a) > 0)
        {
            AddLog(EventID.Update, "成功设置推荐折扣", "成功设置推荐折扣");
            Studio.Web.WebAgent.SuccAndGo("设置成功!", "SetCommendAgio.aspx");
        }
        else
        {
            AddLog(EventID.Update, "设置推荐折扣失败", "设置推荐折扣失败");
            Studio.Web.WebAgent.FailAndGo("设置失败,请重试","SetCommendAgio.aspx");
        }
    }
}
