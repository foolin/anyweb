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

public partial class Admin_CategoryEdit : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        AW_Category_bean category = (new AW_Category_dao()).funcGetCategoryInfo(int.Parse(QS("id")));
        txtName.Text = category.fdCateName;
        txtPath.Text = category.fdCatePath;
        boxShow.Checked = category.fdCateIsShow == 1;

        if (WebAgent.IsInt32(txtPath.Text))
            txtPath.Text = "";

        if (category.Children != null && category.Children.Count > 0)
        {
            //具有子分类的不能改变父节点
            if( category.Parent == null)
                drpParent.Items.Add( new ListItem("没有上级分类","0"));
            else
                drpParent.Items.Add(new ListItem(category.Parent.fdCateName, category.Parent.fdCateID.ToString()));
        }
        else
        {
            drpParent.Items.Add(new ListItem("没有上级分类", "0"));
            foreach (AW_Category_bean bean in (new AW_Category_dao()).funcGetCategories())
            {
                if (bean != category)
                {
                    drpParent.Items.Add(new ListItem(bean.fdCateName, bean.fdCateID.ToString()));
                    foreach (AW_Category_bean bean2 in bean.Children)
                    {
                        if( bean2 != category)
                            drpParent.Items.Add(new ListItem(bean.fdCateName + " - " + bean2.fdCateName, bean2.fdCateID.ToString()));
                    }
                }
            }
        }

        ListItem li = drpParent.Items.FindByValue(category.fdCateParent.ToString());
        if (li != null) li.Selected = true;

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Trim() == "")
            WebAgent.AlertAndBack("请输入名称");

        using (AW_Category_dao dao = new AW_Category_dao())
        {
            AW_Category_bean category = dao.funcGetCategoryInfo(int.Parse(QS("id")));

            AW_Category_bean temp = dao.funcGetCategoryInfo(txtPath.Text);
            if (temp != null && temp.fdCateID != category.fdCateID)
                WebAgent.AlertAndBack("访问路径已经被其他分类占用");

            category.fdCateName = txtName.Text;
            category.fdCateIsShow = boxShow.Checked ? 1 : 0;

            //
            if (category.fdCateParent != int.Parse(drpParent.SelectedValue))
            {
                if (drpParent.SelectedValue == "0")
                {
                    category.fdCateIDPath = category.fdCateID.ToString();
                }
                else
                {
                    AW_Category_bean parent = dao.funcGetCategoryInfo(int.Parse(drpParent.SelectedValue));
                    category.fdCateIDPath = parent.fdCateIDPath + "." + category.fdCateID.ToString();
                }

                //if (category.Children != null && category.Children.Count > 0)
                //{
                //    foreach (AW_Category_bean b in category.Children)
                //    {
                //        b.fdCateIDPath = category.fdCateIDPath + "." + category.fdCateID.ToString();
                //        dao.funcUpdate(b);
                //        if (b.Children != null && b.Children.Count > 0)
                //        {
                //            foreach (AW_Category_bean b2 in category.Children)
                //            {
                //                b2.fdCateIDPath = b.fdCateIDPath + "." + b2.fdCateID.ToString();
                //                dao.funcUpdate(b2);
                //            }
                //        }
                //    }
                //}
            }


            category.fdCateParent = int.Parse(drpParent.SelectedValue);
            category.fdCatePath = txtPath.Text.ToLower();
            if (category.fdCatePath == "")
                category.fdCatePath = category.fdCateID.ToString();

            dao.funcUpdate(category);
            WebAgent.SuccAndGo("修改分类成功", this.RefUrl == null ? "categorylist.aspx" : this.RefUrl);
        }
    }
}
