using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Industry_dao : Dao_Base
	{
		public AW_Industry_dao()
        {
            this._propTable = "AW_Industry";
            this._propPK = "fdInduID";
            this._propFields = "fdInduID,fdInduName,fdInduParent,fdInduOrder";
        }

        public List<AW_Industry_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Industry_bean> list = new List<AW_Industry_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Industry_bean bean = new AW_Industry_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
