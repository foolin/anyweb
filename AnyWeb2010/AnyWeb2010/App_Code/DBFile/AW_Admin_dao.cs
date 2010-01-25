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
	public partial class AW_Admin_dao : SHOP_daoBase
	{
		public AW_Admin_dao()
        {
            this._propTable = "AW_Admin";
            this._propPK = "fdAdmiID";
            this._propFields = "fdAdmiID,fdAdmiAccount,fdAdmiPwd,fdAdmiName,fdAdmiLoginAt,fdAdmiLoginIP,fdAdmiCreateAt,fdAdmiLevel,fdAdmiPurview";
        }

        public List<AW_Admin_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Admin_bean> list = new List<AW_Admin_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Admin_bean bean = new AW_Admin_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
