using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_TemplateColumn : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        if (QS("type") == "1")
        {
            ViewState["REFURL"] = "ColumnList.aspx";
        }
        else if (QS("type") == "2")
        {
            ViewState["REFURL"] = "CategoryList.aspx";
        }
        else
        {
            Response.Redirect("index.aspx");
        }
        if (string.IsNullOrEmpty(QS("ttype")) || !WebAgent.IsInt32(QS("ttype")) || int.Parse(QS("ttype")) < 1 || int.Parse(QS("ttype")) > 2)
        {
            WebAgent.AlertAndBack("模版类别不正确！");
        }
        if (string.IsNullOrEmpty(QS("id")) || !WebAgent.IsInt32(QS("id")))
        {
            WebAgent.AlertAndBack("编号不正确！");
        }
        txtName.Text = QS("name");
        repTemplate.DataSource = new AW_Template_dao().funcGetTempateList(int.Parse(QS("ttype")), txtName.Text);
        repTemplate.DataBind();
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (Request.Form["template"] + "" != "" && WebAgent.IsInt32(Request.Form["template"]))
        {
            if (QS("type") == "1")
            {
                new AW_Column_dao().funcUpdateColumnTemplate(int.Parse(QS("id")), int.Parse(QS("ttype")), int.Parse(Request.Form["template"]), chkUpdate.Checked);
            }
            else
            {
                new AW_Category_dao().funcUpdateCateTemplate(int.Parse(QS("id")), int.Parse(QS("ttype")), int.Parse(Request.Form["template"]), chkUpdate.Checked);
            }
            WebAgent.SuccAndGo("修改成功！", RefUrl);
        }
        else
        {
            WebAgent.AlertAndBack("请选择模版！");
        }
    }
}
