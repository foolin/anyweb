using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Control_innermenu : System.Web.UI.UserControl
{
    public int columnID;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        AW_Column_bean column = (AW_Column_bean)Context.Items["COLUMN"];
        if (column != null)
        {
            if (column.fdColuParentID == 0)
            {
                columnID = column.fdColuID;
            }
            else
            {
                columnID = column.Parent.fdColuID;
            }
        }
        List<AW_Column_bean> columnList = new AW_Column_dao().funcGetIndexColumns();
        repColumn.DataSource = columnList;
        repColumn.DataBind();
        repParent.DataSource = columnList;
        repParent.DataBind();
    }
}
