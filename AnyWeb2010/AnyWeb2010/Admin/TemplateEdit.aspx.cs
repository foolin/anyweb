using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWeb.AW_DL;
using System.IO;
using Studio.IO;

public partial class Admin_TemplateEdit : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        if (string.IsNullOrEmpty(QS("id")) || !WebAgent.IsInt32(QS("id")))
        {
            WebAgent.AlertAndBack("编号不正确!");
        }
        AW_Template_bean bean = AW_Template_bean.funcGetByID(int.Parse(QS("id")));
        if (bean == null)
        {
            WebAgent.AlertAndBack("模版不存在！");
        }
        txtName.Text = bean.fdTempName;
        drpType.SelectedValue = bean.fdTempType.ToString();
        txtContent.Text = bean.fdTempContent;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        AW_Template_bean bean = AW_Template_bean.funcGetByID(int.Parse(QS("id")));
        bean.fdTempName = txtName.Text.Trim();
        bean.fdTempType = int.Parse(drpType.SelectedValue);
        bean.fdTempContent = txtContent.Text;

        AW_Template_dao dao = new AW_Template_dao();
        if (dao.funcCheckIsExists(bean.fdTempName, bean.fdTempID))
        {
            WebAgent.AlertAndBack("模板名称已被占用");
        }

        if (dao.funcUpdate(bean) > 0)
        {
            string templatePath = Server.MapPath(Request.ApplicationPath + "/Control");
            if (!Directory.Exists(templatePath))
            {
                Directory.CreateDirectory(templatePath);
            }
            if (drpType.SelectedValue == "1")
            {
                FileAgent.WriteText(templatePath + "\\" + bean.fdTempName + ".aspx", bean.fdTempContent, false);
            }
            else
            {
                FileAgent.WriteText(templatePath + "\\" + bean.fdTempName + ".ascx", bean.fdTempContent, false);
            }
            WebAgent.SuccAndGo("修改模版成功", "TemplateList.aspx");
        }
    }
}
