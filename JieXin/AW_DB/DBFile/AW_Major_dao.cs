using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Major_dao : Dao_Base
	{
		public AW_Major_dao()
        {
            this._propTable = "AW_Major";
            this._propPK = "fdMajoID";
            this._propFields = "fdMajoID,fdMajoName,fdMajoParent,fdMajoOrder";
        }

        public List<AW_Major_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Major_bean> list = new List<AW_Major_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Major_bean bean = new AW_Major_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
