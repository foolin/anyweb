using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;

public partial class Control_columntip : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        List<AW_Column_bean> list = new List<AW_Column_bean>();
        AW_Column_bean column = (AW_Column_bean)Context.Items["COLUMN"];
        if (column.fdColuParentID == 0)
        {
            list.Add(column);
        }
        else
        {
            list.Add(column.Parent);
            list.Add(column);
        }
        repTip.DataSource = list;
        repTip.DataBind();
    }
}
