using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_MappingEdit : PageAdmin
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
        txtName.Text = bean.Template.fdTempName;
        txtPath.Text = bean.fdMappPath;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        AW_Mapping_bean bean = new AW_Mapping_bean();
        AW_Mapping_dao dao=new AW_Mapping_dao();
        bean.fdMappID = int.Parse(QS("id"));
        bean.fdMappPath = txtPath.Text.Trim();
        bean.Template = new AW_Template_dao().funcGetTemplateByName(txtName.Text.Trim());
        if (bean.Template == null)
        {
            WebAgent.AlertAndBack("模版不存在！");
        }
        bean.fdMappTempID = bean.Template.fdTempID;
        if (dao.funcUpdate(bean) > 0)
        {
            AW_Mapping_bean mapping = dao.funcGetMappingInfo(int.Parse(QS("id")));
            mapping.fdMappPath = bean.fdMappPath;
            mapping.fdMappTempID = bean.fdMappTempID;
            mapping.Template = bean.Template;
            WebAgent.SuccAndGo("修改映射成功！", "MappingList.aspx");
        }
    }
}
