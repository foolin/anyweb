using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;
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
        //txtPath.Text = bean.fdTempPath;
        drpType.Attributes.Add("onchange", "changetype(this.value)");
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        string oldName;
        AW_Template_bean bean = AW_Template_bean.funcGetByID(int.Parse(QS("id")));
        oldName = bean.fdTempName;
        bean.fdTempName = txtName.Text.Trim();
        bean.fdTempType = int.Parse(drpType.SelectedValue);
        bean.fdTempContent = txtContent.Text;
        bean.fdTempPath = txtPath.Text.Trim();

        AW_Template_dao dao = new AW_Template_dao();
        if (dao.funcCheckIsExists(bean.fdTempName, bean.fdTempID))
        {
            WebAgent.AlertAndBack("模板名称已被占用");
        }
        
        if (drpType.SelectedValue == "4" && dao.funcCheckPathIsExists(bean.fdTempPath, 0))//扩展模版
        {
            WebAgent.AlertAndBack("访问路径已被占用");
        }

        if (dao.funcUpdate(bean) > 0)
        {
            string templatePath = Server.MapPath(Request.ApplicationPath + "/Control");
            if (!Directory.Exists(templatePath))
            {
                Directory.CreateDirectory(templatePath);
            }
            FileAgent.WriteText(templatePath + "\\" + bean.fdTempName + ".ascx", bean.fdTempContent, false);
            if (oldName != bean.fdTempName)
            {
                string templateFile = Server.MapPath(Request.ApplicationPath + "/Control" + oldName + ".ascx");
                if (File.Exists(templateFile))
                {
                    File.Delete(templateFile);
                }
            }
            WebAgent.SuccAndGo("修改模版成功", RefUrl);
        }
    }
}
