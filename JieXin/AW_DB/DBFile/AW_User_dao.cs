using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_User_dao : Dao_Base
	{
		public AW_User_dao()
        {
            this._propTable = "AW_User";
            this._propPK = "fdUserID";
            this._propFields = "fdUserID,fdUserAccount,fdUserPwd,fdUserStatus";
        }

        public List<AW_User_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_User_bean> list = new List<AW_User_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_User_bean bean = new AW_User_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
