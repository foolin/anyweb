using System;
using System.Collections.Generic;
using System.Web;
using Studio.Web;
using System.Data;

namespace AnyWeb.AW_DL
{
    public partial class AW_Column_dao
    {
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
        /// 获取所有栏目
        /// </summary>
        /// <returns></returns>
        public List<AW_Column_bean> funcGetColumns()
        {
            DataSet ds = this.funcCommon();
            List<AW_Column_bean>  list = new List<AW_Column_bean>();
            foreach (DataRow row1 in ds.Tables[0].Select("fdColuParentID=0", "fdColuSort ASC"))
            {
                AW_Column_bean bean1 = new AW_Column_bean();
                bean1.funcFromDataRow(row1);
                bean1.IndexTemplate = new AW_Template_dao().funcGetTemplateInfo(bean1.fdColuTempIndex);
                bean1.ContentTemplate = new AW_Template_dao().funcGetTemplateInfo(bean1.fdColuTempContent);
                bean1.Children = new List<AW_Column_bean>();
                foreach (DataRow row2 in ds.Tables[0].Select("fdColuParentID=" + bean1.fdColuID.ToString(), "fdColuSort ASC"))
                {
                    AW_Column_bean bean2 = new AW_Column_bean();
                    bean2.funcFromDataRow(row2);
                    bean2.Parent = bean1;
                    bean2.IndexTemplate = new AW_Template_dao().funcGetTemplateInfo(bean2.fdColuTempIndex);
                    bean2.ContentTemplate = new AW_Template_dao().funcGetTemplateInfo(bean2.fdColuTempContent);
                    bean1.Children.Add(bean2);
                }
                list.Add(bean1);
            }
            return list;
        }

        /// <summary>
        /// 获取首页所有栏目
        /// </summary>
        /// <returns></returns>
        public List<AW_Column_bean> funcGetIndexColumns()
        {
            List<AW_Column_bean> list = (List<AW_Column_bean>)HttpRuntime.Cache["COLUMNS"];
            if (list != null)
            {
                return list;
            }
            list = new List<AW_Column_bean>();
            DataSet ds = this.funcCommon();
            foreach (DataRow row1 in ds.Tables[0].Select("fdColuParentID=0 AND fdColuShowIndex=1", "fdColuSort ASC"))
            {
                AW_Column_bean bean1 = new AW_Column_bean();
                bean1.funcFromDataRow(row1);
                bean1.IndexTemplate = new AW_Template_dao().funcGetTemplateInfo(bean1.fdColuTempIndex);
                bean1.ContentTemplate = new AW_Template_dao().funcGetTemplateInfo(bean1.fdColuTempContent);
                bean1.Children = new List<AW_Column_bean>();
                foreach (DataRow row2 in ds.Tables[0].Select("fdColuParentID=" + bean1.fdColuID.ToString() + " AND fdColuShowIndex=1", "fdColuSort ASC"))
                {
                    AW_Column_bean bean2 = new AW_Column_bean();
                    bean2.funcFromDataRow(row2);
                    bean2.Parent = bean1;
                    bean2.IndexTemplate = new AW_Template_dao().funcGetTemplateInfo(bean2.fdColuTempIndex);
                    bean2.ContentTemplate = new AW_Template_dao().funcGetTemplateInfo(bean2.fdColuTempContent);
                    bean1.Children.Add(bean2);
                }
                list.Add(bean1);
            }
            HttpRuntime.Cache.Insert("COLUMNS", list, null, DateTime.MaxValue, TimeSpan.FromMinutes(5));
            return list;
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
            if (HttpRuntime.Cache["COLUMNS"] != null)
            {
                HttpRuntime.Cache.Remove("COLUMNS");
            }
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
            if (HttpRuntime.Cache["COLUMNS"] != null)
            {
                HttpRuntime.Cache.Remove("COLUMNS");
            }
            return true;
        }

        /// <summary>
        /// 更新栏目模版
        /// </summary>
        /// <param name="coluID"></param>
        /// <param name="type"></param>
        /// <param name="tempID"></param>
        /// <param name="childUpdate"></param>
        /// <returns></returns>
        public int funcUpdateColumnTemplate(int coluID, int type, int tempID, bool childUpdate)
        {
            string cmdText = "";
            if (type == 1)
            {
                cmdText = string.Format("UPDATE AW_Column SET fdColuTempIndex={0} WHERE fdColuID={1}", tempID, coluID);
                if (childUpdate)
                {
                    cmdText += string.Format(" UPDATE AW_Column SET fdColuTempIndex={0} WHERE fdColuParentID={1}", tempID, coluID);
                }
            }
            else
            {
                cmdText = string.Format("UPDATE AW_Column SET fdColuTempContent={0} WHERE fdColuID={1}", tempID, coluID);
                if (childUpdate)
                {
                    cmdText += string.Format(" UPDATE AW_Column SET fdColuTempContent={0} WHERE fdColuParentID={1}", tempID, coluID);
                }
            }
            return this.funcExecute(cmdText);
        }

        /// <summary>
        /// 重写栏目删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override int funcDelete(int id)
        {
            string sql = string.Format("DELETE AW_Column WHERE fdColuID={0} OR fdColuParentID={0}", id);
            if (HttpRuntime.Cache["COLUMNS"] != null)
            {
                HttpRuntime.Cache.Remove("COLUMNS");
            }
            if (HttpRuntime.Cache["HOTARTICLE"] != null)
            {
                HttpRuntime.Cache.Remove("HOTARTICLE");
            }
            return this.funcExecute(sql);
        }

        /// <summary>
        /// 重写添加栏目
        /// </summary>
        /// <param name="aBean"></param>
        /// <returns></returns>
        public override int funcInsert(Bean_Base aBean)
        {
            int result = base.funcInsert(aBean);
            if (HttpRuntime.Cache["COLUMNS"] != null)
            {
                HttpRuntime.Cache.Remove("COLUMNS");
            }
            if (HttpRuntime.Cache["HOTARTICLE"] != null)
            {
                HttpRuntime.Cache.Remove("HOTARTICLE");
            }
            return result;
        }

        /// <summary>
        /// 重写修改栏目
        /// </summary>
        /// <param name="aBean"></param>
        /// <returns></returns>
        public override int funcUpdate(Bean_Base aBean)
        {
            int result = base.funcUpdate(aBean);
            if (HttpRuntime.Cache["COLUMNS"] != null)
            {
                HttpRuntime.Cache.Remove("COLUMNS");
            }
            if (HttpRuntime.Cache["HOTARTICLE"] != null)
            {
                HttpRuntime.Cache.Remove("HOTARTICLE");
            }
            return result;
        }

        /// <summary>
        /// 前台获取栏目信息
        /// </summary>
        /// <param name="columnId"></param>
        /// <returns></returns>
        public AW_Column_bean funcGetColumnIndex(int columnId)
        {
            foreach (AW_Column_bean bean1 in this.funcGetIndexColumns())
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
        /// 获取内页左侧栏目列表
        /// </summary>
        /// <param name="columnId"></param>
        /// <returns></returns>
        public List<AW_Column_bean> funcGetColumnList(int columnId)
        {
            List<AW_Column_bean> list = new List<AW_Column_bean>();
            foreach (AW_Column_bean bean1 in this.funcGetIndexColumns())
            {
                if (bean1.fdColuID == columnId)
                {
                    foreach (AW_Column_bean bean2 in bean1.Children)
                    {
                        list.Add(bean2);
                    }
                    break;
                }
            }
            return list;
        }
    }
}