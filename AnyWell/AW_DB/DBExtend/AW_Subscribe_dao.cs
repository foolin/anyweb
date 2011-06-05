using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Subscribe_dao
	{
        /// <summary>
        /// 获取订阅列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<AW_Subscribe_bean> funcGetSubscribeList(string ids)
        {
            this.propWhere = string.Format("fdSubsID IN ({0})", ids);
            return this.funcGetList();
        }

        /// <summary>
        /// 获取订阅列表
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Subscribe_bean> funcGetSubscribeList(int siteId, int pageIndex, int pageSize, out int recordCount)
        {
            this.propWhere = "fdSubsSiteID=" + siteId;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            this.propGetCount = true;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Subscribe_bean> list = new List<AW_Subscribe_bean>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                AW_Subscribe_bean bean = new AW_Subscribe_bean();
                bean.funcFromDataRow(row);
                bean.fdAutoId = pageSize * (pageIndex - 1) + i + 1;
                list.Add(bean);
            }
            return list;
        }

        /// <summary>
        /// 订阅排序
        /// </summary>
        /// <param name="subscribe">订阅</param>    
        /// <param name="preview">上一个订阅</param>
        /// <param name="next">下一个订阅</param>
        public bool funcSortSubscribe(AW_Subscribe_bean subscribe, AW_Subscribe_bean preview, AW_Subscribe_bean next)
        {
            this.propSelect = " fdSubsID,fdSubsSort";
            this.propOrder = " ORDER BY fdSubsSort DESC";
            this._propFields = "fdSubsID,fdSubsSort";

            bool result = false;

            IDbConnection conn = this.NewConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();

            try
            {
                if (next != null)
                {
                    if (subscribe.fdSubsSort > next.fdSubsSort) //从上往下移
                    {
                        this.propWhere += " AND fdSubsSort<=" + subscribe.fdSubsSort + " AND fdSubsSort>" + next.fdSubsSort.ToString();
                        List<AW_Subscribe_bean> list = this.funcGetList();
                        if (list.Count > 1)
                        {
                            subscribe.fdSubsSort = list[list.Count - 1].fdSubsSort;
                            this.funcUpdate(subscribe, tran);
                            for (int i = 1; i < list.Count; i++)
                            {
                                list[i].fdSubsSort = list[i - 1].fdSubsSort;
                                this.funcUpdate(list[i], tran);
                            }
                        }
                    }
                    else //从下往上移
                    {
                        this.propWhere += " AND fdSubsSort>=" + subscribe.fdSubsSort + " AND fdSubsSort<=" + next.fdSubsSort.ToString();
                        List<AW_Subscribe_bean> list = this.funcGetList();
                        if (list.Count > 1)
                        {
                            subscribe.fdSubsSort = list[0].fdSubsSort;
                            this.funcUpdate(subscribe, tran);
                            for (int i = 0; i < list.Count - 1; i++)
                            {
                                list[i].fdSubsSort = list[i + 1].fdSubsSort;
                                this.funcUpdate(list[i], tran);
                            }
                        }
                    }
                }
                else if (preview != null)
                {
                    if (subscribe.fdSubsSort > preview.fdSubsSort) //从上往下移
                    {
                        this.propWhere += " AND fdSubsSort<=" + subscribe.fdSubsSort + " AND fdSubsSort>=" + preview.fdSubsSort.ToString();
                        List<AW_Subscribe_bean> list = this.funcGetList();
                        if (list.Count > 1)
                        {
                            subscribe.fdSubsSort = list[list.Count - 1].fdSubsSort;
                            this.funcUpdate(subscribe, tran);
                            for (int i = list.Count - 1; i > 0; i--)
                            {
                                list[i].fdSubsSort = list[i - 1].fdSubsSort;
                                this.funcUpdate(list[i], tran);
                            }
                        }
                    }
                    else //从下往上移
                    {
                        this.propWhere += " AND fdSubsSort>=" + subscribe.fdSubsSort + " AND fdSubsSort<" + preview.fdSubsSort.ToString();
                        List<AW_Subscribe_bean> list = this.funcGetList();
                        if (list.Count > 1)
                        {
                            subscribe.fdSubsSort = list[0].fdSubsSort;
                            this.funcUpdate(subscribe, tran);
                            for (int i = 0; i < list.Count - 1; i++)
                            {
                                list[i].fdSubsSort = list[i + 1].fdSubsSort;
                                this.funcUpdate(list[i], tran);
                            }
                        }

                    }
                }
                tran.Commit();
                result = true;
            }
            catch (Exception)
            {
                tran.Rollback();
                result = false;
            }
            finally
            {
                conn.Dispose();
            }
            return result;
        }
	}
}
