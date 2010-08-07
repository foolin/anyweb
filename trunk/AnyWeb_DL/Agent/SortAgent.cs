using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using System.Collections;
using System.Data;

namespace AnyWeb.AnyWeb_DL
{
    public class SortAgent : DbAgent
    {
        public SortAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }

        /// <summary>
        /// 获取图片分类列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetSortListByPhoto()
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetPhotSortList");
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                ArrayList list = new ArrayList();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string choice = "photo";
                    Sort sor = new Sort(row,choice);
                    list.Add(sor);
                }
                return list;
            }
            else
                return null;
        }

        /// <summary>
        /// 获取链接分类列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetSortListByLink()
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetLinkSortList");
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                ArrayList list = new ArrayList();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string choice = "link";
                    Sort sor = new Sort(row,choice);
                    list.Add(sor);
                }
                return list;
            }
            else
                return null;
        }
    }
}
