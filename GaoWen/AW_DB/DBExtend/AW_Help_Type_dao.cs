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
	public partial class AW_Help_Type_dao
	{

        public List<AW_Help_Type_bean> funcGetHelpTypes()
        {
            this.propOrder = " ORDER BY fdTypeSort ASC";
            return this.funcGetList();
        }

        /// <summary>
        /// 排序调前
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public bool funcUp(int helpTypeId)
        {
            AW_Help_Type_bean bean = AW_Help_Type_bean.funcGetByID(helpTypeId);
            if (bean == null) return false;

            this.propSelect = " TOP 1 *";
            this.propWhere = " fdTypeSort<" + bean.fdTypeSort.ToString();
            this.propOrder = " ORDER BY fdTypeSort DESC";

            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count == 0) return false;
            AW_Help_Type_bean beanUp = new AW_Help_Type_bean();
            beanUp.funcFromDataRow(ds.Tables[0].Rows[0]);

            int temp = beanUp.fdTypeSort;
            beanUp.fdTypeSort = bean.fdTypeSort;
            bean.fdTypeSort = temp;
            funcUpdate(bean);
            funcUpdate(beanUp);
            return true;
        }

        /// <summary>
        /// 排序调后
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public bool funcDown(int helpTypeId)
        {
            AW_Help_Type_bean bean = AW_Help_Type_bean.funcGetByID(helpTypeId);
            if (bean == null) return false;

            this.propSelect = " TOP 1 *";
            this.propWhere = " fdTypeSort>" + bean.fdTypeSort.ToString();
            this.propOrder = " ORDER BY fdTypeSort ASC";
            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count == 0) return false;
            AW_Help_Type_bean beanDown = new AW_Help_Type_bean();
            beanDown.funcFromDataRow(ds.Tables[0].Rows[0]);

            int temp = beanDown.fdTypeSort;
            beanDown.fdTypeSort = bean.fdTypeSort;
            bean.fdTypeSort = temp;
            funcUpdate(bean);
            funcUpdate(beanDown);
            return true;
        }


	}
}
