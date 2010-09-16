using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_NoticeEdit : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (!WebAgent.IsInt32(QS("id")))
            WebAgent.AlertAndBack("编号不正确！");
        AW_Notice_bean bean = AW_Notice_bean.funcGetByID(int.Parse(QS("id")));
        if (bean == null)
            WebAgent.AlertAndBack("公告不存在！");
        txtTitle.Text = bean.fdNotiTitle;
        txtContent.Text = bean.fdNotiContent;
        txtSort.Text = bean.fdNotiOrder.ToString();
        if (!this.IsPostBack && Request.UrlReferrer != null)
        {
            ViewState["REFURL"] = Request.UrlReferrer.PathAndQuery;
        }
        else
        {
            ViewState["REFURL"] = "NoticeList.aspx";
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        AW_Notice_bean bean = AW_Notice_bean.funcGetByID(int.Parse(QS("id")));
        bean.fdNotiTitle = txtTitle.Text;
        bean.fdNotiContent = txtContent.Text;
        bean.fdNotiOrder = int.Parse(txtSort.Text);
        if (bean.fdNotiOrder == 0)
            bean.fdNotiOrder = bean.fdNotiID * 100;
        new AW_Notice_dao().funcUpdate(bean);
        WebAgent.SuccAndGo("修改公告成功", ViewState["REFURL"].ToString());
    }
}
