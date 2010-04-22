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
using AnyWeb.AW_DL;
using AnyWeb.AW.Configs;


public partial class Admin_GoodsEdit : PageAdmin
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
        foreach (AW_Brand_bean bean in (new AW_Brand_dao()).funcGetBrands())
        {
            drpBrand.Items.Add(new ListItem(bean.fdBranName, bean.fdBranID.ToString()));
        }


        AW_Goods_bean goods = (new AW_Goods_dao()).funcGetGoodsInfo(int.Parse(QS("id")));
        if (goods == null) Response.Redirect("goodslist.aspx");

        goods.Category = (new AW_Category_dao()).funcGetCategoryInfo(goods.fdGoodCategoryID);
        AW_Category_bean category = goods.Category;

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

        if (goods.Brand != null)
        {
            AW_Brand_bean brand = (new AW_Brand_dao()).funcGetBrandInfo(goods.Brand.fdBranID);
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

        ListItem li1 = radioStatus.Items.FindByValue(goods.fdGoodStatus.ToString());
        if (li1 != null) li1.Selected = true;

        txtName.Text = goods.fdGoodName;
        txtIntro.Text = goods.fdGoodDescription;
        txtMarketPrice.Text = goods.fdGoodMarketPrice > 0 ? goods.fdGoodMarketPrice.ToString() : "";
        txtPromEndAt.Text = goods.fdGoodPromEndAt.Year == 1900 ? "" : goods.fdGoodPromEndAt.ToString("yyyy-MM-dd");
        txtPromPrice.Text = goods.fdGoodPromPrice > 0 ? goods.fdGoodPromPrice.ToString() : "";
        txtPromStartAt.Text = goods.fdGoodPromStartAt.Year == 1900 ? "" : goods.fdGoodPromStartAt.ToString("yyyy-MM-dd");
        txtSalePrice.Text = goods.fdGoodSalePrice > 0 ? goods.fdGoodSalePrice.ToString() : "";
        txtSort.Text = goods.fdGoodSort.ToString();
        //txtStockNum.Text = goods.fdGoodStockNum.ToString();
        txtStockPrice.Text = goods.fdGoodStockPrice > 0 ? goods.fdGoodStockPrice.ToString() : "";
        txtWeight.Text = goods.fdGoodWeight > 0 ? goods.fdGoodWeight.ToString() : "";
        boxPromotion.Checked = goods.fdGoodIsPromotion == 1;
        boxRecommend.Checked = goods.fdGoodIsRecommend == 1;
        boxHomeJinbao.Checked = goods.fdGoodHomeJinbao == 1;
        boxHomeMeijiu.Checked = goods.fdGoodHomeMeijiu == 1;
        boxHomeMingpai.Checked = goods.fdGoodHomeMingpai == 1;
        boxHomeCheap.Checked = goods.fdGoodHomeCheap == 1;

        txtPoint.Text = goods.fdGoodPoint.ToString();

        repPictures.DataSource = goods.Pictures;
        repPictures.DataBind();

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        string pics = Request.Form["pics"] + "";
        string listimg = Request.Form["listimg"] + "";
        if (listimg.Contains(":")) listimg = listimg.Substring(listimg.IndexOf(":"));

        AW_Goods_bean goods = (new AW_Goods_dao()).funcGetGoodsInfo(int.Parse(QS("id")));
        goods.Pictures = new List<AW_Goods_Picture_bean>();
        if (pics.Length > 0)
        {
            foreach (string temp in pics.Split(','))
            {
                if (temp.Trim().Length == 0)
                    continue;
                if (temp.Contains(":"))
                {
                    AW_Goods_Picture_bean pic = new AW_Goods_Picture_bean();
                    pic.fdPictID = int.Parse(temp.Substring(0, temp.IndexOf(":")));
                    pic.fdPictPath = temp.Substring(temp.IndexOf(":")+1);
                    pic.fdPictCreateAt = DateTime.Now;
                    pic.fdPictGoodID = goods.fdGoodID;
                    goods.Pictures.Add(pic);
                }
                else
                {
                    AW_Goods_Picture_bean pic = new AW_Goods_Picture_bean();
                    pic.fdPictCreateAt = DateTime.Now;
                    pic.fdPictPath = temp;
                    pic.fdPictGoodID = goods.fdGoodID;
                    goods.Pictures.Add(pic);
                }
            }
        }
        if (listimg.Length > 0)
        {
            goods.fdGoodListImage = "/Files/Goods/List_" + DL_helper.funcGetTicks().ToString() + Path.GetExtension(listimg);
            SaveListImg(listimg, goods.fdGoodListImage);
        }
        else if (goods.Pictures.Count > 0 && goods.fdGoodListImage.Length == 0)
        {
            goods.fdGoodListImage = "/Files/Goods/List_" + DL_helper.funcGetTicks().ToString() + Path.GetExtension(listimg);
            SaveListImg(goods.Pictures[0].fdPictPath.Replace("S_", ""), goods.fdGoodListImage);
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
        else
        {
            goods.Brand = null;
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

        goods.fdGoodUpdateAt = DateTime.Now;
        goods.fdGoodIsRecommend = boxRecommend.Checked ? 1 : 0;
        goods.fdGoodIsPromotion = boxPromotion.Checked ? 1 : 0;
        goods.fdGoodStatus = int.Parse(radioStatus.SelectedValue);

        goods.fdGoodHomeJinbao = boxHomeJinbao.Checked ? 1 : 0;
        goods.fdGoodHomeMeijiu = boxHomeMeijiu.Checked ? 1 : 0;
        goods.fdGoodHomeMingpai = boxHomeMingpai.Checked ? 1 : 0;
        goods.fdGoodHomeCheap = boxHomeCheap.Checked ? 1 : 0;

        int point = 0;
        if (int.TryParse(txtPoint.Text, out point))
            goods.fdGoodPoint = point;

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

        goods.fdGoodSort = int.Parse(this.txtSort.Text);

        using (AW_Goods_dao dao = new AW_Goods_dao())
        {
            dao.funcUpdate(goods);
            if (goods.Pictures.Count > 0)
            {
                using (AW_Goods_Picture_dao dao1 = new AW_Goods_Picture_dao())
                {
                    string temp = "";
                    foreach (AW_Goods_Picture_bean pic in goods.Pictures)
                    {
                        if (pic.fdPictID == 0)
                        {
                            pic.fdPictGoodID = goods.fdGoodID;
                            pic.fdPictID = dao1.funcNewID();
                            dao1.funcInsert(pic);
                        }
                        temp += "," + pic.fdPictID.ToString();
                    }
                    dao1.funcDeletePictureNoExists(goods.fdGoodID, temp.Substring(1));
                }
            }
            else
            {
                (new AW_Goods_Picture_dao()).funcClearGoodsPictures(goods.fdGoodID);
            }
            if (goods.Brand != null)
            {
                using (AW_Goods_Brand_dao dao2 = new AW_Goods_Brand_dao())
                {
                    AW_Goods_Brand_bean brand = dao2.funcGetGoodsBrandRelation(goods.fdGoodID);
                    if (brand == null)
                    {
                        brand = new AW_Goods_Brand_bean();
                        brand.fdGoBrBrandID = goods.Brand.fdBranID;
                        brand.fdGoBrGoodsID = goods.fdGoodID;
                        brand.fdGoBrID = dao2.funcNewID();
                        dao2.funcInsert(brand);
                    }
                    else
                    {
                        brand.fdGoBrBrandID = goods.Brand.fdBranID;
                        dao2.funcUpdate(brand);
                    }
                }
            }
            else
            {
                (new AW_Goods_Brand_dao()).funcDeleteGoodsBrandRelation(goods.fdGoodID);
            }
            WebAgent.SuccAndGo("修改商品成功", this.RefUrl == null ? "goodslist.aspx" : this.RefUrl);
        }
    }



    void SaveListImg(string source, string listimg)
    {
        //删除原有封面
        if (!File.Exists(Server.MapPath(source)))
            return;


        System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath(source));
        System.Drawing.Image simg;

        int w = img.Width, h = img.Height;
        double w1 = 0, h1 = 0; int w0 = 0, h0 = 0;
        int maxWidth = GeneralConfigs.GetConfig().GoodsListImageWidth, maxHeight = GeneralConfigs.GetConfig().GoodsListImageHeight;

        int orginalWidth = w;
        int orginalHeight = h;

        if (maxWidth == 0) maxWidth = w;
        if (maxHeight == 0) maxHeight = h;

        //计算缩放比例
        w1 = w; h1 = h;
        if (w > maxWidth)
        {
            w1 = maxWidth;
            h1 = h * (w1 / w);
        }
        if (h1 > maxHeight)
        {
            w1 = w1 * (maxHeight / h1);
            h1 = maxHeight;
        }
        w0 = int.Parse(System.Math.Ceiling(w1).ToString()); h0 = int.Parse(System.Math.Ceiling(h1).ToString());

        if (w0 != w || h1 != h)	//当高或宽不相同时生成缩略图
        {
            simg = img.GetThumbnailImage(w0, h0, null, System.IntPtr.Zero);
            simg.Save(Server.MapPath(listimg));
            simg.Dispose();
        }
        else
        {
            img.Save(Server.MapPath(listimg));
            img.Dispose();
        }
    }
}
