using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using System.Collections;
using System.Data;

namespace AnyWeb.AnyWeb_DL
{
    public class ColumnAgent : DbAgent
    {
        public ColumnAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }

        /// <summary>
        /// ��ȡ�ϼ���Ŀ�б�
        /// </summary>
        /// <returns></returns>
        public ArrayList GetParentColumnList(int OwnerID)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetParentColumnList",
                    this.NewParam("@OwnerID", OwnerID));
            }
            ArrayList list = new ArrayList();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Column col = new Column(row);
                list.Add(col);
            }
            return list;
        }

        /// <summary>
        /// ���������Ŀ
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public int AddColumn(Column col)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "AddColumn",
                    this.NewParam("@ColuName", col.ColuName),
                    this.NewParam("@ColuCreateAt", col.ColuCreateAt),
                    this.NewParam("@ColuDesc", col.ColuDesc));
            }
        }

        /// <summary>
        /// ��ȡ������Ŀ�б�
        /// </summary>
        /// <returns></returns>
        public ArrayList GetColumnList()
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetColumnList");
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                ArrayList list = new ArrayList();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Column col = new Column(row);
                    list.Add(col);
                }
                return list;
            }
            else
                return null;
        }

        /// <summary>
        /// �޸�������Ŀ
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public int UpdateColumnInfo(Column col)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateColumnInfo",
                    this.NewParam("@ColuID", col.ColuID),
                    this.NewParam("@ColuName", col.ColuName),
                    this.NewParam("@ColuDesc", col.ColuDesc));
            }
        }

        /// <summary>
        /// ��ȡ������Ŀ��Ϣ
        /// </summary>
        /// <param name="ColID"></param>
        /// <returns></returns>
        public Column GetColumnInfo(int ColID)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetColumnInfo",
                    this.NewParam("@ColuID", ColID));
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                Column col = new Column(ds.Tables[0].Rows[0]);
                return col;
            }
            else 
                return null;
        }

        /// <summary>
        /// �����Ŀ�Ƿ��������
        /// </summary>
        /// <param name="ColuID"></param>
        /// <returns></returns>
        public bool CheckArticleInColumn(int ColuID)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteProcedure("CheckArticleInColumn",
                    this.NewParam("@ArtiColumnID", ColuID)) > 0;
            }
        }

        /// <summary>
        /// ɾ��������Ŀ
        /// </summary>
        /// <param name="ColuID"></param>
        /// <returns></returns>
        public int DeleteColumn(int ColuID)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteColumn",
                    this.NewParam("@ColuID", ColuID));
            }
        }

        /// <summary>
        /// ��ȡ������Ŀ�б�
        /// </summary>
        /// <returns></returns>
        public ArrayList GetColumnListByArticle()
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetColumnList");
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                ArrayList list = new ArrayList();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Column col = new Column(row);
                    list.Add(col);
                }
                return list;
            }
            else
                return null;
        }

        /// <summary>
        /// ͨ�����»�ȡ��Ŀ
        /// </summary>
        /// <param name="ArticleID"></param>
        /// <returns></returns>
        public Column GetColumnByArticle(int ArticleID)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetColumnByArticle",
                    this.NewParam("@ArtiID", ArticleID));
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                return new Column(ds.Tables[0].Rows[0]);
            }
            else
                return null;
        }
    }
}
