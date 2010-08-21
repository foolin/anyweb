using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AnyWeb_DL;
using Studio.Web;

public partial class LinkList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "广州市天河区沙河供销合作社 - 友情链接";
    }

    protected override void OnPreRender(EventArgs e)
    {
        if (Request.QueryString["id"] + "" != ""&&WebAgent.IsInt32(Request.QueryString["id"]))
        {
            drpCate.SelectedValue = Request.QueryString["id"];
        }
        int record = 0;
        repLink.DataSource = new LinkAgent().GetLinkListPage(int.Parse(drpCate.SelectedValue), PN1.PageSize, PN1.PageIndex, out record);
        repLink.DataBind();
        PN1.SetPage(record);
    }
}
