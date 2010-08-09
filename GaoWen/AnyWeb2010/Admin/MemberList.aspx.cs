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

public partial class Admin_MemberList : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        compName.Text = QS("name");
        compStatus.SelectedValue = QS("status");

        DateTime timeFrom = DateTime.MinValue, timeTo = DateTime.MinValue;

        if (DateTime.TryParse(QS("from"), out timeFrom))
            compFrom.Text = timeFrom.ToShortDateString();
        if (DateTime.TryParse(QS("to"), out timeTo))
            compTo.Text = timeTo.ToShortDateString();

        using (AW_Member_dao dao = new AW_Member_dao())
        {
            compRep.DataSource = dao.funcMemberSearch(
                compName.Text.Trim()
                , timeFrom
                , timeTo
                , compStatus.SelectedValue
                , PN1.PageSize
                , PN1.PageIndex
                );
            compRep.DataBind();
            PN1.SetPage(dao.propCount);
        }

    }
}
