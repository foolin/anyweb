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
using Admin.Framework;
using Studio.Web;
using Common.Common;

public partial class GoodsStat :AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ArrayList list = (new CategoryAgent()).GetCategoryNameByType();
            Category c = new Category();
            c.ID = 0;
            c.Name = "所有类别";
            list.Insert(0, c);
            ddlCategory.DataSource = list;
            ddlCategory.DataBind();
        }

    }

    protected override void OnPreRender(EventArgs e)
    {
        int recount = 0;
        int categoryid = 0;

        if (WebAgent.IsInt32(QS("categoryid")))
        {
            ddlCategory.SelectedValue = QS("categoryid"); 
            categoryid = int.Parse(QS("categoryid"));
        }

        this.repGoods.DataSource = (new GoodsAgent()).GetClickStat(categoryid, PN1.PageSize, PN1.PageIndex, out recount);
        this.repGoods.DataBind();
        PN1.SetPage(recount);
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        Response.Redirect("GoodsStat.aspx?categoryid=" + ddlCategory.SelectedValue);
      
    }
}
