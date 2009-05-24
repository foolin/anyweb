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
        /// ���Ӳ�����0-�������ӣ�1-ͼƬ���ӣ���������-ȫ������
        /// <returns></returns>
        public ArrayList GetLinkList(int LinkType)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetLinkList", this.NewParam("@LinkType", LinkType));
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
                return db.ExecuteProcedure("AddLink",
                    this.NewParam("@LinkName", lnk.LinkName),
                    this.NewParam("@LinkImage", lnk.LinkImage),
                    this.NewParam("@LinkUrl", lnk.LinkUrl),
                    this.NewParam("@LinkSort", lnk.LinkSort)) > 0;
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
                    this.NewParam("@LinkImage", lnk.LinkImage),
                    this.NewParam("@LinkUrl", lnk.LinkUrl),
                    this.NewParam("@LinkSort", lnk.LinkSort)
                    );
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
