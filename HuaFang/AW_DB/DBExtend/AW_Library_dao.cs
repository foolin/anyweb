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
            this.propSelect = "fdLibrID,fdLibrType,fdLibrName,fdLibrEnName,fdLibrFirLetter,fdLibrPic,fdLibrDesc,fdLibrSort";
            this.propOrder = "ORDER BY fdLibrSort DESC,fdLibrID DESC";
            this.propWhere = "1=1";
            if( library > 0 )
            {
                this.propWhere += " AND fdLibrType=" + library;
            }
            if( firstLetter > -1 )
            {
                this.propWhere += " AND fdLibrFirLetter=" + firstLetter;
            }

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
            AW_Library_bean bean = AW_Library_bean.funcGetByID( Id, "fdLibrID,fdLibrSort,fdLibrType,fdLibrFirLetter" );
            AW_Library_bean next = nextId == 0 ? null : AW_Library_bean.funcGetByID(nextId, "fdLibrID,fdLibrSort");
            AW_Library_bean preview = previewId == 0 ? null : AW_Library_bean.funcGetByID(previewId, "fdLibrID,fdLibrSort");

            this.propSelect = " fdLibrID,fdLibrSort";
            this.propOrder = " ORDER BY fdLibrSort DESC";
            this._propFields = "fdLibrID,fdLibrSort";

            if (next != null)
            {
                if (bean.fdLibrSort > next.fdLibrSort) //从上往下移
                {
                    this.propWhere += " AND fdLibrSort<=" + bean.fdLibrSort + " AND fdLibrSort>" + next.fdLibrSort.ToString() + " AND fdLibrType=" + bean.fdLibrType + " AND fdLibrFirLetter=" + bean.fdLibrFirLetter;
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
                    this.propWhere += " AND fdLibrSort>=" + bean.fdLibrSort + " AND fdLibrSort<=" + next.fdLibrSort.ToString() + " AND fdLibrType=" + bean.fdLibrType + " AND fdLibrFirLetter=" + bean.fdLibrFirLetter;
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
                    this.propWhere += " AND fdLibrSort<=" + bean.fdLibrSort + " AND fdLibrSort>=" + preview.fdLibrSort.ToString() + " AND fdLibrType=" + bean.fdLibrType + " AND fdLibrFirLetter=" + bean.fdLibrFirLetter;
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
                    this.propWhere += " AND fdLibrSort>=" + bean.fdLibrSort + " AND fdLibrSort<" + preview.fdLibrSort.ToString() + " AND fdLibrType=" + bean.fdLibrType + " AND fdLibrFirLetter=" + bean.fdLibrFirLetter;
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

        public List<AW_Library_bean> funcGetLibraryList( int library, int firstLetter, int libId, int topCount )
        {
            this.propSelect = "fdLibrID,fdLibrType,fdLibrName,fdLibrEnName,fdLibrFirLetter,fdLibrPic,fdLibrDesc,fdLibrSort";
            if( topCount > 0 )
            {
                this.propSelect = string.Format( "TOP {0} {1}", topCount, this.propSelect );
            }
            this.propWhere = string.Format( "fdLibrType={0} AND fdLibrFirLetter={1}", library, firstLetter );
            if( libId > 0 )
            {
                this.propWhere += " AND fdLibrID<>" + libId;
            }
            this.propOrder = "ORDER BY fdLibrSort DESC,fdLibrID DESC";
            List<AW_Library_bean> list = this.funcGetList();
            return list;
        }

        public List<AW_Library_bean> funcGetLibrary( int library, string key, int pageSize, int pageIndex )
        {
            this.propSelect = "fdLibrID,fdLibrType,fdLibrName,fdLibrEnName,fdLibrFirLetter,fdLibrPic,fdLibrDesc,fdLibrSort";
            this.propOrder = "ORDER BY fdLibrSort DESC,fdLibrID DESC";
            this.propWhere = string.Format( " fdLibrType={0} AND ({1})", library, key );

            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propGetCount = true;

            List<AW_Library_bean> list = this.funcGetList();
            return list;
        }

        public AW_Library_bean funcGetNextLibrary( AW_Library_bean library )
        {
            string cmdText = string.Format( "SELECT TOP 1 fdLibrID,fdLibrType,fdLibrName,fdLibrEnName FROM AW_Library WHERE fdLibrType={0} AND fdLibrFirLetter={1} AND fdLibrSort<{2} ORDER BY fdLibrSort DESC", library.fdLibrType, library.fdLibrFirLetter, library.fdLibrSort );
            DataSet ds = this.funcGet( cmdText );
            AW_Library_bean bean = new AW_Library_bean();
            if( ds.Tables[ 0 ].Rows.Count > 0 )
            {
                bean.funcFromDataRow( ds.Tables[ 0 ].Rows[ 0 ] );
                return bean;
            }
            else
            {
                return null;
            }
        }

        public AW_Library_bean funcGetPreLibrary( AW_Library_bean library )
        {
            string cmdText = string.Format( "SELECT TOP 1 fdLibrID,fdLibrType,fdLibrName,fdLibrEnName FROM AW_Library WHERE fdLibrType={0} AND fdLibrFirLetter={1} AND fdLibrSort>{2} ORDER BY fdLibrSort", library.fdLibrType, library.fdLibrFirLetter, library.fdLibrSort );
            DataSet ds = this.funcGet( cmdText );
            AW_Library_bean bean = new AW_Library_bean();
            if( ds.Tables[ 0 ].Rows.Count > 0 )
            {
                bean.funcFromDataRow( ds.Tables[ 0 ].Rows[ 0 ] );
                return bean;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据库名和首字母获取库列表
        /// </summary>
        /// <param name="library"></param>
        /// <param name="firstLetter"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<AW_Library_bean> funcGetLibrary( int library, int firstLetter, int sort, int pageSize, int pageIndex )
        {
            this.propSelect = "fdLibrID,fdLibrType,fdLibrName,fdLibrEnName,fdLibrFirLetter,fdLibrPic,fdLibrDesc,fdLibrSort";
            this.propOrder = "ORDER BY fdLibrEnName ASC";
            if( sort == 1 )
            {
                this.propOrder = "ORDER BY fdLibrName ASC";
            }
            this.propWhere = "1=1";
            if( library > 0 )
            {
                this.propWhere += " AND fdLibrType=" + library;
            }
            if( firstLetter > -1 )
            {
                this.propWhere += " AND fdLibrFirLetter=" + firstLetter;
            }

            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propGetCount = true;

            List<AW_Library_bean> list = this.funcGetList();
            return list;
        }
    }
}
