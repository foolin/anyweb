using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_SiteInfo_dao : Dao_Base
	{
		public AW_SiteInfo_dao()
        {
            this._propTable = "AW_SiteInfo";
            this._propPK = "fdSiInID";
            this._propFields = "fdSiInID,fdSiInTitle,fdSiInContent,fdSiInSort";
        }

        public List<AW_SiteInfo_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_SiteInfo_bean> list = new List<AW_SiteInfo_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_SiteInfo_bean bean = new AW_SiteInfo_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
