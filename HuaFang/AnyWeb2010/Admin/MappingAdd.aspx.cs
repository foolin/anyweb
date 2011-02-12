using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_MappingAdd : PageAdmin
{
    protected void btnOk_Click(object sender, EventArgs e)
    {
        AW_Mapping_bean bean = new AW_Mapping_bean();
        bean.fdMappID=new AW_Mapping_dao().funcNewID();
        bean.fdMappPath = txtPath.Text.Trim();
        bean.Template = new AW_Template_dao().funcGetTemplateByName(txtName.Text.Trim());
        if (bean.Template == null)
        {
            WebAgent.AlertAndBack("模版不存在！");
        }
        bean.fdMappTempID = bean.Template.fdTempID;
        new AW_Mapping_dao().funcInsert(bean);
        WebAgent.SuccAndGo("保存成功！", "MappingList.aspx");
    }
}
