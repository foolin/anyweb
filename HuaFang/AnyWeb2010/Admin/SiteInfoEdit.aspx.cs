using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_SiteInfoEdit : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (QS("id") == "" || !WebAgent.IsInt32(QS("id")))
        {
            WebAgent.AlertAndBack("参数不正确！");
        }

        AW_SiteInfo_bean bean = AW_SiteInfo_bean.funcGetByID(int.Parse(QS("id")));
        if (bean == null)
        {
            WebAgent.AlertAndBack("基本信息不存在！");
        }
        txtTitle.Text = bean.fdSiInTitle;
        txtContent.Text = bean.fdSiInContent;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        AW_SiteInfo_bean bean = AW_SiteInfo_bean.funcGetByID(int.Parse(QS("id")));
        bean.fdSiInTitle = txtTitle.Text;
        bean.fdSiInContent = txtContent.Text;
        new AW_SiteInfo_dao().funcUpdate(bean);
        this.AddLog(EventType.Update, "修改基本信息", "修改基本信息[" + bean.fdSiInTitle + "]");
        WebAgent.SuccAndGo("修改基本信息成功", ViewState["REFURL"].ToString());
    }
}
