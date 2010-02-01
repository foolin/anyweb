using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_Mapping_dao
	{
        /// <summary>
        /// 获取映射列表
        /// </summary>
        /// <returns></returns>
        public List<AW_Mapping_bean> funcGetMappingList()
        {
            List<AW_Mapping_bean> list = (List<AW_Mapping_bean>)HttpRuntime.Cache["MAPPING"];
            if (list != null)
            {
                return list;
            }
            this.propTableApp = "INNER JOIN AW_Template ON fdTempID=fdMappTempID";
            this.propOrder = "ORDER BY fdMappID DESC";
            DataSet ds = this.funcCommon();
            list = new List<AW_Mapping_bean>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                AW_Mapping_bean bean = new AW_Mapping_bean();
                bean.funcFromDataRow(row);
                bean.Template = new AW_Template_bean();
                bean.Template.funcFromDataRow(row);
                list.Add(bean);
            }
            HttpRuntime.Cache.Insert("MAPPING", list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(60), System.Web.Caching.CacheItemPriority.NotRemovable, null);
            return list;
        }

        /// <summary>
        /// 获取映射信息
        /// </summary>
        /// <param name="mappingID"></param>
        /// <returns></returns>
        public AW_Mapping_bean funcGetMappingInfo(int mappingID)
        {
            foreach (AW_Mapping_bean bean in this.funcGetMappingList())
            {
                if (mappingID == bean.fdMappID)
                {
                    return bean;
                }
            }
            return null;
        }

        /// <summary>
        /// 添加映射
        /// </summary>
        /// <param name="aBean"></param>
        /// <returns></returns>
        public override int funcInsert(Bean_Base aBean)
        {
            int result = base.funcInsert(aBean);
            if (result > 0)
            {
                List<AW_Mapping_bean> list = funcGetMappingList();
                list.Insert(0, (AW_Mapping_bean)aBean);
            }
            return result;
        }

        /// <summary>
        /// 删除映射
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override int funcDelete(int id)
        {
            int result = base.funcDelete(id);
            if (result > 0)
            {
                AW_Mapping_bean bean = this.funcGetMappingInfo(id);
                this.funcGetMappingList().Remove(bean);
            }
            return result;
        }

        /// <summary>
        /// 移除映射缓存
        /// </summary>
        public void funcRemoveCache()
        {
            HttpRuntime.Cache.Remove("MAPPING");
        }

        /// <summary>
        /// 通过路径获取映射
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public AW_Mapping_bean funcGetMapping(string url)
        {
            foreach (AW_Mapping_bean bean in this.funcGetMappingList())
            {
                if (bean.fdMappPath.ToLower() == url)
                {
                    return bean;
                }
            }
            return null;
        }
	}
}
