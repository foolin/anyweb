using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWeb.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_EventLog_dao : Dao_Base
	{
		public AW_EventLog_dao()
        {
            this._propTable = "AW_EventLog";
            this._propPK = "fdEvenID";
            this._propFields = "fdEvenID,fdEvenAdmiID,fdEvenName,fdEventType,fdEvenDescription,fdEvenCreateAt,fdEvenIP";
        }

        public List<AW_EventLog_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_EventLog_bean> list = new List<AW_EventLog_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_EventLog_bean bean = new AW_EventLog_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
