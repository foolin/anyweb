using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_Relation_dao : Dao_Base
	{
		public AW_Relation_dao()
        {
            this._propTable = "AW_Relation";
            this._propPK = "fdRelaID";
            this._propFields = "fdRelaID,fdRelaColuID,fdRelaTitle,fdRelaDesc,fdRelaLink,fdRelaSort";
        }

        public List<AW_Relation_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Relation_bean> list = new List<AW_Relation_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Relation_bean bean = new AW_Relation_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
