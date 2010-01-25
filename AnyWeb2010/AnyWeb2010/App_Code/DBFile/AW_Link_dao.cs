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
	public partial class AW_Link_dao : SHOP_daoBase
	{
		public AW_Link_dao()
        {
            this._propTable = "AW_Link";
            this._propPK = "fdLinkID";
            this._propFields = "fdLinkID,fdLinkName,fdLinkUrl,fdLinkPicture";
        }

        public List<AW_Link_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Link_bean> list = new List<AW_Link_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Link_bean bean = new AW_Link_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
