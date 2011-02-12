using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Control_menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        List<AW_Column_bean> columnList = new AW_Column_dao().funcGetIndexColumns();
        repColumn.DataSource = columnList;
        repColumn.DataBind();
        repParent.DataSource = columnList;
        repParent.DataBind();
    }
}
