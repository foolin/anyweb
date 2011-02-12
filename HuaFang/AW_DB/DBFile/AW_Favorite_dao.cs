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
	public partial class AW_Favorite_dao : Dao_Base
	{
		public AW_Favorite_dao()
        {
            this._propTable = "AW_Favorite";
            this._propPK = "fdFavoID";
            this._propFields = "fdFavoID,fdFavoMemberID,fdFavoGoodsID,fdFavoCreateAt";
        }

        public List<AW_Favorite_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Favorite_bean> list = new List<AW_Favorite_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Favorite_bean bean = new AW_Favorite_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
