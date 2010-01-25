using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
    public partial class AW_KeyWord_dao : SHOP_daoBase
	{
		public AW_KeyWord_dao()
        {
            this._propTable = "AW_KeyWord";
            this._propPK = "fdKeyWID";
            this._propFields = "fdKeyWID,fdKeyWName,fdKeyWClickCount,fdKeyWCreateAt,fdKeyWUpdateAt,fdKeyWIsShow,fdKeyWSort";
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
