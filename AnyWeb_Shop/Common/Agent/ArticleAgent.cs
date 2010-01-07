using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using Common.Framework;
using System.Collections;
using System.Data;
using Common.Common;
using Studio.Array;
using System.Web;

namespace Common.Agent
{
    public class ArticleAgent:AgentBase
    {
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <param name="categoryId"></param>
        /// <param name="title"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetArticleList(int pageSize, int pageNo, int categoryId, string title, out int recordCount)
        {
            DataSet ds;

            IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetArticleList",
                                    this.NewParam("@ShopID", ShopInfo.ID),
                                    this.NewParam("@PageSize", pageSize),
                                    this.NewParam("@PageNo", pageNo),
                                    this.NewParam("@CategoryID", categoryId),
                                    this.NewParam("@Title", title.Trim()),
                                    record);
                recordCount = (int)record.Value;
            }
            ObjectList list = new ObjectList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Article a = new Article();
                a.ID = (int)dr["ArticleID"];
                a.Title = (string)dr["Title"];
                a.ShopID = (int)dr["ShopID"];
                a.IsComment = (bool)dr["IsComment"];
                a.CategoryID = (int)dr["CategoryID"];
                a.ClickCount = (int)dr["ClickCount"];
                a.CreateAt = (DateTime)dr["CreateAt"];
                a.CommentCount = (int)dr["CommentCount"];
                a.BackUrl = string.Format( "http://{0}/c/{1}/{2}.aspx" , ShopInfo.ShopDomain ,(string)dr["Path"] ,(int)dr["ArticleID"] );
                a.OfCategory = new Category();
                a.OfCategory.Name = (string)dr["CategoryName"];

