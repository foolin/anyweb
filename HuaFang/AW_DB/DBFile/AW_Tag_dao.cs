using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Tag_dao : Dao_Base
	{
		public AW_Tag_dao()
        {
            this._propTable = "AW_Tag";
            this._propPK = "fdTagID";
            this._propFields = "fdTagID,fdTagName";
        }

        public List<AW_Tag_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Tag_bean> list = new List<AW_Tag_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Tag_bean bean = new AW_Tag_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
