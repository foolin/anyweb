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

public partial class Admin_ColumnDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        string backUrl = "ColumnList.aspx";

        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
            Response.Redirect(backUrl);

        (new AW_Column_dao()).funcDeleteColumn(int.Parse(QS("id")));
        WebAgent.SuccAndGo("删除成功", backUrl);
    }
}
