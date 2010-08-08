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
        /// ��ȡ�����б�
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
        /// ��ȡ������������
        /// </summary>
        /// <returns></returns>
        public List<Link> GetLinkList()
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetAllLinkList");
            }
            List<Link> list = new List<Link>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Link lnk = new Link(row);
                list.Add(lnk);
            }
            return list;
        }

        /// <summary>
        /// ��ȡ������Ϣ
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
        /// �������
        /// </summary>
        /// <param name="Link"></param>
        /// <returns></returns>
        public bool AddLink(Link lnk)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "AddLink",
                    this.NewParam("@LinkName", lnk.LinkName),
                    this.NewParam("@CateID", lnk.LinkCateID),
                    this.NewParam("@LinkUrl", lnk.LinkUrl),
                    this.NewParam("@LinkOrder", lnk.LinkOrder)) > 0;
            }
        }


        /// <summary>
        /// �޸�������Ϣ
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
                    this.NewParam("@CateID", lnk.LinkCateID),
                    this.NewParam("@LinkUrl", lnk.LinkUrl),
                    this.NewParam("@LinkOrder", lnk.LinkOrder));
            }
        }

        /// <summary>
        /// ɾ������
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
