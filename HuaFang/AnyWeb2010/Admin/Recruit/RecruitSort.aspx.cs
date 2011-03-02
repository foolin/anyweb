using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_RecruitSort : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
        Response.AppendHeader("Pragma", "No-Cache");

        int recruitId = 0;
        int previewId = 0;
        int nextId = 0;

        if (QS("id") != "" && WebAgent.IsInt32(QS("id")))
            recruitId = int.Parse(QS("id"));

        if (QS("previewid") != "" && WebAgent.IsInt32(QS("previewid")))
            previewId = int.Parse(QS("previewid"));

        if (QS("nextid") != "" && WebAgent.IsInt32(QS("nextid")))
            nextId = int.Parse(QS("nextid"));

        if (recruitId > 0 && (previewId > 0 || nextId > 0))
        {
            AW_Recruit_bean recruit = AW_Recruit_bean.funcGetByID(recruitId);
            if (recruitId == null)
            {
                return;
            }
            using (AW_Recruit_dao dao = new AW_Recruit_dao())
            {
                dao.funcSortRecruit(recruitId, nextId, previewId);
                this.AddLog(EventType.Update, "修改招聘排序", "修改招聘[" + recruit.fdRecrTitle + "]排序");
                Response.Write("ok");
            }
        }
        else
        {
            Response.Write("parmaters null");
        }
    }
}
