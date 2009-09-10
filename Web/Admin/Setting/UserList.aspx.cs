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

public partial class Setting_UserList : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        repUser.DataSource = new UserAgent().GetUserList(0);
        repUser.DataBind();
    }
}
