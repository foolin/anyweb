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
        public AW_Article_bean funcGetNextArticle(int articleID, int columnid)
        {
            int nextArticleID = this.funcGetNextArticleID(articleID, columnid);
            if (nextArticleID == 0)
            {
                return null;
            }
            else
            {
                return AW_Article_bean.funcGetByID(nextArticleID);
            }
        }

        /// <summary>
        /// 下一篇文章编号
        /// </summary>
        /// <param name="articleID"></param>
        /// <param name="columnid"></param>
        /// <returns></returns>
        public int funcGetNextArticleID(int articleID, int columnid)
        {
            string cmdText = "";

            if (this.DBType == DatabaseType.Oracle)
            {
                cmdText = "SELECT fdArtiID FROM AW_Article WHERE fdArtiColumnID=(SELECT fdArtiColumnID FROM AW_Article WHERE fdArtiID=@fdArtiID) AND fdArtiSort<(SELECT fdArtiSort FROM AW_Article WHERE fdArtiID=@fdArtiID) AND ROWNUM=1 ORDER BY fdArtiSort DESC";
            }
            else
            {
                cmdText = "SELECT TOP 1 fdArtiID FROM AW_Article WHERE fdArtiColumnID=(SELECT fdArtiColumnID FROM AW_Article WHERE fdArtiID=@fdArtiID) AND fdArtiSort<(SELECT fdArtiSort FROM AW_Article WHERE fdArtiID=@fdArtiID) ORDER BY fdArtiSort DESC";
            }


            if (columnid != 0)
            {
                AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo(columnid);
                if (column != null)
                {
                    string order = "fdArtiSort DESC";

                    if (this.DBType == DatabaseType.Oracle)
                    {
                        cmdText = ";SELECT fdArtiID FROM (SELECT  fdArtiID,ROW_NUMBER() OVER (order by " + order + ") formatColu2  FROM AW_Article) table2 ";
                        cmdText += " where (formatColu2-1) = (select formatColu from (SELECT  fdArtiID,ROW_NUMBER() OVER (order by " + order + ") formatColu  FROM AW_Article) table1 where fdArtiID = @fdArtiID ) AND ROWNUM=1";
                    }
                    else
                    {
                        cmdText = "SELECT top 1 fdArtiID FROM (SELECT fdArtiID,ROW_NUMBER() OVER (order by " + order + ") formatColu2 FROM AW_Article) table2 ";
                        cmdText += " where (formatColu2-1) = (select formatColu from (SELECT  fdArtiID,ROW_NUMBER() OVER (order by " + order + ") formatColu  FROM AW_Article) table1 where fdArtiID = @fdArtiID ) ";
                    }
                }
            }

            object nextArticleID;
            using (IDbExecutor db = this.NewExecutor())
            {
                nextArticleID = db.ExecuteScalar(CommandType.Text, cmdText,
                this.NewParam("@fdArtiID", articleID));
            }
            if (nextArticleID == null || nextArticleID == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return int.Parse(nextArticleID.ToString());
            }
        }
    }
}