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
	}
}
