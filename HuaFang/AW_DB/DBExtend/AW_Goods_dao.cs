using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using AnyWell.AW_DL;
using Studio.Data;
using Studio.Web;

namespace AnyWell.AW_DL
{
    public partial class AW_Goods_dao
    {
        /// <summary>
        /// 检查商品是否存在订单信息
        /// </summary>
        /// <param name="goodsID"></param>
        /// <returns></returns>
        public bool funcCheckGoodsExistOrderItem(int goodsID)
        {
            this.propSelect = " count(1)";
            this.propTableApp = " INNER JOIN AW_Order_Item ON fdGoodID=fdItemGoodsID";
            this.propWhere = " fdGoodID=" + goodsID.ToString();

            return (int)this.funcCommon().Tables[0].Rows[0][0] > 0;
        }

        /// <summary>
        /// 管理员获取商品列表
        /// </summary>
        /// <param name="category"></param>
        /// <param name="brand"></param>
        /// <param name="goodsID"></param>
        /// <param name="keyword"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<AW_Goods_bean> funcGetAdminGoodsList(AW_Category_bean category, AW_Brand_bean brand, int status, int goodsID, string keyword, int recommend, int promotion, int sort, int pageSize, int pageIndex)
        {
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propGetCount = true;

            this.propSelect = "fdGoodID,fdGoodName,fdGoodSalePrice,fdGoodSort,fdGoodCategoryID,fdGoodStockNum,fdGoodClickCount,fdGoodScoreCount,fdGoodScoreAverage,fdGoodFavCount,fdGoodIsRecommend,fdGoodIsPromotion,fdGoodStatus,fdGoBrBrandID";
            this.propSelect += ",fdCateID,fdCateName";
            this.propSelect += ",fdBranID,fdBranName";
            this.propTableApp = " INNER JOIN AW_Category ON fdGoodCategoryID=fdCateID";
            this.propTableApp += " LEFT JOIN AW_Goods_Brand ON fdGoodID=fdGoBrGoodsID";
            this.propTableApp += " LEFT JOIN AW_Brand ON fdGoBrBrandID=fdBranID";
            switch (sort)
            {
                case 1://销量(高-低)
                    this.propOrder = "ORDER BY fdGoodSaleNum DESC,fdGoodID DESC";
                    break;
                case 2://销量(低-高)
                    this.propOrder = "ORDER BY fdGoodSaleNum ASC,fdGoodID DESC";
                    break;
                case 3://价格(高-低)
                    this.propOrder = "ORDER BY fdGoodSalePrice DESC,fdGoodID DESC";
                    break;
                case 4://价格(低-高)
                    this.propOrder = "ORDER BY fdGoodSalePrice ASC,fdGoodID DESC";
                    break;
                case 5://点击(高-低)
                    this.propOrder = "ORDER BY fdGoodClickCount DESC,fdGoodID DESC";
                    break;
                case 6://点击(低-高)
                    this.propOrder = "ORDER BY fdGoodClickCount ASC,fdGoodID DESC";
                    break;
                case 7://评论数(高-低)
                    this.propOrder = "ORDER BY fdGoodCommentCount DESC,fdGoodID DESC";
                    break;
                case 8://评论数(低-高)
                    this.propOrder = "ORDER BY fdGoodCommentCount ASC,fdGoodID DESC";
                    break;
                case 9://得分(高-低)
                    this.propOrder = "ORDER BY fdGoodScoreAverage DESC,fdGoodID DESC";
                    break;
                case 10://得分(低-高)
                    this.propOrder = "ORDER BY fdGoodScoreAverage ASC,fdGoodID DESC";
                    break;
                case 11://收藏数(高-低)
                    this.propOrder = "ORDER BY fdGoodFavCount DESC,fdGoodID DESC";
                    break;
                case 12://收藏数(低-高)
                    this.propOrder = "ORDER BY fdGoodFavCount ASC,fdGoodID DESC";
                    break;
                default:
                    this.propOrder = "ORDER BY fdGoodSort DESC,fdGoodID DESC";
                    break;
            }

            this.propWhere = " 1=1 ";
            if (category != null)
            {
                this.propWhere += " AND fdCateIDPath like '" + category.fdCateIDPath + "%'";
            }
            if (brand != null)
            {
                this.propWhere += " AND (fdGoBrBrandID=" + brand.fdBranID.ToString();
                if (brand.Children != null && brand.Children.Count > 0)
                {
                    foreach (AW_Brand_bean child in brand.Children)
                    {
                        this.propWhere += " OR fdGoBrBrandID=" + child.fdBranID.ToString();
                    }
                }
                this.propWhere += ")";
            }
            if (status > 0)
                this.propWhere += " AND fdGoodStatus=" + status.ToString();
            if (keyword.Length > 0)
                this.propWhere += " AND fdGoodName like '%" + keyword.Replace("'", "''") + "%'";
            if (goodsID > 0)
                this.propWhere += " AND fdGoodID=" + goodsID.ToString();
            if (recommend == 0 || recommend == 1)
                this.propWhere += " AND fdGoodIsRecommend=" + recommend.ToString();
            else if (recommend == 2)
                this.propWhere += " AND fdGoodHomeJinbao=1";
            else if (recommend == 3)
                this.propWhere += " AND fdGoodHomeMeijiu=1";
            else if (recommend == 4)
                this.propWhere += " AND fdGoodHomeMingpai=1";
            if (promotion >= 0)
                this.propWhere += " AND fdGoodIsPromotion=" + promotion.ToString();

            List<AW_Goods_bean> list = new List<AW_Goods_bean>();
            foreach (DataRow row in this.funcCommon().Tables[0].Rows)
            {
                AW_Goods_bean bean = new AW_Goods_bean();
                bean.funcFromDataRow(row);
                bean.Category = new AW_Category_bean();
                bean.Category.funcFromDataRow(row);
                if (row["fdBranID"] != System.DBNull.Value)
                {
                    bean.Brand = new AW_Brand_bean();
                    bean.Brand.funcFromDataRow(row);
                }
                list.Add(bean);
            }
            return list;
        }


