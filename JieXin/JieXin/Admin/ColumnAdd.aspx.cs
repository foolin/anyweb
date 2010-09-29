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

public partial class Admin_ColumnAdd : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        foreach (AW_Column_bean bean in (new AW_Column_dao()).funcGetColumns())
        {
            drpParent.Items.Add(new ListItem(bean.fdColuName, bean.fdColuID.ToString()));
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtName.Text))
            WebAgent.AlertAndBack("栏目名称不能为空");
        using (AW_Column_dao dao = new AW_Column_dao())
        {
            AW_Column_bean bean = new AW_Column_bean();
            bean.fdColuID = dao.funcNewID();
            bean.fdColuName = txtName.Text;
            bean.fdColuSort = bean.fdColuID;
            bean.fdColuDescription = txtDesc.Text;
            bean.fdColuParentID = int.Parse(drpParent.SelectedValue);
            int record = dao.funcInsert(bean);
            if (record > 0)
            {
                this.AddLog(EventType.Insert, "添加栏目", "添加栏目[" + bean.fdColuName + "]");
                Studio.Web.WebAgent.SuccAndGo("添加成功", "ColumnList.aspx");
            }
        }
    }

}
