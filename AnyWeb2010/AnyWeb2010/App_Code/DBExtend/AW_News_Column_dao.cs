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
	public partial class AW_News_Column_dao
	{
        /// <summary>
        /// 获取栏目信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public AW_News_Column_bean funcGetColumnInfo(string path)
        {
            if (path == "")
                return null;

            if (WebAgent.IsInt32(path))
                return this.funcGetColumnInfo(int.Parse(path));

            foreach (AW_News_Column_bean bean1 in this.funcGetColumns())
            {
                if (bean1.fdColuPath == path)
                    return bean1;
                foreach (AW_News_Column_bean bean2 in bean1.Children)
                {
                    if (bean2.fdColuPath == path)
                        return bean2;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取栏目信息
        /// </summary>
        /// <param name="columnId"></param>
        /// <returns></returns>
        public AW_News_Column_bean funcGetColumnInfo(int columnId)
        {

            foreach (AW_News_Column_bean bean1 in this.funcGetColumns())
            {
                if (bean1.fdColuID == columnId)
                    return bean1;
                foreach (AW_News_Column_bean bean2 in bean1.Children)
                {
                    if (bean2.fdColuID == columnId)
                        return bean2;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取所有栏目(缓存)
        /// </summary>
        /// <returns></returns>
        public List<AW_News_Column_bean> funcGetColumns()
        {
            List<AW_News_Column_bean> list = (List<AW_News_Column_bean>)HttpRuntime.Cache["NEWS_COLUMNS"];
            if (list != null) return list;

            DataSet ds = this.funcCommon();
            list = new List<AW_News_Column_bean>();
            foreach (DataRow row1 in ds.Tables[0].Select("fdColuParentID=0", "fdColuSort ASC"))
            {
                AW_News_Column_bean bean1 = new AW_News_Column_bean();
                bean1.funcFromDataRow(row1);
                bean1.Children = new List<AW_News_Column_bean>();
                foreach (DataRow row2 in ds.Tables[0].Select("fdColuParentID="+bean1.fdColuID.ToString(), "fdColuSort ASC"))
                {
                    AW_News_Column_bean bean2 = new AW_News_Column_bean();
                    bean2.funcFromDataRow(row2);
                    bean2.Parent = bean1;
                    bean1.Children.Add(bean2);
                }
                list.Add(bean1);
            }
            HttpRuntime.Cache.Insert("NEWS_COLUMNS", list, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero);
            return list;
        }

        public override int funcInsert(Bean_Base aBean)
        {
            int count = base.funcInsert(aBean);
            HttpRuntime.Cache.Remove("NEWS_COLUMNS");
            return count;
        }

        public override int funcDelete(int id)
        {
            int count = base.funcDelete(id);
            HttpRuntime.Cache.Remove("NEWS_COLUMNS");
            return count;
        }

        public override int funcUpdate(Bean_Base aBean)
        {
            int count = base.funcUpdate(aBean);
            HttpRuntime.Cache.Remove("NEWS_COLUMNS");
            return count;
        }

        /// <summary>
        /// 排序调前
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public bool funcUp(int columnId)
        {
            AW_News_Column_bean bean = AW_News_Column_bean.funcGetByID(columnId);
            if (bean == null) return false;

            this.propSelect = " TOP 1 *";
            this.propWhere = " fdColuParentID=" + bean.fdColuParentID.ToString() + " AND fdColuSort<" + bean.fdColuSort.ToString();
            this.propOrder = " ORDER BY fdColuSort DESC";

            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count == 0) return false;
            AW_News_Column_bean beanUp = new AW_News_Column_bean();
            beanUp.funcFromDataRow(ds.Tables[0].Rows[0]);

            int temp = beanUp.fdColuSort;
            beanUp.fdColuSort = bean.fdColuSort;
            bean.fdColuSort = temp;
            funcUpdate(bean);
            funcUpdate(beanUp);
            return true;
        }

        /// <summary>
        /// 排序调后
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public bool funcDown(int columnId)
        {
            AW_News_Column_bean bean = AW_News_Column_bean.funcGetByID(columnId);
            if (bean == null) return false;

            this.propSelect = " TOP 1 *";
            this.propWhere = " fdColuParentID=" + bean.fdColuParentID.ToString() + " AND fdColuSort>" + bean.fdColuSort.ToString();
            this.propOrder = " ORDER BY fdColuSort ASC";
            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count == 0) return false;
            AW_News_Column_bean beanDown = new AW_News_Column_bean();
            beanDown.funcFromDataRow(ds.Tables[0].Rows[0]);

            int temp = beanDown.fdColuSort;
            beanDown.fdColuSort = bean.fdColuSort;
            bean.fdColuSort = temp;
            funcUpdate(bean);
            funcUpdate(beanDown);
            return true;
        }

	}
}
