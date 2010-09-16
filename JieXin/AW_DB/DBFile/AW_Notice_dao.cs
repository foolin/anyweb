using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Notice_dao : Dao_Base
	{
		public AW_Notice_dao()
        {
            this._propTable = "AW_Notice";
            this._propPK = "fdNotiID";
            this._propFields = "fdNotiID,fdNotiTitle,fdNotiContent,fdNotiOrder,fdNotiCreateAt";
        }

        public List<AW_Notice_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Notice_bean> list = new List<AW_Notice_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Notice_bean bean = new AW_Notice_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
