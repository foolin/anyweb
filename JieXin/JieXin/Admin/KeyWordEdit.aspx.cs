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
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_KeyWordEdit : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        string id = QS("id");
        if (!WebAgent.IsInt32(id)) WebAgent.AlertAndBack("编号不正确!");
        AW_KeyWord_bean bean = AW_KeyWord_bean.funcGetByID(id);
        if (bean == null)
        {
            WebAgent.AlertAndBack("关键词不存在！");
        }

        txtName.Text = bean.fdKeyWName;
        txtSort.Text = bean.fdKeyWSort.ToString();
        chkStatus.Checked = bean.fdKeyWIsShow == 1;

        if (!this.IsPostBack && Request.UrlReferrer != null)
        {
            ViewState["REFURL"] = Request.UrlReferrer.PathAndQuery;
        }
        else
        {
            ViewState["REFURL"] = "ArticleList.aspx";
        }
    }


    protected void btnOk_Click(object sender, EventArgs e)
    {
        int sort = 0;
        if (!int.TryParse(txtSort.Text.Trim(), out sort))
        {
            WebAgent.AlertAndBack("排序输入不正确！");
        }
        AW_KeyWord_bean bean = AW_KeyWord_bean.funcGetByID(int.Parse(QS("id")));
        bean.fdKeyWName = txtName.Text;
        bean.fdKeyWSort = sort;
        if (bean.fdKeyWSort == 0)
            bean.fdKeyWSort = bean.fdKeyWID * 100;
        bean.fdKeyWIsShow = chkStatus.Checked ? 1 : 2;
        new AW_KeyWord_dao().funcUpdate(bean);
        this.AddLog(EventType.Update, "修改关键词", "修改关键词[" + bean.fdKeyWName + "]");
        WebAgent.SuccAndGo("修改成功！", (string)ViewState["REFURL"]);
    }
}
