using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using Studio.Data;

namespace AnyWeb.AW_DL
{
    public partial class AW_Article_dao
    {
        /// <summary>
        /// 根据栏目获取文章列表
        /// </summary>
        /// <param name="column"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetArticle(AW_Column_bean column, int pageSize, int pageIndex)
        {
            this.propSelect = "a.*,c.fdColuName,c.fdColuPicture";
            this.propTableApp = " a INNER JOIN AW_Column c ON a.fdArtiColumnID = c.fdColuID";
            this.propOrder = "ORDER BY a.fdArtiSort DESC,fdArtiID DESC";
            if (column != null)
            {
                this.propWhere = " c.fdColuID = " + column.fdColuID.ToString();
                if (column.Children != null)
                {
                    foreach (AW_Column_bean child in column.Children)
                        this.propWhere += " OR c.fdColuID = " + child.fdColuID.ToString();
                }
            }
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propGetCount = true;
            DataSet ds = this.funcCommon();
            List<AW_Article_bean> list = new List<AW_Article_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow(r);
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }


        public int funcGetArticleCount(int columnId)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                object rev = db.ExecuteScalar("SELECT COUNT(*) FROM AW_Article WHERE fdArtiColumnID = " + columnId);
                return Convert.IsDBNull(rev) ? 0 : (int)rev;
            }
        }


        /// <summary>
        /// 获取某个栏目最新的新闻
        /// </summary>
        /// <param name="column"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<AW_Article_bean> funcGetColumnTopArticle(AW_Column_bean column, int top)
        {
            List<AW_Article_bean> list = (List<AW_Article_bean>)HttpRuntime.Cache["ArticleList_" + column.fdColuID.ToString()];
            if (list != null) return list;

            this.propSelect = " TOP " + top.ToString() + " fdArtiID,fdArtiTitle";
            this.propOrder = " ORDER BY fdArtiID DESC";
            this.propWhere = " fdArtiColumnID=" + column.fdColuID.ToString();
            if (column.Children != null)
            {
                foreach (AW_Column_bean child in column.Children)
                    this.propWhere += " OR fdArtiColumnID = " + child.fdColuID.ToString();
            }

            list = this.funcGetList();
            HttpRuntime.Cache.Insert("ArticleList_" + column.fdColuID.ToString(), list, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero);
            return list;
        }

        /// <summary>
        /// 获取下一篇文章
        /// </summary>
        /// <param name="articleID"></param>
        /// <returns></returns>
        public AW_Article_bean funcGetNextArticle(int articleID)
        {
            string cmdText = "SELECT TOP 1 * FROM AW_Article WHERE fdArtiColumnID=(SELECT fdArtiColumnID FROM AW_Article WHERE fdArtiID=@fdArtiID) AND fdArtiSort<(SELECT fdArtiSort FROM AW_Article WHERE fdArtiID=@fdArtiID) ORDER BY fdArtiSort DESC";
            DataSet ds = this.funcGet(cmdText);
            if (ds.Tables[0].Rows.Count > 0)
            {
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow(ds.Tables[0].Rows[0]);
                return bean;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取上一篇文章
        /// </summary>
        /// <param name="articleID"></param>
        /// <returns></returns>
        public AW_Article_bean funcGetPreviousArticle(int articleID)
        {
            string cmdText = "SELECT TOP 1 fdArtiID FROM FA_Article WHERE fdArtiColuID=(SELECT fdArtiColuID FROM FA_Article WHERE fdArtiID=@fdArtiID) AND fdArtiSort>(SELECT fdArtiSort FROM FA_Article WHERE fdArtiID=@fdArtiID) ORDER BY fdArtiSort";
            DataSet ds = this.funcGet(cmdText);
            if (ds.Tables[0].Rows.Count > 0)
            {
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow(ds.Tables[0].Rows[0]);
                return bean;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 调整商品排序
        /// </summary>
        /// <param name="column"></param>
        /// <param name="goodsId"></param>
        /// <param name="nextId"></param>
        /// <param name="previewId"></param>
        public void funcSortArticle(int articleId, int nextId, int previewId)
        {
            AW_Article_bean article = AW_Article_bean.funcGetByID(articleId, "fdArtiID,fdArtiSort");
            AW_Article_bean next = nextId == 0 ? null : AW_Article_bean.funcGetByID(nextId, "fdArtiID,fdArtiSort");
            AW_Article_bean preview = previewId == 0 ? null : AW_Article_bean.funcGetByID(previewId, "fdArtiID,fdArtiSort");

            this.propSelect = " fdArtiID,fdArtiSort";
            this.propOrder = " ORDER BY fdArtiSort DESC";

            this._propFields = "fdArtiID,fdArtiSort";

            if (next != null)
            {
                if (article.fdArtiSort > next.fdArtiSort) //从上往下移
                {
                    this.propWhere += " AND fdArtiSort<=" + article.fdArtiSort + " AND fdArtiSort>" + next.fdArtiSort.ToString();
                    List<AW_Article_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        article.fdArtiSort = list[list.Count - 1].fdArtiSort;
                        this.funcUpdate(article);
                        for (int i = 1; i < list.Count; i++)
                        {
                            list[i].fdArtiSort = list[i - 1].fdArtiSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdArtiSort>=" + article.fdArtiSort + " AND fdArtiSort<=" + next.fdArtiSort.ToString();
                    List<AW_Article_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        article.fdArtiSort = list[0].fdArtiSort;
                        this.funcUpdate(article);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdArtiSort = list[i + 1].fdArtiSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
            }
            else if (preview != null)
            {
                if (article.fdArtiSort > preview.fdArtiSort) //从上往下移
                {
                    this.propWhere += " AND fdArtiSort<=" + article.fdArtiSort + " AND fdArtiSort>=" + preview.fdArtiSort.ToString();
                    List<AW_Article_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        article.fdArtiSort = list[list.Count - 1].fdArtiSort;
                        this.funcUpdate(article);
                        for (int i = list.Count - 1; i > 0; i--)
                        {
                            list[i].fdArtiSort = list[i - 1].fdArtiSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdArtiSort>=" + article.fdArtiSort + " AND fdArtiSort<" + preview.fdArtiSort.ToString();
                    List<AW_Article_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        article.fdArtiSort = list[0].fdArtiSort;
                        this.funcUpdate(article);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdArtiSort = list[i + 1].fdArtiSort;
                            this.funcUpdate(list[i]);
                        }
                    }

                }
            }
        }
    }
}