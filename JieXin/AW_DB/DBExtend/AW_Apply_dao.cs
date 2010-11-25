using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Apply_dao
	{
        /// <summary>
        /// 获取已申请的职位
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<int> funcGetExistIds( int userId,int resuId, string ids )
        {
            string sql = string.Format( "SELECT fdApplRecrID FROM AW_Apply WHERE fdApplUserID={0} AND fdApplResuID={1} AND fdApplRecrID IN ({2})", userId, resuId, ids );
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
        /// 获取职位申请列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Apply_bean> funcGetApplyList( int userId, int pageIndex, int pageSize, out int recordCount )
        {
            this.propTableApp = "INNER JOIN AW_Resume ON fdApplResuID=fdResuID INNER JOIN AW_Recruit ON fdApplRecrID=fdRecrID";
            this.propSelect = "fdApplID,fdApplCreateAt,fdRecrID,fdRecrCompany,fdRecrJob,fdRecrAreaName,fdResuName";
            this.propWhere = "fdApplUserID=" + userId;
            this.propOrder = "ORDER BY fdApplID DESC";
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            this.propGetCount = true;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Apply_bean> list = new List<AW_Apply_bean>();
            if( ds.Tables[ 0 ].Rows.Count > 0 )
            {
                foreach( DataRow row in ds.Tables[ 0 ].Rows )
                {
                    AW_Apply_bean bean = new AW_Apply_bean();
                    bean.funcFromDataRow( row );
                    bean.Recruit = new AW_Recruit_bean();
                    bean.Recruit.funcFromDataRow( row );
                    bean.Resume = new AW_Resume_bean();
                    bean.Resume.funcFromDataRow( row );
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
