using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_NoticeSort : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        int noticeId = 0;
        int previewId = 0;
        int nextId = 0;

        if (QS("id") != "" && WebAgent.IsInt32(QS("id")))
            noticeId = int.Parse(QS("id"));

        if (QS("previewid") != "" && WebAgent.IsInt32(QS("previewid")))
            previewId = int.Parse(QS("previewid"));

        if (QS("nextid") != "" && WebAgent.IsInt32(QS("nextid")))
            nextId = int.Parse(QS("nextid"));

        if (noticeId > 0 && (previewId > 0 || nextId > 0))
        {
            using (AW_Notice_dao dao = new AW_Notice_dao())
            {
                dao.funcSortNotice(noticeId, nextId, previewId);
                Response.Write("ok");
            }
        }
        else
        {
            Response.Write("parmaters null");
        }
    }
}
