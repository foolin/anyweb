using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Area_dao : Dao_Base
	{
		public AW_Area_dao()
        {
            this._propTable = "AW_Area";
            this._propPK = "fdAreaID";
            this._propFields = "fdAreaID,fdAreaName,fdAreaParent,fdAreaOrder,fdAreaIsHot";
        }

        public List<AW_Area_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Area_bean> list = new List<AW_Area_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Area_bean bean = new AW_Area_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
