using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Column_dao : Dao_Base
	{
		public AW_Column_dao()
        {
            this._propTable = "AW_Column";
            this._propPK = "fdColuID";
            this._propFields = "fdColuID,fdColuName,fdColuSort,fdColuDescription,fdColuParentID";
        }

        public List<AW_Column_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Column_bean> list = new List<AW_Column_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Column_bean bean = new AW_Column_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
