using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Awards_dao : Dao_Base
	{
		public AW_Awards_dao()
        {
            this._propTable = "AW_Awards";
            this._propPK = "fdAwarID";
            this._propFields = "fdAwarID,fdAwarResuID,fdAwarDate,fdAwarName";
        }

        public List<AW_Awards_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Awards_bean> list = new List<AW_Awards_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Awards_bean bean = new AW_Awards_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
