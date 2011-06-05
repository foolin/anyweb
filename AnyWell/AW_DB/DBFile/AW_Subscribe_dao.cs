using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Subscribe_dao : Dao_Base
	{
		public AW_Subscribe_dao()
        {
            this._propTable = "AW_Subscribe";
            this._propPK = "fdSubsID";
            this._propFields = "fdSubsID,fdSubsSiteID,fdSubsCompany,fdSubsSurname,fdSubsName,fdSubsEmail,fdSubsSort";
        }

        public List<AW_Subscribe_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Subscribe_bean> list = new List<AW_Subscribe_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Subscribe_bean bean = new AW_Subscribe_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