        /// <summary>
        /// 获取商品信息，包括商品图片和品牌
        /// </summary>
        /// <param name="goodsID"></param>
        /// <returns></returns>
        public AW_Goods_bean funcGetGoodsInfo(int goodsID)
        {
            AW_Goods_bean bean = AW_Goods_bean.funcGetByID(goodsID);
            if (bean != null)
            {
                bean.Pictures = (new AW_Goods_Picture_dao()).funcGetGoodsPictures(goodsID);
                AW_Goods_Brand_bean brand = (new AW_Goods_Brand_dao()).funcGetGoodsBrandRelation(goodsID);
                if (brand != null)
                {
                    bean.Brand = new AW_Brand_bean();
                    bean.Brand.fdBranID = brand.fdGoBrBrandID;
                }
            }

            return bean;
        }

        /// <summary>
        /// 获取点击最多的商品
        /// </summary>
        /// <param name="category"></param>
        /// <param name="brand"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<AW_Goods_bean> funcGetGoodsClickTopList(AW_Category_bean category, AW_Brand_bean brand, int top)
        {
            string key = "GoodsClickTop_" + top.ToString() + "_";
            if (category != null) key += category.fdCateID.ToString() + "_category";
            else if (brand != null) key += brand.fdBranID.ToString() + "_brand";
            List<AW_Goods_bean> list = (List<AW_Goods_bean>)HttpRuntime.Cache[key];
            if (list != null) return list;

            this.propSelect = " TOP " + top.ToString() + " fdGoodID,fdGoodName,fdGoodClickCount,fdGoodListImage";
            this.propTableApp = " INNER JOIN AW_Category ON fdGoodCategoryID=fdCateID";
            this.propOrder = " ORDER BY fdGoodClickCount DESC,fdGoodSort DESC";
            this.propWhere = " fdGoodStatus=1 ";
            if (category != null)
            {
                this.propWhere += " AND fdCateIDPath LIKE '" + category.fdCateIDPath + "%'";
            }
            if (brand != null)
            {
                this.propTableApp += " INNER JOIN AW_Goods_Brand ON fdGoBrGoodsID=fdGoodID";
                this.propWhere += "  AND (fdGoBrBrandID=" + brand.fdBranID.ToString();
                if (brand.Children != null && brand.Children.Count > 0)
                {
                    foreach (AW_Brand_bean child in brand.Children)
                        this.propWhere += " OR fdGoBrBrandID=" + child.fdBranID.ToString();
                }
                this.propWhere += ")";
            }
            list = this.funcGetList();
            HttpRuntime.Cache.Insert(key, list, null, DateTime.Now.AddMinutes(3), TimeSpan.Zero);
            return list;
        }

        /// <summary>
        /// 获取销售最多的商品
        /// </summary>
        /// <param name="category"></param>
        /// <param name="brand"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<AW_Goods_bean> funcGetGoodsSaleTopList(AW_Category_bean category, AW_Brand_bean brand, int top)
        {
            string key = "GoodsSaleTop_" + top.ToString() + "_";
            if (category != null) key += category.fdCateID.ToString() + "_category";
            else if (brand != null) key += brand.fdBranID.ToString() + "_brand";
            List<AW_Goods_bean> list = (List<AW_Goods_bean>)HttpRuntime.Cache[key];
            if (list != null) return list;

            this.propSelect = " TOP " + top.ToString() + " fdGoodID,fdGoodName,fdGoodSaleNum,fdGoodListImage,fdGoodMarketPrice,fdGoodSalePrice";
            this.propTableApp = " INNER JOIN AW_Category ON fdGoodCategoryID=fdCateID";
            this.propOrder = " ORDER BY fdGoodSaleNum DESC,fdGoodSort DESC";
            this.propWhere = " fdGoodStatus=1 ";
            if (category != null)
            {
                this.propWhere += " AND fdCateIDPath LIKE '" + category.fdCateIDPath + "%'";
            }
            if (brand != null)
            {
                this.propTableApp += " INNER JOIN AW_Goods_Brand ON fdGoBrGoodsID=fdGoodID";
                this.propWhere += "  AND (fdGoBrBrandID=" + brand.fdBranID.ToString();
                if (brand.Children != null && brand.Children.Count > 0)
                {
                    foreach (AW_Brand_bean child in brand.Children)
                        this.propWhere += " OR fdGoBrBrandID=" + child.fdBranID.ToString();
                }
                this.propWhere += ")";
            }
            list = this.funcGetList();
            HttpRuntime.Cache.Insert(key, list, null, DateTime.Now.AddMinutes(3), TimeSpan.Zero);
            return list;
        }

