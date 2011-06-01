using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Exhibitor_dao : Dao_Base
	{
		public AW_Exhibitor_dao()
        {
            this._propTable = "AW_Exhibitor";
            this._propPK = "fdExhiID";
            this._propFields = "fdExhiID,fdExhiColuID,fdExhiName,fdExhiEnName,fdExhiNumber,fdExhiType,fdExhiUrl,fdExhiContent,fdExhiCreateAt,fdExhiIsDel,fdExhiStatus,fdExhiSort";
        }

        public List<AW_Exhibitor_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Exhibitor_bean> list = new List<AW_Exhibitor_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Exhibitor_bean bean = new AW_Exhibitor_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
