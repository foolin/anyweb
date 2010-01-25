using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWeb.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_News_dao
	{

        /// <summary>
        /// 根据栏目获取新闻列表
        /// </summary>
        /// <param name="column"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<AW_News_bean> funcGetNews(AW_News_Column_bean column,int pageSize, int pageIndex)
        {
            this.propSelect = "n.*,c.fdColuName,c.fdColuPath,c.fdColuPicture";
            this.propTableApp = " n INNER JOIN AW_News_Column c ON n.fdNewsColumnID = c.fdColuID";
            this.propOrder = "ORDER BY c.fdColuSort ASC,n.fdNewsCreateAt DESC";
            if (column != null)
            {
                this.propWhere = " c.fdColuID = " + column.fdColuID.ToString();
                if (column.Children != null)
                {
                    foreach (AW_News_Column_bean child in column.Children)
                        this.propWhere += " OR c.fdColuID = " + child.fdColuID.ToString();
                }
            }
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propGetCount = true;
            DataSet ds = this.funcCommon();
            List<AW_News_bean> list = new List<AW_News_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_News_bean bean = new AW_News_bean();
                bean.funcFromDataRow(r);
                bean.Column = new AW_News_Column_bean();
                bean.Column.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }


        public int funcGetNewsCount(int columnId)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                object rev = db.ExecuteScalar("SELECT COUNT(*) FROM AW_News WHERE fdNewsColumnID = " + columnId);
                return Convert.IsDBNull(rev) ? 0 : (int)rev;
            }
        }


        /// <summary>
        /// 获取某个栏目最新的新闻
        /// </summary>
        /// <param name="column"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<AW_News_bean> funcGetColumnTopNews(AW_News_Column_bean column, int top)
        {
            List<AW_News_bean> list = (List<AW_News_bean>)HttpRuntime.Cache["NewsList_" + column.fdColuID.ToString()];
            if (list != null) return list;

            this.propSelect = " TOP " + top.ToString() + " fdNewsID,fdNewsTitle";
            this.propOrder = " ORDER BY fdNewsID DESC";
            this.propWhere = " fdNewsColumnID=" + column.fdColuID.ToString();
            if (column.Children != null)
            {
                foreach (AW_News_Column_bean child in column.Children)
                    this.propWhere += " OR fdNewsColumnID = " + child.fdColuID.ToString();
            }

            list = this.funcGetList();
            HttpRuntime.Cache.Insert("NewsList_" + column.fdColuID.ToString(), list, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero);
            return list;
        }

	}
}
