using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Job_dao : Dao_Base
	{
		public AW_Job_dao()
        {
            this._propTable = "AW_Job";
            this._propPK = "fdJobID";
            this._propFields = "fdJobID,fdJobName,fdJobParent,fdJobOrder";
        }

        public List<AW_Job_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Job_bean> list = new List<AW_Job_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Job_bean bean = new AW_Job_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
