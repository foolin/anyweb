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

public partial class Admin_HelpTypeList : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        using (AW_Help_Type_dao dao = new AW_Help_Type_dao())
        {
            compRep.DataSource = dao.funcGetHelpTypes();
            compRep.DataBind();
        }

    }
}