        /// <summary>
        /// 获取促销商品
        /// </summary>
        /// <param name="category"></param>
        /// <param name="brand"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<AW_Goods_bean> funcGetGoodsPromotionTopList(AW_Category_bean category, AW_Brand_bean brand, int top)
        {
            string key = "GoodsPromotionTop_" + top.ToString() + "_";
            if (category != null) key += category.fdCateID.ToString() + "_category";
            else if (brand != null) key += brand.fdBranID.ToString() + "_brand";
            List<AW_Goods_bean> list = (List<AW_Goods_bean>)HttpRuntime.Cache[key];
            if (list != null) return list;

            this.propSelect = " TOP " + top.ToString() + " fdGoodID,fdGoodName,fdGoodSalePrice,fdGoodPromPrice,fdGoodPromStartAt,fdGoodPromEndAt,fdGoodListImage";
            this.propTableApp = " INNER JOIN AW_Category ON fdGoodCategoryID=fdCateID";
            this.propOrder = " ORDER BY fdGoodSort DESC,fdGoodID DESC";
            this.propWhere = " fdGoodStatus=1 AND fdGoodIsRecommend=1 AND fdGoodPromStartAt<'" + DateTime.Now.ToString() + "' AND fdGoodPromEndAt>'" + DateTime.Now.AddDays(-1).ToString() + "'";
            if (category != null)
            {
                this.propWhere += " AND fdCateIDPath LIKE '" + category.fdCateIDPath + "%'";
            }
            if (brand != null)
            {
                this.propTableApp += " INNER JOIN AW_Goods_Brand ON fdGoBrGoodsID=fdGoodID";
                this.propWhere += "  AND (fdGoBrBrandID=" + brand.fdBranID.ToString();
                if (brand.Children != null && brand.Children.Count > 0)
                {
                    foreach (AW_Brand_bean child in brand.Children)
                        this.propWhere += " OR fdGoBrBrandID=" + child.fdBranID.ToString();
                }
                this.propWhere += ")";
            }
            list = this.funcGetList();
            HttpRuntime.Cache.Insert(key, list, null, DateTime.Now.AddMinutes(3), TimeSpan.Zero);
            return list;
        }

        /// <summary>
        /// 获取推荐商品
        /// </summary>
        /// <param name="category"></param>
        /// <param name="brand"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<AW_Goods_bean> funcGetGoodsRecommendTopList(AW_Category_bean category, AW_Brand_bean brand, int top)
        {
            string key = "GoodsRecommendTop_" + top.ToString() + "_";
            if (category != null) key += category.fdCateID.ToString() + "_category";
            else if (brand != null) key += brand.fdBranID.ToString() + "_brand";
            List<AW_Goods_bean> list = (List<AW_Goods_bean>)HttpRuntime.Cache[key];
            if (list != null) return list;

            this.propSelect = " TOP " + top.ToString() + " fdGoodID,fdGoodName,fdGoodMarketPrice,fdGoodSalePrice,fdGoodListImage";
            this.propTableApp = " INNER JOIN AW_Category ON fdGoodCategoryID=fdCateID";
            this.propOrder = " ORDER BY fdGoodSort DESC,fdGoodID DESC";
            this.propWhere = " fdGoodStatus=1 AND fdGoodIsRecommend=1";
            if (category != null)
            {
                this.propWhere += " AND fdCateIDPath LIKE '" + category.fdCateIDPath + "%'";
            }
            if (brand != null)
            {
                this.propTableApp += " INNER JOIN AW_Goods_Brand ON fdGoBrGoodsID=fdGoodID";
                this.propWhere += "  AND (fdGoBrBrandID=" + brand.fdBranID.ToString();
                if (brand.Children != null && brand.Children.Count > 0)
                {
                    foreach (AW_Brand_bean child in brand.Children)
                        this.propWhere += " OR fdGoBrBrandID=" + child.fdBranID.ToString();
                }
                this.propWhere += ")";
            }
            list = this.funcGetList();
            HttpRuntime.Cache.Insert(key, list, null, DateTime.Now.AddMinutes(3), TimeSpan.Zero);
            return list;
        }

