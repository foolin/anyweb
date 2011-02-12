using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_LogList : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        foreach (AW_Admin_bean admin in new AW_Admin_dao().funcGetAdmins())
        {
            drpAdmin.Items.Add(new ListItem(admin.fdAdmiName, admin.fdAdmiAccount));
        }
        drpAdmin.SelectedValue = QS("admin");
        drpOper.SelectedValue = QS("type");
        using (AW_Log_dao dao = new AW_Log_dao())
        {
            compRep.DataSource = dao.funcGetLogList(drpAdmin.SelectedValue, int.Parse(drpOper.SelectedValue), PN1.PageSize, PN1.PageIndex);
            compRep.DataBind();
            PN1.SetPage(dao.propCount);
        }
    }

    protected string getType(int typeID)
    {
        switch (typeID)
        {
            case 1: return "登录";
            case 2: return "添加";
            case 3: return "删除";
            case 4: return "修改";
            default: return "未知";
        }
    }
}
