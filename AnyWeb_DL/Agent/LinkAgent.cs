using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using System.Data;
using System.Collections;

namespace AnyWeb.AnyWeb_DL
{
    public class LinkAgent : DbAgent
    {
        public LinkAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }

        /// <summary>
        /// 获取连接列表
        /// </summary>
        /// 连接参数：0-文字链接，1-图片链接，其它数字-全部链接
        /// <returns></returns>
        public ArrayList GetLinkList(int PageSize,int PageIndex,out int RecordCount)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 4, true);
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetLinkList",
                    this.NewParam("@PageSize",PageSize),
                    this.NewParam("@PageNo",PageIndex),
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
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "AddLink",
                    this.NewParam("@LinkName", lnk.LinkName),
                    this.NewParam("@LinkImage", lnk.LinkImage),
                    this.NewParam("@LinkUrl", lnk.LinkUrl),
                    this.NewParam("@LinkSort", lnk.LinkSort)) > 0;
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
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateLinkInfo",
                    this.NewParam("@LinkID", lnk.LinkID),
                    this.NewParam("@LinkName", lnk.LinkName),
                    this.NewParam("@LinkImage", lnk.LinkImage),
                    this.NewParam("@LinkUrl", lnk.LinkUrl),
                    this.NewParam("@LinkSort", lnk.LinkSort));
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
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteLink",
                    this.NewParam("@LinkID", LinkID));
            }
        }



    }
}