        /// <summary>
        /// 获取最新商品
        /// </summary>
        /// <param name="category"></param>
        /// <param name="brand"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<AW_Goods_bean> funcGetGoodsLastTopList(AW_Category_bean category, AW_Brand_bean brand, int top)
        {
            string key = "GoodsLastTop_" + top.ToString() + "_";
            if (category != null) key += category.fdCateID.ToString() + "_category";
            else if (brand != null) key += brand.fdBranID.ToString() + "_brand";
            List<AW_Goods_bean> list = (List<AW_Goods_bean>)HttpRuntime.Cache[key];
            if (list != null) return list;

            this.propSelect = " TOP " + top.ToString() + " fdGoodID,fdGoodName,fdGoodMarketPrice,fdGoodSalePrice,fdGoodListImage";
            this.propTableApp = " INNER JOIN AW_Category ON fdGoodCategoryID=fdCateID";
            this.propOrder = " ORDER BY fdGoodSort DESC";
            this.propWhere = " fdGoodStatus=1";
            if (category != null)
            {
                this.propWhere += " AND fdCateIDPath LIKE '" + category.fdCateIDPath + "%'";
            }
            if (brand != null)
            {
                this.propTableApp += " INNER JOIN AW_Goods_Brand ON fdGoBrGoodsID=fdGoodID";
                this.propWhere += "  AND (fdGoBrBrandID=" + brand.fdBranID.ToString();
                if (brand.Children != null && brand.Children.Count > 0)
                {
                    foreach (AW_Brand_bean child in brand.Children)
                        this.propWhere += " OR fdGoBrBrandID=" + child.fdBranID.ToString();
                }
                this.propWhere += ")";
            }
            list = this.funcGetList();
            HttpRuntime.Cache.Insert(key, list, null, DateTime.Now.AddMinutes(3), TimeSpan.Zero);
            return list;
        }

        /// <summary>
        /// Ajax获取更新商品点击数、获取商品点击数、收藏数、评分人数以及得分、评论数
        /// </summary>
        /// <param name="goodsID"></param>
        /// <returns></returns>
        public AW_Goods_bean funcGetGoodsAjaxInfo(int goodsID)
        {
            //增加点击数
            this.funcExecute(String.Format("UPDATE AW_Goods SET fdGoodClickCount=fdGoodClickCount+1 WHERE fdGoodID={0}", goodsID));
            return AW_Goods_bean.funcGetByID(goodsID, "fdGoodID,fdGoodClickCount,fdGoodFavCount,fdGoodScoreCount,fdGoodScoreAverage,fdGoodCommentCount,fdGoodStockNum");
        }

        /// <summary>
        /// 增加商品的收藏数
        /// </summary>
        /// <param name="goodsID"></param>
        public void funcAddGoodsFavCount(int goodsID)
        {
            this.funcExecute(String.Format("UPDATE AW_Goods SET fdGoodFavCount=fdGoodFavCount+1 WHERE fdGoodID={0}", goodsID));
        }

        /// <summary>
        /// 减少商品收藏数
        /// </summary>
        /// <param name="goodsID"></param>
        public void funcPlusGoodsFavCount(int goodsID)
        {
            this.funcExecute(String.Format("UPDATE AW_Goods SET fdGoodFavCount=fdGoodFavCount-1 WHERE fdGoodID={0}", goodsID));
        }

        /// <summary>
        /// 获取最新商品
        /// </summary>
        /// <param name="category"></param>
        /// <param name="brand"></param>
        /// <param name="sort">0默认,1价格从高到低,2价格从低到高,3点击从高到低,4点击从低到高,5成交从高到低,6成交从低到高</param>
        /// <returns></returns>
        public List<AW_Goods_bean> funcGetGoodsList(AW_Category_bean category, AW_Brand_bean brand, int sortType, int pageSize, int pageIndex)
        {
            this.propGetCount = true;
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propSelect = " fdGoodID,fdGoodName,fdGoodMarketPrice,fdGoodSalePrice,fdGoodIsPromotion,fdGoodPromStartAt,fdGoodPromEndAt,fdGoodListImage,fdGoodDescription";
            this.propTableApp = " INNER JOIN AW_Category ON fdGoodCategoryID=fdCateID";
            this.propWhere = " fdGoodStatus=1";
            if (sortType == 0)
                this.propOrder = " ORDER BY fdGoodSort DESC";
            else if (sortType == 1)
                this.propOrder = " ORDER BY fdGoodSalePrice DESC,fdGoodSort DESC";
            else if (sortType == 2)
                this.propOrder = " ORDER BY fdGoodSalePrice ASC,fdGoodSort DESC";
            else if (sortType == 3)
                this.propOrder = " ORDER BY fdGoodClickCount DESC,fdGoodSort DESC";
            else if (sortType == 4)
                this.propOrder = " ORDER BY fdGoodClickCount ASC,fdGoodSort DESC";
            else if (sortType == 5)
                this.propOrder = " ORDER BY fdGoodSaleNum DESC,fdGoodSort DESC";
            else
                this.propOrder = " ORDER BY fdGoodSaleNum ASC,fdGoodSort DESC";

            if (category != null)
            {
                this.propWhere += " AND fdCateIDPath LIKE '" + category.fdCateIDPath + "%'";
            }

            if (brand != null)
            {
                this.propTableApp += " INNER JOIN AW_Goods_Brand ON fdGoBrGoodsID=fdGoodID";
                this.propWhere += "  AND (fdGoBrBrandID=" + brand.fdBranID.ToString();
                if (brand.Children != null && brand.Children.Count > 0)
                {
                    foreach (AW_Brand_bean child in brand.Children)
                        this.propWhere += " OR fdGoBrBrandID=" + child.fdBranID.ToString();
                }
                this.propWhere += ")";
            }

            List<AW_Goods_bean> list = this.funcGetList();
            return list;
        }

