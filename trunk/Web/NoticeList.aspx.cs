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
using AnyWeb.AnyWeb_DL;

public partial class NoticeList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        int Record = 0;
        repNotice.DataSource = new NoticeAgent().GetNoticeList(PN1.PageSize, PN1.PageIndex, out Record);
        repNotice.DataBind();
        PN1.SetPage(Record);
    }
}
