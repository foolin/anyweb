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

using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_ColumnEdit : PageAdmin
{
    public bool hasPic;
    public string picUrl;
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        if (!WebAgent.IsInt32(QS("id")))
            WebAgent.AlertAndBack("编号不正确!");

        AW_Column_bean column = (new AW_Column_dao()).funcGetColumnInfo(int.Parse(QS("id")));
        if (column == null)
            WebAgent.AlertAndBack("新闻栏目不存在!");

        foreach (AW_Column_bean bean in (new AW_Column_dao()).funcGetColumns()) {
            if (bean.fdColuID != column.fdColuID)
                drpParent.Items.Add(new ListItem(bean.fdColuName, bean.fdColuID.ToString()));
        }

        txtName.Text = column.fdColuName;
        txtDesc.Text = column.fdColuDescription;
        ListItem li = drpParent.Items.FindByValue(column.fdColuParentID.ToString());
        if (li != null) li.Selected = true;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtName.Text))
            WebAgent.AlertAndBack("栏目名称不能为空");
        using (AW_Column_dao dao = new AW_Column_dao())
        {
            AW_Column_bean column = dao.funcGetColumnInfo(int.Parse(QS("id")));

            if (column.Children != null && column.Children.Count > 0 && column.fdColuParentID != int.Parse(drpParent.SelectedValue))
                WebAgent.AlertAndBack("该栏目存在子栏目，不允许修改其父级栏目!");

            column.fdColuName = txtName.Text.Trim();
            column.fdColuDescription = txtDesc.Text.Trim();
            column.fdColuParentID = int.Parse(drpParent.SelectedValue);
            dao.funcUpdate(column);
            this.AddLog(EventType.Update, "修改栏目", "修改栏目[" + column.fdColuName + "]");
            WebAgent.SuccAndGo("修改文章栏目成功", "ColumnList.aspx");
        }
    }    
}
