using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWeb.AW_DL;

public partial class Admin_RelationEdit : PageAdmin
{
    protected AW_Relation_bean relation;
    protected override void OnPreRender(EventArgs e)
    {
        string id = QS("id");

        if (!WebAgent.IsInt32(id)) WebAgent.AlertAndBack("编号不正确!");

        relation = AW_Relation_bean.funcGetByID(QS("id"));
        relation.Column = AW_Column_bean.funcGetByID(relation.fdRelaColuID);
        if (relation == null) WebAgent.AlertAndBack("信息关联不存在!");

        if (!this.IsPostBack && Request.UrlReferrer != null)
        {
            ViewState["REFURL"] = Request.UrlReferrer.PathAndQuery;
        }
        else
        {
            ViewState["REFURL"] = "RelationList.aspx";
        }

        txtTitle.Text = relation.fdRelaTitle;
        txtLink.Text = relation.fdRelaLink;
        txtSort.Text = relation.fdRelaSort.ToString();
        txtDesc.Text = relation.fdRelaDesc;
        int i = 0;
        foreach (AW_Column_bean bean1 in (new AW_Column_dao()).funcGetColumns())
        {
            drpColumn.Items.Add(new ListItem(bean1.fdColuName, bean1.fdColuID.ToString()));
            litJs.Text += string.Format("child[{0}] = new Array;", i);
            int j = 0;
            if (bean1.fdColuID == relation.Column.fdColuParentID || bean1.fdColuID == relation.Column.fdColuID)
            {
                drpChild.Items.Add(new ListItem("不选择二级栏目", "0"));
                foreach (AW_Column_bean bean2 in bean1.Children)
                {
                    drpChild.Items.Add(new ListItem(bean2.fdColuName, bean2.fdColuID.ToString()));
                    litJs.Text += string.Format("child[{0}][{1}] = \"{2}:{3}\";", i, j, bean2.fdColuID, bean2.fdColuName);
                    j++;
                }
            }
            else
            {
                foreach (AW_Column_bean bean2 in bean1.Children)
                {
                    litJs.Text += string.Format("child[{0}][{1}] = \"{2}:{3}\";", i, j, bean2.fdColuID, bean2.fdColuName);
                    j++;
                }
            }
            i++;
        }
        if (relation.Column.fdColuParentID == 0)
        {
            drpColumn.SelectedValue = relation.Column.fdColuID.ToString();
            drpChild.SelectedValue = "0";
        }
        else
        {
            drpColumn.SelectedValue = relation.Column.fdColuParentID.ToString();
            drpChild.SelectedValue = relation.Column.fdColuID.ToString();
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        relation = AW_Relation_bean.funcGetByID(QS("id"));
        if (String.IsNullOrEmpty(txtTitle.Text))
            WebAgent.AlertAndBack("标题不能为空");

        if (String.IsNullOrEmpty(txtLink.Text))
            WebAgent.AlertAndBack("链接地址不能为空");

        if (string.IsNullOrEmpty(txtSort.Text))
            WebAgent.AlertAndBack("排序不能为空");

        if (!WebAgent.IsInt32(txtSort.Text.Trim()))
            WebAgent.AlertAndBack("排序格式不正确");
        if (txtDesc.Text.Length > 50)
        {
            WebAgent.AlertAndBack("描述内容不能超出50个字");
        }
        string childColumn = Request.Form[drpChild.UniqueID] + "";
        using (AW_Relation_dao dao = new AW_Relation_dao())
        {
            relation.fdRelaTitle = txtTitle.Text.Trim();            
            relation.fdRelaSort = int.Parse(txtSort.Text.Trim());
            relation.fdRelaDesc = txtDesc.Text;
            if (relation.fdRelaSort == 0)
                relation.fdRelaSort = relation.fdRelaID * 100;
            if (txtLink.Text.Trim().ToLower().StartsWith("http://"))
            {
                relation.fdRelaLink = txtLink.Text.Trim().ToLower();
            }
            else
            {
                relation.fdRelaLink = "http://" + txtLink.Text.Trim().ToLower();
            }
            if (childColumn != "0")
            {
                relation.fdRelaColuID = int.Parse(childColumn);
            }
            else
            {
                relation.fdRelaColuID = int.Parse(drpColumn.SelectedValue);
            }
            dao.funcUpdate(relation);
            WebAgent.SuccAndGo("修改成功", ViewState["REFURL"].ToString());
        }
    }
}
