using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Link_dao
	{
        /// <summary>
        /// 获取链接列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Link_bean> funcGetLinkList( int pageSize, int pageIndex, out int recordCount )
        {
            this.propOrder = "ORDER BY fdLinkSort DESC,fdLinkID DESC";
            this.propGetCount = true;
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            List<AW_Link_bean> list = this.funcGetList();
            recordCount = this.propCount;
            return list;
        }

        /// <summary>
        /// 调整友情链接排序
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="nextId"></param>
        /// <param name="previewId"></param>
        public void funcSortLink( int linkId, int nextId, int previewId )
        {
            AW_Link_bean link = AW_Link_bean.funcGetByID( linkId, "fdLinkID,fdLinkSort" );
            AW_Link_bean next = nextId == 0 ? null : AW_Link_bean.funcGetByID( nextId, "fdLinkID,fdLinkSort" );
            AW_Link_bean preview = previewId == 0 ? null : AW_Link_bean.funcGetByID( previewId, "fdLinkID,fdLinkSort" );

            this.propSelect = " fdLinkID,fdLinkSort";
            this.propOrder = " ORDER BY fdLinkSort DESC";

            this._propFields = "fdLinkID,fdLinkSort";

            if( next != null )
            {
                if( link.fdLinkSort > next.fdLinkSort ) //从上往下移
                {
                    this.propWhere += " AND fdLinkSort<=" + link.fdLinkSort + " AND fdLinkSort>" + next.fdLinkSort.ToString();
                    List<AW_Link_bean> list = this.funcGetList();
                    if( list.Count > 1 )
                    {
                        link.fdLinkSort = list[ list.Count - 1 ].fdLinkSort;
                        this.funcUpdate( link );
                        for( int i = 1; i < list.Count; i++ )
                        {
                            list[ i ].fdLinkSort = list[ i - 1 ].fdLinkSort;
                            this.funcUpdate( list[ i ] );
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdLinkSort>=" + link.fdLinkSort + " AND fdLinkSort<=" + next.fdLinkSort.ToString();
                    List<AW_Link_bean> list = this.funcGetList();
                    if( list.Count > 1 )
                    {
                        link.fdLinkSort = list[ 0 ].fdLinkSort;
                        this.funcUpdate( link );
                        for( int i = 0; i < list.Count - 1; i++ )
                        {
                            list[ i ].fdLinkSort = list[ i + 1 ].fdLinkSort;
                            this.funcUpdate( list[ i ] );
                        }
                    }
                }
            }
            else if( preview != null )
            {
                if( link.fdLinkSort > preview.fdLinkSort ) //从上往下移
                {
                    this.propWhere += " AND fdLinkSort<=" + link.fdLinkSort + " AND fdLinkSort>=" + preview.fdLinkSort.ToString();
                    List<AW_Link_bean> list = this.funcGetList();
                    if( list.Count > 1 )
                    {
                        link.fdLinkSort = list[ list.Count - 1 ].fdLinkSort;
                        this.funcUpdate( link );
                        for( int i = list.Count - 1; i > 0; i-- )
                        {
                            list[ i ].fdLinkSort = list[ i - 1 ].fdLinkSort;
                            this.funcUpdate( list[ i ] );
                        }
                    }
                }
                else //从下往上移
                {
                    this.propWhere += " AND fdLinkSort>=" + link.fdLinkSort + " AND fdLinkSort<" + preview.fdLinkSort.ToString();
                    List<AW_Link_bean> list = this.funcGetList();
                    if( list.Count > 1 )
                    {
                        link.fdLinkSort = list[ 0 ].fdLinkSort;
                        this.funcUpdate( link );
                        for( int i = 0; i < list.Count - 1; i++ )
                        {
                            list[ i ].fdLinkSort = list[ i + 1 ].fdLinkSort;
                            this.funcUpdate( list[ i ] );
                        }
                    }

                }
            }
        }

        /// <summary>
        /// 获取友情链接列表
        /// </summary>
        /// <returns></returns>
        public List<AW_Link_bean> funcGetLinkList()
        {
            this.propOrder = "ORDER BY fdLinkSort DESC,fdLinkID DESC";
            return this.funcGetList();
        }
	}
}
