﻿using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Favorite_dao
	{
        /// <summary>
        /// 获取已收藏的编号
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<int> funcGetExistIds( int userId, string ids )
        {
            string sql = string.Format( "SELECT fdFavoID FROM AW_Favorite WHERE fdFavoUserID={0} AND fdFavoRecrID IN ({1})", userId, ids );
            DataSet ds = this.funcGet( sql );
            if( ds.Tables[ 0 ].Rows.Count > 0 )
            {
                List<int> list = new List<int>();
                foreach( DataRow row in ds.Tables[ 0 ].Rows )
                {
                    list.Add( ( int ) row[ 0 ] );
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取职位收藏列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Favorite_bean> funcGetFavoriteList( int userId, int pageIndex, int pageSize, out int recordCount )
        {
            this.propTableApp = "INNER JOIN AW_Recruit ON fdFavoRecrID=fdRecrID";
            this.propSelect = "fdFavoID,fdFavoCreateAt,fdRecrID,fdRecrCompany,fdRecrJob,fdRecrAreaName";
            this.propWhere = "fdFavoUserID=" + userId;
            this.propOrder = "ORDER BY fdFavoID DESC";
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            this.propGetCount = true;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            if( ds.Tables[ 0 ].Rows.Count > 0 )
            {
                List<AW_Favorite_bean> list = new List<AW_Favorite_bean>();
                foreach( DataRow row in ds.Tables[ 0 ].Rows )
                {
                    AW_Favorite_bean bean = new AW_Favorite_bean();
                    bean.funcFromDataRow( row );
                    bean.Recruit = new AW_Recruit_bean();
                    bean.Recruit.funcFromDataRow( row );
                    list.Add( bean );
                }
                return list;
            }
            else
            {
                return null;
            }
        }
	}
}
