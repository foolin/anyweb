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


public partial class Admin_HelpTypeAdd : ShopAdmin
{

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Trim() == "")
            WebAgent.AlertAndBack("请输入名称");

        using (AW_Help_Type_dao dao = new AW_Help_Type_dao())
        {
            AW_Help_Type_bean bean = new AW_Help_Type_bean();
            bean.fdTypeID = dao.funcNewID();
            bean.fdTypeName = txtName.Text.Trim();
            bean.fdTypeSort = bean.fdTypeID;
            dao.funcInsert(bean);
            WebAgent.SuccAndGo("添加分类成功", "HelpTypeList.aspx");
        }

    }

}
