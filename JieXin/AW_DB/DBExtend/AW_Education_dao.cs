using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Education_dao
	{
        public List<AW_Education_bean> funcGetEducationList( int resuId )
        {
            this.propWhere = "fdEducResuID=" + resuId;
            return this.funcGetList();
        }

        /// <summary>
        /// 根据简历编号获取最高教育经历
        /// </summary>
        /// <param name="resuId"></param>
        /// <returns></returns>
        public AW_Education_bean funcGetByResuID( int resuId )
        {
            this.propSelect = "TOP 1 fdEducSpeciality,fdEducOtherSpecialty,fdEducDegree";
            this.propWhere = "fdEducResuID=" + resuId;
            this.propOrder = "ORDER BY fdEducDegree DESC";
            DataSet ds = this.funcCommon();
            if( ds.Tables[ 0 ].Rows.Count > 0 )
            {
                AW_Education_bean bean = new AW_Education_bean();
                bean.funcFromDataRow( ds.Tables[ 0 ].Rows[ 0 ] );
                return bean;
            }
            else
            {
                return null;
            }
        }

        public DataSet funcGetByResuIDs( string ids )
        {
            this.propSelect = "fdEducResuID,fdEducSpeciality,fdEducOtherSpecialty,fdEducDegree";
            this.propWhere = string.Format( "fdEducResuID IN ({0})", ids );
            return this.funcCommon();
        }
	}
}
