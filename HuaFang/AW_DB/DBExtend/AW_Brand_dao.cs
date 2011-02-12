using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Data;
using Studio.Web;

namespace AnyWell.AW_DL
{
	public partial class AW_Brand_dao
    {
        /// <summary>
        /// 获取品牌列表，支持二级分类，缓存
        /// </summary>
        /// <returns></returns>
        public List<AW_Brand_bean> funcGetBrands()
        {
            List<AW_Brand_bean> brands = (List<AW_Brand_bean>)HttpRuntime.Cache["Brands"];
            if (brands != null) return brands;

            DataSet ds = this.funcCommon();
            brands = new List<AW_Brand_bean>();
            foreach (DataRow row1 in ds.Tables[0].Select("fdBranParentID=0", "fdBranSort ASC"))
            {
                AW_Brand_bean brand1 = new AW_Brand_bean();
                brand1.funcFromDataRow(row1);
                brand1.Children = new List<AW_Brand_bean>();
                foreach (DataRow row2 in ds.Tables[0].Select("fdBranParentID=" + brand1.fdBranID.ToString(), "fdBranSort ASC"))
                {
                    AW_Brand_bean brand2 = new AW_Brand_bean();
                    brand2.funcFromDataRow(row2);
                    brand2.Parent = brand1;
                    brand1.Children.Add(brand2);
                }
                brands.Add(brand1);
            }
            ds.Dispose();

            HttpRuntime.Cache.Insert("Brands", brands, null, DateTime.MaxValue, TimeSpan.FromMinutes(5));
            return brands;
        }

        /// <summary>
        /// 根据访问路径获取品牌
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public AW_Brand_bean funcGetBrandInfo(string path)
        {
            if (path == "")
                return null;

            if (WebAgent.IsInt32(path))
                return funcGetBrandInfo(int.Parse(path));

            path = path.ToLower();

            foreach (AW_Brand_bean bean1 in this.funcGetBrands())
            {
                if (bean1.fdBranPath == path)
                    return bean1;
                foreach (AW_Brand_bean bean2 in bean1.Children)
                {
                    if (bean2.fdBranPath == path)
                        return bean2;
                }
            }
            return null;
        }

        /// <summary>
        /// 根据编号获取分类
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public AW_Brand_bean funcGetBrandInfo(int brandId)
        {
            if (brandId == 0)
                return null;

            foreach (AW_Brand_bean bean1 in this.funcGetBrands())
            {
                if (bean1.fdBranID == brandId)
                    return bean1;
                foreach (AW_Brand_bean bean2 in bean1.Children)
                {
                    if (bean2.fdBranID == brandId)
                        return bean2;
                }
            }
            return null;
        }



        /// <summary>
        /// 排序调前
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public bool funcUp(int brandID)
        {
            AW_Brand_bean bean = this.funcGetBrandInfo(brandID);
            if (bean == null) return false;

            this.propSelect = " TOP 1 *";
            this.propWhere = " fdBranParentID=" + bean.fdBranParentID.ToString() + " and fdBranSort<" + bean.fdBranSort.ToString();
            this.propOrder = " ORDER BY fdBranSort DESC";

            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count == 0) return false;
            AW_Brand_bean bean2 = new AW_Brand_bean();
            bean2.funcFromDataRow(ds.Tables[0].Rows[0]);

            int temp = bean2.fdBranSort;
            bean2.fdBranSort = bean.fdBranSort;
            bean.fdBranSort = temp;
            funcUpdate(bean);
            funcUpdate(bean2);
            return true;
        }

        /// <summary>
        /// 排序调后
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public bool funcDown(int brandID)
        {
            AW_Brand_bean bean = this.funcGetBrandInfo(brandID);
            if (bean == null) return false;

            this.propSelect = " TOP 1 *";
            this.propWhere = " fdBranParentID=" + bean.fdBranParentID.ToString() + " and fdBranSort>" + bean.fdBranSort.ToString();
            this.propOrder = " ORDER BY fdBranSort ASC";
            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count == 0) return false;
            AW_Brand_bean bean2 = new AW_Brand_bean();
            bean2.funcFromDataRow(ds.Tables[0].Rows[0]);

            int temp = bean2.fdBranSort;
            bean2.fdBranSort = bean.fdBranSort;
            bean.fdBranSort = temp;
            funcUpdate(bean);
            funcUpdate(bean2);
            return true;
        }



        public override int funcInsert(Bean_Base aBean)
        {
            HttpRuntime.Cache.Remove("Brands");
            return base.funcInsert(aBean);
        }

        public override int funcUpdate(Bean_Base aBean)
        {
            HttpRuntime.Cache.Remove("Brands");
            return base.funcUpdate(aBean);
        }

        public override int funcDelete(int aID)
        {
            HttpRuntime.Cache.Remove("Brands");
            return base.funcDelete(aID);
        }

	}
}
