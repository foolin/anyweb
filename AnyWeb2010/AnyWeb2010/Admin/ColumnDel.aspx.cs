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

public partial class Admin_ColumnDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        string backUrl = "ColumnList.aspx";

        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
            Response.Redirect(backUrl);

        AW_Column_bean column = (new AW_Column_dao()).funcGetColumnInfo(int.Parse(QS("id")));

        if (column == null)
            Response.Redirect(backUrl);

        if (column.Children != null && column.Children.Count > 0)
            WebAgent.FailAndGo("该栏目下存在子栏目，不能删除！", backUrl);

        if ((new AW_Article_dao()).funcGetArticleCount(column.fdColuID) > 0)
            WebAgent.FailAndGo("该栏目下存在文章，不能删除！", backUrl);

        (new AW_Column_dao()).funcDelete(column.fdColuID);
        WebAgent.SuccAndGo("删除成功", backUrl);
    }
}
