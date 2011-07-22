using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Data;
using Studio.Web;

namespace AnyWell.AW_DL
{
    public partial class AW_Library_dao
    {
        /// <summary>
        /// 根据库名和首字母获取库列表
        /// </summary>
        /// <param name="library"></param>
        /// <param name="firstLetter"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<AW_Library_bean> funcGetLibrary(int library, int firstLetter, int pageSize, int pageIndex)
        {
            this.propSelect = "fdLibrID,fdLibrType,fdLibrName,fdLibrEnName,fdLibrFirLetter,fdLibrDesc,fdLibrSort";
            this.propOrder = "ORDER BY fdLibrID DESC";
            this.propWhere = string.Format( " fdLibrType={0} AND fdLibrFirLetter={1}", library, firstLetter );

            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propGetCount = true;

            List<AW_Library_bean> list = this.funcGetList();
            return list;
        }

        /// <summary>
        /// 根据ID获取库信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AW_Library_bean funcGetLibraryItemByID(int id)
        {
            this.propSelect = "fdLibrID,fdLibrType,fdLibrName,fdLibrEnName,fdLibrFirLetter,fdLibrDesc,fdLibrSort";
            this.propWhere = " fdLibrID = " + id.ToString();

            List<AW_Library_bean> list = this.funcGetList();
            return list[0];
        }

        /// <summary>
        /// 调整库信息排序
        /// </summary>
        /// <param name="column"></param>
        /// <param name="Id"></param>
        /// <param name="nextId"></param>
        /// <param name="previewId"></param>
        public void funcSortLibrary(int Id, int nextId, int previewId)
        {
            AW_Library_bean bean = AW_Library_bean.funcGetByID(Id, "fdLibrID,fdLibrSort");
            AW_Library_bean next = nextId == 0 ? null : AW_Library_bean.funcGetByID(nextId, "fdLibrID,fdLibrSort");
            AW_Library_bean preview = previewId == 0 ? null : AW_Library_bean.funcGetByID(previewId, "fdLibrID,fdLibrSort");

            this.propSelect = " fdLibrID,fdLibrSort";
            this.propOrder = " ORDER BY fdLibrSort DESC";
            this._propFields = "fdLibrID,fdLibrSort";

            if (next != null)
            {
                if (bean.fdLibrSort > next.fdLibrSort) //从上往下移
                {
                    this.propWhere += " AND fdLibrSort<=" + bean.fdLibrSort + " AND fdLibrSort>" + next.fdLibrSort.ToString();
                    List<AW_Library_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        bean.fdLibrSort = list[list.Count - 1].fdLibrSort;
                        this.funcUpdate(bean);
                        for (int i = 1; i < list.Count; i++)
                        {
                            list[i].fdLibrSort = list[i - 1].fdLibrSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdLibrSort>=" + bean.fdLibrSort + " AND fdLibrSort<=" + next.fdLibrSort.ToString();
                    List<AW_Library_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        bean.fdLibrSort = list[0].fdLibrSort;
                        this.funcUpdate(bean);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdLibrSort = list[i + 1].fdLibrSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
            }
            else if (preview != null)
            {
                if (bean.fdLibrSort > preview.fdLibrSort) //从上往下移
                {
                    this.propWhere += " AND fdLibrSort<=" + bean.fdLibrSort + " AND fdLibrSort>=" + preview.fdLibrSort.ToString();
                    List<AW_Library_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        bean.fdLibrSort = list[list.Count - 1].fdLibrSort;
                        this.funcUpdate(bean);
                        for (int i = list.Count - 1; i > 0; i--)
                        {
                            list[i].fdLibrSort = list[i - 1].fdLibrSort;
                            this.funcUpdate(list[i]);
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdLibrSort>=" + bean.fdLibrSort + " AND fdLibrSort<" + preview.fdLibrSort.ToString();
                    List<AW_Library_bean> list = this.funcGetList();
                    if (list.Count > 1)
                    {
                        bean.fdLibrSort = list[0].fdLibrSort;
                        this.funcUpdate(bean);
                        for (int i = 0; i < list.Count - 1; i++)
                        {
                            list[i].fdLibrSort = list[i + 1].fdLibrSort;
                            this.funcUpdate(list[i]);
                        }
                    }

                }
            }
        }
    }
}
