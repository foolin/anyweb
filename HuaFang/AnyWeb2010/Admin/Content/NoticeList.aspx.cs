using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_NoticeList : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        int recordCount = 0;
        compRep.DataSource = new AW_Notice_dao().funcGetNoticeList(PN1.PageSize, PN1.PageIndex, out recordCount);
        compRep.DataBind();
        PN1.SetPage(recordCount);
    }
}
