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

public partial class Admin_KeyWordAdd : PageAdmin
{
    protected void btnOk_Click(object sender, EventArgs e)
    {
        int sort = 0;
        if (!int.TryParse(txtSort.Text.Trim(), out sort))
        {
            WebAgent.AlertAndBack("排序输入不正确！");
        }
        using (AW_KeyWord_dao dao = new AW_KeyWord_dao())
        {
            AW_KeyWord_bean bean = new AW_KeyWord_bean();
            bean.fdKeyWID = dao.funcNewID();
            bean.fdKeyWCreateAt = DateTime.Now;
            bean.fdKeyWName = txtName.Text;
            bean.fdKeyWSort = sort;
            if (bean.fdKeyWSort == 0)
            {
                bean.fdKeyWSort = bean.fdKeyWID * 100;
            }
            bean.fdKeyWIsShow = 1;
            if (chkStatus.Checked)
                bean.fdKeyWIsShow = 1;
            else
                bean.fdKeyWIsShow = 2;
            dao.funcInsert(bean);
        }
        WebAgent.SuccAndGo("添加成功！", "KeyWordList.aspx");
    }

}
