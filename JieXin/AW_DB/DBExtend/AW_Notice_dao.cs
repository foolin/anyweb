using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Notice_dao
	{
        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Notice_bean> funcGetNoticeList(int pageSize, int pageIndex, out int recordCount)
        {
            this.propSelect = "fdNotiID,fdNotiTitle,fdNotiCreateAt";
            this.propOrder = "ORDER BY fdNotiOrder DESC,fdNotiID DESC";
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            List<AW_Notice_bean> list = this.funcGetList();
            recordCount = this.propCount;
            return list;
        }

        /// <summary>
        /// 调整公告排序
        /// </summary>
        /// <param name="column"></param>
        /// <param name="goodsId"></param>
        /// <param name="nextId"></param>
        /// <param name="previewId"></param>
        public void funcSortNotice(int noticeId, int nextId, int previewId)
        {
            AW_Notice_bean notice = AW_Notice_bean.funcGetByID(noticeId, "fdNotiID,fdNotiOrder");
            AW_Notice_bean next = nextId == 0 ? null : AW_Notice_bean.funcGetByID(nextId, "fdNotiID,fdNotiOrder");
            AW_Notice_bean preview = previewId == 0 ? null : AW_Notice_bean.funcGetByID(previewId, "fdNotiID,fdNotiOrder");

            this.propSelect = " fdNotiID,fdNotiOrder";
            this.propOrder = " ORDER BY fdNotiOrder DESC";

            this._propFields = "fdNotiID,fdNotiOrder";

            if (next != null)
            {
                if (notice.fdNotiOrder > next.fdNotiOrder) //从上往下移
                {
                    this.propWhere += " AND fdNotiOrder<=" + notice.fdNotiOrder + " AND fdNotiOrder>" + next.fdNotiOrder.ToString();
                    List<AW_Notice_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        notice.fdNotiOrder = list[list.Count - 1].fdNotiOrder;
                        this.funcUpdate(notice);
                        for (int i = 1; i < list.Count; i++)
                        {
                            list[i].fdNotiOrder = list[i - 1].fdNotiOrder;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdNotiOrder>=" + notice.fdNotiOrder + " AND fdNotiOrder<=" + next.fdNotiOrder.ToString();
                    List<AW_Notice_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        notice.fdNotiOrder = list[0].fdNotiOrder;
                        this.funcUpdate(notice);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdNotiOrder = list[i + 1].fdNotiOrder;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
            }
            else if (preview != null)
            {
                if (notice.fdNotiOrder > preview.fdNotiOrder) //从上往下移
                {
                    this.propWhere += " AND fdNotiOrder<=" + notice.fdNotiOrder.ToString() + " AND fdNotiOrder>=" + preview.fdNotiOrder.ToString();
                    List<AW_Notice_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        notice.fdNotiOrder = list[list.Count - 1].fdNotiOrder;
                        this.funcUpdate(notice);
                        for (int i = list.Count - 1; i > 0; i--)
                        {
                            list[i].fdNotiOrder = list[i - 1].fdNotiOrder;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdNotiOrder>=" + notice.fdNotiOrder + " AND fdNotiOrder<" + preview.fdNotiOrder;
                    List<AW_Notice_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        notice.fdNotiOrder = list[0].fdNotiOrder;
                        this.funcUpdate(notice);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdNotiOrder = list[i + 1].fdNotiOrder;
                            this.funcUpdate(list[i]);
                        }
                    }

                }
            }
        }


        /**************************************************自定义控件********************************************************************************/
        string selectStr = "fdNotiID,fdNotiTitle,fdNotiOrder,fdNotiCreateAt";

        /// <summary>
        /// 下一篇公告编号
        /// </summary>
        /// <param name="articleID"></param>
        /// <param name="columnid"></param>
        /// <returns></returns>
        public int funcGetNextNoticeIDByUC(int noticeID)
        {
            string cmdText = "SELECT TOP 1 fdNotiID FROM AW_Notice WHERE fdNotiOrder<(SELECT fdNotiOrder FROM AW_Notice WHERE fdNotiID=@fdNotiID) ORDER BY fdNotiOrder DESC";

            object nextNoticeID;
            using (IDbExecutor db = this.NewExecutor())
            {
                nextNoticeID = db.ExecuteScalar(CommandType.Text, cmdText,
                this.NewParam("@fdNotiID", noticeID));
            }
            if (nextNoticeID == null || nextNoticeID == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return int.Parse(nextNoticeID.ToString());
            }
        }

        /// <summary>
        /// 上一篇公告编号
        /// </summary>
        /// <param name="articleID"></param>
        /// <param name="columnid"></param>
        /// <returns></returns>
        public int funcGetPreviousNoticeIDByUC(int noticeID)
        {
            string cmdText = "SELECT TOP 1 fdNotiID FROM AW_Notice WHERE fdNotiOrder>(SELECT fdNotiOrder FROM AW_Notice WHERE fdNotiID=@fdNotiID) ORDER BY fdNotiOrder";

            object previousNoticeID;
            using (IDbExecutor db = this.NewExecutor())
            {
                previousNoticeID = db.ExecuteScalar(CommandType.Text, cmdText,
                this.NewParam("@fdNotiID", noticeID));
            }
            if (previousNoticeID == null || previousNoticeID == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return int.Parse(previousNoticeID.ToString());
            }
        }

        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="topCount">前n条</param>
        /// <param name="where">附加筛选条件</param>
        /// <param name="order">附加排序条件</param>
        /// <param name="cacheName">缓存名称</param>
        /// <param name="getContent">是否获取公告内容</param>
        /// <returns></returns>
        public List<AW_Notice_bean> funcGetNoticeListByUC(int topCount, string where, string order, string cacheName, bool getContent)
        {
            if (!string.IsNullOrEmpty(cacheName) && HttpRuntime.Cache["NOTICE_CACHE_UC_" + cacheName] != null)
            {
                return (List<AW_Notice_bean>)HttpRuntime.Cache["NOTICE_CACHE_UC_" + cacheName];
            }

            this.propSelect = this.selectStr;
            if (getContent)
            {
                this.propSelect += ",fdNotiContent";
            }

            if (topCount > 0)
            {
                this.propSelect = " TOP " + topCount + " " + this.propSelect;
            }

            this.propWhere = "1=1";

            if (string.IsNullOrEmpty(where) == false)
            {
                this.propWhere += " AND " + where.Replace(";", "；").Replace("--", "－－");
            }

            if (string.IsNullOrEmpty(order) == false)
            {
                this.propOrder = "ORDER BY " + funcReplaceSqlField(order);
            }
            else
            {
                this.propOrder = "ORDER BY fdNotiOrder DESC";
            }

            List<AW_Notice_bean> notices = this.funcGetList();

            if (!string.IsNullOrEmpty(cacheName))
            {
                HttpRuntime.Cache.Insert("NOTICE_CACHE_UC_" + cacheName, notices, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(20), System.Web.Caching.CacheItemPriority.NotRemovable, null);
            }

            return notices;
        }

        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="where">附加筛选条件</param>
        /// <param name="order">附加排序条件</param>
        /// <param name="pageID">当前页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="getContent">是否获取文章内容</param>
        /// <returns></returns>
        public List<AW_Notice_bean> funcGetNoticeListByUC(string where, string order, int pageID, int pageSize, out int recordCount, bool getContent)
        {
            this.propSelect = this.selectStr;
            if (getContent)
            {
                this.propSelect += ",fdArtiContent";
            }

            this.propWhere = "1=1";

            if (string.IsNullOrEmpty(where) == false)
            {
                this.propWhere += " AND " + where.Replace(";", "；").Replace("--", "－－");
            }

            if (string.IsNullOrEmpty(order) == false)
            {
                this.propOrder = "ORDER BY " + funcReplaceSqlField(order);
            }
            else
            {
                this.propOrder = "ORDER BY fdNotiOrder DESC";
            }

            this.propPage = pageID;
            this.propPageSize = pageSize;
            this.propGetCount = true;

            List<AW_Notice_bean> notices = this.funcGetList();
            recordCount = this.propCount;

            return notices;
        }
	}
}
