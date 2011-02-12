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
using Studio.Web;
using AnyWell.Configs;

public partial class Admin_KeyWordList : PageAdmin
{
    protected int status;

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected override void OnPreRender(EventArgs e)
    {
        if (!int.TryParse(QS("s"), out status))
            status = -1;
        using (AW_KeyWord_dao dao = new AW_KeyWord_dao())
        {
            repKeyWord.DataSource = dao.funcKeyWordList(status, PN1.PageSize, PN1.PageIndex);
            repKeyWord.DataBind();
            PN1.SetPage(dao.propCount);
        }
    }

}
