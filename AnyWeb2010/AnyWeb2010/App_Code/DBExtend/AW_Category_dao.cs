using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWeb.AW_DL;
using System.Web;
using Studio.Data;
using Studio.Web;

namespace AnyWeb.AW_DL
{
	public partial class AW_Category_dao
    {
        /// <summary>
        /// 获取分类列表，支持三级分类，缓存
        /// </summary>
        /// <returns></returns>
        public List<AW_Category_bean> funcGetCategories()
        {
            List<AW_Category_bean> categories = (List<AW_Category_bean>)HttpRuntime.Cache["Categories"];
            if (categories != null) return categories;

            DataSet ds = this.funcCommon();
            categories = new List<AW_Category_bean>();
            foreach (DataRow row1 in ds.Tables[0].Select("fdCateParent=0","fdCateSort ASC"))
            {
                AW_Category_bean category1 = new AW_Category_bean();
                category1.funcFromDataRow(row1);
                category1.Children = new List<AW_Category_bean>();
                foreach (DataRow row2 in ds.Tables[0].Select("fdCateParent=" + category1.fdCateID.ToString(), "fdCateSort ASC"))
                {
                    AW_Category_bean category2 = new AW_Category_bean();
                    category2.funcFromDataRow(row2);
                    category2.Parent = category1;
                    category2.Children = new List<AW_Category_bean>();
                    foreach (DataRow row3 in ds.Tables[0].Select("fdCateParent=" + category2.fdCateID.ToString(), "fdCateSort ASC"))
                    {
                        AW_Category_bean category3 = new AW_Category_bean();
                        category3.funcFromDataRow(row3);
                        category3.Parent = category2;
                        category2.Children.Add(category3);
                    }
                    category1.Children.Add(category2);
                }
                categories.Add(category1);
            }
            ds.Dispose();

            HttpRuntime.Cache.Insert("Categories", categories, null, DateTime.MaxValue, TimeSpan.FromMinutes(5));
            return categories;
        }

        /// <summary>
        /// 根据访问路径获取分类
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public AW_Category_bean funcGetCategoryInfo(string path)
        {
            if (path == "") 
                return null;
            if (WebAgent.IsInt32(path))
                return this.funcGetCategoryInfo(int.Parse(path));

            path = path.ToLower();

            foreach (AW_Category_bean bean1 in this.funcGetCategories())
            {
                if (bean1.fdCatePath == path)
                    return bean1;
                foreach (AW_Category_bean bean2 in bean1.Children)
                {
                    if (bean2.fdCatePath == path)
                        return bean2;
                    foreach (AW_Category_bean bean3 in bean2.Children)
                    {
                        if (bean3.fdCatePath == path)
                            return bean3;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 根据编号获取分类
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public AW_Category_bean funcGetCategoryInfo(int categoryId)
        {
            if (categoryId == 0)
                return null;

            foreach (AW_Category_bean bean1 in this.funcGetCategories())
            {
                if (bean1.fdCateID == categoryId)
                    return bean1;
                foreach (AW_Category_bean bean2 in bean1.Children)
                {
                    if (bean2.fdCateID == categoryId)
                        return bean2;
                    foreach (AW_Category_bean bean3 in bean2.Children)
                    {
                        if (bean3.fdCateID == categoryId)
                            return bean3;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 检查分类是否存在商品
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public bool funcCheckCategoryExistGoods(int categoryId)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                int count = (int)db.ExecuteScalar("SELECT COUNT(*) FROM AW_Goods WHERE fdGoodCategoryID="+categoryId.ToString());
                return count > 0;
            }
        }

        /// <summary>
        /// 排序调前
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public bool funcUp(int categoryID)
        {
            AW_Category_bean bean = this.funcGetCategoryInfo(categoryID);
            if (bean == null) return false;

            this.propSelect = " TOP 1 *";
            this.propWhere = " fdCateParent=" + bean.fdCateParent.ToString() + " and fdCateSort<" + bean.fdCateSort.ToString();
            this.propOrder = " ORDER BY fdCateSort DESC";

            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count == 0) return false;
            AW_Category_bean bean2 = new AW_Category_bean();
            bean2.funcFromDataRow(ds.Tables[0].Rows[0]);

            int temp = bean2.fdCateSort;
            bean2.fdCateSort = bean.fdCateSort;
            bean.fdCateSort = temp;
            funcUpdate(bean);
            funcUpdate(bean2);
            return true;
        }

        /// <summary>
        /// 排序调后
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public bool funcDown(int categoryID)
        {
            AW_Category_bean bean = this.funcGetCategoryInfo(categoryID);
            if (bean == null) return false;

            this.propSelect = " TOP 1 *";
            this.propWhere = " fdCateParent=" + bean.fdCateParent.ToString() + " and fdCateSort>" + bean.fdCateSort.ToString();
            this.propOrder = " ORDER BY fdCateSort ASC";
            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count == 0) return false;
            AW_Category_bean bean2 = new AW_Category_bean();
            bean2.funcFromDataRow(ds.Tables[0].Rows[0]);

            int temp = bean2.fdCateSort;
            bean2.fdCateSort = bean.fdCateSort;
            bean.fdCateSort = temp;
            funcUpdate(bean);
            funcUpdate(bean2);
            return true;
        }



        public override int funcInsert(Bean_Base aBean)
        {
            HttpRuntime.Cache.Remove("Categories");
            return base.funcInsert(aBean);
        }

        public override int funcUpdate(Bean_Base aBean)
        {
            HttpRuntime.Cache.Remove("Categories");
            return base.funcUpdate(aBean);
        }

        public override int funcDelete(int aID)
        {
            HttpRuntime.Cache.Remove("Categories");
            return base.funcDelete(aID);
        }

	}
}
