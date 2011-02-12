using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Mapping_dao : Dao_Base
	{
		public AW_Mapping_dao()
        {
            this._propTable = "AW_Mapping";
            this._propPK = "fdMappID";
            this._propFields = "fdMappID,fdMappTempID,fdMappPath";
        }

        public List<AW_Mapping_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Mapping_bean> list = new List<AW_Mapping_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Mapping_bean bean = new AW_Mapping_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
