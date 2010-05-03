using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;
using Studio.Web;

public partial class Admin_RelationAdd : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        int i = 0;
        foreach (AW_Column_bean bean1 in (new AW_Column_dao()).funcGetColumns())
        {
            drpColumn.Items.Add(new ListItem(bean1.fdColuName, bean1.fdColuID.ToString()));
            litJs.Text += string.Format("child[{0}] = new Array;", i);
            int j = 0;
            foreach (AW_Column_bean bean2 in bean1.Children)
            {
                litJs.Text += string.Format("child[{0}][{1}] = \"{2}:{3}\";", i, j, bean2.fdColuID, bean2.fdColuName);
                j++;
            }
            i++;
        }

        ListItem li = drpColumn.Items.FindByValue(QS("cid"));
        if (li != null) li.Selected = true;
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtTitle.Text))
            WebAgent.AlertAndBack("标题不能为空");

        if (String.IsNullOrEmpty(txtLink.Text))
            WebAgent.AlertAndBack("链接地址不能为空");

        if (string.IsNullOrEmpty(txtSort.Text))
            WebAgent.AlertAndBack("排序不能为空");

        if (!WebAgent.IsInt32(txtSort.Text.Trim()))
            WebAgent.AlertAndBack("排序格式不正确");
        string childColumn = Request.Form["drpChild"] + "";
        using (AW_Relation_dao dao = new AW_Relation_dao())
        {

            AW_Relation_bean bean = new AW_Relation_bean();
            bean.fdRelaID = dao.funcNewID();
            if (childColumn != "0")
            {
                bean.fdRelaColuID = int.Parse(childColumn);
            }
            else
            {
                bean.fdRelaColuID = int.Parse(drpColumn.SelectedValue);
            }
            bean.fdRelaTitle = txtTitle.Text.Trim();
            if (txtLink.Text.Trim().ToLower().StartsWith("http://"))
            {
                bean.fdRelaLink = txtLink.Text.Trim().ToLower();
            }
            else
            {
                bean.fdRelaLink = "http://" + txtLink.Text.Trim().ToLower();
            }
            bean.fdRelaSort = int.Parse(txtSort.Text.Trim());
            if (bean.fdRelaSort == 0)
            {
                bean.fdRelaSort = bean.fdRelaID * 100;
            }

            int record = dao.funcInsert(bean);
            if (record > 0)
            {
                Studio.Web.WebAgent.SuccAndGo("添加成功", string.Format("RelationList.aspx?id={0}&cid={1}", drpColumn.SelectedValue, childColumn));
            }
        }
    }
}
