using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Template_dao
	{
        /// <summary>
        /// 获取模版列表(缓存)
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Template_bean> funcGetTempateList()
        {
            List<AW_Template_bean> list = (List<AW_Template_bean>)HttpRuntime.Cache.Get("TEMPLATE");
            if (list != null)
                return list;
            this.propSelect = "fdTempID,fdTempName,fdTempType,fdTempCreateAt,fdTempPath";
            this.propOrder = "ORDER BY fdTempID DESC";
            list = this.funcGetList();
            HttpRuntime.Cache.Insert("TEMPLATE", list, null, DateTime.MaxValue, TimeSpan.FromMinutes(5));
            return list;
        }

        /// <summary>
        /// 获取模版列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Template_bean> funcGetTempateList(int type, int pageIndex, int pageSize, out int recordCount)
        {
            if(type!=0)
            {
                this.propWhere = "fdTempType=" + type.ToString();
            }
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            this.propOrder = "ORDER BY fdTempID DESC";
            List<AW_Template_bean> list = this.funcGetList();
            recordCount = this.propCount;
            return list;
        }

        /// <summary>
        /// 检查文件名称是否存在
        /// </summary>
        /// <param name="templateName"></param>
        /// <returns></returns>
        public bool funcCheckIsExists(string pageName, int templateID)
        {
            this.propWhere = string.Format("fdTempName='{0}'", pageName);
            if (templateID != 0)
            {
                this.propWhere += " AND fdTempID<>" + templateID.ToString();
            }
            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 检查访问路径是否存在
        /// </summary>
        /// <param name="templateName"></param>
        /// <returns></returns>
        public bool funcCheckPathIsExists(string path, int templateID)
        {
            this.propWhere = string.Format("fdTempPath='{0}' AND fdTempType=4", path);
            if (templateID != 0)
            {
                this.propWhere += " AND fdTempID<>" + templateID.ToString();
            }
            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 通过模版名称获取模版信息
        /// </summary>
        /// <param name="templateName"></param>
        /// <returns></returns>
        public AW_Template_bean funcGetTemplateByName(string templateName)
        {
            this.propWhere = string.Format("fdTempName='{0}'", templateName);
            DataSet ds = this.funcCommon();
            if (ds.Tables[0].Rows.Count > 0)
            {
                AW_Template_bean bean = new AW_Template_bean();
                bean.funcFromDataRow(ds.Tables[0].Rows[0]);
                return bean;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取设置模版列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Template_bean> funcGetTempateList(int type,string name)
        {
            this.propWhere = "fdTempType=" + type.ToString();
            if (!string.IsNullOrEmpty(name))
            {
                this.propWhere += string.Format(" AND fdTempName LIKE '%{0}%'", name);
            }
            this.propOrder = "ORDER BY fdTempID DESC";
            return this.funcGetList();
        }

        /// <summary>
        /// 获取模版信息
        /// </summary>
        /// <param name="tempID"></param>
        /// <returns></returns>
        public AW_Template_bean funcGetTemplateInfo(int tempID)
        {
            foreach (AW_Template_bean bean in this.funcGetTempateList())
            {
                if (bean.fdTempID == tempID)
                {
                    return bean;
                }
            }
            return null;
        }

        public override int funcInsert(Bean_Base aBean)
        {
            int count = base.funcInsert(aBean);
            HttpRuntime.Cache.Remove("TEMPLATE");
            return count;
        }

        public override int funcDelete(int id)
        {
            string cmdText = "UPDATE AW_Column SET fdColuTempIndex=0 WHERE fdColuTempIndex=" + id.ToString();
            cmdText += " UPDATE AW_Column SET fdColuTempContent=0 WHERE fdColuTempContent=" + id.ToString();
            cmdText += " UPDATE AW_Category SET fdCateTempIndex=0 WHERE fdCateTempIndex=" + id.ToString();
            cmdText += " UPDATE AW_Category SET fdCateTempContent=0 WHERE fdCateTempContent=" + id.ToString();
            this.funcExecute(cmdText);
            int count = base.funcDelete(id);
            HttpRuntime.Cache.Remove("TEMPLATE");
            return count;
        }

        public override int funcUpdate(Bean_Base aBean)
        {
            int count = base.funcUpdate(aBean);
            HttpRuntime.Cache.Remove("TEMPLATE");
            return count;
        }
	}
}
