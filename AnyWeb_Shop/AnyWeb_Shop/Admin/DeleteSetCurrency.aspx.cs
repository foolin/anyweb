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

using Admin.Framework;
using Studio.Web;
using Common.Agent;

public partial class DeleteSetCurrency :AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WebAgent.IsInt32(QS("sid")))
        {
            if ((new CurrencyAgent()).DeleteSetCurrency(int.Parse(QS("sid"))) > 0)
            {
                WebAgent.SuccAndGo("删除成功!", ViewState["BACK"].ToString());
            }
            else
            {
                WebAgent.FailAndGo("删除失败,请重试!", ViewState["BACK"].ToString());
            }
        }
        else
            WebAgent.FailAndGo("参数错误");
    }
}
