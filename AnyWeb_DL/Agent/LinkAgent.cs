using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using System.Data;
using System.Collections;
using System.Web;

namespace AnyWeb.AnyWeb_DL
{
    public class LinkAgent : DbAgent
    {
        public LinkAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }

        /// <summary>
        /// 获取连接列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <param name="CateID"></param>
        /// <returns></returns>
        public ArrayList GetLinkList(int CateID, int PageSize, int PageIndex, out int RecordCount)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 4, true);
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetLinkList",
                    this.NewParam("@CateID", CateID),
                    this.NewParam("@PageSize", PageSize),
                    this.NewParam("@PageNo", PageIndex),
                    record);
                RecordCount = (int)record.Value;
            }
            ArrayList list = new ArrayList();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Link lnk = new Link(row);
                list.Add(lnk);
            }
            return list;
        }

        /// <summary>
        /// 获取所有友情链接
        /// </summary>
        /// <returns></returns>
        public List<Link> GetLinkList()
        {
            List<Link> list = (List<Link>)HttpRuntime.Cache["LINK"];
            if (list != null)
                return list;
            list = new List<Link>();
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetAllLinkList");
            }
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Link lnk = new Link(row);
                list.Add(lnk);
            }
            HttpRuntime.Cache.Insert("LINK", list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(5));
            return list;
        }

        /// <summary>
        /// 根据类别获取链接(前台)
        /// </summary>
        /// <param name="CateID"></param>
        /// <returns></returns>
        public List<Link> GetLinkListByCateID(int CateID)
        {
            List<Link> list = new List<Link>();
            foreach (Link link in this.GetLinkList())
            {
                if (link.LinkCateID == CateID)
                {
                    list.Add(link);
                }
            }
            return list;
        }

        /// <summary>
        /// 清除缓存
        /// </summary>
        public void ClearCache()
        {
            if (HttpRuntime.Cache["LINK"] != null)
            {
                HttpRuntime.Cache.Remove("LINK");
            }
        }

        /// <summary>
        /// 获取连接信息
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public Link GetLinkInfo(int LinkID)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetLinkInfo",
                    this.NewParam("@LinkID", LinkID));
            }
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
            {
                Link lnk = new Link(ds.Tables[0].Rows[0]);
                return lnk;
            }
        }

        /// <summary>
        /// 添加连接
        /// </summary>
        /// <param name="Link"></param>
        /// <returns></returns>
        public bool AddLink(Link lnk)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                bool result = db.ExecuteNonQuery(CommandType.StoredProcedure, "AddLink",
                    this.NewParam("@LinkName", lnk.LinkName),
                    this.NewParam("@CateID", lnk.LinkCateID),
                    this.NewParam("@LinkUrl", lnk.LinkUrl),
                    this.NewParam("@LinkOrder", lnk.LinkOrder)) > 0;
                this.ClearCache();
                return result;
            }
        }


        /// <summary>
        /// 修改连接信息
        /// </summary>
        /// <param name="Link"></param>
        /// <returns></returns>
        public int UpdateLinkInfo(Link lnk)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                int result = db.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateLinkInfo",
                    this.NewParam("@LinkID", lnk.LinkID),
                    this.NewParam("@LinkName", lnk.LinkName),
                    this.NewParam("@CateID", lnk.LinkCateID),
                    this.NewParam("@LinkUrl", lnk.LinkUrl),
                    this.NewParam("@LinkOrder", lnk.LinkOrder));
                this.ClearCache();
                return result;
            }
        }

        /// <summary>
        /// 删除连接
        /// </summary>
        /// <param name="LinkID"></param>
        /// <returns></returns>
        public int DeleteLink(int LinkID)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                int result = db.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteLink",
                    this.NewParam("@LinkID", LinkID));
                this.ClearCache();
                return result;
            }
        }

        /// <summary>
        /// 获取链接分页
        /// </summary>
        /// <param name="CateID"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public ArrayList GetLinkListPage(int CateID, int PageSize, int PageIndex, out int RecordCount)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 4, true);
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetLinkListByCate",
                    this.NewParam("@CateID", CateID),
                    this.NewParam("@PageSize", PageSize),
                    this.NewParam("@PageNo", PageIndex),
                    record);
                RecordCount = (int)record.Value;
            }
            ArrayList list = new ArrayList();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Link lnk = new Link();
                lnk.LinkName = (string)row["LinkName"];
                lnk.LinkUrl = (string)row["LinkUrl"];
                list.Add(lnk);
            }
            return list;
        }
    }
}
