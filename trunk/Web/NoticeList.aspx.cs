using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AnyWeb_DL;

public partial class NoticeList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        this.Title = "广州市天河区沙河供销合作社 - 通知公告";
        this.litTitle.Text = "通知公告";
        int Record = 0;
        repNotice.DataSource = new NoticeAgent().GetNoticeList(PN1.PageSize, PN1.PageIndex, out Record);
        repNotice.DataBind();
        PN1.SetPage(Record);
    }
}
