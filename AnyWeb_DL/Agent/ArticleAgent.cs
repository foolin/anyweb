using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using System.Data;
using System.Collections;

namespace AnyWeb.AnyWeb_DL
{
    public class ArticleAgent : DbAgent
    {
        public ArticleAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="ar"></param>
        /// <returns></returns>
        public int AddArticle(Article ar)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "AddArticle",
                    this.NewParam("@ArtiTitle", ar.ArtiTitle),
                    this.NewParam("@ArtiContent", ar.ArtiContent),
                    this.NewParam("@ArtiCreateAt", ar.ArtiCreateAt),
                    this.NewParam("@ArtiColumnID", ar.ArtiColumnID),
                    this.NewParam("@ArtiStatus", ar.ArtiStatus),
                    this.NewParam("@ArtiIsTop", ar.ArtiIsTop),
                    this.NewParam("@ArtiClicks", ar.ArtiClicks),
                    this.NewParam("@ArtiOrder", ar.ArtiOrder),
                    this.NewParam("@ArtiUserID", ar.ArtiUserID),
                    this.NewParam("@ArtiUserName", ar.ArtiUserName),
                    this.NewParam("@ArtiPic",ar.ArtiPic));
            }
        }

        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="ColumnID"></param>
        /// <param name="UserID"></param>
        /// <param name="Title"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageNo"></param>
        /// <param name="Record"></param>
        /// <returns></returns>
        public ArrayList GetArticleList(int ColumnID, int UserID, string Title, int PageSize, int PageNo, out int Record)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 4, true);
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetArticleList",
                    this.NewParam("@UserID", UserID),
                    this.NewParam("@ColumnID", ColumnID),
                    this.NewParam("@ArtiTitle", Title),
                    this.NewParam("@PageSize", PageSize),
                    this.NewParam("@PageNo", PageNo),
                    record);
                Record = (int)record.Value;
            }

            ArrayList list = new ArrayList();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Article ar = new Article(row);
                ar.ArtiColumnName = (string)row["ColuName"];
                list.Add(ar);
            }
            return list;
        }

        /// <summary>
        /// 获取文章内容
        /// </summary>
        /// <param name="ArtiID"></param>
        /// <returns></returns>
        public Article GetArticleInfo(int ArtiID)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetArticleInfo",
                    this.NewParam("@ArtiID", ArtiID));
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                Article ar = new Article(ds.Tables[0].Rows[0]);
                ar.ArtiContent = (string)ds.Tables[0].Rows[0]["ArtiContent"];
                return ar;
            }
            else
                return null;
        }

        /// <summary>
        /// 修改文章内容
        /// </summary>
        /// <param name="ar"></param>
        /// <returns></returns>
        public int UpdateArticleInfo(Article ar)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateArticleInfo",
                    this.NewParam("@ArtiID", ar.ArtiID),
                    this.NewParam("@ArtiTitle", ar.ArtiTitle),
                    this.NewParam("@ArtiContent", ar.ArtiContent),
                    this.NewParam("@ArtiColumnID", ar.ArtiColumnID),
                    this.NewParam("@ArtiIsTop", ar.ArtiIsTop),
                    this.NewParam("@ArtiOrder", ar.ArtiOrder),
                    this.NewParam("@ArtiPic",ar.ArtiPic));
            }
        }

        /// <summary>
        /// 获取文章标题
        /// </summary>
        /// <param name="ArtiID"></param>
        /// <returns></returns>
        public Article GetArticleTitle(int ArtiID)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetArticleTitle",
                    this.NewParam("@ArtiID", ArtiID));
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                Article ar = new Article();
                ar.ArtiID = (int)ds.Tables[0].Rows[0]["ArtiID"];
                ar.ArtiTitle = (string)ds.Tables[0].Rows[0]["ArtiTitle"];
                return ar;
            }
            else
                return null;
        }

        /// <summary>
        /// 批量删除文章
        /// </summary>
        /// <param name="ids"></param>
        public void DeleteArticle(string ids)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                db.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteArticles",
                    this.NewParam("@ids", ids));
            }
        }

        /// <summary>
        /// 批量移动栏目
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="ArtiColumnID"></param>
        public void MoveArticle(string ids,int ArtiColumnID)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                db.ExecuteNonQuery(CommandType.StoredProcedure, "MoveArticles",
                    this.NewParam("@ids", ids),
                    this.NewParam("@ArtiColumnID", ArtiColumnID));
            }
        }

        /// <summary>
        /// 获取文章回收站列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageNo"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public ArrayList GetArticleRecycleList(int PageSize,int PageNo,out int RecordCount)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 4, true);
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetArticleRecycleList",
                    this.NewParam("@PageSize", PageSize),
                    this.NewParam("@PageNo", PageNo),
                    record);
                RecordCount = (int)record.Value;
            }

            ArrayList list = new ArrayList();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Article ar = new Article(row);
                ar.ArtiColumnName = (string)row["ColuName"];
                list.Add(ar);
            }
            return list;
        }

        /// <summary>
        /// 批量还原文章
        /// </summary>
        /// <param name="ids"></param>
        public void ResumeArticle(string ids)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                db.ExecuteNonQuery(CommandType.StoredProcedure, "ResumeArticle",
                    this.NewParam("@ids", ids));
            }
        }

        /// <summary>
        /// 批量清除文章
        /// </summary>
        /// <param name="ids"></param>
        public void ClearArticle(string ids)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                db.ExecuteNonQuery(CommandType.StoredProcedure, "ClearArticle",
                    this.NewParam("@ids", ids));
            }
        }
    }
}
