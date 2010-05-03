using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_AD_dao : Dao_Base
	{
		public AW_AD_dao()
        {
            this._propTable = "AW_AD";
            this._propPK = "fdAdID";
            this._propFields = "fdAdID,fdAdName,fdAdPic,fdAdLink";
        }

        public List<AW_AD_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_AD_bean> list = new List<AW_AD_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_AD_bean bean = new AW_AD_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
