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
using AnyWeb.AW.Configs;

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
            if (dao.funcGetCategoryInfo(txtPath.Text) != null)
                WebAgent.AlertAndBack("访问路径已经被其他分类占用");

            AW_Category_bean bean = new AW_Category_bean();
            bean.fdCateID = dao.funcNewID();
            bean.fdCateSort = bean.fdCateID;
            bean.fdCateName = txtName.Text;
            bean.fdCateIsShow = boxShow.Checked ? 1 : 0;
            bean.fdCateParent = int.Parse(drpParent.SelectedValue);
            bean.Parent = dao.funcGetCategoryInfo(bean.fdCateParent);
            bean.fdCateIDPath = bean.Parent == null ? bean.fdCateID.ToString() : (bean.Parent.fdCateIDPath + "." + bean.fdCateID.ToString());
            bean.fdCatePath = txtPath.Text.ToLower();
            if (bean.fdCatePath == "")
                bean.fdCatePath = bean.fdCateID.ToString();

            dao.funcInsert(bean);


            if (GeneralConfigs.GetConfig().SetupCategory == false)
            {
                GeneralConfigs.GetConfig().SetupCategory = true;
                GeneralConfigs.Serialiaze(GeneralConfigs.GetConfig(), DefaultConfigFileManager.ConfigFilePath);
            }

            WebAgent.SuccAndGo("添加分类成功", this.RefUrl == null ? "categorylist.aspx" : this.RefUrl);
        }
    }
}
