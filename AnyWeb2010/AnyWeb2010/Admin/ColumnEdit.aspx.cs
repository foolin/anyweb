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

public partial class Admin_ColumnEdit : ShopAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        if (!WebAgent.IsInt32(QS("id"))) 
            WebAgent.AlertAndBack("编号不正确!");

        AW_News_Column_bean column = (new AW_News_Column_dao()).funcGetColumnInfo(int.Parse(QS("id")));
        if (column == null) 
            WebAgent.AlertAndBack("新闻栏目不存在!");

        foreach (AW_News_Column_bean bean in (new AW_News_Column_dao()).funcGetColumns())
        {
            if( bean.fdColuID != column.fdColuID)
                drpParent.Items.Add(new ListItem(bean.fdColuName, bean.fdColuID.ToString()));
        }

        txtName.Text = column.fdColuName;
        if (!WebAgent.IsInt32(column.fdColuPath))
        {
            txtPath.Text = column.fdColuPath;
        }
        txtDesc.Text = column.fdColuDescription;
        chkShowIndex.Checked = column.fdColuShowIndex == 1;
        ListItem li = drpParent.Items.FindByValue(column.fdColuParentID.ToString());
        if (li != null) li.Selected = true;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtName.Text))
            WebAgent.AlertAndBack("栏目名称不能为空");

        using (AW_News_Column_dao dao = new AW_News_Column_dao())
        {
            AW_News_Column_bean column = dao.funcGetColumnInfo(int.Parse(QS("id")));

            string columnPath = txtPath.Text.Trim();
            AW_News_Column_bean isExists = dao.funcGetColumnInfo(columnPath);
            if (columnPath != "" && isExists != null && isExists.fdColuID!=column.fdColuID)
            {
                txtPath.Focus();
                WebAgent.AlertAndBack("栏目路径已被占用");
                return;
            }
            column.fdColuPath = columnPath;
            if (column.fdColuPath == "")
            {
                column.fdColuPath = column.fdColuID.ToString();
            }
            column.fdColuName = txtName.Text.Trim();
            column.fdColuDescription = txtDesc.Text.Trim();
            column.fdColuShowIndex = chkShowIndex.Checked ? 1 : 0;
            column.fdColuParentID = int.Parse(drpParent.SelectedValue);

            dao.funcUpdate(column);
            WebAgent.SuccAndGo("修改新闻栏目成功", "ColumnList.aspx");
        }
    }


}
