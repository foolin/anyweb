using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Apply_dao : Dao_Base
	{
		public AW_Apply_dao()
        {
            this._propTable = "AW_Apply";
            this._propPK = "fdApplID";
            this._propFields = "fdApplID,fdApplUserID,fdApplResuID,fdApplRecrID,fdApplCreateAt";
        }

        public List<AW_Apply_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Apply_bean> list = new List<AW_Apply_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Apply_bean bean = new AW_Apply_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
