using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_AD_dao
	{
        /// <summary>
        /// 获取企业图片广告
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_AD_bean> funcGetCompanyADList(int type,int pageSize,int pageIndex,out int recordCount)
        {
            this.propWhere = "fdAdType=" + type;
            this.propOrder = "ORDER BY fdAdSort DESC,fdAdID DESC";
            this.propGetCount = true;
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            List<AW_AD_bean> list = this.funcGetList();
            recordCount = this.propCount;
            return list;
        }

        /// <summary>
        /// 调整图片广告排序
        /// </summary>
        /// <param name="column"></param>
        /// <param name="goodsId"></param>
        /// <param name="nextId"></param>
        /// <param name="previewId"></param>
        public void funcSortAD(int noticeId, int nextId, int previewId)
        {
            AW_AD_bean ad = AW_AD_bean.funcGetByID(noticeId, "fdAdID,fdAdSort");
            AW_AD_bean next = nextId == 0 ? null : AW_AD_bean.funcGetByID(nextId, "fdAdID,fdAdSort");
            AW_AD_bean preview = previewId == 0 ? null : AW_AD_bean.funcGetByID(previewId, "fdAdID,fdAdSort");

            this.propSelect = " fdAdID,fdAdSort";
            this.propOrder = " ORDER BY fdAdSort DESC";

            this._propFields = "fdAdID,fdAdSort";

            if (next != null)
            {
                if (ad.fdAdSort > next.fdAdSort) //从上往下移
                {
                    this.propWhere += " AND fdAdSort<=" + ad.fdAdSort + " AND fdAdSort>" + next.fdAdSort.ToString();
                    List<AW_AD_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        ad.fdAdSort = list[list.Count - 1].fdAdSort;
                        this.funcUpdate(ad);
                        for (int i = 1; i < list.Count; i++)
                        {
                            list[i].fdAdSort = list[i - 1].fdAdSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdAdSort>=" + ad.fdAdSort + " AND fdAdSort<=" + next.fdAdSort.ToString();
                    List<AW_AD_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        ad.fdAdSort = list[0].fdAdSort;
                        this.funcUpdate(ad);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdAdSort = list[i + 1].fdAdSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
            }
            else if (preview != null)
            {
                if (ad.fdAdSort > preview.fdAdSort) //从上往下移
                {
                    this.propWhere += " AND fdAdSort<=" + ad.fdAdSort.ToString() + " AND fdAdSort>=" + preview.fdAdSort.ToString();
                    List<AW_AD_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        ad.fdAdSort = list[list.Count - 1].fdAdSort;
                        this.funcUpdate(ad);
                        for (int i = list.Count - 1; i > 0; i--)
                        {
                            list[i].fdAdSort = list[i - 1].fdAdSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdAdSort>=" + ad.fdAdSort + " AND fdAdSort<" + preview.fdAdSort;
                    List<AW_AD_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        ad.fdAdSort = list[0].fdAdSort;
                        this.funcUpdate(ad);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdAdSort = list[i + 1].fdAdSort;
                            this.funcUpdate(list[i]);
                        }
                    }

                }
            }
        }
	}
}
