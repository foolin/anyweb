using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Tag_Associated_dao : Dao_Base
	{
		public AW_Tag_Associated_dao()
        {
            this._propTable = "AW_Tag_Associated";
            this._propPK = "fdTaAsID";
            this._propFields = "fdTaAsID,fdTaAsTagID,fdTaAsDataID,fdTaAsType";
        }

        public List<AW_Tag_Associated_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Tag_Associated_bean> list = new List<AW_Tag_Associated_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Tag_Associated_bean bean = new AW_Tag_Associated_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
