using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Article_Picture_dao : Dao_Base
	{
		public AW_Article_Picture_dao()
        {
            this._propTable = "AW_Article_Picture";
            this._propPK = "fdArPiID";
            this._propFields = "fdArPiID,fdArPiPath,fdArPiArtiID,fdArPiType";
        }

        public List<AW_Article_Picture_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Article_Picture_bean> list = new List<AW_Article_Picture_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Article_Picture_bean bean = new AW_Article_Picture_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
