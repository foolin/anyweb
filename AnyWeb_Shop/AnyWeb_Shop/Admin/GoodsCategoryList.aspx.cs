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

public partial class GoodsCategoryList : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ods1_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.OutputParameters["recordCount"] != null)
        {
            int record = (int)e.OutputParameters["recordCount"];
            PN1.SetPage(record);

        }
    }

    public void repCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        Category c = (Category)e.Item.DataItem;
        Repeater rep2 = (Repeater)e.Item.FindControl("rep2");
        if (rep2 != null)
        {
            using (CategoryAgent ca = new CategoryAgent())
            {
                rep2.DataSource = ca.GetCategoryChildren(c.ID);
                rep2.DataBind();
            }

        }
    }
}
