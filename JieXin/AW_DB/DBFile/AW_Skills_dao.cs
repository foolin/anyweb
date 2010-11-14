using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Skills_dao : Dao_Base
	{
		public AW_Skills_dao()
        {
            this._propTable = "AW_Skills";
            this._propPK = "fdSkilID";
            this._propFields = "fdSkilID,fdSkilResuID,fdSkilName,fdSkilMonth,fdSkilLevel";
        }

        public List<AW_Skills_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Skills_bean> list = new List<AW_Skills_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Skills_bean bean = new AW_Skills_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
