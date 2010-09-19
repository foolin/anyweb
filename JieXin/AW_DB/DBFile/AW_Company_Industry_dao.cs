﻿using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Company_Industry_dao : Dao_Base
	{
		public AW_Company_Industry_dao()
        {
            this._propTable = "AW_Company_Industry";
            this._propPK = "fdCoInCompID";
            this._propFields = "fdCoInCompID,fdCoInInduID";
        }

        public List<AW_Company_Industry_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Company_Industry_bean> list = new List<AW_Company_Industry_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Company_Industry_bean bean = new AW_Company_Industry_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//