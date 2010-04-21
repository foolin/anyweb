using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;
using Studio.Web;
using System.IO;

public partial class Admin_TemplateDel : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        string url = Request.UrlReferrer == null ? "TemplateList.aspx" : Request.UrlReferrer.AbsoluteUri;

        if (String.IsNullOrEmpty(QS("id")) || !Studio.Web.WebAgent.IsInt32(QS("id")))
        {
            WebAgent.AlertAndBack("编号不正确！");
        }

        AW_Template_bean bean = AW_Template_bean.funcGetByID(int.Parse(QS("id")));
        if (bean == null)
        {
            WebAgent.AlertAndBack("模版不存在！");
        }

        if (new AW_Template_dao().funcDelete(QS("id")) > 0)
        {
            string templateFile = Server.MapPath(Request.ApplicationPath + "/Control" + ".ascx");
            if (File.Exists(templateFile))
            {
                File.Delete(templateFile);
            }
            Studio.Web.WebAgent.SuccAndGo("删除成功", url);
        }
    }
}
