using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;

public partial class Control_rightclpt : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        AW_Column_bean column = (AW_Column_bean)Context.Items["COLUMN"];
        repRelation.DataSource = new AW_Relation_dao().funcGetRelationList(column.fdColuID);    //获取关联文章
        repRelation.DataBind();
    }
}
