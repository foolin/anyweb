using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;
using AnyWell.Configs;

namespace AnyWell.AW_DL
{
	public partial class AW_Navigation_dao
	{
        /// <summary>
        /// 获取所有导航栏
        /// </summary>
        /// <returns></returns>
        public List<AW_Navigation_bean> funcGetNavigations()
        {
            List<AW_Navigation_bean> list;
            if (HttpRuntime.Cache["NAVIGATION_CACHE_NAVIGATIONS"] != null)
            {
                return (List<AW_Navigation_bean>)HttpRuntime.Cache["NAVIGATION_CACHE_NAVIGATIONS"];
            }

            list = new List<AW_Navigation_bean>();
            DataSet ds = this.funcCommon();
            foreach (DataRow row1 in ds.Tables[0].Select("fdNaviParentID=0", "fdNaviSort ASC"))
            {
                AW_Navigation_bean bean1 = new AW_Navigation_bean();
                bean1.funcFromDataRow(row1);
                bean1.Children = new List<AW_Navigation_bean>();
                foreach (DataRow row2 in ds.Tables[0].Select("fdNaviParentID=" + bean1.fdNaviID.ToString(), "fdNaviSort ASC"))
                {
                    AW_Navigation_bean bean2 = new AW_Navigation_bean();
                    bean2.funcFromDataRow(row2);
                    bean2.Parent = bean1;
                    bean1.Children.Add(bean2);
                }
                list.Add(bean1);
            }
            HttpRuntime.Cache.Insert("NAVIGATION_CACHE_NAVIGATIONS", list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20), System.Web.Caching.CacheItemPriority.NotRemovable, null);
            return list;
        }

        /// <summary>
        /// 读取导航栏信息
        /// </summary>
        /// <param name="naviId"></param>
        /// <returns></returns>
        public AW_Navigation_bean funcGetNavigationByID(int naviId) 
        {
            foreach (AW_Navigation_bean bean1 in this.funcGetNavigations()) 
            {
                if (bean1.fdNaviID == naviId)
                    return bean1;
                foreach (AW_Navigation_bean bean2 in bean1.Children) 
                {
                    if (bean2.fdNaviID == naviId)
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
        public bool funcUp(int navigationId)
        {
            AW_Navigation_bean bean = AW_Navigation_bean.funcGetByID(navigationId);
            if (bean == null) return false;

            this.propSelect = " TOP 1 *";
            this.propWhere = " fdNaviParentID=" + bean.fdNaviParentID.ToString() + " AND fdNaviSort<" + bean.fdNaviSort.ToString();
            this.propOrder = " ORDER BY fdNaviSort DESC";

            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count == 0) return false;
            AW_Navigation_bean beanUp = new AW_Navigation_bean();
            beanUp.funcFromDataRow(ds.Tables[0].Rows[0]);

            int temp = beanUp.fdNaviSort;
            beanUp.fdNaviSort = bean.fdNaviSort;
            bean.fdNaviSort = temp;
            funcUpdate(bean);
            funcUpdate(beanUp);
            CacheAgent.ClearCache("NAVIGATION_CACHE_");
            return true;
        }

        /// <summary>
        /// 排序调后
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public bool funcDown(int columnId)
        {
            AW_Navigation_bean bean = AW_Navigation_bean.funcGetByID(columnId);
            if (bean == null) return false;

            this.propSelect = " TOP 1 *";
            this.propWhere = " fdNaviParentID=" + bean.fdNaviParentID.ToString() + " AND fdNaviSort>" + bean.fdNaviSort.ToString();
            this.propOrder = " ORDER BY fdNaviSort ASC";
            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count == 0) return false;
            AW_Navigation_bean beanDown = new AW_Navigation_bean();
            beanDown.funcFromDataRow(ds.Tables[0].Rows[0]);

            int temp = beanDown.fdNaviSort;
            beanDown.fdNaviSort = bean.fdNaviSort;
            bean.fdNaviSort = temp;
            funcUpdate(bean);
            funcUpdate(beanDown);
            CacheAgent.ClearCache("NAVIGATION_CACHE_");
            return true;
        }

        public override int funcInsert(Bean_Base aBean)
        {
            int result = base.funcInsert(aBean);
            CacheAgent.ClearCache("NAVIGATION_CACHE_");
            return result;
        }

        public override int funcUpdate(Bean_Base aBean)
        {
            int result = base.funcUpdate(aBean);
            CacheAgent.ClearCache("NAVIGATION_CACHE_");
            return result;
        }

        /// <summary>
        /// 删除栏目
        /// </summary>
        /// <param name="columnId"></param>
        public void funcDeleteNavigation(int navigationId)
        {
            string sql = string.Format("DELETE AW_Navigation WHERE fdNaviID={0} OR fdNaviParentID={0}", navigationId);
            this.funcExecute(sql);
            CacheAgent.ClearCache("NAVIGATION_CACHE_");
        }
	}
}
