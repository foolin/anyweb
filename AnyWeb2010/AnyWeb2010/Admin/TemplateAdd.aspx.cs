using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;
using System.IO;
using Studio.Web;
using Studio.IO;

public partial class Admin_TemplateAdd : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        AW_Template_bean bean = new AW_Template_bean();
        bean.fdTempID = new AW_Template_dao().funcNewID();
        bean.fdTempName = txtName.Text.Trim();
        bean.fdTempType = int.Parse(drpType.SelectedValue);      
        bean.fdTempContent = txtContent.Text;
        bean.fdTempCreateAt = DateTime.Now;

        AW_Template_dao dao = new AW_Template_dao();
        if (dao.funcCheckIsExists(bean.fdTempName, 0))
        {
            WebAgent.AlertAndBack("文件名称已被占用");
        }

        if (dao.funcInsert(bean) > 0)
        {
            string templatePath = Server.MapPath(Request.ApplicationPath + "/Control");
            FileAgent.WriteText(templatePath + "\\" + bean.fdTempName + ".ascx", bean.fdTempContent, false);
            WebAgent.SuccAndGo("添加成功", "TemplateList.aspx");
        }
    }
}
