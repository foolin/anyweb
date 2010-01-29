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
using Studio.Web;
using AnyWeb.AW.Configs;

public partial class Admin_KeyWordList : PageAdmin
{
    protected int status;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!int.TryParse(QS("s"), out status))
            status = -1;
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        using (AW_KeyWord_dao dao = new AW_KeyWord_dao())
        {
            repKeyWord.DataSource = dao.funcKeyWordList(status, PN1.PageSize, PN1.PageIndex);
            repKeyWord.DataBind();
            PN1.SetPage(dao.propCount);
        }
    }

}
