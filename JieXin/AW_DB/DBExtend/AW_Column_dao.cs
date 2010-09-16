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
	public partial class AW_Column_dao
	{
        /// <summary>
        /// 获取所有栏目
        /// </summary>
        /// <returns></returns>
        public List<AW_Column_bean> funcGetColumns()
        {
            List<AW_Column_bean> list;
            if (HttpRuntime.Cache["COLUMN_CACHE_COLUMNS"] != null)
            {
                return (List<AW_Column_bean>)HttpRuntime.Cache["COLUMN_CACHE_COLUMNS"];
            }

            list = new List<AW_Column_bean>();
            DataSet ds = this.funcCommon();
            foreach (DataRow row1 in ds.Tables[0].Select("fdColuParentID=0", "fdColuSort ASC"))
            {
                AW_Column_bean bean1 = new AW_Column_bean();
                bean1.funcFromDataRow(row1);
                bean1.Children = new List<AW_Column_bean>();
                foreach (DataRow row2 in ds.Tables[0].Select("fdColuParentID=" + bean1.fdColuID.ToString(), "fdColuSort ASC"))
                {
                    AW_Column_bean bean2 = new AW_Column_bean();
                    bean2.funcFromDataRow(row2);
                    bean2.Parent = bean1;
                    bean1.Children.Add(bean2);
                }
                list.Add(bean1);
            }
            HttpRuntime.Cache.Insert("COLUMN_CACHE_COLUMNS", list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20), System.Web.Caching.CacheItemPriority.NotRemovable, null);
            return list;
        }

        /// <summary>
        /// 获取栏目信息
        /// </summary>
        /// <param name="columnId"></param>
        /// <returns></returns>
        public AW_Column_bean funcGetColumnInfo(int columnId)
        {

            foreach (AW_Column_bean bean1 in this.funcGetColumns())
            {
                if (bean1.fdColuID == columnId)
                    return bean1;
                foreach (AW_Column_bean bean2 in bean1.Children)
                {
                    if (bean2.fdColuID == columnId)
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
        public bool funcUp(int columnId)
        {
            AW_Column_bean bean = AW_Column_bean.funcGetByID(columnId);
            if (bean == null) return false;

            this.propSelect = " TOP 1 *";
            this.propWhere = " fdColuParentID=" + bean.fdColuParentID.ToString() + " AND fdColuSort<" + bean.fdColuSort.ToString();
            this.propOrder = " ORDER BY fdColuSort DESC";

            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count == 0) return false;
            AW_Column_bean beanUp = new AW_Column_bean();
            beanUp.funcFromDataRow(ds.Tables[0].Rows[0]);

            int temp = beanUp.fdColuSort;
            beanUp.fdColuSort = bean.fdColuSort;
            bean.fdColuSort = temp;
            funcUpdate(bean);
            funcUpdate(beanUp);
            CacheAgent.ClearCache("COLUMN_CACHE_");
            return true;
        }

        /// <summary>
        /// 排序调后
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public bool funcDown(int columnId)
        {
            AW_Column_bean bean = AW_Column_bean.funcGetByID(columnId);
            if (bean == null) return false;

            this.propSelect = " TOP 1 *";
            this.propWhere = " fdColuParentID=" + bean.fdColuParentID.ToString() + " AND fdColuSort>" + bean.fdColuSort.ToString();
            this.propOrder = " ORDER BY fdColuSort ASC";
            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count == 0) return false;
            AW_Column_bean beanDown = new AW_Column_bean();
            beanDown.funcFromDataRow(ds.Tables[0].Rows[0]);

            int temp = beanDown.fdColuSort;
            beanDown.fdColuSort = bean.fdColuSort;
            bean.fdColuSort = temp;
            funcUpdate(bean);
            funcUpdate(beanDown);
            CacheAgent.ClearCache("COLUMN_CACHE_");
            return true;
        }

        public override int funcInsert(Bean_Base aBean)
        {
            int result = base.funcInsert(aBean);
            CacheAgent.ClearCache("COLUMN_CACHE_");
            return result;
        }

        public override int funcUpdate(Bean_Base aBean)
        {
            int result = base.funcUpdate(aBean);
            CacheAgent.ClearCache("COLUMN_CACHE_");
            return result;
        }

        /// <summary>
        /// 删除栏目
        /// </summary>
        /// <param name="columnId"></param>
        public void funcDeleteColumn(int columnId)
        {
            string sql = string.Format("DELETE AW_Column WHERE fdColuID={0} OR fdColuParentID={0}", columnId);
            this.funcExecute(sql);
            CacheAgent.ClearCache("COLUMN_CACHE_");
        }

        /**************************************************自定义控件********************************************************************************/
        /// <summary>
        /// 下一个栏目编号
        /// </summary>
        /// <param name="articleID"></param>
        /// <param name="columnid"></param>
        /// <returns></returns>
        public int funcGetNextColumnIDByUC(int columnID)
        {
            string cmdText = "SELECT TOP 1 fdColuID FROM AW_Column WHERE fdColuParentID=(SELECT fdColuParentID FROM AW_Column WHERE fdColuID=@fdColuID) AND fdColuSort<(SELECT fdColuSort FROM AW_Column WHERE fdColuID=@fdColuID) ORDER BY fdColuSort DESC";

            object nextColumnID;
            using (IDbExecutor db = this.NewExecutor())
            {
                nextColumnID = db.ExecuteScalar(CommandType.Text, cmdText,
                this.NewParam("@fdColuID", columnID));
            }
            if (nextColumnID == null || nextColumnID == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return int.Parse(nextColumnID.ToString());
            }
        }

        /// <summary>
        /// 上一个栏目编号
        /// </summary>
        /// <param name="articleID"></param>
        /// <param name="columnid"></param>
        /// <returns></returns>
        public int funcGetPreviousColumnIDByUC(int columnID)
        {
            string cmdText = "SELECT TOP 1 fdColuID FROM AW_Column WHERE fdColuParentID=(SELECT fdColuParentID FROM AW_Column WHERE fdColuID=@fdColuID) AND fdColuSort>(SELECT fdColuSort FROM AW_Column WHERE fdColuID=@fdColuID) ORDER BY fdColuSort";

            object previousColumnID;
            using (IDbExecutor db = this.NewExecutor())
            {
                previousColumnID = db.ExecuteScalar(CommandType.Text, cmdText,
                this.NewParam("@fdColuID", columnID));
            }
            if (previousColumnID == null || previousColumnID == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return int.Parse(previousColumnID.ToString());
            }
        }

        /// <summary>
        /// 获取栏目列表
        /// </summary>
        /// <param name="columnID"></param>
        /// <param name="parent"></param>
        /// <param name="topCount"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="cacheName"></param>
        /// <returns></returns>
        public List<AW_Column_bean> funcGetColumnListByUC(int columnID, bool parent, int topCount, string where, string order, string cacheName)
        {
            if (!string.IsNullOrEmpty(cacheName) && HttpRuntime.Cache["COLUMN_CACHE_UC_" + cacheName] != null)
            {
                return (List<AW_Column_bean>)HttpRuntime.Cache["COLUMN_CACHE_UC_" + cacheName];
            }
            this.propSelect = "*";

            if (topCount > 0)
            {
                this.propSelect = "TOP " + topCount.ToString() + " " + this.propSelect;
            }

            this.propWhere = "1=1";

            if (parent)
            {
                this.propWhere += " AND fdColuParentID=(SELECT fdColuParentID FROM AW_Column WHERE fdColuID=@fdColuID)";
            }
            else
            {
                this.propWhere += " AND fdColuParentID=@fdColuID";
            }

            if (string.IsNullOrEmpty(where) == false)
            {
                this.propWhere += " AND " + where.Replace(";", "；").Replace("--", "－－");
            }

            if (string.IsNullOrEmpty(order) == false)
            {
                this.propOrder = "ORDER BY " + funcReplaceSqlField(order);
            }
            else
            {
                this.propOrder = "ORDER BY fdColuSort DESC";
            }

            this.funcAddParam("@fdColuID", columnID);
            DataSet ds = this.funcCommon();

            List<AW_Column_bean> columns = new List<AW_Column_bean>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                AW_Column_bean bean = new AW_Column_bean();
                bean.funcFromDataRow(row);
                columns.Add(bean);
            }
            if (!string.IsNullOrEmpty(cacheName))
            {
                HttpRuntime.Cache.Insert("COLUMN_CACHE_UC_" + cacheName, columns, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20), System.Web.Caching.CacheItemPriority.NotRemovable, null);
            }
            return columns;
        }
	}
}
