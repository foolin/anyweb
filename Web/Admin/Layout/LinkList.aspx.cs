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

public partial class Layout_LinkList : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnPreRender(EventArgs e)
    {
        int RecordCount = 0;
        drpLink.DataSource = new LinkAgent().GetLinkList(PN1.PageSize, PN1.PageIndex, out RecordCount);
        drpLink.DataBind();
        PN1.SetPage(RecordCount);
    }
}
