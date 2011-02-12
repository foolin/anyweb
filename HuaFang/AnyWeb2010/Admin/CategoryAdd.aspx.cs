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
using AnyWell.Configs;

public partial class Admin_CategoryAdd : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        foreach (AW_Category_bean bean in (new AW_Category_dao()).funcGetCategories())
        {
            drpParent.Items.Add(new ListItem(bean.fdCateName, bean.fdCateID.ToString()));
            foreach (AW_Category_bean bean2 in bean.Children)
            {
                drpParent.Items.Add(new ListItem(bean.fdCateName+" - "+ bean2.fdCateName, bean2.fdCateID.ToString()));
            }
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (txtName.Text.Trim() == "")
            WebAgent.AlertAndBack("请输入名称");

        using (AW_Category_dao dao = new AW_Category_dao())
        {

            AW_Category_bean bean = new AW_Category_bean();
            bean.fdCateID = dao.funcNewID();
            bean.fdCateSort = bean.fdCateID;
            bean.fdCateName = txtName.Text;
            bean.fdCateParent = int.Parse(drpParent.SelectedValue);
            bean.Parent = dao.funcGetCategoryInfo(bean.fdCateParent);
            bean.fdCateIDPath = bean.Parent == null ? bean.fdCateID.ToString() : (bean.Parent.fdCateIDPath + "." + bean.fdCateID.ToString());
            if (bean.fdCatePath == "")
                bean.fdCatePath = bean.fdCateID.ToString();

            dao.funcInsert(bean);

            this.AddLog(EventType.Insert, "添加分类", "添加分类[" + bean.fdCateName + "]");
            WebAgent.SuccAndGo("添加分类成功", this.RefUrl == null ? "categorylist.aspx" : this.RefUrl);
        }
    }
}
