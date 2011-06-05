using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Plugins_Subscribe_SubscribeDel : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ids = QS("ids").Trim();
        if (string.IsNullOrEmpty(ids))
        {
            ShowError("请选择订阅！");
        }

        AW_Subscribe_dao dao = new AW_Subscribe_dao();
        List<AW_Subscribe_bean> list = dao.funcGetSubscribeList(ids);

        if (!IsPostBack)
        {
            repSubscribes.DataSource = list;
            repSubscribes.DataBind();
        }
        else
        {
            if (dao.funcDeletes(ids) > 0)
            {
                foreach (AW_Subscribe_bean bean in list)
                {
                    AddLog(EventType.Delete, "删除订阅", string.Format("删除订阅:{0}({1})", bean.fdSubsCompany, bean.fdSubsID));
                }
            }
            Response.Write("<script type=text/javascript>parent.deleteSubscribeOK();</script>");
            Response.End();
        }
    }
}
