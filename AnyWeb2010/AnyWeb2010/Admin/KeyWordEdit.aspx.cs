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

using AnyWeb.AW_DL;
using Studio.Web;

public partial class Admin_KeyWordEdit : ShopAdmin
{
    protected AW_KeyWord_bean bean;

    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(QS("id"), out id))
            bean = AW_KeyWord_bean.funcGetByID(id);

        if (bean == null)
        {
            WebAgent.AlertAndBack("关键字不存在！");
        }

    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        txtName.Text = bean.fdKeyWName;
        txtSort.Text = bean.fdKeyWSort.ToString();

        chkStatus.Checked = bean.fdKeyWIsShow == 1;
    }


    protected void btnOk_Click(object sender, EventArgs e)
    {
        int sort = 0;
        if (!int.TryParse(txtSort.Text.Trim(), out sort))
        {
            WebAgent.AlertAndBack("排序号输入不正确！");
        }
        bean.fdKeyWName = txtName.Text;
        bean.fdKeyWSort = sort;
        bean.fdKeyWIsShow = chkStatus.Checked ? 1 : 0;
        bean.fdKeyWUpdateAt = DateTime.Now;
        new AW_KeyWord_dao().funcUpdate(bean);
        WebAgent.SuccAndGo("修改关键字成功！", RefUrl);
    }
}
