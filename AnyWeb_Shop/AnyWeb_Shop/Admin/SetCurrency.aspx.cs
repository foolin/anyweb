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
using Common.Agent;
using Common.Common;
using Studio.Web;
using Admin.Framework;

public partial class SetCurrency :AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnPreRender(EventArgs e)
    {
        ArrayList list = (new CurrencyAgent()).GetCurrencyList();

        Currency c = new Currency();
        c.ID = 0;
        c.Name = "全部";
        list.Insert(0,c);

        this.ddlCurrency.DataSource = list;
        this.ddlCurrency.DataBind();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if ((new CurrencyAgent()).InsertSetCurrency(int.Parse(ddlCurrency.SelectedValue)) > 0)
        {
            WebAgent.SuccAndGo("添加成功!", ViewState["BACK"].ToString());
        }
    }
}
