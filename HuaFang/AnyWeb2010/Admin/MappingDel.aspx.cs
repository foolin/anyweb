using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_MappingDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        if (string.IsNullOrEmpty(QS("id")) || !WebAgent.IsInt32(QS("id")))
        {
            WebAgent.AlertAndBack("编号不正确！");
        }

        AW_Mapping_bean bean = new AW_Mapping_dao().funcGetMappingInfo(int.Parse(QS("id")));
        if (bean == null)
        {
            WebAgent.AlertAndBack("映射不存在！");
        }
        if (new AW_Mapping_dao().funcDelete(bean.fdMappID) > 0)
        {
            WebAgent.SuccAndGo("删除成功！", "MappingList.aspx");
        }
    }
}
