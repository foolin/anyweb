using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Work_dao : Dao_Base
	{
		public AW_Work_dao()
        {
            this._propTable = "AW_Work";
            this._propPK = "fdWorkID";
            this._propFields = "fdWorkID,fdWorkResuID,fdWorkBegin,fdWorkEnd,fdWorkName,fdWorkIndustryID,fdWorkIndustry,fdWorkDimension,fdWorkType,fdWorkDepartment,fdWorkJobID,fdWorkJob,fdWorkOtherJob,fdWorkIntro,fdWorkIsOverSeas";
        }

        public List<AW_Work_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Work_bean> list = new List<AW_Work_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Work_bean bean = new AW_Work_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
