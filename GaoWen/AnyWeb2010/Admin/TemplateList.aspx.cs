using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;

public partial class Admin_TemplateList : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        drpType.SelectedValue = QS("type");
        int record = 0;
        repTemplate.DataSource = new AW_Template_dao().funcGetTempateList(int.Parse(drpType.SelectedValue), PN1.PageIndex, PN1.PageSize, out record);
        repTemplate.DataBind();
        PN1.SetPage(record);        
    }
}
