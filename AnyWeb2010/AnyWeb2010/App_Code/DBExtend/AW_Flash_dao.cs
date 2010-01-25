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
            return true;
        }

	}
}
