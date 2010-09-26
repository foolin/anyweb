using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_KeyWord_dao : Dao_Base
	{
		public AW_KeyWord_dao()
        {
            this._propTable = "AW_KeyWord";
            this._propPK = "fdKeyWID";
            this._propFields = "fdKeyWID,fdKeyWName,fdKeyWCreateAt,fdKeyWIsShow,fdKeyWSort";
        }

        public List<AW_KeyWord_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_KeyWord_bean> list = new List<AW_KeyWord_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_KeyWord_bean bean = new AW_KeyWord_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
