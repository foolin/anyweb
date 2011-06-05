using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Ajax_SubscribeSort : AjaxPageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int subscribeId = 0;
        int previewId = 0;
        int nextId = 0;

        int.TryParse(QS("id"), out subscribeId);

        int.TryParse(QS("previewid"), out previewId);

        int.TryParse(QS("nextid"), out nextId);

        if (subscribeId > 0 && (previewId > 0 || nextId > 0))
        {
            AW_Subscribe_bean subscribe = AW_Subscribe_bean.funcGetByID(subscribeId);

            if (subscribe == null)
            {
                RenderString("订阅不存在，排序失败！");
            }

            AW_Subscribe_bean next = nextId == 0 ? null : AW_Subscribe_bean.funcGetByID(nextId, "fdSubsID,fdSubsSort");
            AW_Subscribe_bean preview = previewId == 0 ? null : AW_Subscribe_bean.funcGetByID(previewId, "fdSubsID,fdSubsSort");

            if (next == null && preview == null)
            {
                RenderString("存在操作已删除订阅，排序失败！");
            }

            using (AW_Subscribe_dao dao = new AW_Subscribe_dao())
            {
                if (dao.funcSortSubscribe(subscribe, preview, next))
                {
                    this.AddLog(EventType.Update, "修改订阅排序", "修改订阅[" + subscribe.fdSubsID + "]排序");
                    RenderString("");
                }
                else
                {
                    RenderString("排序失败，请稍候再试！");
                }
            }
        }
        else
        {
            RenderString("存在操作已删除订阅，排序失败！");
        }
    }
}
