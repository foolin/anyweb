using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using System.Data;
using System.Collections;

namespace AnyWeb.AnyWeb_DL
{
    public class NoticeAgent: DbAgent
    {
        public NoticeAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }

        public int AddNotice(Notice nt)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "AddNotice",
                    this.NewParam("@NotiArtiID", nt.NotiArtiID),
                    this.NewParam("@NotiOrder", nt.NotiOrder),
                    this.NewParam("@NotiCreateAt", nt.NotiCreateAt));
            }
        }

        public int UpdateNotice(Notice nt)
        { 
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateNotice",
                    this.NewParam("@NotiID", nt.NotiID),
                    this.NewParam("@NotiOrder", nt.NotiOrder));
            }
        }

        public List<Notice> GetNoticeList(int PageSize, int PageIndex, out int RecordCount)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 4, true);
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetNoticeList",
                    this.NewParam("@PageSize", PageSize),
                    this.NewParam("@PageNo", PageIndex),
                    record);
                RecordCount = (int)record.Value;
            }

            List<Notice> list = new List<Notice>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Notice notice = new Notice(row);
                notice.Title = (string)row["ArtiTitle"];
                list.Add(notice);
            }
            return list;
        }

        public Notice GetNoticeInfo(int NotiID)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetNoticeInfo",
                    this.NewParam("@NotiID", NotiID));
            }
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
            {
                Notice notice = new Notice(ds.Tables[0].Rows[0]);
                notice.Title = (string)ds.Tables[0].Rows[0]["ArtiTitle"];
                return notice;
            }
        }

        public void DeleteNotice(string ids)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                db.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteNotice",
                    this.NewParam("@ids", ids));
            }
        }
    }
}
