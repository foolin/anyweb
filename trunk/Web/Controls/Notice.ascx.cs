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

public partial class Controls_Notice : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        repNotice.DataSource = new NoticeAgent().GetNoticeList();
        repNotice.DataBind();
    }
}
