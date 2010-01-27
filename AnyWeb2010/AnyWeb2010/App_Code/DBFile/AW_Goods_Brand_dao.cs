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
	public partial class AW_Goods_Brand_dao : Dao_Base
	{
		public AW_Goods_Brand_dao()
        {
            this._propTable = "AW_Goods_Brand";
            this._propPK = "fdGoBrID";
            this._propFields = "fdGoBrID,fdGoBrGoodsID,fdGoBrBrandID";
        }

        public List<AW_Goods_Brand_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Goods_Brand_bean> list = new List<AW_Goods_Brand_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Goods_Brand_bean bean = new AW_Goods_Brand_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
