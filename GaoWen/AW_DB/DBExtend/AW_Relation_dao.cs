using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_Relation_dao
	{
        /// <summary>
        /// 根据栏目获取信息关联列表
        /// </summary>
        /// <param name="column"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<AW_Relation_bean> funcGetRelation(AW_Column_bean column, int pageSize, int pageIndex)
        {
            this.propSelect = "r.*,c.fdColuName,c.fdColuPicture";
            this.propTableApp = " r INNER JOIN AW_Column c ON r.fdRelaColuID = c.fdColuID";
            this.propOrder = "ORDER BY r.fdRelaSort DESC,r.fdRelaID DESC";
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
            List<AW_Relation_bean> list = new List<AW_Relation_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Relation_bean bean = new AW_Relation_bean();
                bean.funcFromDataRow(r);
                bean.Column = new AW_Column_bean();
                bean.Column.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }

        /// <summary>
        /// 获取首页关联列表
        /// </summary>
        /// <param name="columnID"></param>
        /// <returns></returns>
        public List<AW_Relation_bean> funcGetRelationList(int columnID)
        {
            this.propTopCount = 20;
            this.propWhere = "fdRelaColuID=" + columnID;            
            this.propOrder = "ORDER BY fdRelaSort DESC,fdRelaID DESC";
            return this.funcGetList();
        }

        /// <summary>
        /// 调整信息关联排序
        /// </summary>
        /// <param name="column"></param>
        /// <param name="goodsId"></param>
        /// <param name="nextId"></param>
        /// <param name="previewId"></param>
        public void funcSortRelation(int relationId, int nextId, int previewId)
        {
            AW_Relation_bean relation = AW_Relation_bean.funcGetByID(relationId, "fdRelaID,fdRelaSort");
            AW_Relation_bean next = nextId == 0 ? null : AW_Relation_bean.funcGetByID(nextId, "fdRelaID,fdRelaSort");
            AW_Relation_bean preview = previewId == 0 ? null : AW_Relation_bean.funcGetByID(previewId, "fdRelaID,fdRelaSort");

            this.propSelect = " fdRelaID,fdRelaSort";
            this.propOrder = " ORDER BY fdRelaSort DESC";

            this._propFields = "fdRelaID,fdRelaSort";

            if (next != null)
            {
                if (relation.fdRelaSort > next.fdRelaSort) //从上往下移
                {
                    this.propWhere += " AND fdRelaSort<=" + relation.fdRelaSort + " AND fdRelaSort>" + next.fdRelaSort.ToString();
                    List<AW_Relation_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        relation.fdRelaSort = list[list.Count - 1].fdRelaSort;
                        this.funcUpdate(relation);
                        for (int i = 1; i < list.Count; i++)
                        {
                            list[i].fdRelaSort = list[i - 1].fdRelaSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdRelaSort>=" + relation.fdRelaSort + " AND fdRelaSort<=" + next.fdRelaSort.ToString();
                    List<AW_Relation_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        relation.fdRelaSort = list[0].fdRelaSort;
                        this.funcUpdate(relation);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdRelaSort = list[i + 1].fdRelaSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
            }
            else if (preview != null)
            {
                if (relation.fdRelaSort > preview.fdRelaSort) //从上往下移
                {
                    this.propWhere += " AND fdRelaSort<=" + relation.fdRelaSort + " AND fdRelaSort>=" + preview.fdRelaSort.ToString();
                    List<AW_Relation_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        relation.fdRelaSort = list[list.Count - 1].fdRelaSort;
                        this.funcUpdate(relation);
                        for (int i = list.Count - 1; i > 0; i--)
                        {
                            list[i].fdRelaSort = list[i - 1].fdRelaSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdRelaSort>=" + relation.fdRelaSort + " AND fdRelaSort<" + preview.fdRelaSort.ToString();
                    List<AW_Relation_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        relation.fdRelaSort = list[0].fdRelaSort;
                        this.funcUpdate(relation);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdRelaSort = list[i + 1].fdRelaSort;
                            this.funcUpdate(list[i]);
                        }
                    }

                }
            }
        }
	}
}
