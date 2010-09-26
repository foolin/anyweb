using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_CompanyADList : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (!string.IsNullOrEmpty(QS("type")) && !WebAgent.IsInt32(QS("type")))
            WebAgent.AlertAndBack("参数错误！");
        drpType.SelectedValue = QS("type");
        int recordCount = 0;
        compRep.DataSource = new AW_AD_dao().funcGetADList(int.Parse(drpType.SelectedValue), PN1.PageSize, PN1.PageIndex, out recordCount);
        compRep.DataBind();
        PN1.SetPage(recordCount);
    }
}
