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
	public partial class AW_News_dao : SHOP_daoBase
	{
		public AW_News_dao()
        {
            this._propTable = "AW_News";
            this._propPK = "fdNewsID";
            this._propFields = "fdNewsID,fdNewsColumnID,fdNewsTitle,fdNewsContent,fdNewsCreateAt";
        }

        public List<AW_News_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_News_bean> list = new List<AW_News_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_News_bean bean = new AW_News_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
