using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_Template_dao
	{
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
        /// 删除模版
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override int funcDelete(int id)
        {
            int result = base.funcDelete(id);
            if (result > 0)
            {
                new AW_Mapping_dao().funcRemoveCache();
            }
            return result;
        }
	}
}
