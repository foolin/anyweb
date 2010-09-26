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

using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_KeyWordList : PageAdmin
{
    protected int status;

    protected override void OnPreRender(EventArgs e)
    {
        if (!int.TryParse(QS("s"), out status))
            status = -1;

        using (AW_KeyWord_dao dao = new AW_KeyWord_dao())
        {
            compRep.DataSource = dao.funcKeyWordList(status, PN1.PageSize, PN1.PageIndex);
            compRep.DataBind();
            PN1.SetPage(dao.propCount);
        }
    }

}
