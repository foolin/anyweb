using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_KeyWord_dao
	{

        public List<AW_KeyWord_bean> funcKeyWordList(int status, int pageSize, int pageIndex)
        {
            this.propOrder = "ORDER BY fdKeyWSort DESC, fdKeyWID DESC";
            if (status!=-1)
            {
                this.propWhere = " fdKeyWIsShow =" + status;
            }
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propGetCount = true;
            DataSet ds = this.funcCommon();
            List<AW_KeyWord_bean> list = new List<AW_KeyWord_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_KeyWord_bean bean = new AW_KeyWord_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }

        public List<AW_KeyWord_bean> funcTopKeyWordList(int top)
        {
            string cacheKey = "KEYWORDTOP" + top;
            List<AW_KeyWord_bean> list = (List<AW_KeyWord_bean>)HttpRuntime.Cache[cacheKey];
            if (list != null) return list;

            this.propSelect = "TOP " + top + " *";
            this.propWhere = "fdKeyWIsShow = 1";
            this.propOrder = "ORDER BY fdKeyWSort DESC, fdKeyWID DESC";
            list = this.funcGetList();
            //HttpRuntime.Cache.Insert(cacheKey, list);
            HttpRuntime.Cache.Insert(cacheKey, list, null, DateTime.Now.AddMinutes(3), TimeSpan.Zero);
            return list;
        }

        //设置在首页显示或不显示
        public int funcKeyWordSet(int id, int status)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery("UPDATE AW_KeyWord SET fdKeyWIsShow = " + status + " WHERE fdKeyWID =" + id);
            }
        }

        //增加搜索关键字
        public void funcAddKeyWord(string keyword)
        {
            this.propWhere = "fdKeyWName = '" + keyword + "'";
            List<AW_KeyWord_bean> list = this.funcGetList();
            if (list.Count > 0)
            {
                //已存在则修改搜索数量和最后更新时间
                AW_KeyWord_bean bean = list[0];
                bean.fdKeyWClickCount++;
                bean.fdKeyWUpdateAt = DateTime.Now;
                this.funcUpdate(bean);
            }
            else {
                //新加搜索关键字
                AW_KeyWord_bean bean = new AW_KeyWord_bean();
                bean.fdKeyWID = this.funcNewID();
                bean.fdKeyWName = keyword;
                bean.fdKeyWClickCount = 1;
                bean.fdKeyWCreateAt = DateTime.Now;
                bean.fdKeyWUpdateAt = DateTime.Now;
                bean.fdKeyWIsShow = 0;
                this.funcInsert(bean);
            }
        }

        /// <summary>
        /// 调整搜素关键字排序
        /// </summary>
        /// <param name="column"></param>
        /// <param name="goodsId"></param>
        /// <param name="nextId"></param>
        /// <param name="previewId"></param>
        public void funcSortKeyWords(int id, int nextId, int previewId)
        {
            AW_KeyWord_bean keyword = AW_KeyWord_bean.funcGetByID(id, "fdKeyWID,fdKeyWSort");
            AW_KeyWord_bean next = nextId == 0 ? null : AW_KeyWord_bean.funcGetByID(nextId, "fdKeyWID,fdKeyWSort");
            AW_KeyWord_bean preview = previewId == 0 ? null : AW_KeyWord_bean.funcGetByID(previewId, "fdKeyWID,fdKeyWSort");

            this.propSelect = " fdKeyWID,fdKeyWSort";
            this.propOrder = " ORDER BY fdKeyWSort DESC, fdKeyWClickCount DESC, fdKeyWID DESC";

            this._propFields = "fdKeyWID,fdKeyWSort";

            if (next != null)
            {
                if (keyword.fdKeyWSort > next.fdKeyWSort) //从上往下移
                {
                    this.propWhere += " AND fdKeyWSort<=" + keyword.fdKeyWSort + " AND fdKeyWSort>" + next.fdKeyWSort.ToString();
                    List<AW_KeyWord_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        keyword.fdKeyWSort = list[list.Count - 1].fdKeyWSort;
                        this.funcUpdate(keyword);
                        for (int i = 1; i < list.Count; i++)
                        {
                            list[i].fdKeyWSort = list[i - 1].fdKeyWSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdKeyWSort>=" + keyword.fdKeyWSort + " AND fdKeyWSort<=" + next.fdKeyWSort.ToString();
                    List<AW_KeyWord_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        keyword.fdKeyWSort = list[0].fdKeyWSort;
                        this.funcUpdate(keyword);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdKeyWSort = list[i + 1].fdKeyWSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
            }
            else if (preview != null)
            {
                if (keyword.fdKeyWSort > preview.fdKeyWSort) //从上往下移
                {
                    this.propWhere += " AND fdKeyWSort<=" + keyword.fdKeyWSort + " AND fdKeyWSort>=" + preview.fdKeyWSort.ToString();
                    List<AW_KeyWord_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        keyword.fdKeyWSort = list[list.Count - 1].fdKeyWSort;
                        this.funcUpdate(keyword);
                        for (int i = list.Count - 1; i > 0; i--)
                        {
                            list[i].fdKeyWSort = list[i - 1].fdKeyWSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdKeyWSort>=" + keyword.fdKeyWSort + " AND fdKeyWSort<" + preview.fdKeyWSort.ToString();
                    List<AW_KeyWord_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        keyword.fdKeyWSort = list[0].fdKeyWSort;
                        this.funcUpdate(keyword);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdKeyWSort = list[i + 1].fdKeyWSort;
                            this.funcUpdate(list[i]);
                        }
                    }

                }
            }
        }


        public int funcGetMaxSort()
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                object count = db.ExecuteScalar("SELECT MAX(fdKeyWSort) FROM AW_KeyWord");
                return Convert.IsDBNull(count) ? 0 : (int)count;
            }
        }

	}
}
