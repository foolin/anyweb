using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Navigation_dao : Dao_Base
	{
		public AW_Navigation_dao()
        {
            this._propTable = "AW_Navigation";
            this._propPK = "fdNaviID";
            this._propFields = "fdNaviID,fdNaviItemID,fdNaviTitle,fdNaviLink,fdNaviType,fdNaviParentID,fdNaviSort";
        }

        public List<AW_Navigation_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Navigation_bean> list = new List<AW_Navigation_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Navigation_bean bean = new AW_Navigation_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
