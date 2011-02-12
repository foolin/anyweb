using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_TableId_dao : Dao_Base
	{
		public AW_TableId_dao()
        {
            this._propTable = "AW_TableId";
            this._propPK = "fdTableName";
            this._propFields = "fdTableName,fdNextID";
        }

        public List<AW_TableId_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_TableId_bean> list = new List<AW_TableId_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_TableId_bean bean = new AW_TableId_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
