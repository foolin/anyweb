using System;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Collections.Generic;
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


public partial class Admin_GoodsAdd : PageAdmin
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        txtPromStartAt.Attributes["onclick"] = "setday(this)";
        txtPromEndAt.Attributes["onclick"] = "setday(this)";

        drpCategory.Attributes["onchange"] = "cateChange(this.value)";
        drpCategory2.Attributes["onchange"] = "cateChange2(this.value)";
        drpBrand.Attributes["onchange"] = "brandChange(this.value)";

        foreach (ListItem item in radioStatus.Items)
            item.Attributes["class"] = "checkbox";
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        foreach (AW_Category_bean bean in (new AW_Category_dao()).funcGetCategories())
        {
            drpCategory.Items.Add(new ListItem(bean.fdCateName, bean.fdCateID.ToString()));
        }


        if (QS("category") != "" && WebAgent.IsInt32(QS("category")))
        {
            AW_Category_bean category = (new AW_Category_dao()).funcGetCategoryInfo(int.Parse(QS("category")));
            if (category != null)
            {
                if (category.Parent == null) //第一级
                {
                    ListItem item = drpCategory.Items.FindByValue(category.fdCateID.ToString());
                    if (item != null) item.Selected = true;
                    if (category.Children != null && category.Children.Count > 0)
                    {
                        drpCategory2.DataSource = category.Children;
                        drpCategory2.DataBind();
                        drpCategory2.Attributes["style"] = "display:";
                    }
                }
                else if (category.Parent != null && category.Parent.Parent == null)//第二级
                {
                    ListItem item = drpCategory.Items.FindByValue(category.Parent.fdCateID.ToString());
                    if (item != null) item.Selected = true;
                    drpCategory2.DataSource = category.Parent.Children;
                    drpCategory2.DataBind();
                    drpCategory2.Attributes["style"] = "display:";
                    item = drpCategory2.Items.FindByValue(category.fdCateID.ToString());
                    if (item != null) item.Selected = true;
                }
                else if (category.Parent != null && category.Parent.Parent != null)//第三级
                {
                    ListItem item = drpCategory.Items.FindByValue(category.Parent.Parent.fdCateID.ToString());
                    if (item != null) item.Selected = true;
                    drpCategory2.DataSource = category.Parent.Parent.Children;
                    drpCategory2.DataBind();
                    drpCategory2.Attributes["style"] = "display:";
                    item = drpCategory2.Items.FindByValue(category.Parent.fdCateID.ToString());
                    if (item != null) item.Selected = true;
                    drpCategory3.DataSource = category.Parent.Parent.Children;
                    drpCategory3.DataBind();
                    drpCategory3.Attributes["style"] = "display:";
                    item = drpCategory2.Items.FindByValue(category.fdCateID.ToString());
                    if (item != null) item.Selected = true;
                }
            }
        }


        foreach (AW_Brand_bean bean in (new AW_Brand_dao()).funcGetBrands())
        {
            drpBrand.Items.Add(new ListItem(bean.fdBranName, bean.fdBranID.ToString()));
        }


        if (QS("brand") != "" && WebAgent.IsInt32(QS("brand")))
        {
            AW_Brand_bean brand = (new AW_Brand_dao()).funcGetBrandInfo(int.Parse(QS("brand")));
            if (brand != null)
            {
                if (brand.Parent == null) //第一级
                {
                    ListItem item = drpBrand.Items.FindByValue(brand.fdBranID.ToString());
                    if (item != null) item.Selected = true;
                    if (brand.Children != null && brand.Children.Count > 0)
                    {
                        drpBrand2.DataSource = brand.Children;
                        drpBrand2.DataBind();
                        drpBrand2.Attributes["style"] = "display:";
                    }
                }
                else if (brand.Parent != null && brand.Parent.Parent == null)//第二级
                {
                    ListItem item = drpBrand.Items.FindByValue(brand.Parent.fdBranID.ToString());
                    if (item != null) item.Selected = true;
                    drpBrand2.DataSource = brand.Parent.Children;
                    drpBrand2.DataBind();
                    drpBrand2.Attributes["style"] = "display:";
                    item = drpBrand2.Items.FindByValue(brand.fdBranID.ToString());
                    if (item != null) item.Selected = true;
                }
            }
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        AW_Goods_bean goods = SaveData();
        WebAgent.SuccAndGo("添加商品成功", "goodslist.aspx");
    }

    protected void btnContine_Click(object sender, EventArgs e)
    {
        AW_Goods_bean goods = SaveData();
        this.AddLog( EventType.Insert, "添加商品", "添加商品[" + goods.fdGoodName + "]" );
        WebAgent.SuccAndGo("添加商品成功", "goodsadd.aspx?category=" + goods.Category.fdCateID.ToString() + "&brand=" + (goods.Brand == null ? "" : goods.Brand.fdBranID.ToString()));
    }

    AW_Goods_bean SaveData()
    {
        string pics = Request.Form["pics"] + "";
        string listimg = Request.Form["listimg"] + "";

        AW_Goods_bean goods = new AW_Goods_bean();
        goods.Pictures = new List<AW_Goods_Picture_bean>();
        if (pics.Length > 0)
        {
            foreach (string temp in pics.Split(','))
            {
                if (temp.Trim().Length == 0)
                    continue;
                AW_Goods_Picture_bean pic = new AW_Goods_Picture_bean();
                pic.fdPictCreateAt = DateTime.Now;
                pic.fdPictPath = temp;
                goods.Pictures.Add(pic);
            }
        }
        if (listimg.Length > 0)
        {
            goods.fdGoodListImage = listimg;
        }
        else if (goods.Pictures.Count > 0)
        {
            goods.fdGoodListImage = goods.Pictures[ 0 ].fdPictPath.Replace( "S_", "" );
        }

        if (drpBrand.SelectedIndex > 0)
        {
            goods.Brand = new AW_Brand_bean();
            if (Request.Form[drpBrand2.UniqueID] + "" != "")
            {
                goods.Brand.fdBranID = int.Parse(Request.Form[drpBrand2.UniqueID]);
            }
            else
            {
                goods.Brand.fdBranID = int.Parse(drpBrand.SelectedValue); 
            }
        }
        if (Request.Form[drpCategory3.UniqueID] + "" != "")
        {
            goods.fdGoodCategoryID = int.Parse(Request.Form[drpCategory3.UniqueID]);
        }
        else if (Request.Form[drpCategory2.UniqueID] + "" != "")
        {
            goods.fdGoodCategoryID = int.Parse(Request.Form[drpCategory2.UniqueID]);
        }
        else if (Request.Form[drpCategory.UniqueID] + "" != "")
        {
            goods.fdGoodCategoryID = int.Parse(Request.Form[drpCategory.UniqueID]);
        }
        goods.fdGoodName = txtName.Text;
        goods.fdGoodDescription = txtIntro.Text;
        goods.fdGoodStockNum = int.Parse(txtStockNum.Text);

        if (txtStockPrice.Text != "" && WebAgent.IsNumeric(txtStockPrice.Text))
            goods.fdGoodStockPrice = float.Parse(txtStockPrice.Text);
        if (txtMarketPrice.Text != "" && WebAgent.IsNumeric(txtMarketPrice.Text))
            goods.fdGoodMarketPrice = float.Parse(txtMarketPrice.Text);
        if (txtSalePrice.Text != "" && WebAgent.IsNumeric(txtSalePrice.Text))
            goods.fdGoodSalePrice = float.Parse(txtSalePrice.Text);
        if (txtWeight.Text != "" && WebAgent.IsNumeric(txtWeight.Text))
            goods.fdGoodWeight = float.Parse(txtWeight.Text);

        goods.fdGoodCreateAt = DateTime.Now;
        goods.fdGoodUpdateAt = DateTime.Now;
        goods.fdGoodIsRecommend = boxRecommend.Checked ? 1 : 0;
        goods.fdGoodIsPromotion = boxPromotion.Checked ? 1 : 0;
        goods.fdGoodStatus = int.Parse(radioStatus.SelectedValue);

        goods.fdGoodHomeJinbao = boxHomeJinbao.Checked ? 1 : 0;
        goods.fdGoodHomeMeijiu = boxHomeMeijiu.Checked ? 1 : 0;
        goods.fdGoodHomeMingpai = boxHomeMingpai.Checked ? 1 : 0;

        if (txtPromPrice.Text != "" && WebAgent.IsNumeric(txtPromPrice.Text))
            goods.fdGoodPromPrice = float.Parse(txtPromPrice.Text);
        else
            goods.fdGoodIsPromotion = 0;

        if (txtPromStartAt.Text != "" && WebAgent.IsDate(txtPromStartAt.Text))
            goods.fdGoodPromStartAt = DateTime.Parse(txtPromStartAt.Text);
        else
            goods.fdGoodPromStartAt = DateTime.Parse("1900-1-1");

        if (txtPromEndAt.Text != "" && WebAgent.IsDate(txtPromEndAt.Text))
            goods.fdGoodPromEndAt = DateTime.Parse(txtPromEndAt.Text);
        else
            goods.fdGoodPromEndAt = DateTime.Parse("1900-1-1");

        //积分
        int point = 0;
        int.TryParse(txtPoint.Text, out point);
        goods.fdGoodPoint = point;

        using (AW_Goods_dao dao = new AW_Goods_dao())
        {
            goods.fdGoodID = dao.funcNewID();
            goods.fdGoodSort = goods.fdGoodID * 100;
            dao.funcInsert(goods);
            if (goods.Pictures.Count > 0)
            {
                using (AW_Goods_Picture_dao dao1 = new AW_Goods_Picture_dao())
                {
                    foreach (AW_Goods_Picture_bean pic in goods.Pictures)
                    {
                        pic.fdPictGoodID = goods.fdGoodID;
                        pic.fdPictID = dao1.funcNewID();
                        dao1.funcInsert(pic);
                    }
                }
            }
            if (goods.Brand != null)
            {
                using (AW_Goods_Brand_dao dao2 = new AW_Goods_Brand_dao())
                {
                    AW_Goods_Brand_bean brand = new AW_Goods_Brand_bean();
                    brand.fdGoBrBrandID = goods.Brand.fdBranID;
                    brand.fdGoBrGoodsID = goods.fdGoodID;
                    brand.fdGoBrID = dao2.funcNewID();
                    dao2.funcInsert(brand);
                }
            }
        }

        goods.Category = (new AW_Category_dao()).funcGetCategoryInfo(goods.fdGoodCategoryID);

        return goods;
    }
}
