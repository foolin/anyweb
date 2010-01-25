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

public partial class Admin_HelpTypeEdit : ShopAdmin
{
    AW_Help_Type_bean helpType;

    protected void Page_Load(object sender, EventArgs e)
    {
        string id = QS("id");

        if (!WebAgent.IsInt32(id)) WebAgent.AlertAndBack("编号不正确!");

        helpType = AW_Help_Type_bean.funcGetByID(QS("id"));

        if (helpType == null) WebAgent.AlertAndBack("分类不存在!");
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        txtName.Text = helpType.fdTypeName;

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Trim() == "")
            WebAgent.AlertAndBack("请输入名称!");

        using (AW_Help_Type_dao dao = new AW_Help_Type_dao())
        {
            helpType.fdTypeName = txtName.Text.Trim();
            dao.funcUpdate(helpType);
            WebAgent.SuccAndGo("修改分类成功", "HelpTypeList.aspx");
        }
    }
    
}
