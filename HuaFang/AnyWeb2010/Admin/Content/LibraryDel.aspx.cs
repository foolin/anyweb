using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_LibraryDel : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        string id = QS("id");
        string url = Request.UrlReferrer == null ? "LibraryList.aspx" : Request.UrlReferrer.AbsoluteUri;
        if (String.IsNullOrEmpty(id) || !Studio.Web.WebAgent.IsInt32(id))
        {
            WebAgent.AlertAndBack("编号错误！");
        }
        AW_Library_bean bean = (new AW_Library_dao()).funcGetLibraryItemByID(int.Parse(id));
        if (bean == null)
        {
            WebAgent.AlertAndBack("库信息不存在！");
        }
        int record = new AW_Library_dao().funcDelete(id);
        if (record > 0)
        {
            this.AddLog(EventType.Delete, "删除库信息", "删除库信息[" + bean.fdLibrName + "]");
            Studio.Web.WebAgent.SuccAndGo("删除成功", url);
        }
    }
}
