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
        public List<AW_Article_bean> funcGetNews(AW_Column_bean column, int pageSize, int pageIndex)
        {
            this.propSelect = "n.*,c.fdColuName,c.fdColuPicture";
            this.propTableApp = " n INNER JOIN AW_Column c ON n.fdArtiColumnID = c.fdColuID";
            this.propOrder = "ORDER BY c.fdColuSort ASC,n.fdArtiCreateAt DESC";
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


        public int funcGetNewsCount(int columnId)
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
        public List<AW_Article_bean> funcGetColumnTopNews(AW_Column_bean column, int top)
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
    }
}