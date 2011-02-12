using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Help_dao
	{

        public List<AW_Help_bean> funcHelpSearch(int typeId)
        {
            this.propWhere = " fdHelpTypeID = " + typeId.ToString();
            this.propOrder = "ORDER BY fdHelpSort ASC";
            return this.funcGetList();
        }


        /// <summary>
        /// 排序调前（针对同一个分类下面）
        /// </summary>
        public bool funcUp(int helpId, int helpTypeId)
        {
            AW_Help_bean bean = AW_Help_bean.funcGetByID(helpId);
            if (bean == null) return false;

            this.propSelect = " TOP 1 *";
            this.propWhere = String.Format(" fdHelpTypeID = {0} and fdHelpSort < {1}", bean.fdHelpTypeID, bean.fdHelpSort);
            this.propOrder = " ORDER BY fdHelpSort DESC";

            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count == 0) return false;
            AW_Help_bean beanUp = new AW_Help_bean();
            beanUp.funcFromDataRow(ds.Tables[0].Rows[0]);

            int temp = beanUp.fdHelpSort;
            beanUp.fdHelpSort = bean.fdHelpSort;
            bean.fdHelpSort = temp;
            funcUpdate(bean);
            funcUpdate(beanUp);
            return true;
        }

        /// <summary>
        /// 排序调后（针对同一个分类下面）
        /// </summary>
        public bool funcDown(int helpId, int helpTypeId)
        {
            AW_Help_bean bean = AW_Help_bean.funcGetByID(helpId);
            if (bean == null) return false;

            this.propSelect = " TOP 1 *";
            this.propWhere = String.Format(" fdHelpTypeID = {0} and fdHelpSort > {1}", bean.fdHelpTypeID, bean.fdHelpSort);
            this.propOrder = " ORDER BY fdHelpSort ASC";
            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count == 0) return false;
            AW_Help_bean beanDown = new AW_Help_bean();
            beanDown.funcFromDataRow(ds.Tables[0].Rows[0]);

            int temp = beanDown.fdHelpSort;
            beanDown.fdHelpSort = bean.fdHelpSort;
            bean.fdHelpSort = temp;
            funcUpdate(bean);
            funcUpdate(beanDown);
            return true;
        }

        /// <summary>
        /// 获取第一个
        /// </summary>
        /// <returns></returns>
        public AW_Help_bean funcGetFirst()
        {
            this.propSelect = "top 1 *";
            this.propOrder = " ORDER BY fdHelpID ASC";
            List<AW_Help_bean> list = this.funcGetList();
            return list.Count == 0 ? null : list[0];
        }


	}
}
