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

public partial class Admin_GoodsList : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        foreach (AW_Category_bean bean in (new AW_Category_dao()).funcGetCategories())
        {
            drpCategory.Items.Add(new ListItem(bean.fdCateName, bean.fdCateID.ToString()));
            foreach (AW_Category_bean bean1 in bean.Children)
            {
                drpCategory.Items.Add(new ListItem(bean.fdCateName + "-" + bean1.fdCateName, bean1.fdCateID.ToString()));
                foreach (AW_Category_bean bean2 in bean1.Children)
                {
                    drpCategory.Items.Add(new ListItem(bean.fdCateName + "-" + bean1.fdCateName + "-" + bean2.fdCateName, bean2.fdCateID.ToString()));
                }
            }
        }
        foreach (AW_Brand_bean bean in (new AW_Brand_dao()).funcGetBrands())
        {
            drpBrand.Items.Add(new ListItem(bean.fdBranName, bean.fdBranID.ToString()));
            foreach (AW_Brand_bean bean1 in bean.Children)
            {
                drpBrand.Items.Add(new ListItem(bean.fdBranName + "-" + bean1.fdBranName, bean1.fdBranID.ToString()));
            }
        }

        ListItem li = drpCategory.Items.FindByValue(QS("category"));
        if (li != null) li.Selected = true;
        li = drpBrand.Items.FindByValue(QS("brand"));
        if (li != null) li.Selected = true;
        li = drpStatus.Items.FindByValue(QS("status"));
        if (li != null) li.Selected = true;
        li = drpSort.Items.FindByValue(QS("sort"));
        if (li != null) li.Selected = true;

        txtGoodsID.Text = QS("id").Trim();
        txtGoodsName.Text = QS("name").Trim();
        drpRecommend.SelectedValue = QS("recommend");
        drpPromotion.SelectedValue = QS("promotion");
        int recommend = 0, promotion = 0;
        int.TryParse(drpRecommend.SelectedValue, out recommend);
        int.TryParse(drpPromotion.SelectedValue, out promotion);

        using (AW_Goods_dao dao = new AW_Goods_dao())
        {
            AW_Category_bean category = (new AW_Category_dao()).funcGetCategoryInfo(int.Parse(drpCategory.SelectedValue));
            AW_Brand_bean brand = (new AW_Brand_dao()).funcGetBrandInfo(int.Parse(drpBrand.SelectedValue));
            int goodsID = txtGoodsID.Text != "" && WebAgent.IsInt32(txtGoodsID.Text) ? int.Parse(txtGoodsID.Text) : 0;
            repGoodses.DataSource = dao.funcGetAdminGoodsList(
                category,
                brand,
                int.Parse(drpStatus.SelectedValue),
                goodsID,
                txtGoodsName.Text,
                recommend,
                promotion,
                int.Parse(drpSort.SelectedValue),
                PN1.PageSize,
                PN1.PageIndex
            );
            repGoodses.DataBind();
            PN1.SetPage(dao.propCount);
        }

    }
}
