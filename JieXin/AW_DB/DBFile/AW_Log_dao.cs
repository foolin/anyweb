using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Log_dao : Dao_Base
	{
		public AW_Log_dao()
        {
            this._propTable = "AW_Log";
            this._propPK = "fdLogID";
            this._propFields = "fdLogID,fdLogName,fdLogDesc,fdLogAccount,fdLogType,fdLogIP,fdLogCreateAt";
        }

        public List<AW_Log_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Log_bean> list = new List<AW_Log_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Log_bean bean = new AW_Log_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
