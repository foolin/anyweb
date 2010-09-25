using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
    public partial class AW_ADManage_dao
    {
        /// <summary>
        /// 获取广告
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_ADManage_bean> funcGetADList(int type, int pageSize, int pageIndex, out int recordCount)
        {
            this.propWhere = "fdAdType=" + type;
            this.propOrder = "ORDER BY fdAdSort DESC,fdAdID DESC";
            this.propGetCount = true;
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            List<AW_ADManage_bean> list = this.funcGetList();
            recordCount = this.propCount;
            return list;
        }

        /// <summary>
        /// 调整广告排序
        /// </summary>
        /// <param name="column"></param>
        /// <param name="goodsId"></param>
        /// <param name="nextId"></param>
        /// <param name="previewId"></param>
        public void funcSortAD(int noticeId, int nextId, int previewId)
        {
            AW_ADManage_bean ad = AW_ADManage_bean.funcGetByID(noticeId, "fdAdID,fdAdSort");
            AW_ADManage_bean next = nextId == 0 ? null : AW_ADManage_bean.funcGetByID(nextId, "fdAdID,fdAdSort");
            AW_ADManage_bean preview = previewId == 0 ? null : AW_ADManage_bean.funcGetByID(previewId, "fdAdID,fdAdSort");

            this.propSelect = " fdAdID,fdAdSort";
            this.propOrder = " ORDER BY fdAdSort DESC";

            this._propFields = "fdAdID,fdAdSort";

            if (next != null)
            {
                if (ad.fdAdManageSort > next.fdAdManageSort) //从上往下移
                {
                    this.propWhere += " AND fdAdSort<=" + ad.fdAdManageSort + " AND fdAdSort>" + next.fdAdManageSort.ToString();
                    List<AW_ADManage_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        ad.fdAdManageSort = list[list.Count - 1].fdAdManageSort;
                        this.funcUpdate(ad);
                        for (int i = 1; i < list.Count; i++)
                        {
                            list[i].fdAdManageSort = list[i - 1].fdAdManageSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdAdSort>=" + ad.fdAdManageSort + " AND fdAdSort<=" + next.fdAdManageSort.ToString();
                    List<AW_ADManage_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        ad.fdAdManageSort = list[0].fdAdManageSort;
                        this.funcUpdate(ad);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdAdManageSort = list[i + 1].fdAdManageSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
            }
            else if (preview != null)
            {
                if (ad.fdAdManageSort > preview.fdAdManageSort) //从上往下移
                {
                    this.propWhere += " AND fdAdSort<=" + ad.fdAdManageSort.ToString() + " AND fdAdSort>=" + preview.fdAdManageSort.ToString();
                    List<AW_ADManage_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        ad.fdAdManageSort = list[list.Count - 1].fdAdManageSort;
                        this.funcUpdate(ad);
                        for (int i = list.Count - 1; i > 0; i--)
                        {
                            list[i].fdAdManageSort = list[i - 1].fdAdManageSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdAdSort>=" + ad.fdAdManageSort + " AND fdAdSort<" + preview.fdAdManageSort;
                    List<AW_ADManage_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        ad.fdAdManageSort = list[0].fdAdManageSort;
                        this.funcUpdate(ad);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdAdManageSort = list[i + 1].fdAdManageSort;
                            this.funcUpdate(list[i]);
                        }
                    }

                }
            }
        }
    }
}
