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

using AnyWeb.AW_DL;

public partial class Admin_HelpList : ShopAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        compType.DataSource = new AW_Help_Type_dao().funcGetHelpTypes();
        compType.DataBind();
        compType.SelectedValue = QS("tid");

        int typeId = 0;
        int.TryParse(compType.SelectedValue, out typeId);
        compRep.DataSource = new AW_Help_dao().funcHelpSearch(typeId);
        compRep.DataBind();
    }

}
