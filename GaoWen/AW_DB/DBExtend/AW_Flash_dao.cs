using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWeb.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_FlaAW_dao
	{

        public List<AW_FlaAW_bean> funcGetFlashes()
        {
            this.propOrder = " ORDER BY fdFlasSort ASC";
            return this.funcGetList();
        }

        /// <summary>
        /// 排序调前
        /// </summary>
        public bool funcUp(int flashId)
        {
            AW_FlaAW_bean bean = AW_FlaAW_bean.funcGetByID(flashId);
            if (bean == null) return false;

            this.propSelect = " TOP 1 *";
            this.propWhere = " fdFlasSort<" + bean.fdFlasSort.ToString();
            this.propOrder = " ORDER BY fdFlasSort DESC";

            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count == 0) return false;
            AW_FlaAW_bean beanUp = new AW_FlaAW_bean();
            beanUp.funcFromDataRow(ds.Tables[0].Rows[0]);

            int temp = beanUp.fdFlasSort;
            beanUp.fdFlasSort = bean.fdFlasSort;
            bean.fdFlasSort = temp;
            funcUpdate(bean);
            funcUpdate(beanUp);
            this.funcClearCache();
            return true;
        }

        /// <summary>
        /// 排序调后
        /// </summary>
        public bool funcDown(int flashId)
        {
            AW_FlaAW_bean bean = AW_FlaAW_bean.funcGetByID(flashId);
            if (bean == null) return false;

            this.propSelect = " TOP 1 *";
            this.propWhere = " fdFlasSort>" + bean.fdFlasSort.ToString();
            this.propOrder = " ORDER BY fdFlasSort ASC";
            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count == 0) return false;
            AW_FlaAW_bean beanDown = new AW_FlaAW_bean();
            beanDown.funcFromDataRow(ds.Tables[0].Rows[0]);

            int temp = beanDown.fdFlasSort;
            beanDown.fdFlasSort = bean.fdFlasSort;
            bean.fdFlasSort = temp;
            funcUpdate(bean);
            funcUpdate(beanDown);
            this.funcClearCache();
            return true;
        }

        /// <summary>
        /// 获取首页幻灯片
        /// </summary>
        /// <returns></returns>
        public List<AW_FlaAW_bean> funcGetFlashList()
        {
            List<AW_FlaAW_bean> list = (List<AW_FlaAW_bean>)HttpRuntime.Cache["FLASH"];
            if (list != null)
            {
                return list;
            }
            list = new List<AW_FlaAW_bean>();
            this.propOrder = " ORDER BY fdFlasSort ASC";
            list = this.funcGetList();
            HttpRuntime.Cache.Insert("FLASH", list, null, DateTime.MaxValue, TimeSpan.FromMinutes(5));
            return list;
        }

        /// <summary>
        /// 获取幻灯片图片数量
        /// </summary>
        /// <returns></returns>
        public int funcGetFlashCount() { 
            return this.funcGetFlashList().Count;
        }

        public void funcClearCache() {
            if (HttpRuntime.Cache["FLASH"] != null)
            {
                HttpRuntime.Cache.Remove("FLASH");
            }
        }

        public override int funcInsert(Bean_Base aBean)
        {
            int result = base.funcInsert(aBean);
            this.funcClearCache();
            return result;
        }

        public override int funcUpdate(Bean_Base aBean)
        {
            int result = base.funcUpdate(aBean);
            this.funcClearCache();
            return result;
        }

        public override int funcDelete(int id)
        {
            int result = base.funcDelete(id);
            this.funcClearCache();
            return result;
        }
	}
}
