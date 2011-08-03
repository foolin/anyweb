using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_LibrarySort : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
        Response.AppendHeader("Pragma", "No-Cache");

        int Id = 0;
        int previewId = 0;
        int nextId = 0;

        if (QS("id") != "" && WebAgent.IsInt32(QS("id")))
            Id = int.Parse(QS("id"));

        if (QS("previewid") != "" && WebAgent.IsInt32(QS("previewid")))
            previewId = int.Parse(QS("previewid"));

        if (QS("nextid") != "" && WebAgent.IsInt32(QS("nextid")))
            nextId = int.Parse(QS("nextid"));

        if (Id > 0 && (previewId > 0 || nextId > 0))
        {
            using (AW_Library_dao dao = new AW_Library_dao())
            {
                AW_Library_bean bean = AW_Library_bean.funcGetByID( Id );
                if (bean == null)
                {
                    return;
                }
                dao.funcSortLibrary(Id, nextId, previewId);
                if( bean.fdLibrType == 1 )
                {
                    this.AddLog( EventType.Update, "修改名人排序", "修改名人[" + bean.fdLibrName + "]排序" );
                }
                else
                {
                    this.AddLog( EventType.Update, "修改品牌排序", "修改品牌[" + bean.fdLibrName + "]排序" );
                }
                Response.Write("ok");
            }
        }
        else
        {
            Response.Write("parmaters null");
        }
    }
}
