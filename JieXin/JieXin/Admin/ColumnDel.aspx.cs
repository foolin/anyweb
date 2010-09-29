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
        {
            WebAgent.AlertAndBack("栏目编号错误！");
        }
        AW_Column_bean bean = AW_Column_bean.funcGetByID(int.Parse(QS("id")));
        if (bean == null)
        {
            WebAgent.AlertAndBack("栏目不存在！");
        }
        (new AW_Column_dao()).funcDeleteColumn(bean.fdColuID);
        this.AddLog(EventType.Delete, "删除栏目", "删除栏目[" + bean.fdColuName + "]");
        WebAgent.SuccAndGo("删除成功", backUrl);
    }
}
