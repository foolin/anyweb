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
using AnyWeb.AW_DL;
using AnyWeb.AW_DL;

public partial class Admin_ColumnAdd : ShopAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        foreach (AW_News_Column_bean bean in (new AW_News_Column_dao()).funcGetColumns())
        {
            drpParent.Items.Add(new ListItem(bean.fdColuName, bean.fdColuID.ToString()));
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtName.Text))
            WebAgent.AlertAndBack("栏目名称不能为空");

        using (AW_News_Column_dao dao = new AW_News_Column_dao())
        {
            if(txtPath.Text.Trim()!="" && dao.funcGetColumnInfo(txtPath.Text.Trim())!=null)
            {
                txtPath.Focus();
                WebAgent.AlertAndBack("栏目路径已被占用");
                return;
            }

            AW_News_Column_bean bean = new AW_News_Column_bean();
            bean.fdColuID = dao.funcNewID();
            bean.fdColuName = txtName.Text;
            bean.fdColuPath = txtPath.Text.Trim();
            bean.fdColuSort = bean.fdColuID;
            bean.fdColuDescription = txtDesc.Text;
            bean.fdColuParentID = int.Parse(drpParent.SelectedValue);

            if (bean.fdColuPath == "")
            {
                bean.fdColuPath = bean.fdColuID.ToString();
            }

            bean.fdColuShowIndex = chkShowIndex.Checked ? 1 : 0;
            int record = dao.funcInsert(bean);
            if (record > 0)
            {
                Studio.Web.WebAgent.SuccAndGo("添加成功", "ColumnList.aspx");
            }
        }
    }

}
