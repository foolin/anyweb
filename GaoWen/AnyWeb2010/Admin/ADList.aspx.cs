using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using AnyWeb.AW_DL;

public partial class Admin_ADList : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        using (AW_AD_dao dao = new AW_AD_dao())
        {
            compRep.DataSource = dao.funcGetList();
            compRep.DataBind();
        }
    }
}