        /// <summary>
        /// 获取需要处理的搜索分词字典
        /// </summary>
        /// <returns></returns>
        public List<string> funcGetSearchSplitWords()
        {
            List<string> words = (List<string>)HttpRuntime.Cache["SearchSplitWords"];
            if (words != null) return words;

            string path = HttpContext.Current.Server.MapPath("~/App_Data/SearchSplit.xml");
            words = new List<string>();
            if (File.Exists(path))
            {
                XmlDocument xml;
                try
                {
                    xml = new XmlDocument();
                    xml.Load(path);
                    XmlNode root = xml.SelectSingleNode("words");
                    foreach (XmlNode node in root.SelectNodes("word"))
                    {
                        words.Add(node.InnerText);
                    }

                    if(words.Count == 0)
                    {
                        words = this.funcGetSearchDefaultSplitWords();
                    }
                }
                catch
                {
                    words = this.funcGetSearchDefaultSplitWords();
                }
            }
            else
            {
                words = this.funcGetSearchDefaultSplitWords();
            }

            HttpRuntime.Cache.Insert("SearchSplitWords", words, new System.Web.Caching.CacheDependency(path), DateTime.MaxValue, TimeSpan.FromMinutes(5));
            return words;
        }

        /// <summary>
        /// 获取默认的搜索分词字典
        /// </summary>
        /// <returns></returns>
        List<string> funcGetSearchDefaultSplitWords()
        {
            List<string> words = new List<string>();
            foreach (AW_Category_bean category1 in (new AW_Category_dao()).funcGetCategories())
            {
                words.Add(category1.fdCateName);
                foreach (AW_Category_bean category2 in category1.Children)
                {
                    words.Add(category2.fdCateName);
                    foreach (AW_Category_bean category3 in category2.Children)
                    {
                        words.Add(category3.fdCateName);
                    }
                }
            }
            foreach (AW_Brand_bean brand1 in (new AW_Brand_dao()).funcGetBrands())
            {
                words.Add(brand1.fdBranName);
                foreach (AW_Brand_bean brand2 in brand1.Children)
                {
                    words.Add(brand2.fdBranName);
                }
            }
            return words;
        }

        /// <summary>
        /// 搜索商品
        /// </summary>
        /// <param name="category"></param>
        /// <param name="brand"></param>
        /// <param name="priceStart"></param>
        /// <param name="priceEnd"></param>
        /// <param name="keyword"></param>
        /// <param name="sortType"></param>
        /// <returns></returns>
        public List<AW_Goods_bean> funcSearch(AW_Category_bean category, AW_Brand_bean brand, float priceStart, float priceEnd, string keyword, int sortType, int pageSize, int pageIndex)
        {
            this.propGetCount = true;
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propSelect = " fdGoodID,fdGoodName,fdGoodMarketPrice,fdGoodSalePrice,fdGoodIsPromotion,fdGoodPromStartAt,fdGoodPromEndAt,fdGoodListImage,fdGoodDescription";
            this.propTableApp = " INNER JOIN AW_Category ON fdGoodCategoryID=fdCateID";
            this.propWhere = " fdGoodStatus=1";
            if (sortType == 0)
                this.propOrder = " ORDER BY fdGoodSort DESC";
            else if (sortType == 1)
                this.propOrder = " ORDER BY fdGoodSalePrice DESC,fdGoodSort DESC";
            else if (sortType == 2)
                this.propOrder = " ORDER BY fdGoodSalePrice ASC,fdGoodSort DESC";
            else if (sortType == 3)
                this.propOrder = " ORDER BY fdGoodClickCount DESC,fdGoodSort DESC";
            else if (sortType == 4)
                this.propOrder = " ORDER BY fdGoodClickCount ASC,fdGoodSort DESC";
            else if (sortType == 5)
                this.propOrder = " ORDER BY fdGoodSaleNum DESC,fdGoodSort DESC";
            else
                this.propOrder = " ORDER BY fdGoodSaleNum ASC,fdGoodSort DESC";

            if (priceEnd > 0)
                this.propWhere += " AND fdGoodSalePrice<=" + priceEnd.ToString();
            if (priceStart > 0)
                this.propWhere += " AND fdGoodSalePrice>=" + priceStart.ToString();

            if (keyword.Trim().Length > 0)
            {
                foreach (string word in this.funcGetSearchSplitWords())
                {
                    if (keyword.Contains(word))
                    {
                        keyword = keyword.Replace(word, " " + word + " ");
                    }
                }
                foreach (string key in keyword.Split(new string[1] { " " }, StringSplitOptions.RemoveEmptyEntries))
                {
                    this.propWhere += " AND fdGoodName LIKE '%" + key.Replace("'", "''") + "%'";
                }
            }

            if (category != null)
            {
                this.propWhere += " AND fdCateIDPath LIKE '" + category.fdCateIDPath + "%'";
            }

            if (brand != null)
            {
                this.propTableApp += " INNER JOIN AW_Goods_Brand ON fdGoBrGoodsID=fdGoodID";
                this.propWhere += "  AND (fdGoBrBrandID=" + brand.fdBranID.ToString();
                if (brand.Children != null && brand.Children.Count > 0)
                {
                    foreach (AW_Brand_bean child in brand.Children)
                        this.propWhere += " OR fdGoBrBrandID=" + child.fdBranID.ToString();
                }
                this.propWhere += ")";
            }

            List<AW_Goods_bean> list = this.funcGetList();
            return list;
        }