                list.Add(a);
            }

            return list;
        }

        /// <summary>
        /// 获得商城文章
        /// </summary>
        /// <returns></returns>
        public ArrayList GetSysArticleList()
        {
            DataSet ds;

            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetSysArticlelist" ,
                                   this.NewParam("@ShopID",ShopInfo.ID));
            }
            ArrayList list = new ArrayList();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                Article a = new Article();
                a.ID = (int)dr["ArticleID"];
                a.Title = (string)dr["Title"];
                a.ShopID = (int)dr["ShopID"];
                a.IsComment = (bool)dr["IsComment"];
                a.CategoryID = (int)dr["CategoryID"];
                a.ClickCount = (int)dr["ClickCount"];
                a.CreateAt = (DateTime)dr["CreateAt"];
                a.CommentCount = (int)dr["CommentCount"];
                a.BackUrl = string.Format( "http://{0}/c/{1}/{2}.aspx" , ShopInfo.ShopDomain  , (string)dr["Path"] , (int)dr["ArticleID"] );
                a.OfCategory = new Category();
                a.OfCategory.Name = (string)dr["CategoryName"];
                a.IsShow = (bool)dr["IsShow"];

                list.Add( a );
            }

            return list;
        }

        /// <summary>
        /// 获得商城文章
        /// </summary>
        /// <returns></returns>
        public List<Article> GetSysArticleListByWeb(int ShopID)
        {
            DataSet ds;

            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetSysArticlelistByWeb",
                                   this.NewParam("@ShopID", ShopID));
            }
            List<Article> list = new List<Article>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Article a = new Article();
                a.ID = (int)dr["ArticleID"];
                a.Title = (string)dr["Title"];
                a.ShopID = (int)dr["ShopID"];
                a.IsShow = (bool)dr["IsShow"];

                list.Add(a);
            }

            return list;
        }

        /// <summary>
        /// 根据编号获得商城文章
        /// </summary>
        /// <returns></returns>
        public ArrayList GetSysArticleListByID(int cid)
        {
            DataSet ds;

            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetSysArticleByID" ,
                                   this.NewParam( "@CategoryID" , cid ) );
            }
            ArrayList list = new ArrayList();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                Article a = new Article();
                a.ID = (int)dr["ArticleID"];
                a.Title = (string)dr["Title"];
                a.IsShow = (bool)dr["IsShow"];
                a.BackUrl = string.Format( "http://{0}/c/{1}/{2}.aspx" , ShopInfo.ShopDomain , (string)dr["Path"] , (int)dr["ArticleID"] );
             
                list.Add( a );
            }

            return list;
        }

        /// <summary>
        /// 修改商城文章
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int UpdateSysArticle(Article a)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_SysArticlesUpdate",
                                    this.NewParam("@ArticleID", a.ID),
                                    this.NewParam("@Title", a.Title),
                                    this.NewParam("@Content", a.Content),
                                    this.NewParam("@IsShow", a.IsShow));
            }
            
        }

        /// <summary>
        /// 根据栏目获取文章,并且分页
        /// </summary>
        /// <param name="pagesize">每页大小</param>
        /// <param name="pageno">第几页</param>
        /// <param name="categoryid">栏目编号</param>
        /// <param name="recordcount">返回记录数</param>
        /// <returns>文章列表</returns>
        public ArrayList GetArticleList(int pagesize, int pageno, int categoryid, out int recordcount)
        {
            ArrayList list =  GetArticleList(pagesize, pageno, categoryid, "", out recordcount);

            ArrayList list1 = new ArrayList();

            foreach (Article a in list)
            {
                a.OfCategory = (Category)ShopInfo.Categorys.GetById(categoryid);
                list1.Add(a);
            }

            return list1;
        }

        /// <summary>
        /// 批量删除文章
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="count"></param>
        public int ArticlesDelete(string ids,int count)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_ArticlesDelete" ,
                                    this.NewParam( "@ArticleIDs" , ids ) ,
                                    this.NewParam( "@Num" , count ) );
            }
        }

        /// <summary>
        /// 删除单篇文章
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="count"></param>
        public int ArticlesDeletes(Article a)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_ArticlesDeletes" ,
                                    this.NewParam( "@ArticleID" , a.ID ) );
            }
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="at"></param>
        public int AddArticle(Article at)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_ArticleAdd" ,
                                    this.NewParam( "@Title" , at.Title ) ,
                                    this.NewParam( "@CategoryID" , at.CategoryID ),
                                    this.NewParam( "@Content",at.Content ),
                                    this.NewParam("@IsComment",at.IsComment),
                                    this.NewParam( "@ShopID",ShopInfo.ID ) );
            }
        }

        /// <summary>
        /// 添加文章点击次数
        /// </summary>
        /// <param name="articleid"></param>
        public void ArticleClicksAdd(int articleid)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_ArticleClicksAdd",
                    this.NewParam("@ArticleID", articleid));
            }
        }
        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="at"></param>
        public int UpdateArticle(Article at)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_ArticleUpdate" ,
                                    this.NewParam( "@ArticleID" , at.ID ),
                                    this.NewParam( "@Title" , at.Title ) ,
                                    this.NewParam( "@CategoryID" , at.CategoryID ) ,
                                    this.NewParam( "@Content" , at.Content ) ,
                                    this.NewParam( "@IsComment" , at.IsComment ));
            }
        }



        /// <summary>
        /// 获取单篇文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Article GetArticleByid(int id)
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetArticleByID" ,
                                this.NewParam( "@ArticleID" , id ) );
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            Article a = new Article(ds.Tables[0].Rows[0]);
            a.OfCategory = new Category();
            a.OfCategory.Name = (string)ds.Tables[0].Rows[0]["CategoryName"];
            return a;

        }

        /// <summary>
        /// 根据栏目获取文章
        /// </summary>
        /// <param name="categoryid">栏目编号</param>
        /// <returns></returns>
        public ObjectList GetLastArticles(int categoryid)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetLastArticles",
                                 this.NewParam("@categoryid", categoryid));
            }
            ObjectList list = new ObjectList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Article a = new Article();

                a.ID = (int)dr["ArticleID"];
                a.Title = (string)dr["Title"];
                a.ShopID = (int)dr["ShopID"];
                a.IsComment = (bool)dr["IsComment"];
                a.CategoryID = (int)dr["CategoryID"];
                a.ClickCount = (int)dr["ClickCount"];
                a.CreateAt = (DateTime)dr["CreateAt"];
                a.CommentCount = (int)dr["CommentCount"];

                a.OfCategory = (Category)ShopInfo.Categorys.GetById((int)dr["CategoryID"]);
                list.Add(a);
            }
            return list;

        }


        /// <summary>
        /// 获得单个单篇文章栏目
        /// </summary>
        /// <param name="categoryid"></param>
        /// <returns></returns>
        public SingleArticle GetSingleArticle(int categoryid)
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetSingleArticle" ,
                                    this.NewParam( "@CategoryID" , categoryid ) );
            }
            if ( ds.Tables[0].Rows.Count > 0 )
            {
                SingleArticle sa = new SingleArticle();
                sa.OfCategory = new Category();
       
                sa.Content = (string)ds.Tables[0].Rows[0]["Content"];
                sa.CategoryID = (int)ds.Tables[0].Rows[0]["CategoryID"];
                sa.ID = (int)ds.Tables[0].Rows[0]["SingleArticleID"];
                sa.OfCategory.Name = (string)ds.Tables[0].Rows[0]["CategoryName"];
                sa.OfCategory.Path = (string)ds.Tables[0].Rows[0]["Path"];
                sa.OfCategory.Type = (int)ds.Tables[0].Rows[0]["Type"];
                return sa;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 添加单篇文章栏目
        /// </summary>
        /// <param name="sa"></param>
        /// <returns></returns>
        public int SingleArticleAdd(SingleArticle sa)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_SingleArticleAdd" ,
                                    this.NewParam( "@CategoryName" , sa.OfCategory.Name ) ,
                                    this.NewParam( "@Path" , sa.OfCategory.Path ) ,
                                    this.NewParam( "@Content" , sa.Content ),
                                    this.NewParam( "@ShopID" , ShopInfo.ID) );
            }
        }


        /// <summary>
        /// 修改单篇文章栏目
        /// </summary>
        /// <param name="sa"></param>
        /// <returns></returns>
        public int SingleArticleUpdate(SingleArticle sa)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_SingleArticleUpdate" ,
                                    this.NewParam( "@CategoryName" , sa.OfCategory.Name ) ,
                                    this.NewParam( "@Path" , sa.OfCategory.Path ) ,
                                    this.NewParam( "@Content" , sa.Content ) ,
                                    this.NewParam( "@CategoryID" , sa.CategoryID ) );
            }
        }

        /// <summary>
        /// 删除单篇文章栏目
        /// </summary>
        /// <param name="cateogryid"></param>
        /// <returns></returns>
        public int SingerArticleDelet(int cateogryid)
        {

            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_SingleArticleDelete" ,
                                        this.NewParam( "@CategoryID" , cateogryid ) );
            }
        }
       
    }
}
