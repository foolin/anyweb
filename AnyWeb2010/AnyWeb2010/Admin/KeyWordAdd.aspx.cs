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

public partial class Admin_KeyWordAdd : ShopAdmin
{

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        txtSort.Text = (new AW_KeyWord_dao().funcGetMaxSort() + 1).ToString();
    }


    protected void btnOk_Click(object sender, EventArgs e)
    {
        int sort = 0;
        if (!int.TryParse(txtSort.Text.Trim(), out sort))
        {
            WebAgent.AlertAndBack("排序号输入不正确！");
        }
        using (AW_KeyWord_dao dao = new AW_KeyWord_dao())
        {
            AW_KeyWord_bean bean = new AW_KeyWord_bean();
            bean.fdKeyWID = dao.funcNewID();
            bean.fdKeyWCreateAt = DateTime.Now;
            bean.fdKeyWName = txtName.Text;
            bean.fdKeyWSort = sort;
            bean.fdKeyWIsShow = 1;
            dao.funcInsert(bean);
        }
        WebAgent.SuccAndGo("添加搜索关键字成功！", RefUrl);
    }

}