        /// <summary>
        /// 根据ids获取商品
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<AW_Goods_bean> funcGetGoodsByIDs(string ids)
        {
            this.propWhere = " fdGoodID IN (" + ids + ")";

            List<AW_Goods_bean> list = new List<AW_Goods_bean>();
            foreach (DataRow row in this.funcCommon().Tables[0].Rows)
            {
                AW_Goods_bean bean = new AW_Goods_bean();
                bean.funcFromDataRow(row);
                list.Add(bean);
            }
            return list;
        }

        /// <summary>
        /// 库存不足商品数量
        /// </summary>
        /// <returns></returns>
        public int funcStockNotEnoughCount()
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                object rev = db.ExecuteScalar("SELECT COUNT(*) FROM AW_Goods WHERE fdGoodStockNum <= fdGoodSaleNum");
                return Convert.IsDBNull(rev) ? 0 : (int)rev;
            }
        }

        /// <summary>
        /// 更新商品评分
        /// </summary>
        /// <param name="goodId"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        public int funcScore(int goodId, int score)
        {
            AW_Goods_bean bean = AW_Goods_bean.funcGetByID(goodId, "fdGoodID,fdGoodScoreAverage,fdGoodScoreCount,fdGoodCommentCount");
            bean.fdGoodScoreAverage = (bean.fdGoodScoreAverage * bean.fdGoodScoreCount + score) / (bean.fdGoodScoreCount + 1);
            bean.fdGoodScoreCount++;
            bean.fdGoodCommentCount++;
            this._propFields = "fdGoodID,fdGoodScoreAverage,fdGoodScoreCount,fdGoodCommentCount";
            return this.funcUpdate(bean);
        }

        /// <summary>
        /// 更新商品的评分，重新求平均分值。
        /// </summary>
        public int funcScore(int goodsId)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                string cmdText = String.Format("update AW_Goods set fdGoodScoreAverage = (SELECT cast(round(avg(cast(fdCommScore as numeric(8,1))),1) as numeric(8,1)) FROM AW_Goods_Comment where fdCommGoodsID = {0}) where fdGoodID = {0}", goodsId);
                return db.ExecuteNonQuery(cmdText);
            }
        }

        /// <summary>
        /// 增加商品评论数 +1
        /// </summary>
        /// <param name="goodsId">商品编号</param>
        public int funcAddCommentCount(int goodsId)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                string cmdText = "UPDATE AW_Goods SET fdGoodCommentCount = fdGoodCommentCount+1 WHERE fdGoodID = " + goodsId;
                return db.ExecuteNonQuery(cmdText);
            }
        }

        /// <summary>
        /// 获取商品的相关商品
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public List<AW_Goods_bean> funcGetSimilarGoods(AW_Goods_bean goods)
        {
            this.propSelect = " fdGoodID,fdGoodName,fdGoodMarketPrice,fdGoodSalePrice,fdGoodIsPromotion,fdGoodPromStartAt,fdGoodPromEndAt,fdGoodListImage,fdGoodDescription";
            this.propWhere = " fdGoodStatus=1 AND fdGoodID<>" + goods.fdGoodID.ToString() + " AND fdGoodCategoryID=" + goods.Category.fdCateID.ToString();
            this.propOrder = " ORDER BY fdGoodSort DESC";

            List<AW_Goods_bean> list = this.funcGetList();
            if (list.Count == 0)
            {
                this.propTableApp = " INNER JOIN AW_Category ON fdGoodCategoryID=fdCateID";
                this.propWhere = " fdGoodStatus=1 AND fdGoodID<>" + goods.fdGoodID.ToString() + " AND fdCateIDPath LIKE '" + goods.Category.funcGetRootCategory().fdCateIDPath + "%'";
                list = this.funcGetList();
            }
            return list;
        }

        /// <summary>
        /// 上架/下架
        /// </summary>
        public int funcSetStatus(string ids, int status)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                string cmdText = String.Format("UPDATE AW_Goods SET fdGoodStatus = {1} WHERE fdGoodID IN ({0})", ids, status);
                return db.ExecuteNonQuery(cmdText);
            }
        }

        /// <summary>
        /// 推荐/取消推荐
        /// </summary>
        public int funcSetRecommend(string ids, int recommend)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                string cmdText = String.Format("UPDATE AW_Goods SET fdGoodIsRecommend = {1} WHERE fdGoodID IN ({0})", ids, recommend);
                return db.ExecuteNonQuery(cmdText);
            }
        }

        /// <summary>
        /// 取消促销
        /// </summary>
        public int funcSetPromotion(string ids)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                string cmdText = String.Format("UPDATE AW_Goods SET fdGoodIsPromotion=0,fdGoodPromPrice = 0,fdGoodPromStartAt='1900-1-1 0:00:00',fdGoodPromEndAt='1900-1-1 0:00:00' WHERE fdGoodID IN ({0})", ids);
                return db.ExecuteNonQuery(cmdText);
            }
        }

        /// <summary>
        /// 获取30元促销
        /// </summary>
        /// <returns></returns>
        public List<AW_Goods_bean> funcGetPromotionOf30Yuan(string cacheKey)
        {
            List<AW_Goods_bean> list = (List<AW_Goods_bean>)HttpRuntime.Cache[cacheKey];
            if (list != null) return list;

            this.propSelect = " TOP 5 fdGoodID,fdGoodName,fdGoodSalePrice,fdGoodPromPrice,fdGoodPromStartAt,fdGoodPromEndAt,fdGoodListImage,fdGoodMarketPrice";
            this.propTableApp = " INNER JOIN AW_Category ON fdGoodCategoryID=fdCateID";
            this.propOrder = " ORDER BY fdGoodSort DESC,fdGoodID DESC";
            this.propWhere = " fdGoodStatus=1 AND fdGoodIsPromotion=1 AND fdGoodPromStartAt<'" + DateTime.Now.ToString() + "' AND fdGoodPromEndAt>'" + DateTime.Now.AddDays(-1).ToString() + "'";
            this.propWhere += " AND fdGoodPromPrice<=30";
            list = this.funcGetList();
            HttpRuntime.Cache.Insert(cacheKey, list, null, DateTime.Now.AddMinutes(3), TimeSpan.Zero);
            return list;
        }

        /// <summary>
        /// 获取50元促销
        /// </summary>
        /// <returns></returns>
        public List<AW_Goods_bean> funcGetPromotionOf50Yuan(string cacheKey)
        {
            List<AW_Goods_bean> list = (List<AW_Goods_bean>)HttpRuntime.Cache[cacheKey];
            if (list != null) return list;

            this.propSelect = " TOP 5 fdGoodID,fdGoodName,fdGoodSalePrice,fdGoodPromPrice,fdGoodPromStartAt,fdGoodPromEndAt,fdGoodListImage,fdGoodMarketPrice";
            this.propTableApp = " INNER JOIN AW_Category ON fdGoodCategoryID=fdCateID";
            this.propOrder = " ORDER BY fdGoodSort DESC,fdGoodID DESC";
            this.propWhere = " fdGoodStatus=1 AND fdGoodIsPromotion=1 AND fdGoodPromStartAt<'" + DateTime.Now.ToString() + "' AND fdGoodPromEndAt>'" + DateTime.Now.AddDays(-1).ToString() + "'";
            this.propWhere += " AND fdGoodPromPrice>30 AND fdGoodPromPrice<=50";
            list = this.funcGetList();
            HttpRuntime.Cache.Insert(cacheKey, list, null, DateTime.Now.AddMinutes(3), TimeSpan.Zero);
            return list;
        }

        /// <summary>
        /// 获取首页劲爆推荐
        /// </summary>
        /// <returns></returns>
        public List<AW_Goods_bean> funcGetHomeJinbao(string cacheKey)
        {
            List<AW_Goods_bean> list = (List<AW_Goods_bean>)HttpRuntime.Cache[cacheKey];
            if (list != null) return list;

            this.propSelect = " TOP 1 fdGoodID,fdGoodName,fdGoodSalePrice,fdGoodPromPrice,fdGoodPromStartAt,fdGoodPromEndAt,fdGoodListImage,fdGoodMarketPrice";
            this.propTableApp = " INNER JOIN AW_Category ON fdGoodCategoryID=fdCateID";
            this.propOrder = " ORDER BY fdGoodSort DESC,fdGoodID DESC";
            this.propWhere = " fdGoodStatus=1 AND fdGoodHomeJinbao=1";
            list = this.funcGetList();
            HttpRuntime.Cache.Insert(cacheKey, list, null, DateTime.Now.AddMinutes(3), TimeSpan.Zero);
            return list;
        }

        /// <summary>
        /// 获取首页美酒推荐
        /// </summary>
        /// <returns></returns>
        public List<AW_Goods_bean> funcGetHomeMeijiu(string cacheKey)
        {
            List<AW_Goods_bean> list = (List<AW_Goods_bean>)HttpRuntime.Cache[cacheKey];
            if (list != null) return list;

            this.propSelect = " TOP 10 fdGoodID,fdGoodName,fdGoodSalePrice,fdGoodPromPrice,fdGoodPromStartAt,fdGoodPromEndAt,fdGoodListImage,fdGoodMarketPrice";
            this.propTableApp = " INNER JOIN AW_Category ON fdGoodCategoryID=fdCateID";
            this.propOrder = " ORDER BY fdGoodSort DESC,fdGoodID DESC";
            this.propWhere = " fdGoodStatus=1 AND fdGoodHomeMeijiu=1";
            list = this.funcGetList();
            HttpRuntime.Cache.Insert(cacheKey, list, null, DateTime.Now.AddMinutes(3), TimeSpan.Zero);
            return list;
        }

        /// <summary>
        /// 获取首页名牌推荐
        /// </summary>
        /// <returns></returns>
        public List<AW_Goods_bean> funcGetHomeMingpai(string cacheKey)
        {
            List<AW_Goods_bean> list = (List<AW_Goods_bean>)HttpRuntime.Cache[cacheKey];
            if (list != null) return list;

            this.propSelect = " TOP 10 fdGoodID,fdGoodName,fdGoodSalePrice,fdGoodPromPrice,fdGoodPromStartAt,fdGoodPromEndAt,fdGoodListImage,fdGoodMarketPrice";
            this.propTableApp = " INNER JOIN AW_Category ON fdGoodCategoryID=fdCateID";
            this.propOrder = " ORDER BY fdGoodSort DESC,fdGoodID DESC";
            this.propWhere = " fdGoodStatus=1 AND fdGoodHomeMingpai=1";
            list = this.funcGetList();
            HttpRuntime.Cache.Insert(cacheKey, list, null, DateTime.Now.AddMinutes(3), TimeSpan.Zero);
            return list;
        }

        /// <summary>
        /// 获取首页超值专区
        /// </summary>
        /// <returns></returns>
        public List<AW_Goods_bean> funcGetHomeCheap(string cacheKey)
        {
            List<AW_Goods_bean> list = (List<AW_Goods_bean>)HttpRuntime.Cache[cacheKey];
            if (list != null) return list;

            this.propSelect = " TOP 5 fdGoodID,fdGoodName,fdGoodSalePrice,fdGoodPromPrice,fdGoodPromStartAt,fdGoodPromEndAt,fdGoodListImage,fdGoodMarketPrice";
            this.propTableApp = " INNER JOIN AW_Category ON fdGoodCategoryID=fdCateID";
            this.propOrder = " ORDER BY fdGoodSort DESC,fdGoodID DESC";
            this.propWhere = " fdGoodStatus=1 AND fdGoodHomeCheap=1";
            list = this.funcGetList();
            HttpRuntime.Cache.Insert(cacheKey, list, null, DateTime.Now.AddMinutes(3), TimeSpan.Zero);
            return list;
        }

        /// <summary>
        /// 调整商品排序
        /// </summary>
        /// <param name="column"></param>
        /// <param name="goodsId"></param>
        /// <param name="nextId"></param>
        /// <param name="previewId"></param>
        public void funcSortGoods(int goodsId, int nextId, int previewId)
        {
            AW_Goods_bean goods = AW_Goods_bean.funcGetByID(goodsId, "fdGoodID,fdGoodSort");
            AW_Goods_bean next = nextId == 0 ? null : AW_Goods_bean.funcGetByID(nextId, "fdGoodID,fdGoodSort");
            AW_Goods_bean preview = previewId == 0 ? null : AW_Goods_bean.funcGetByID(previewId, "fdGoodID,fdGoodSort");

            this.propSelect = " fdGoodID,fdGoodSort";
            this.propOrder = " ORDER BY fdGoodSort DESC";

            this._propFields = "fdGoodID,fdGoodSort";

            if (next != null)
            {
                if (goods.fdGoodSort > next.fdGoodSort) //从上往下移
                {
                    this.propWhere += " AND fdGoodSort<=" + goods.fdGoodSort + " AND fdGoodSort>" + next.fdGoodSort.ToString();
                    List<AW_Goods_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        goods.fdGoodSort = list[list.Count - 1].fdGoodSort;
                        this.funcUpdate(goods);
                        for (int i = 1; i < list.Count; i++)
                        {
                            list[i].fdGoodSort = list[i - 1].fdGoodSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdGoodSort>=" + goods.fdGoodSort + " AND fdGoodSort<=" + next.fdGoodSort.ToString();
                    List<AW_Goods_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        goods.fdGoodSort = list[0].fdGoodSort;
                        this.funcUpdate(goods);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdGoodSort = list[i + 1].fdGoodSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
            }
            else if (preview != null)
            {
                if (goods.fdGoodSort > preview.fdGoodSort) //从上往下移
                {
                    this.propWhere += " AND fdGoodSort<=" + goods.fdGoodSort + " AND fdGoodSort>=" + preview.fdGoodSort.ToString();
                    List<AW_Goods_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        goods.fdGoodSort = list[list.Count - 1].fdGoodSort;
                        this.funcUpdate(goods);
                        for (int i = list.Count - 1; i > 0; i--)
                        {
                            list[i].fdGoodSort = list[i - 1].fdGoodSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdGoodSort>=" + goods.fdGoodSort + " AND fdGoodSort<" + preview.fdGoodSort.ToString();
                    List<AW_Goods_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        goods.fdGoodSort = list[0].fdGoodSort;
                        this.funcUpdate(goods);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdGoodSort = list[i + 1].fdGoodSort;
                            this.funcUpdate(list[i]);
                        }
                    }

                }
            }
        }

    }
}