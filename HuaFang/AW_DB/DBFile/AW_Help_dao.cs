using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Help_dao : Dao_Base
	{
		public AW_Help_dao()
        {
            this._propTable = "AW_Help";
            this._propPK = "fdHelpID";
            this._propFields = "fdHelpID,fdHelpTypeID,fdHelpQuestion,fdHelpAnswer,fdHelpSort,fdHelpCreateAt";
        }

        public List<AW_Help_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Help_bean> list = new List<AW_Help_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Help_bean bean = new AW_Help_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
