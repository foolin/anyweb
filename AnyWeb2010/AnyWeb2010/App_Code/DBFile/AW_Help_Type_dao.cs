using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWeb.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_Help_Type_dao : SHOP_daoBase
	{
		public AW_Help_Type_dao()
        {
            this._propTable = "AW_Help_Type";
            this._propPK = "fdTypeID";
            this._propFields = "fdTypeID,fdTypeName,fdTypeSort";
        }

        public List<AW_Help_Type_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Help_Type_bean> list = new List<AW_Help_Type_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Help_Type_bean bean = new AW_Help_Type_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
