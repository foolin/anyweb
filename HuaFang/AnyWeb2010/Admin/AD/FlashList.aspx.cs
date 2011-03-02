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
using AnyWell.AW_DL;

public partial class Admin_FlashList : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        using (AW_FlaAW_dao dao = new AW_FlaAW_dao())
        {
            compRep.DataSource = dao.funcGetFlashes();
            compRep.DataBind();
        }
    }
}
